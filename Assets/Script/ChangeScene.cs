using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {

public void ChangeToScene(int sceneNumber)
    {
        Application.LoadLevel(sceneNumber);
    }
}
