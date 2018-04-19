using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClickController : MonoBehaviour {

	[SerializeField]
	Camera cam;

	[SerializeField]
	GameObject[] prefabsForHover;

	private GameObject currentHover;
	private bool canBuild;

	// Use this for initialization
	void Start () {
		currentHover = Instantiate (prefabsForHover [0], Vector3.zero, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		MouseHover ();
		if (RoundManager.roundPhase == 1)
			buildTower ();
	}

	void buildTower(){
		if (Input.GetMouseButtonDown (0)) {
			Ray ray = cam.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(ray,out hit)){
				if (hit.transform.tag == "Floor") {
					currentHover.transform.position = hit.transform.position;
					Instantiate (prefabsForHover [0], hit.transform.position, Quaternion.identity);
					}
				}	
			}
	}

	void MouseHover(){
		Ray ray = cam.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		if(Physics.Raycast(ray,out hit)){
			if (hit.transform.tag == "Floor") {
				currentHover.transform.position = hit.transform.position;
			}
		}
	}
}
