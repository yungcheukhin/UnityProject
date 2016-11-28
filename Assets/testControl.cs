using UnityEngine;
using System.Collections;

public class testControl : MonoBehaviour
{
    public Animation anim;
    private bool flag = true;
    public string death_animation = "Death",
        idle_animation = "Idle",
        attack_animation = "Attack",
        run_animation = "Run",
        walk_animation = "Walk";

    public float speed;
    private MazeCell currentCell;

    void Update()
    {
        Track();
    }

    void Track()
    {
        if (flag)
        {   // not in collision
            float step = speed * Time.deltaTime;

            Vector3 player_location = GameObject.FindGameObjectWithTag("Player").transform.position;

            transform.position = Vector3.Lerp(transform.position, player_location, step);

            anim.CrossFade(walk_animation);

        }
        else
        {   // in collision, do sth and expect no collision occur in next frame

            flag = true;
        }

        

    }

    void OnCollisionStay (Collision col)
    {
        if(col.gameObject.tag == ("Player"))
        {
            //Destroy(gameObject);
            flag = false;
            anim.CrossFade(attack_animation);
        }
    }

    public void SetLocation(MazeCell cell)
    {
        currentCell = cell;
        transform.localPosition = cell.transform.localPosition;
    }

    public void SetEnemyLocation(Vector3 spawnLocation)
    {
        transform.localPosition = spawnLocation;
    }

}