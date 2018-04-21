using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClickController : MonoBehaviour {

	[SerializeField]
	Camera cam;

	[SerializeField]
	GameObject obstacle;

	[SerializeField]
	GameObject enemy;

	[SerializeField]
	GameObject[] prefabsTowers;

	[SerializeField]
	GameObject[] prefabsForHover;

	public int enemiesToSpawn;
	public float msBetweenSpawns;
	public Transform enemySpawnPoint;

	private GameObject currentHover;
	private bool canBuild;
	private List<GameObject> towers = new List<GameObject>();
	// Use this for initialization
	void Start () {
		currentHover = Instantiate (prefabsForHover [0], Vector3.zero, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		MouseHover ();
		if (Input.GetMouseButtonDown (0)) {
			if (RoundManager.roundPhase == 1)
				buildTower ();
			else if (RoundManager.roundPhase == 2)
				selectTower ();
		//	else if (RoundManager.roundPhase == 3)
		//		spawnEnemies ();
		}

	}

	void buildTower(){
		
		Ray ray = cam.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit)) {
			if (hit.transform.tag == "Floor") {
				print ("Building a tower");
				Vector3 temp;
				temp.x = Mathf.RoundToInt (hit.point.x);
				temp.y = 0.5f;
				temp.z = Mathf.RoundToInt (hit.point.z);
				currentHover.transform.position = temp;
				//currentHover.transform.position = hit.transform.position;
				GameObject tempO = Instantiate (prefabsTowers [0], temp, Quaternion.identity);
				towers.Add(tempO);
				RoundManager.towersToPlace -= 1;
				if (RoundManager.towersToPlace == 0) {
					RoundManager.roundPhase = 2;
					print ("Phase 2 begins");
					print ("The tower list contains " + towers.Count + " towers"); 
			}
			}
		}
	}

	void selectTower(){
		//consider the path forward for combinations. Contain the possible combinations on the
		//individual towers and then have a little menu or tooltip when a tower is selected.
		print ("Clicking in Phase 2");
		Ray ray = cam.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit)) {
			print ("Clicked on a " + hit.transform.tag);
			if (hit.transform.tag == "NewTower") {
				hit.transform.tag = "Tower";
				foreach (GameObject o in towers) {
					if (o.tag == "NewTower") {
						Instantiate (obstacle, o.transform.position, Quaternion.identity);
						Destroy (o);
					}
				}
				towers.Clear ();
				RoundManager.roundPhase = 3;
				print ("Phase 3 begins");
				print ("The tower list contains " + towers.Count + " towers");
				AstarPath.active.Scan ();
				spawnEnemies ();
			}
		}
	}
		
	void spawnEnemies(){
		print ("Spawning enemies");
		for (int i = 0; i < enemiesToSpawn; i++) {
			StartCoroutine (spawnDelay (i * msBetweenSpawns));
		}
		RoundManager.roundPhase = 4;
		print ("Phase 4 begins");
		print (RoundManager.enemies + " should be spawned at an interval of " + msBetweenSpawns + " seconds");
	}

	IEnumerator spawnDelay(float delay){
		yield return new WaitForSeconds (delay);
		Instantiate (enemy, enemySpawnPoint.position, Quaternion.identity);
	}

	void MouseHover(){
		Ray ray = cam.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		if(Physics.Raycast(ray,out hit)){
			Vector3 temp;
			temp.x = Mathf.RoundToInt (hit.point.x);
			temp.y = 1f;
			temp.z = Mathf.RoundToInt (hit.point.z);
			currentHover.transform.position = temp;
			if (hit.transform.tag == "Floor") {
				if (currentHover != null)
					Destroy (currentHover);
				currentHover = Instantiate (prefabsForHover [0], temp, Quaternion.identity);
			} else if (hit.transform.tag == "Tower") {
				if (currentHover != null)
					Destroy (currentHover);
				currentHover = Instantiate (prefabsForHover [1], temp, Quaternion.identity);
			} else if (hit.transform.tag == "NewTower") {
				if (currentHover != null)
					Destroy (currentHover);
				currentHover = Instantiate (prefabsForHover [2], temp, Quaternion.identity);
			}
		}
	}
}