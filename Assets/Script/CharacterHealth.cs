using UnityEngine;
using UnityEditor.SceneManagement;
using System.Collections;

public class CharacterHealth : MonoBehaviour {

    public int current_health = 100;
    public AudioClip sound1;

	void Update ()
    {
        if (current_health <= 0)
        {
            OwnCharacterController deadth_animation = GameObject.FindGameObjectWithTag("Player").GetComponent<OwnCharacterController>();
            deadth_animation.Death();
            //GetComponent<AudioSource>().Play();
            Invoke("restartLevel", 3);
            //restartLevel();
        }
	}

    public void restartLevel()
    {
        string current_scene = EditorSceneManager.GetActiveScene().name;
        EditorSceneManager.LoadScene(current_scene);
    }

    void getHit()
    {
        current_health -= 50;
    }

    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            InvokeRepeating("getHit", 1.0f, 1.0f);
        }
    }
}
