using UnityEngine;
using System.Collections;

public class testControl : MonoBehaviour
{
    private Animation anim;

    public string death_animation = "Death",
        idle_animation = "Idle",
        attack_animation = "Attack",
        run_animation = "Run",
        walk_animation = "Walk";

    Vector3 Stand = new Vector3(0, 0, 0);

    float stopTime;
    float moveTime;
    int curr_frame;
    int total_frame;
    float timeCounter1;
    float timeCounter2;
    float vel_x, vel_y, vel_z;

    void Update()
    {
        timeCounter1 += Time.deltaTime;
        if (timeCounter1 < moveTime)
        {
            transform.Translate(vel_x, vel_y, 0, Space.Self);
            anim.CrossFade(walk_animation);
        }
        else
        {
            timeCounter2 += Time.deltaTime;
            if (timeCounter2 > stopTime)
            {
                Change();
                timeCounter1 = 0;
                timeCounter2 = 0;
            }
        }
        //Check();
    }
    void Change()
    {
        stopTime = Random.Range(1, 5);
        moveTime = Random.Range(1, 20);
        vel_x = Random.Range(1, 10);
        vel_y = Random.Range(1, 10);
    }


}