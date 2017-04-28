using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveControl : MonoBehaviour {
    public GameObject this_instance;

	public void SwitchActive () {
        if (this_instance.activeInHierarchy) this_instance.active = false;
        else this_instance.active = true;

    }
}
