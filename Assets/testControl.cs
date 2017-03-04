using UnityEngine;
using System.Collections;

public class testControl : MonoBehaviour
{
    public Animation anim;
    private GameObject player;
    private GameObject thisObject;
    private bool flag = true;
    public string death_animation = "Death",
        idle_animation = "Idle",
        attack_animation = "Attack",
        run_animation = "Run",
        walk_animation = "Walk";

	//Speed of enemy
    public float speed = 2f;
    private MazeCell currentCell;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        thisObject = GameObject.FindGameObjectWithTag("Enemy");
        target = player.transform;
        SetPlayerTarget(target);
    }

    void Update()
    {
        Track();
        LookAtTarget();
    }

    void FixedUpdate()
    {

    }

    void Track()
    {
        if (flag)
        {   
			// not in collision
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

    /*void OnCollisionStay (Collision col)
    {
        if(col.gameObject.tag == ("Player"))
        {
            //Destroy(gameObject);
            flag = false;
            anim.CrossFade(attack_animation);
        }
    }*/

    public void SetLocation(MazeCell cell)
    {
        currentCell = cell;
        transform.localPosition = cell.transform.localPosition;
    }

    public void SetEnemyLocation(Vector3 spawnLocation)
    {
        transform.localPosition = spawnLocation;
    }


    // enemy looking at player code below:

    private float lookSmooth = 0.09f;
    private Transform target;
    Vector3 destination = Vector3.zero;
    OwnCharacterController charController;
    float rotateVel = 0;

    void SetPlayerTarget(Transform t)
    {
        target = t;
        if (target != null)
        {
            if (target.GetComponent<OwnCharacterController>())
            {
                charController = target.GetComponent<OwnCharacterController>();
            }
            else
                Debug.LogError("Camera target need a character controller");
        }
        else
            Debug.LogError("Camera dont have a target");
    }

    void LookAtTarget()
    {
        float eulerYAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, target.eulerAngles.y, ref rotateVel, lookSmooth);
        transform.rotation = Quaternion.Euler(0, eulerYAngle, 0);

    }

}