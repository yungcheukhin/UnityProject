using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    Transform player;               // Reference to the player's position.
    CharacterHealth playerHealth;      // Reference to the player's health.
    NavMeshAgent nav;               // Reference to the nav mesh agent.


    void Awake()
    {
        // Set up the references.
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent<CharacterHealth>();
        nav = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        // If the enemy and the player have health left...
        if (playerHealth.current_health > 0 && nav != null)
        {
            // set the destination of the nav mesh agent to the player.
            if(player != null)
            nav.SetDestination(player.position);
        }
        else
        {
            // disable the nav mesh agent.
            if(nav != null)
            nav.enabled = false;
        }
    }
}