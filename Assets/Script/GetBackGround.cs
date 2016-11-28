using UnityEngine;
using System.Collections;

public class GetBackGround : MonoBehaviour {

    private Vector3 fitGround;
    public float floatGroundLimit = 0.0f;
    // Use this for initialization
    void Start()
    {
        fitGround = transform.position;
        fitGround.y = 0;
        transform.localPosition = fitGround;
    }

    // Update is called once per frame
    void Update () {
        fitGround = transform.position;
        if (Mathf.Abs(fitGround.y) > floatGroundLimit)
        {
            fitGround.y = 0;
            transform.localPosition = fitGround;
        }
	}
}
