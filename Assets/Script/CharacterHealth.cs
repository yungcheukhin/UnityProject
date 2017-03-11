using UnityEngine;
using UnityEngine.UI;
using UnityEditor.SceneManagement;
using System.Collections;

public class CharacterHealth : MonoBehaviour {

    public AudioClip sound1;
    public int starting_health = 100;
    public int current_health = 100;
    public Animation anim;
    public string death_animation = "death";
    GameMaster gm;
    //public Image damage_image;
    //public float flash_speed = 5f;
    //public Color flash_colour = new Color(1f, 0f, 0f, 0.1f);

    //bool isDead = false;
    bool damaged = false;

    private void Awake()
    {
        gm = FindObjectOfType<GameMaster>();
    }

	void Update ()
    {
        /*if (damaged)
        {
            damage_image.color = flash_colour;
        }
        else
        {
            damage_image.color = Color.Lerp(damage_image.color, Color.clear, flash_speed * Time.deltaTime);
        }
        damaged = false;*/

        if (current_health <= 0)
        {
            anim.CrossFade("death");
            if (!IsInvoking("restartLevel"))
            {
                Invoke("restartLevel", 3);
            }
        }
    }

    public void restartLevel()
    {
        //string current_scene = EditorSceneManager.GetActiveScene().name;
        //EditorSceneManager.LoadScene(current_scene);
        gm.setRestart();
    }

    public void TakeDamage (int amount)
    {
        damaged = true;

        current_health -= amount;

    }

}
