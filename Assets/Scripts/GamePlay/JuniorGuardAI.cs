using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuniorGuardAI : MonoBehaviour {

	public bool isFrozen = false;
    public float freezeTimer = 0f;
    private Vector3 preFrozenVel;
    // private Rigidbody rb;

	public UnityEngine.AI.NavMeshAgent agent;
	private GameObject player;
	private RaycastHit hit;
	private Vector3 distVec;

	public float visionDist = 10;
	public float visionAngle = 30;

	private float timer = 0;
	private Vector3 initPos;
	private Quaternion initRot;

    public Animator anim;

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

	// Use this for initialization
	void Start () {
		// rb = GetComponent<Rigidbody>();
		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = GameObject.Find("Soldier_Team1_Unlit").GetComponent<Animator>();
        //player = GameObject.Find("Player");
        player = GameObject.FindWithTag("Player");
        Debug.Log(player);
		initPos = transform.position;
		initRot = transform.rotation;
		currWaypoint = -1;
		setNextWaypoint();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.F)) {
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
		}

		if (CheckForPlayer()) {
			currState = AIState.Chase;
            anim.SetBool("isRun", true);
			timer = 0; //used to check time since player was last spotted, along with time since chase stopped (no need to have two timers)
		} else {
			timer += Time.deltaTime;
            anim.SetBool("isRun", false);
		}

		switch (currState) {
			case AIState.Patrol:
				if (agent.remainingDistance < 0.5f && !agent.pathPending) {
					setNextWaypoint();
                }
				break;

			case AIState.Chase:
				agent.SetDestination(player.transform.position); //change "Player" name as appropriate
				if (agent.remainingDistance < 1f && !agent.pathPending) {
					//TODO: attack
					print("there will eventually have been an attack here");
				}
				if (timer >= 1) {
					currState = AIState.LoseTarget;
					timer = 0;
				}
				break;

			case AIState.LoseTarget:
				agent.Stop();
				agent.ResetPath();
				//TODO: loop through confused animation
				if (timer >= 3) {
					currState = AIState.WalkBack;
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

	public void Freeze() {
		preFrozenVel = agent.velocity;
		isFrozen = true;
		agent.Stop();
		agent.velocity = Vector3.zero;
		// rb.constraints = RigidbodyConstraints.FreezeAll;
	}

	bool CheckForPlayer() {
		distVec = player.transform.position - transform.position;
		return (distVec.magnitude < visionDist
			&& Vector3.Angle(transform.TransformDirection(Vector3.forward), distVec) < visionAngle
			&& Physics.Raycast(transform.position, distVec, out hit, visionDist) && hit.collider.gameObject.tag == "Player");
	}

	void setNextWaypoint() {
		if (waypoints.Length > 0) {
            //currWaypoint = (currWaypoint + 1) % waypoints.Length;
            currWaypoint = (currWaypoint + 5) % waypoints.Length;
            agent.SetDestination(waypoints[currWaypoint].transform.position);
		} else {
			print("Could not set next waypoint because the number of waypoints is not greater than zero.");
		}
	}
}
