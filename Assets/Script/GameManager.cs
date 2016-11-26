using UnityEngine;
using UnityEditor.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour {

    int current_scene;
	public void OnStartGame(int sceneToLoad)
    {
        EditorSceneManager.LoadScene(sceneToLoad);
    }
    
}
