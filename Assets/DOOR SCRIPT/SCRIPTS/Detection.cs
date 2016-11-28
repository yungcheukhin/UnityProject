//////////////////////////////////////
//Script created by Alexander Ameye //
//Last edit: 10/19/2016  					  //
//Version: 1.0.3 (FREE)  						//
//////////////////////////////////////

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Detection : MonoBehaviour
{
	// INSPECTOR SETTINGS
	[Header("Detection Settings")]
	[Tooltip("Within this radius the player is able to open/close the door/window.")]
	public float Reach = 4.0F;

	// PRIVATE SETTINGS
	[HideInInspector] public bool InReach;

	// DEBUGGING
	[Header("Debug Settings")]
	[Tooltip("The color of the line shown in scene-view that represents the raycast.")]
	public Color DebugRayColor = Color.green;

	// START FUNCTION
	void Start ()
	{
		//Give the player the name and tag "Player" for future reference.
		gameObject.name = "Player";
		gameObject.tag = "Player";
	}

	// UPDATE FUNCTION
	void Update ()
	{
		//Set origin of ray to 'center of screen' and direction of ray to 'cameraview'.
		Ray ray = Camera.main.ViewportPointToRay(new Vector3 (0.5F, 0.5F, 0F));

		RaycastHit hit; //Variable reading information about the collider hit.

		//Cast ray from center of the screen towards where the player is looking.
		if (Physics.Raycast(ray, out hit, Reach))
		{
			if (hit.collider.tag == "Door")
			{
				InReach = true;

				if (Input.GetKey(KeyCode.E))
				{
					//Give the object that was hit the name 'Door'.
					GameObject Door = hit.transform.gameObject;

					//Get access to the 'Door' script attached to the object that was hit.
					Door dooropening = Door.GetComponent<Door>();

					//Open/close the door by running the 'Open' function found in the 'Door' script.
					if (dooropening.Running == false) StartCoroutine (hit.collider.GetComponent<Door>().Open());
				}
			}

			else InReach = false;

		}

		else InReach = false;

		//Draw the ray as a colored line for debugging purposes.
		Debug.DrawRay (ray.origin, ray.direction * Reach, DebugRayColor);
	}
}
