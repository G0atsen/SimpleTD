using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RoundManager {

	public static int roundPhase = 1; // phase 1 is building
									// phase 2 is selection
									// phase 3 is enemies spawn
									// phase 1 begins again
	public static int towersToPlace = 5;

	public static int enemies = 0;
}
