using UnityEngine;
using UnityEditor.SceneManagement;
using System.Collections;

public class CharacterHealth : MonoBehaviour {

    public int current_health = 100;

	void Update ()
    {
        if (current_health <= 0)
        {
            OwnCharacterController deadth_animation = GameObject.FindGameObjectWithTag("Player").GetComponent<OwnCharacterController>();
            deadth_animation.Death();
            Invoke("restartLevel", 3);
            //restartLevel();
        }
	}

    public void restartLevel()
    {
        string current_scene = EditorSceneManager.GetActiveScene().name;
        EditorSceneManager.LoadScene(current_scene);
    }
}
