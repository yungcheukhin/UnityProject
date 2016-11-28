using UnityEngine;
using System.Collections;

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
    float forwardInput, turnInput, horizontalInput;

    private bool canRun = false;    //store flag to determine run
    private bool haveInput = false; 
    private MazeCell currentCell;

	public Transform target;

	float x = 0.0f;
	float y = 0.0f;

    public Quaternion TargetRotation
    {
        get { return targetRotation; }
    }
    void Start()
    {
        Cursor.visible = false;
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
        if (GetComponent<Rigidbody>())
            rBody = GetComponent<Rigidbody>();
        else
            Debug.LogError("The Character dont have any rigidbody");

        forwardInput = turnInput  = horizontalInput = 0;

    }

    void GetInput()
    {
        forwardInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        //directionInput = Input.GetAxis("Horizontal");
        canRun = Input.GetKey("left shift");
        haveInput = Input.anyKey;

    }

    void Update()   //dont require physic
    {
       
		oldMouseX = mouseX;
		GetInput();
		mouseX = Input.GetAxis ("Mouse X");
		//mouseDelta = mouseX - oldMouseX;
		//Check mouse orbit delta and stop rotating when mouse not moving
		if (Mathf.Abs(mouseX-oldMouseX)>0) {
			rotationX += mouseX * sensitivityX;
		} else {
			rotationX = 0;
		}
		//rotationX += mouseDelta * sensitivityX;

		//Other direction inputs by keyboard
//		try {
//			//keyboardTurn = Input.GetAxis("Horizontal");
//			if (Mathf.Abs (directionInput) > inputDelay) {	
////				leftright = Vector3(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"),0);
////				transform.position += leftright * Time.deltaTime * keyboardSensitivityX;
//			} else {
//				//no keyboard input
 
//				//lock rotation of character
                                                                                                                                       
//				directionInput = 0f;
//				//rotationX = 0f;
//			}
//			//rotationX += keyboardTurn * Time.deltaTime * rotateVel;
//		//	rotationY += Input.GetAxis("Vertical") * Time.deltaTime * rotateVel;
//		}
//		catch (UnityException e) {
//			if (!loggedInputInfo) {
//				Debug.Log ("Hint: Setup axes \"Horizontal\" and \"MouseX\" to support aiming direction. This is optional.\nYou can map them to whichever keys or joystick axes you want to control aiming direction.\n"+e.StackTrace, this);
//				loggedInputInfo = true;
//			}
//		}

		// rotationX = ClampAngle(rotationX, turnmin, turnmax);

		Quaternion rotation = Quaternion.Euler (0, rotationX, 0);

		turnInput = rotationX;

		turn = turnInput * Time.deltaTime;
		turn = Mathf.Clamp(turn, turnmin, turnmax); 
		//turn *= rotateVel;
		targetRotation *= Quaternion.AngleAxis(turn, Vector3.up);
		transform.rotation = targetRotation;

		//rotationX = Mathf.Repeat(rotationX, 360);
		//transform.rotation = originalRotation * rotation * Vector3.forward;

    }

    void FixedUpdate()  //need physic calculation
    {
        Move();
    }

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
            //move
            //transform.forward = rBody.
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

    void Mouse_move(){

	}

    void Turn()
    {   
		//find where to apply this statement
		//transform.localEulerAngles = new Vector3 (Camera.main.transform.localEulerAngles.x, transform.localEulerAngles.y, transform.localEulerAngles.z);

        //if(Mathf.Abs(turnInput) > inputDelay)
        //{
			turn = turnInput * Time.deltaTime;
			turn = Mathf.Clamp(turn, turnmin, turnmax); 
			//turn *= rotateVel;
            targetRotation *= Quaternion.AngleAxis(turn, Vector3.up);
        //}
		transform.rotation = targetRotation;
    }

    public void Death()
    {
        rBody.velocity = Vector3.zero;
        anim.CrossFade(death_animation);
    }

	public static float ClampAngle(float angle, float min, float max){
		if (angle < -360F)
			angle += 360F;
		if (angle > 360F)
			angle -= 360F;
		return Mathf.Clamp(angle, min, max);
	}

	public void SetLocation(MazeCell cell){
		currentCell = cell;
		transform.localPosition = cell.transform.localPosition;
	}


}
