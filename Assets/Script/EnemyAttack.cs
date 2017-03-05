using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    public float time_between_attack = 2.0f;
    public int attack_damage = 10;
    bool player_in_range;
    float timer;
    public Animation anim;
    GameObject player;
    GameObject enemy;
    CharacterHealth player_health;
    testControl ctrl;
    public string attack_animation = "Attack", idle_animation = "Idle";

    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        player_health = player.GetComponent<CharacterHealth>();
        ctrl = enemy.GetComponent<testControl>();
    }

    void OnCollisionStay (Collision other)
    {
        if(other.gameObject == player)
        {
            player_in_range = true;
        }
    }

    void OnCollisionExit (Collision other)
    {
        if(other.gameObject == player)
        {
            player_in_range = false;
        }
    }
	
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= time_between_attack && player_in_range)
        {
            Attack();
            ctrl.underAttack();
        }

        //if (player_health.current_health <= 0)
        //{
        //    anim.CrossFade(idle_animation);
        //}
    }

    void Attack()
    {
        timer = 0f;

        if(player_health.current_health > 0)
        {
            player_health.TakeDamage(attack_damage);
        }
    }
}
