using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstarEnemyController : MonoBehaviour {

	private float health;
	private int waypointIndex = 0;
	private Transform currentTarget;
	private Waypoints pointSet;

	// Use this for initialization
	void Start () {
		health = 30f;
		pointSet = GameObject.FindGameObjectWithTag ("Waypoints").GetComponent<Waypoints> ();
		currentTarget = pointSet.points[0];
		//currentTarget.y = 1f;
		this.GetComponent<Pathfinding.AIDestinationSetter>().target = currentTarget;
	}

	void TakeDamage(float damage){
		health -= damage;
		if (health <= 0f) {
			Destroy (this.gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (waypointIndex < pointSet.points.Length) {
			if (Vector3.Distance (this.transform.position, currentTarget.position) <= 1f) {
				waypointIndex += 1;
				if (waypointIndex >= pointSet.points.Length) {
					Destroy (this.gameObject);
				} else {
					currentTarget = pointSet.points[waypointIndex];
					this.GetComponent<Pathfinding.AIDestinationSetter> ().target = currentTarget;
				}
			}
		} else {
			Destroy (this.gameObject);
		}
	}
}