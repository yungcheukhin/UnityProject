using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public Transform target;
    public float lookSmooth = 0.09f;
    public Vector3 offsetFromTarget = new Vector3(0, 4, -5);
    public float xTilt = 10;
    public float yaw = 0.0f;
    public float pitch = 0.0f;

	public float distance = -10f;
	public float distMin = 0.5f;
	public float distMax = 15f;

	public float yLimitMin = 5.0f;
	public float yLimitMax = 80f;

	public float xSpeed = 120.0f;
	public float ySpeed = 120.0f;

	float rotationXAxis = 0.0f;
	float rotationYAxis = 0.0f;

    public float speedH = 2.0f;
    public float speedV = 2.0f;

	float x = 0.0f;
	float y = 0.0f;
	float xyOffset = 0.02f;



    Vector3 destination = Vector3.zero;
    OwnCharacterController charController;
    float rotateVel = 0;

    void Awake()
    {
		Vector3 angles = transform.eulerAngles;
		x = angles.x;
		y = angles.y;

        SetCameraTarget(target);
		rotationXAxis = angles.x;
		rotationYAxis = angles.y;


    }

    void SetCameraTarget(Transform t)
    {
        target = t;
        if (target)
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

    void LateUpdate()
    {
		MouseMovement(target);

        //roataing
        //LookAtTarget();

		//moving
		//MovingToTarget();

        /*
        if (charController.haveInput)
            LookAtTarget();
        else
            LookAtMouse();
            */
    }

	void MouseMovement(Transform t){
		//with rotation and position
		if (t) {
			x += Input.GetAxis("Mouse X") * xSpeed * distance * xyOffset;
			y -= Input.GetAxis("Mouse Y") * ySpeed * xyOffset;

			y = ClampAngle(y, yLimitMin, yLimitMax);

			Quaternion rotation = Quaternion.Euler (y, x, 0);

			distance = Mathf.Clamp (distance - Input.GetAxis ("Mouse ScrollWheel") * 5, distMin, distMax);

			RaycastHit hit;
			if (Physics.Linecast (t.position, transform.position, out hit)) {
				distance -= hit.distance;
			}

			Vector3 negDist = new Vector3 (0.0f, 0.0f, -distance);
			Vector3 position = rotation * negDist + t.position;

			transform.rotation = rotation;
			transform.position = position;
		}

	}

    void MovingToTarget()
    {
        destination = charController.TargetRotation * offsetFromTarget;
        destination += target.position;
        transform.position = destination;
    }

    void LookAtTarget()
    {
        float eulerYAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, target.eulerAngles.y, ref rotateVel, lookSmooth);
        //add some code to make the camera follow the mouse movement as well
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, eulerYAngle, 0);

    }

    void LookAtMouse()
    {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");
        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }

	public static float ClampAngle(float angle, float min, float max){
		if (angle < -360F)
			angle += 360F;
		if (angle > 360F)
			angle -= 360F;
		return Mathf.Clamp(angle, min, max);
	}

}
