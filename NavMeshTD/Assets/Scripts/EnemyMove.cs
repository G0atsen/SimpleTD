using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour {

	public NavMeshAgent agent;
	// Use this for initialization
	void Start () {
		agent.SetDestination (new Vector3 (-10f, 1.5f, 10f));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
