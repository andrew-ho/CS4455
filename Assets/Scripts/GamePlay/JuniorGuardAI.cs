using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]

public class JuniorGuardAI : MonoBehaviour {

	public bool isFrozen = false;
    public float freezeTimer = 0f;
    private Vector3 preFrozenVel;
    // private Rigidbody rb;
    private float patrolTimer = 0f;
    private bool atWaypoint = false;

	public UnityEngine.AI.NavMeshAgent agent;
	private GameObject player;
	private RaycastHit hit;
	private Vector3 distVec;

	public float visionDist = 10;
	public float visionAngle = 30;

	private float timer = 0;
	private Vector3 initPos;
	private Quaternion initRot;

	public bool knockedOut = false;

    public Animator anim;
    public Animator playerAnim;
    CanvasGroup canvasGroup;

    public enum AIState
	{
		Patrol,
		Chase,
		LoseTarget,
		WalkBack
	};
	public AIState currState;

	private int currWaypoint;
	public GameObject[] waypoints;

    private void Awake()
    {
        canvasGroup = GameObject.Find("GameOverCanvas").GetComponent<CanvasGroup>();
        HideGameOverMenu();
    }

    // Use this for initialization
    void Start () {
		// rb = GetComponent<Rigidbody>();
		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		//player = GameObject.Find("Player");
		initPos = transform.position;
		initRot = transform.rotation;
		currWaypoint = -1;
		setNextWaypoint();

        player = GameObject.FindWithTag("Player");
        playerAnim = player.GetComponent<Animator>();
        anim = this.gameObject.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		if (knockedOut) {
			return;
		}
		/*if (Input.GetKeyDown(KeyCode.F)) {
			Freeze();
		}
		if (isFrozen) {
			freezeTimer += Time.deltaTime;
			if (freezeTimer > 5) {
				agent.Resume();
				agent.velocity = preFrozenVel;
				// rb.constraints = RigidbodyConstraints.None;
				freezeTimer = 0;
				isFrozen = false;
			} else {
				return;
			}
		}*/
		anim.SetBool("lostPlayer", false);

		if (CheckForPlayer()) {
            anim.SetBool("isRun", true);
            currState = AIState.Chase;
			timer = 0; //used to check time since player was last spotted, along with time since chase stopped (no need to have two timers)
		} else {
            timer += Time.deltaTime;
		}

		switch (currState) {
			case AIState.Patrol:
				if (agent.remainingDistance < .5f && !agent.pathPending) {
					atWaypoint = true;
					agent.Stop();
					agent.ResetPath();
					anim.SetBool("isWaiting", true);
				}
				if (atWaypoint) {
					patrolTimer += Time.deltaTime;
					if (patrolTimer > 2) {
						setNextWaypoint();
						patrolTimer = 0;
						atWaypoint = false;
						anim.SetBool("isWaiting", false);
					}
				}
				break;

			case AIState.Chase:
				agent.SetDestination(player.transform.position); //change "Player" name as appropriate
				if (agent.remainingDistance < 1.5f && !agent.pathPending) {
					//TODO: attack
					//print("there will eventually have been an attack here");
                    anim.SetBool("isAttack", true);
                    playerAnim.SetBool("isDeath", true);
                    //print("there will eventually have been an attack here");
                    StartCoroutine(ShowGameOverMenu());
                }
				if (timer >= 1) {
					currState = AIState.LoseTarget;
					anim.SetBool("isRun", false);
					timer = 0;
				}
				break;

			case AIState.LoseTarget:
				agent.Stop();
				agent.ResetPath();
				//TODO: loop through confused animation
				if (timer >= 3) {
					currState = AIState.WalkBack;
					anim.SetBool("lostPlayer", true);
				}
				break;

			case AIState.WalkBack:
				agent.Stop();
				agent.ResetPath();
				//walks to the nearest waypoint and continues the path
				float closestDist = Mathf.Infinity;
				float currDist;
				int closestWaypoint = -2;
				for (int i = 0; i < waypoints.Length; i++) {
					currDist = Vector3.Distance(transform.position, waypoints[i].transform.position);
					if (currDist < closestDist) {
						closestDist = currDist;
						closestWaypoint = i - 1;
					}
				}
				setNextWaypoint();
				currState = AIState.Patrol;
				break;

			default:
				break;
		}
	}

	/*public void Freeze() {
		preFrozenVel = agent.velocity;
		isFrozen = true;
		agent.Stop();
		agent.velocity = Vector3.zero;
		// rb.constraints = RigidbodyConstraints.FreezeAll;
	}*/

	bool CheckForPlayer() {
		distVec = player.transform.position - transform.position;
		return (distVec.magnitude < visionDist
			&& Vector3.Angle(transform.TransformDirection(Vector3.forward), distVec) < visionAngle
			&& Physics.Raycast(transform.position, distVec, out hit, visionDist) && hit.collider.gameObject.tag == "Player");
	}

	void setNextWaypoint() {
		if (waypoints.Length > 0) {
			currWaypoint = (currWaypoint + 1) % waypoints.Length;
			agent.SetDestination(waypoints[currWaypoint].transform.position);
		} else {
			print("Could not set next waypoint because the number of waypoints is not greater than zero.");
		}
	}

    IEnumerator ShowGameOverMenu()
    {
        yield return new WaitForSeconds(3f);
        Cursor.lockState = CursorLockMode.None;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
        Time.timeScale = 0f;
    }

    public void HideGameOverMenu()
    {
        Cursor.lockState = CursorLockMode.Locked;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0f;
        Time.timeScale = 1f;
    }

    private void OnCollisionEnter(Collision collision)
    {
    	if (collision.collider.tag == "Cube" || (collision.collider.name == "End" && collision.collider.GetComponent<Animator>().GetBool("Out") == true)) {
			knockedOut = true;
			agent.Stop();
			agent.ResetPath();
			anim.SetBool("knockedOut", true);
			Destroy(gameObject);
    	}
    }
}
