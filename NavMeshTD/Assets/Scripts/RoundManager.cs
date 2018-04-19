using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour {

	public static int roundPhase; // phase 1 is building
								// phase 2 is selection
								// phase 3 is enemies spawn
								// phase 1 begins again
	// Use this for initialization
	public RoundManager ();

	void Start () {
		roundPhase = 1;
	}
}
