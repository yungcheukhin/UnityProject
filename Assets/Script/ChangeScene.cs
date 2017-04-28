using UnityEngine;
using UnityEditor.SceneManagement;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

public void ChangeToScene(int sceneNumber)
    {
        string myName = GameObject.FindWithTag("Name").GetComponent<UnityEngine.UI.Text>().text;
        PlayerPrefs.SetString("player_name", myName);
        SceneManager.LoadScene(sceneNumber);
    }

}
