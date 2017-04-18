using UnityEngine;
using System.Collections;

public class setYZero : MonoBehaviour {
    private Vector3 fitGround;

    public float height=0.0f;
    // Use this for initialization
    void Start () {
        fitGround = transform.position;
        fitGround.y = height;
        transform.localPosition = fitGround;

    }
	
	// Update is called once per frame
	void Update () {
        fitGround = transform.position;
        fitGround.y = height;
        transform.localPosition = fitGround;
    }

}
