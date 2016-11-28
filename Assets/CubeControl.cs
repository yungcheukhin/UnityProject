using UnityEngine;
using System.Collections;

public class CubeControl : MonoBehaviour {

    private MazeCell currentCell;

    void Update ()
    {
	
	}

    void OnCollisionEnter (Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
            Win();
        }
    }

    void Win()
    {

    }

    public void SetCubeLocation(MazeCell cell)
    {
        currentCell = cell;
        transform.localPosition = cell.transform.localPosition;
    }
}
