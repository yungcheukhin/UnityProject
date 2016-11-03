using UnityEngine;
using UnityEditor.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour {

	public void OnStartGame(int sceneToLoad)
    {
        EditorSceneManager.LoadScene(sceneToLoad);
    }
}
