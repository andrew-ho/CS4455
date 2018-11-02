using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavAgent : MonoBehaviour {
    NavMeshAgent agent;
    public Transform[] wayPoints;
    int curWayPoint = 0;
	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = 5000000000f;
        Physics.IgnoreLayerCollision(9, 9);
    }
	
	// Update is called once per frame
	void Update () {
        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    curWayPoint++;
                    agent.destination = wayPoints[curWayPoint % wayPoints.Length].position;
                }
            }
        }
    }
}
