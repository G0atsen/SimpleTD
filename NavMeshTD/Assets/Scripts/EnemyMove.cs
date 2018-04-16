using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour {

	public NavMeshAgent agent;

	private int waypointIndex = 0;
	private Vector3 currentTarget;
	// Use this for initialization
	void Start () {
		currentTarget = Waypoints.points [0].position;
		currentTarget.y = 1f;
		agent.SetDestination (currentTarget);
	}
	
	// Update is called once per frame
	void Update () {
		if (waypointIndex < Waypoints.points.Length-1) {
			if (Vector3.Distance (this.transform.position, currentTarget) <= 0.25f) {
				waypointIndex += 1;
				currentTarget = Waypoints.points [waypointIndex].position;
				currentTarget.y = 1f;
				print (this.transform.position - currentTarget);
				agent.SetDestination (currentTarget);
			}
		}
	}
}
