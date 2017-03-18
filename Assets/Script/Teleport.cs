using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class Teleport : MonoBehaviour {

    public string level_to_load;

    public void OnTriggerEnter (Collider Trigger)
    {
        if(!(Trigger.tag=="Player"))
        {
            return;
        }
        EditorSceneManager.LoadScene(level_to_load);
    }
}
