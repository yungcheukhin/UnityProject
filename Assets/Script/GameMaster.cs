using UnityEngine;
using UnityEditor.SceneManagement;
using System.Collections;
using System.Collections.Generic;


public class GameMaster : MonoBehaviour {

    public int game_round = 0;  // 1 = round 1, 2 = round 2, 3 = round 3
    public static GameMaster instance = null;//make the game master as an instance so that we can access it elsewhere
    public int doorOpenTime = 4; // time for door to auto close 
    public float offsetY = 40;
    public float sizeX  = 100;
    public float sizeY = 40;
    public Transform musicPrefab;
    private int current_health;
    bool RestartFlag = false;   //true if the game needa restart
    Queue <Transform> previous_locations = new Queue<Transform>();
    Transform enemy_spawn_location;

    ///////////////////////////maze variable//////////////////////////
    public Maze FixedMaze;
    public Maze mazePrefab;
    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public GameObject cubePrefab;
    private OwnCharacterController player ;
    private GameObject Max;
    private testControl enemy;
    private CubeControl cube;
    private Maze mazeInstance;
    private GameObject playerInstance;
    private GameObject enemyInstance;
    private MazeCell currentCell;
    private bool doorOpened = false;
    //private GameObject cubeInstance;
    bool MapCreated = false;
    /////////////////////////////////End///////////////////////////////

    // Update is called once per frame
    private void Awake()
    {
        if (instance == null) //To check the existence of the GM to avoid two instances of GM
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        //Instantiate(gameObject);
        //DontDestroyOnLoad(gameObject); //Keep the GM persist between scenes

        if (!GameObject.FindGameObjectWithTag("MM"))
        {
            var mManger = Instantiate(musicPrefab, transform.position, Quaternion.identity);
            mManger.name = musicPrefab.name;
            DontDestroyOnLoad(mManger);
        }
    }

    private void Start ()
    {
        if(game_round == 0)
        {
            // game main menu
        }
        else if (game_round == 1)
        {
            BeginGameR1();
        }
        else if (game_round == 2)
        {
            BeginGameR2();
        }
        else if (game_round == 3)
        {
            StartCoroutine(BeginGameR3());
        }
        else
        {
            //game main menu
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
            RestartGame();
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
            Max = GameObject.FindGameObjectWithTag("Player");
            if (Max != null) current_health = Max.GetComponent<CharacterHealth>().current_health;
            else current_health = 0;
            GUI.Box(new Rect(Screen.width / 2 - sizeX / 2, offsetY, sizeX, sizeY), playerName+"\nHealth: " + current_health);
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

    private IEnumerator BeginGameR3()
    {
        mazeInstance = Instantiate(mazePrefab) as Maze;
        yield return StartCoroutine(mazeInstance.Generate());
        playerInstance = Instantiate(playerPrefab) as GameObject;
        enemyInstance = Instantiate(enemyPrefab) as GameObject;
        //cubeInstance = Instantiate(cubePrefab) as GameObject;
        player = playerPrefab.GetComponent(typeof(OwnCharacterController)) as OwnCharacterController;
        enemy = enemyPrefab.GetComponent(typeof(testControl)) as testControl;
        cube = cubePrefab.GetComponent(typeof(CubeControl)) as CubeControl;
        player.SetLocation(mazeInstance.GetCell(mazeInstance.RandomCoordinates));
        //cube.SetCubeLocation(mazeInstance.GetCell(mazeInstance.RandomCoordinates));
        StartCoroutine(spawnEnemy(5));
        //enemy.SetEnemyLocation(enemy_spawn_location.position);
    }

    private void BeginGameR2()
    {
        //mazeInstance = Instantiate(mazePrefab) as Maze;
        //yield return StartCoroutine(mazeInstance.Generate());
        playerInstance = Instantiate(playerPrefab) as GameObject;
        enemyInstance = Instantiate(enemyPrefab) as GameObject;
        //cubeInstance = Instantiate(cubePrefab) as GameObject;
        player = playerPrefab.GetComponent(typeof(OwnCharacterController)) as OwnCharacterController;
        enemy = enemyPrefab.GetComponent(typeof(testControl)) as testControl;
        //cube = cubePrefab.GetComponent(typeof(CubeControl)) as CubeControl;
        player.SetLocation(FixedMaze.GetCell(mazeInstance.RandomCoordinates));
        //cube.SetCubeLocation(mazeInstance.GetCell(mazeInstance.RandomCoordinates));
        StartCoroutine(spawnEnemy(5));
        //enemy.SetEnemyLocation(enemy_spawn_location.position);
    }

    private void BeginGameR1()
    {

    }

    private void RestartGame()
    {
        //StopAllCoroutines();
        //Destroy(mazeInstance.gameObject);
        string current_scene = EditorSceneManager.GetActiveScene().name;
        EditorSceneManager.LoadScene(current_scene);
        if (game_round == 0)
        {
            // game main menu
        }
        else if (game_round == 1)
        {
            BeginGameR1();
        }
        else if (game_round == 2)
        {
            BeginGameR2();
        }
        else if (game_round == 3)
        {
            StartCoroutine(BeginGameR3());
        }
        else
        {
            //game main menu
        }
        RestartFlag = false;
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

    IEnumerator spawnEnemy(float time)
    {
        yield return new WaitForSeconds(time);
        if (enemy_spawn_location.position != null && enemy_spawn_location != null)
        {
            enemy.SetEnemyLocation(enemy_spawn_location.position);
        }
    }

    public void openCellDoor(IntVector2 currPos)
    {
        if (!doorOpened) {
            doorOpened = true;
            currentCell = mazeInstance.GetCell(currPos);
            //currentCell.GetComponent<MazeDoor>().OnPlayerEntered();
            currentCell.OnPlayerEntered();
            Invoke("closeCellDoor", doorOpenTime);
        }



    }

    public void closeCellDoor()
    {
        //currentCell.GetComponent<MazeDoor>().OnPlayerExited();
        currentCell.OnPlayerExited();
        doorOpened = false;


    }

}
