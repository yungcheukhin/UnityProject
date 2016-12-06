using UnityEngine;
using UnityEditor.SceneManagement;
using System.Collections;

public class CharacterHealth : MonoBehaviour {

    public int current_health = 100;
    public int health_reduce = 5;
	public int health_increase = 2;
    public AudioClip sound1;
	void Update ()
    {
		//Dealth condition
        if (current_health <= 0)
        {
            OwnCharacterController deadth_animation = GameObject.FindGameObjectWithTag("Player").GetComponent<OwnCharacterController>();
            deadth_animation.Death();
            // audio = GetComponent<AudioSource>();
            //audio.Play();
            Invoke("restartLevel", 3);
            //restartLevel();
        }

		//Flip to gain health
		if (Input.GetKeyUp ("space")&&(current_health<=200)) {
			externalHealthGain();
		}
	}

    public void restartLevel()
    {
        string current_scene = EditorSceneManager.GetActiveScene().name;
        EditorSceneManager.LoadScene(current_scene);
    }

    void getHit()
    {
        current_health -= health_reduce;
    }

	void externalHealthGain(){
		current_health += health_increase;
	}

    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            InvokeRepeating("getHit", 2, 5);
            //getHit();
        }
    }
}
