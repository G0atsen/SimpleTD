using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClickController : MonoBehaviour {

	[SerializeField]
	Camera cam;

	[SerializeField]
	GameObject[] prefabsForHover;

	private GameObject currentHover;
	// Use this for initialization
	void Start () {
		currentHover = Instantiate (prefabsForHover [0], Vector3.zero, Quaternion.identity);

	}
	
	// Update is called once per frame
	void Update () {
		MouseHover ();
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
