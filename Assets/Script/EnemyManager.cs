using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    private CharacterHealth playerHealth;       // Reference to the player's heatlh.
    public GameObject enemy;                // The enemy prefab to be spawned.
    public float spawnTime = 3f;            // How long between each spawn.
    //public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
    //set custom range for random position
    public float MinX = 0;
    public float MaxX = 10;
    public float MinY = 0;
    public float MaxY = 10;
    public float MinZ = 0;
    public float MaxZ = 10;

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

        // Find a random index between zero and one less than the number of spawn points.
        //int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        float x = Random.Range(MinX, MaxX);
        float y = Random.Range(MinY, MaxY);
        float z = Random.Range(MinZ, MaxZ);

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        //Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        Instantiate(enemy, new Vector3(x, y, z), Quaternion.identity);

    }
}
