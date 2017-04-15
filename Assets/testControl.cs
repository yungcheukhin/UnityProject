using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class testControl : MonoBehaviour
{
    public Animation anim;
    private GameObject player;
    private GameObject thisObject;
    private bool flag = true;
    private bool underattack = false;
    public string death_animation = "Death",
        idle_animation = "Idle",
        attack_animation = "Attack",
        run_animation = "Run",
        walk_animation = "Walk";
    private Transform player_location;       // Reference to the player's position.
    private CharacterHealth playerHealth;    // Reference to the player's health.
    private NavMeshAgent nav;                // Reference to the nav mesh agent.

    //Speed of enemy
    public float enemy_movement_speed = 2f;
    private MazeCell currentCell;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        thisObject = GameObject.FindGameObjectWithTag("Enemy");
        target = player.transform;
        SetPlayerTarget(target);
        player_location = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player_location.GetComponent<CharacterHealth>();
        nav = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if(thisObject == null) thisObject = GameObject.FindGameObjectWithTag("Enemy");

        LookAtTarget();
        // If the enemy and the player have health left...
        if (playerHealth.current_health > 0)
        {
            
            nav.SetDestination(player_location.position);// set the destination of the nav mesh agent to the player.
            NavMeshPath path = new NavMeshPath(); //get path
            GetComponent<NavMeshAgent>().CalculatePath(destination, path);
            if (path.status == NavMeshPathStatus.PathPartial)
            {
                Stall(); //if no path is detected, stay at the current position
            }
            else Track();
        }
        else
        {
            // disable the nav mesh agent.
            nav.enabled = false;
        }
    }

    void Stall()
    {
        enemy_movement_speed = 0;
        anim.CrossFade(idle_animation);
    }

    void Track()
    {
        if (flag && !underattack)
        {   
			// not in collision
            float step = enemy_movement_speed * Time.deltaTime;

            anim.CrossFade(walk_animation);
        }
        else if(!flag && !underattack)
        {   // in collision, do sth and expect no collision occur in next frame
            flag = true;
        }
        else
        {   //underattack, play attack anim

            if (!IsInvoking("exitAttack"))
            {
                anim.Play(attack_animation);
                Invoke("exitAttack", 2.0f);
            }
        }
    }

    public void underAttack()
    {
        underattack = true;
    }

    public void exitAttack()
    {
        underattack = false;
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

    public void setIdle()
    {
        thisObject.SetActive(false);
    }

    public void setActive()
    {
        thisObject.SetActive(true);
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