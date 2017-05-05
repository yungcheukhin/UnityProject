using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixRoom : MonoBehaviour {

	// Use this for initialization
	void Start () {
        MazeRoom newRoom = ScriptableObject.CreateInstance<MazeRoom>();
    }
	
}
