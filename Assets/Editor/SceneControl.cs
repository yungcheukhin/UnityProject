using UnityEngine.SceneManagement;
using UnityEngine;


public class SceneControl : MonoBehaviour {

    public static void LoadaScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
