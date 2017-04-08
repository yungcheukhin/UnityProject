using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    private CharacterHealth playerHealth;       // Reference to the player's heatlh.
    public GameObject enemy;                // The enemy prefab to be spawned.
    public float spawnTime = 3f;            // How long between each spawn.
    //public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
    //set custom random position
    public float x_coordinate = 0;
    public float y_coordinate = 0;
    public float z_coordinate = 0;

    void Start()
    {
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        InvokeRepeating("Spawn", spawnTime, spawnTime);

        //set the playerHealth
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterHealth>();
    }


    void Spawn()
    {
        // If the player has no health left...
        if (playerHealth.current_health <= 0f)
        {
            // exit the function.
            return;
        }

        // Create an instance of the enemy prefab at the selected spawn point's position and rotation.
        //Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        Instantiate(enemy, new Vector3(x_coordinate, y_coordinate, z_coordinate), Quaternion.identity);

    }
}
