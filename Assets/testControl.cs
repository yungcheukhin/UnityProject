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

    public float speed = 100f;
    private MazeCell currentCell;

    public Transform target;
    Quaternion targetRotation;
    Rigidbody rBody;

    public float turnSpeed = 5.0f;

    Vector3 _dir;

    void Start()
    {

    }

    void Update()
    {
        Track();
    }

    void FixedUpdate()
    {
      //  rBody.AddForce(_dir * speed);
    }

    void Track()
    {
        if (flag)
        {   // not in collision
            float step = speed * Time.deltaTime;

            Vector3 player_location = GameObject.FindGameObjectWithTag("Player").transform.position;

            transform.position = Vector3.Lerp(transform.position, player_location, step);

            //_dir = target.position - transform.position;
            //_dir.Normalize();
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_dir), turnSpeed * Time.deltaTime);
            //transform.rotation = Quaternion.AngleAxis(0, Vector3.up);
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