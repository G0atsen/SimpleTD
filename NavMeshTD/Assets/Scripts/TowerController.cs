using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour {

	[SerializeField]
	string towerType;

	[SerializeField]
	LayerMask enemiesLayer;

	public float damage;

	public float fireRate;
	public  float timeTaken;
	public float radius;
	// Use this for initialization
	/*
	The static variable enemies should be edited every time an enemy is killed. This way both the MouseClickController 
	and the Towers can be coordinated. The round shall changed but will be handled by the MouseClickController
	*/

	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if (RoundManager.roundPhase == 4) {
			timeTaken += Time.deltaTime;
			float temp = 1 / fireRate;
			if (timeTaken >= temp) {
				timeTaken = 0f;
				projectile ();
			}
		}
	}

	void projectile(){
		Collider[] hitColliders = Physics.OverlapSphere(this.transform.position,radius,enemiesLayer);
		if (hitColliders != null) {
			int i = 0;
			float closest = Vector3.Distance (hitColliders [0].transform.position, this.transform.position);
			Collider currentEnemy = hitColliders [0];
			while (i < hitColliders.Length) {
				if (Vector3.Distance (hitColliders [i].transform.position, this.transform.position) < closest) {
					closest = Vector3.Distance (hitColliders [i].transform.position, this.transform.position);
					currentEnemy = hitColliders [i];
				}
				i++;
			}
			print (currentEnemy.name);
			currentEnemy.gameObject.SendMessage ("TakeDamage",damage);
		}
	}

	void aoe(){
		Collider[] hitColliders = Physics.OverlapSphere(this.transform.position,radius,enemiesLayer);
		if (hitColliders [0] != null) {
			int i = 0;
			while (i < hitColliders.Length) {
				i++;
				hitColliders[i].gameObject.SendMessage ("TakeDamage",damage);
			}
		}
	}

	void bounce(){
		Collider[] hitColliders = Physics.OverlapSphere (this.transform.position, radius, enemiesLayer);
		if (hitColliders [0] != null) {
			int i = 0;
			float closest = Vector3.Distance (hitColliders [0].transform.position, this.transform.position);
			Collider currentEnemy = hitColliders [0];
			while (i < hitColliders.Length) {
				if (Vector3.Distance (hitColliders [i].transform.position, this.transform.position) < closest) {
					closest = Vector3.Distance (hitColliders [i].transform.position, this.transform.position);
					currentEnemy = hitColliders [i];
				}
				i++;
			}
			currentEnemy.SendMessage ("TakeDamage", damage);
			Collider[] secondaryHit = Physics.OverlapSphere (currentEnemy.transform.position, radius, enemiesLayer);
			if (secondaryHit [0] != null) {
				int j = 0;
				float closest1 = Vector3.Distance (hitColliders [0].transform.position, this.transform.position);
				Collider currentEnemy1 = secondaryHit [0];
				while (j < hitColliders.Length) {
					if (Vector3.Distance (hitColliders [j].transform.position, currentEnemy.transform.position) < closest) {
						closest = Vector3.Distance (hitColliders [j].transform.position, currentEnemy.transform.position);
						currentEnemy = hitColliders [j];
					}
					j++;
				}
			}
		}
	}
}