using UnityEngine;
using UnityEditor.SceneManagement;
using System.Collections;
using System.Collections.Generic;


public class GameMaster : MonoBehaviour {

    public float offsetY = 40;
    public float sizeX  = 100;
    public float sizeY = 40;
    public Transform musicPrefab;
    bool RestartFlag = false;   //true if the game needa restart
    Queue <Transform> previous_locations = new Queue<Transform>();
    Transform enemy_spawn_location;

    ///////////////////////////maze variable//////////////////////////
    public Maze mazePrefab;
    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public GameObject cubePrefab;
    private OwnCharacterController player ;
    private testControl enemy;
    private CubeControl cube;
    private Maze mazeInstance;
    private GameObject playerInstance;
    private GameObject enemyInstance;
    private GameObject cubeInstance;
    bool MapCreated = false;
    /////////////////////////////////End///////////////////////////////

    // Update is called once per frame
    private void Start ()
    {
        StartCoroutine(BeginGame());    //generate maze

        if (!GameObject.FindGameObjectWithTag("MM"))
        {
            var mManger = Instantiate(musicPrefab, transform.position, Quaternion.identity);
            mManger.name = musicPrefab.name;
            DontDestroyOnLoad(mManger);
        }
	}
    
    private void Update()
    {
        if (!MapCreated && GameObject.FindGameObjectWithTag("MainCamera"))
        {
            Destroy(GameObject.Find("Loading Scene"));

            MapCreated = true;
        }   //if maze finish generating, delete the camera

        if (RestartFlag)
        {
            restartLevel();
        }

        PreviousLocation();
        if (previous_locations.Count == 15)
        {
            enemy_spawn_location = previous_locations.Dequeue();
        }
    } 

    void OnGUI()
    {
        if (MapCreated)
        {
            string playerName = PlayerPrefs.GetString("player_name");
            int currentHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterHealth>().current_health;
            GUI.Box(new Rect(Screen.width / 2 - sizeX / 2, offsetY, sizeX, sizeY), playerName+"\nHealth: " + currentHealth);
        }
    }
  
    public void setRestart()
    {
        RestartFlag = true;
    }    //command to restart game

    public void restartLevel()
    {
        string current_scene = EditorSceneManager.GetActiveScene().name;
        EditorSceneManager.LoadScene(current_scene);
    }

    private IEnumerator BeginGame()
    {
        mazeInstance = Instantiate(mazePrefab) as Maze;
        yield return StartCoroutine(mazeInstance.Generate());
        playerInstance = Instantiate(playerPrefab) as GameObject;
        enemyInstance = Instantiate(enemyPrefab) as GameObject;
        cubeInstance = Instantiate(cubePrefab) as GameObject;
        player = playerPrefab.GetComponent(typeof(OwnCharacterController)) as OwnCharacterController;
        enemy = enemyPrefab.GetComponent(typeof(testControl)) as testControl;
        cube = cubePrefab.GetComponent(typeof(CubeControl)) as CubeControl;
        player.SetLocation(mazeInstance.GetCell(mazeInstance.RandomCoordinates));
        cube.SetCubeLocation(mazeInstance.GetCell(mazeInstance.RandomCoordinates));
        if(enemy_spawn_location.position != null)
        {
            enemy.SetEnemyLocation(enemy_spawn_location.position);
        }
        //enemy.SetEnemyLocation(enemy_spawn_location.position);
    }

    private void RestartGame()
    {
        StopAllCoroutines();
        Destroy(mazeInstance.gameObject);
    }

    public void PreviousLocation ()
    {
        int max_size = 15;

        if(previous_locations.Count >= max_size)
        {
            previous_locations.Dequeue();
        }
        if (GameObject.FindGameObjectWithTag("Player")) 
            previous_locations.Enqueue(GameObject.FindGameObjectWithTag("Player").transform);
    }

}
