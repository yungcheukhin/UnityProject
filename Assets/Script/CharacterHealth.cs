using UnityEngine;
using UnityEngine.UI;
using UnityEditor.SceneManagement;
using System.Collections;

public class CharacterHealth : MonoBehaviour {

    public AudioClip sound1;
    public int starting_health = 100;
    public int current_health;
    public Image damage_image;
    public float flash_speed = 5f;
    public Color flash_colour = new Color(1f, 0f, 0f, 0.1f);

    bool isDead;
    bool damaged;

	void Update ()
    {
        if (damaged)
        {
            damage_image.color = flash_colour;
        }
        else
        {
            damage_image.color = Color.Lerp(damage_image.color, Color.clear, flash_speed * Time.deltaTime);
        }
        damaged = false;
    }

    public void restartLevel()
    {
        string current_scene = EditorSceneManager.GetActiveScene().name;
        EditorSceneManager.LoadScene(current_scene);
    }

    public void TakeDamage (int amount)
    {
        damaged = true;

        current_health -= amount;

        if (current_health <= 0 && !isDead)
        {
            Death();
        }
    }

    void Death()
    {
        isDead = true;

        OwnCharacterController deadth_animation = GameObject.FindGameObjectWithTag("Player").GetComponent<OwnCharacterController>();
        deadth_animation.Death();
        // audio = GetComponent<AudioSource>();
        //audio.Play();
        Invoke("restartLevel", 3);
        //restartLevel();
    }

}
