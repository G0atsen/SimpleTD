using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject Floor;
	// Use this for initialization
	void Start () {
		Floor.GetComponent<Renderer> ().material.renderQueue = 3001;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
