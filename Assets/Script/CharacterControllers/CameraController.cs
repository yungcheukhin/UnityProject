using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public Transform target;
    public float lookSmooth = 0.09f;
    public Vector3 offsetFromTarget = new Vector3(0, 4, -5);
    public float xTilt = 10;
    public float yaw = 0.0f;
    public float pitch = 0.0f;

	public float yLimitMin = -20f;
	public float yLimitMax = 80f;

	float rotationXAxis = 0.0f;
	float rotationYAxis = 0.0f;

    public float speedH = 2.0f;
    public float speedV = 2.0f;
    

    Vector3 destination = Vector3.zero;
    OwnCharacterController charController;
    float rotateVel = 0;

    void Awake()
    {
        SetCameraTarget(target);
		Vector3 angles = transform.eulerAngles;
		rotationXAxis = angles.x;
		rotationYAxis = angles.y;


    }

    void SetCameraTarget(Transform t)
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

    void LateUpdate()
    {
        //moving
        MovingToTarget();

        //roataing
        LookAtTarget();
        /*
        if (charController.haveInput)
            LookAtTarget();
        else
            LookAtMouse();
            */
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
		return Mathf.Clamp (angle, min, max);
	}

}
