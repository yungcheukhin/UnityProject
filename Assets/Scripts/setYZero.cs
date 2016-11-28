using UnityEngine;
using System.Collections;

public class setYZero : MonoBehaviour {
    private Vector3 fitGround;
    // Use this for initialization
    void Start () {
        fitGround = transform.position;
        fitGround.y = 0;
        transform.localPosition = fitGround;

    }
	
	// Update is called once per frame
	void Update () {
        fitGround = transform.position;
        fitGround.y = 0;
        transform.localPosition = fitGround;
    }

}
