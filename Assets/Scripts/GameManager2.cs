using UnityEngine;
using System.Collections;

public class GameManager2 : MonoBehaviour {

	public Maze mazePrefab;
	public GameObject playerPrefab;
	private Maze mazeInstance;
	private GameObject playerInstance;
    bool MapCreated = false;

	private void Start () {
		StartCoroutine(BeginGame());
    }
	
	private void Update () {

        if (!MapCreated && GameObject.FindGameObjectWithTag("MainCamera"))
        {
            Destroy(GameObject.Find("DefaultCam"));
            MapCreated = true;
        }

    }

	private IEnumerator BeginGame () {
        

		mazeInstance = Instantiate(mazePrefab) as Maze;
		yield return StartCoroutine(mazeInstance.Generate());

		playerInstance = Instantiate(playerPrefab) as GameObject;
		//playerInstance.SetLocation(mazeInstance.GetCell(mazeInstance.RandomCoordinates));

	}

	private void RestartGame () {
	    StopAllCoroutines();
		Destroy(mazeInstance.gameObject);
	}
}