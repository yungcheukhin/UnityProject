using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CharacterHealth : MonoBehaviour {

    public AudioClip sound1;
    public int starting_health = 100;
    public int current_health = 100;
    public Animation anim;
    private GameMaster gm;
    
    private bool damaged = false;

    private void Awake()
    {
        gm = FindObjectOfType<GameMaster>();
    }

	void Update ()
    {

        if (current_health <= 0)
        {
            gm.death();
            if (!IsInvoking("restartLevel"))
            {
                Invoke("restartLevel", 3);
            }
        }
    }

    public void restartLevel()
    {
        gm.setRestart();
    }

    public void TakeDamage (int amount)
    {
        damaged = true;

        current_health -= amount;

    }

}
