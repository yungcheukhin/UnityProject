using UnityEngine;
using System.Collections;

public class OwnCharacterController : MonoBehaviour {
	public GameObject camera;
	private CharacterMotor motor;
    public float inputDelay = 0.1f; //perform better control with delay in input
    public float forwardVel = 0.8f;
    public float runVel = 1.6f;
    public float rotateVel = 80f;   //determine how fast it turn
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

	public float sensitivityX = 80F;
	public float sensitivityY = 80F;
	public float keyboardSensitivityX = 15F;

	private float rotationX = 0F;
	private float keyboardX = 0F;
	private float mouseX = 0F;
	private float rotationY = 0F;
	private float finalRotate = 0F;
	float turn =0F;

	private static bool loggedInputInfo = false;
	public float turnmin = -90.0f;
	public float turnmax = 90.0f;
	public float xLimitMin = -180f;
	public float xLimitMax = 180f;

	Quaternion originalRotation;
    Quaternion targetRotation;
    Rigidbody rBody;
    float forwardInput, turnInput, keyboardTurn;

    private bool canRun = false;
    public bool haveInput = false;
	private bool turnflag = false;
    private MazeCell currentCell;

    public Quaternion TargetRotation
    {
        get { return targetRotation; }
    }

    void Awake()
    {
		motor = GetComponent(typeof(CharacterMotor)) as CharacterMotor;
		if (motor==null) Debug.Log("Motor is null!!");
		originalRotation = transform.localRotation;
        targetRotation = transform.rotation;
        if (GetComponent<Rigidbody>())
            rBody = GetComponent<Rigidbody>();
        else
            Debug.LogError("The Character dont have any rigidbody");

        forwardInput = turnInput = 0;

    }

    void GetInput()
    {
        forwardInput = Input.GetAxis("Vertical");
        //turnInput = Input.GetAxis("Horizontal");
        //turnInput = ClampAngle(turnInput, turnmin, turnmax);
		//keyboardTurn = Input.GetAxis("Horizontal");
        canRun = Input.GetKey("left shift");
		keyboardTurn = Input.GetAxis("Horizontal");
        haveInput = Input.anyKey;

    }

    void Update()   //dont require physic
    {
		
        GetInput();
		mouseX = Input.GetAxis ("Mouse X");
		rotationX += mouseX * sensitivityX;
		turnflag = true;

		//Quaternion rotation = Quaternion.Euler (0, rotationX, 0);

		try {
			//keyboardTurn = Input.GetAxis("Horizontal");
			if (Mathf.Abs (keyboardTurn) > inputDelay) {	
				keyboardX += keyboardTurn * keyboardSensitivityX ;
			} else {
				//no keyboard input
 
				//lock rotation of character
                                                                                                                                       
				keyboardX = 0f;
				//rotationX = 0f;
			}
			//rotationX += keyboardTurn * Time.deltaTime * rotateVel;
		//	rotationY += Input.GetAxis("Vertical") * Time.deltaTime * rotateVel;
		}
		catch (UnityException e) {
			if (!loggedInputInfo) {
				Debug.Log ("Hint: Setup axes \"Horizontal\" and \"MouseX\" to support aiming direction. This is optional.\nYou can map them to whichever keys or joystick axes you want to control aiming direction.\n"+e.StackTrace, this);
				loggedInputInfo = true;
			}
		}



		//rotationX = Mathf.Repeat(rotationX, 360);

		rotationX = ClampAngle(rotationX, turnmin, turnmax);
		keyboardX = ClampAngle(keyboardX, turnmin, turnmax);
		//rotationY = Mathf.Clamp(rotationY, -85, 85);
		finalRotate = rotationX + keyboardX;

		Quaternion rotation = Quaternion.Euler (0, rotationX, 0);

//		Quaternion xQuaternion = Quaternion.AngleAxis (rotationX , Vector3.up);
//		Quaternion yQuaternion = Quaternion.AngleAxis (rotationY, -Vector3.right);

		turnInput = finalRotate;
		//finalRotate = rotationX;
//		if (turnflag) {
//			Turn();
//		}

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
        if (Mathf.Abs(forwardInput) > inputDelay)
        {
            //move
            //transform.forward = rBody.
            rBody.velocity = transform.forward * forwardInput * forwardVel;

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
