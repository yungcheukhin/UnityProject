using UnityEngine;
using System.Collections;

public class DoorHandler : MonoBehaviour {

	private Animator _animator = null;

	// Use this for initialization
	void Start () {
		_animator = GetComponent<Animator> ();
	}

	void OnTriggerEnter(Collider collider){
		_animator.SetBool ("isopen", true);
	}

	void OnTriggerExit(Collider collider){
		_animator.SetBool ("isopen", false);
	}

}
