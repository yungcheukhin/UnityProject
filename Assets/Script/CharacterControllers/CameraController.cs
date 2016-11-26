using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public GameObject player;

	private Vector3 offset;

    public Transform target;
    public float lookSmooth = 0.11f;
    public Vector3 offsetFromTarget = new Vector3(0, 20, -5);
    public float xTilt = 10;
    public float yaw = 0.0f;
    public float pitch = 0.0f;

	public float distance = 5f;
	public float distMin = 2f;
	public float distMax = 15f;

	public float yLimitMin = 5.0f;
	public float yLimitMax = 80f;
	public float xLimitMin = -180f;
	public float xLimitMax = 180f;

	public float xSpeed = 120.0f;
	public float ySpeed = 120.0f;

	float rotationXAxis = 0.0f;
	float rotationYAxis = 0.0f;

    public float speedH = 2.0f;
    public float speedV = 2.0f;

	private float rotationY = 0F;
	public float sensitivityCamY = 50F;
	Quaternion rotate;

	float x = 0.0f;
	float y = 0.0f;
	float xyOffset = 0.02f;

	float height = 5.0f;
	float heightDamping = 2.0f;
	float rotationDamping = 3.0f;

	float wantedHeight = 5.0f;
	float wantedRotationAngle =0.0f;
	float currentRotationAngle = 0.0f;
	float currentRotation = 0.0f;
	float currentHeight = 5.0f;


    Vector3 destination = Vector3.zero;
    OwnCharacterController charController;
    float rotateVel = 0;

    void Awake()
    {
		Vector3 angles = transform.eulerAngles;
		x = angles.x;
		y = angles.y;

        SetCameraTarget(target);
		rotationXAxis = 0;
		rotationYAxis = angles.y;
		offset = transform.position - player.transform.position;
		Vector3 targetPostition = new Vector3( target.position.x, this.transform.position.y, target.position.z) ;


    }

    void SetCameraTarget(Transform t)
    {
        target = t;
        if (target)
        {
			if (target.GetComponentInParent<OwnCharacterController> ()) {
			}
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
		//MouseMovement(target);
		rotationY += Input.GetAxis ("Mouse Y") * sensitivityCamY;
		rotate *= Quaternion.AngleAxis(rotationY, Vector3.right);

		transform.rotation = rotate;

		currentHeight = transform.position.y;
		currentHeight = Mathf.Lerp (currentHeight, wantedHeight, heightDamping * Time.deltaTime);

//
//		transform.position.y = currentHeight;
//		transform.LookAt (target);

		//rotationY = ClampAngle(rotationY, yLimitMin, 10.0f);

		Quaternion rotation = Quaternion.Euler (rotationY, 0, 0);

		Quaternion yQuaternion = Quaternion.AngleAxis (rotationY, -Vector3.right);

    }

	void MouseMovement(Transform t){
		//with rotation and position
		if (t) {
			//x += Input.GetAxis("Mouse X") * xSpeed * distance * xyOffset;
			y -= Input.GetAxis("Mouse Y") * ySpeed * xyOffset;

			y = ClampAngle(y, yLimitMin, yLimitMax);
			//x = ClampAngle(x, xLimitMin, xLimitMax);

			Quaternion rotation = Quaternion.Euler (y, 0, 0);

			distance = Mathf.Clamp (distance - Input.GetAxis ("Mouse ScrollWheel") * 5, distMin, distMax);

			RaycastHit hit;
			if (Physics.Linecast (t.position, transform.position, out hit)) {
				distance -= hit.distance;
			}

			Vector3 negDist = new Vector3 (0.0f, 4.0f, -distance);
			Vector3 position = rotation * negDist + t.position;

			//transform.rotation = rotation;
			transform.position = position;
			//transform.position.x = 0;
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
