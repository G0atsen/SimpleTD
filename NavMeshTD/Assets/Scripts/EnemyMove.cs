using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour {

	public NavMeshAgent agent;

	private int waypointIndex = 0;
	private Vector3 currentTarget;
	private Waypoints pointSet;
	// Use this for initialization
	void Start () {
		pointSet = GameObject.FindGameObjectWithTag ("Waypoints").GetComponent<Waypoints> ();
		currentTarget = pointSet.points[0].position;
		currentTarget.y = 1f;
		agent.SetDestination (currentTarget);
	}
	
	// Update is called once per frame
	void Update () {
		if (waypointIndex <pointSet.points.Length-1) {
			if (Vector3.Distance (this.transform.position, currentTarget) <= 0.25f) {
				waypointIndex += 1;
				currentTarget = pointSet.points[waypointIndex].position;
				currentTarget.y = 1f;
				agent.SetDestination (currentTarget);
			}
		}
	}
}
