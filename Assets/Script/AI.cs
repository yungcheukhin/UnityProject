using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    private Transform player_location;       // Reference to the player's position.
    private CharacterHealth playerHealth;    // Reference to the player's health.
    private NavMeshAgent nav;                // Reference to the nav mesh agent.


    void Awake()
    {
        // Set up the references.
        player_location = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player_location.GetComponent<CharacterHealth>();
        nav = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        // If the enemy and the player have health left...
        if (playerHealth.current_health > 0)
        {
            // set the destination of the nav mesh agent to the player.
            nav.SetDestination(player_location.position);
        }
        else
        {
            // disable the nav mesh agent.
            nav.enabled = false;
        }
    }
}