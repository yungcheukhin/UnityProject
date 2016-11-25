using UnityEngine;
using UnityEditor.SceneManagement;
using System.Collections;

public class CharacterHealth : MonoBehaviour {
    public int current_health = 100;
	void Update ()
    {
        if (current_health <= 0)
        {
            string current_scene = EditorSceneManager.GetActiveScene().name;
            EditorSceneManager.LoadScene(current_scene);
        }
	}
}
