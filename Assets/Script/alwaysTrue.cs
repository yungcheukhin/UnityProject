using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alwaysTrue : MonoBehaviour {

    public GameObject ThisObj;
    GameMaster Script;
    private void Start()
    {
        Script = ThisObj.GetComponent(typeof(GameMaster)) as GameMaster;
    }

    void Update () {
        if (!Script.isActiveAndEnabled) Script.enabled = true;
	}
}
