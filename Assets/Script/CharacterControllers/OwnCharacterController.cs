using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class OwnCharacterController : MonoBehaviour {

	private CharacterMotor motor;
    public float inputDelay = 0.1f; //perform better control with delay in input
    public float forwardVel = 0.8f;
    public float runVel = 1.6f;
    public float horizontalVel = 0.6f;
    public Animation anim;
    public string death_animation = "death",
        flip_animation = "flip",
        idle_animation = "idle",
        jump_animation = "jump",
        kick_animation = "kick",
        punch_animation = "punch",
        run_animation = "run",
        walk_animation = "walk";
    Vector3 Stand = new Vector3(0,0,0);

	public float sensitivityX = 10f;
	private float rotationX = 0F;
	private float mouseX = 0F;
	private float oldMouseX = 0F;
	private float mouseDelta = 0F;
	private float rotationY = 0F;
	private float finalRotate = 0F;
	float turn = 0F;

	private static bool loggedInputInfo = false;
	public float turnmin = -90.0f;
	public float turnmax = 90.0f;

	Vector3 leftright;

	Quaternion originalRotation;
    Quaternion targetRotation;
    Rigidbody rBody;
    float forwardInput, turnInput, directionInput, horizontalInput;
	bool flipInput;

    private bool canRun = false;    //store flag to determine run
    private bool haveInput = false;
    private bool isDead = false;
	private bool openDoor = false;
    private MazeCell currentCell;
	private MazeCell currentCellPos;

	private Transform target;

	private MazeDoor door;
	private GameObject doorInstance;
	public GameObject doorPrefab;


	float x = 0.0f;
	float y = 0.0f;

    public Quaternion TargetRotation
    {
        get { return targetRotation; }
    }
    void Start()
    {
        Cursor.visible = false;
//		door =.GetComponent<MazeDoor>();
		//door = doorPrefab.GetComponent (typeof(MazeDoor)) as MazeDoor;
//		door.OnPlayerExited();
    }
    void Awake()
    {
        Vector3 angles = transform.eulerAngles;
		x = angles.y;
		y = angles.x;
		rBody = GetComponent<Rigidbody>();
		motor = GetComponent(typeof(CharacterMotor)) as CharacterMotor;
		if (motor==null) Debug.Log("Motor is null!!");
		originalRotation = transform.localRotation;
        targetRotation = transform.rotation;

		doorInstance = Instantiate (doorPrefab) as GameObject;
		door = doorPrefab.GetComponent (typeof(MazeDoor)) as MazeDoor;
		if (door == null) Debug.Log ("Door is null!");

		//Get the current coordinates in 2d form and get Mazecell by 2d-position
		//check if there is player entered and open door
//		checkCellHvDoor(T2IntVector2());

        if (GetComponent<Rigidbody>())
            rBody = GetComponent<Rigidbody>();
        else
            Debug.LogError("The Character dont have any rigidbody");

        forwardInput = turnInput  = horizontalInput = 0;

    }

    void GetInput()
    {
        forwardInput = Input.GetAxis("Vertical");https://www.youtube.com/watch?v=dT9eI40RNoQ&t=10293s
        horizontalInput = Input.GetAxis("Horizontal");
        //directionInput = Input.GetAxis("Horizontal");
        canRun = Input.GetKey("left shift");
		flipInput = Input.GetKey("space");
        haveInput = Input.anyKey;
//		if (Input.GetKey (KeyCode.Z)) {
//			openDoor = true;
//		} else {
//			openDoor = false;
//		}

    }

    void Update()   //dont require physic
    {

		oldMouseX = mouseX;
		GetInput();
		mouseX = Input.GetAxis ("Mouse X");

		//Check mouse orbit delta and stop rotating when mouse not moving
		if (Mathf.Abs(mouseX-oldMouseX)>0) {
			rotationX += mouseX * sensitivityX;
		} else {
			rotationX = 0;
		}

		//Convert Mouse X rotation into Quaternion
		Quaternion rotation = Quaternion.Euler (0, rotationX, 0);
		turnInput = rotationX;
		turn = turnInput * Time.deltaTime;
		turn = Mathf.Clamp(turn, turnmin, turnmax); 

		//Rotate the player centering at it's Y-axis
		targetRotation *= Quaternion.AngleAxis(turn, Vector3.up);
		transform.rotation = targetRotation;

		//Flip animation Input
		if (flipInput) {
			anim.CrossFade(flip_animation);
		}

//		player = playerPrefab.GetComponent(typeof(OwnCharacterController)) as OwnCharacterController;
//		player.SetLocation(mazeInstance.GetCell(mazeInstance.RandomCoordinates));

			

    }

    void FixedUpdate()  //need physic calculation
    {
        if(!isDead) Move();
    }


	//Forward input, with walk, run or idle animation
    void Move()
    {
        if (Mathf.Abs(horizontalInput) > inputDelay && Mathf.Abs(forwardInput) > inputDelay)
        {
            if (canRun)
            {
                rBody.velocity = transform.right * horizontalInput * horizontalVel + transform.forward * forwardInput * runVel;
                if(forwardInput <0) rBody.velocity = transform.right * horizontalInput * horizontalVel + transform.forward * forwardInput * forwardVel;
                anim.CrossFade(run_animation);
            }
            else
            {
                rBody.velocity = transform.right * horizontalInput * horizontalVel + transform.forward * forwardInput * forwardVel;
                anim.CrossFade(walk_animation);
            }
        }
        else if (Mathf.Abs(horizontalInput) > inputDelay)
        {
            rBody.velocity = transform.right * horizontalInput * horizontalVel;
            anim.CrossFade(walk_animation);
        }
        else if (Mathf.Abs(forwardInput) > inputDelay)
        {

            if (canRun)
            {
                rBody.velocity = transform.forward * forwardInput * runVel;
                anim.CrossFade(run_animation);
            }
            else
            {
                rBody.velocity = transform.forward * forwardInput * forwardVel;
                anim.CrossFade(walk_animation);
            }
        }
        else
        {
            //dont move
            rBody.velocity = Vector3.zero;
            anim.CrossFade(idle_animation);
        }
    }

	//Extra Turning function
    void Turn()
    {   
        //if(Mathf.Abs(turnInput) > inputDelay)
        //{
			turn = turnInput * Time.deltaTime;
			turn = Mathf.Clamp(turn, turnmin, turnmax); 
			//turn *= rotateVel;
            targetRotation *= Quaternion.AngleAxis(turn, Vector3.up);
        //}
		transform.rotation = targetRotation;
    }

	//Death animation
    public void Death()
    {
        rBody.velocity = Vector3.zero;
        anim.CrossFade(death_animation);
        isDead = true;
    }

	//Clamp Angles
	public static float ClampAngle(float angle, float min, float max){
		if (angle < -360F)
			angle += 360F;
		if (angle > 360F)
			angle -= 360F;
		return Mathf.Clamp(angle, min, max);
	}

	//Set at Maze location
	public void SetLocation(MazeCell cell){
		currentCell = cell;
		transform.localPosition = cell.transform.localPosition;
	}

	public IntVector2 T2IntVector2(){
		Vector2 pos = GameObject.FindGameObjectWithTag ("Player").transform.position;
		IntVector2 intVectorVar;
		intVectorVar.x = (int)pos.x;
		intVectorVar.z = (int)pos.y;
		return intVectorVar;
	}

	public void checkCellHvDoor(IntVector2 posIntVectorVar){
		Maze cell= null;
//		currentCellPos = cell.GetCell(posIntVectorVar);
		currentCellPos.transform.localPosition = transform.localPosition;
		currentCellPos.GetComponent<MazeCell>().OnPlayerEntered();
	}
}
