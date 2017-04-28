using UnityEngine;
using UnityEditor.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class GameMaster : MonoBehaviour {
    private bool isFirstTime = true;
    public int game_round = 1; // 1 = round 1, 2 = round 2, 3 = round 3, 0 = main menu
    public static GameMaster instance = null;//make the game master as an instance so that we can access it elsewhere
    public int doorOpenTime = 4; // time for door to auto close
    public int tranSkillPersist = 3; //time for trans skill to persist
    public int tranSkillCD = 5; //time for trans skill to cool down
    public int escapeTime = 301; //time for escaping the maze
    public int escapeTimeReduce = 25;   //every success escape reduce this amount of time
    public float offsetY = 40;
    public float sizeX  = 100;
    public float sizeY = 40;
    public Transform musicPrefab;
    private int current_health;
    bool RestartFlag = false;   //true if the game needa restart
    Queue <Transform> previous_locations = new Queue<Transform>();
    Transform enemy_spawn_location;
    public GameObject chestPrefab;
    bool chest_opened = false;
    public GameObject playerPrefab;
    private GameObject enemyPrefab;
    public GameObject R1EnemyPrefab;
    private OwnCharacterController player;
    private OpenChest chest;
    private GameObject Max;
    private testControl enemy;
    private int success_escape = 0; // times that successfully escape the maze
    ///////////////////////////maze variable//////////////////////////
    private MazeDoor R1Door;
    public Maze R1Maze;
    public Maze R2Maze;
    public Maze mazePrefab;
    private Maze mazeInstance;
    private GameObject playerInstance;
    private GameObject enemyInstance;
    private GameObject chestInstance;
    private MazeCell currentCell;
    private MazeWall[] wall;
    private bool doorOpened = false;

    //private GameObject cubeInstance;
    bool MapCreated = false;

    /////////////////////////////////End///////////////////////////////
    public GameObject WinScreen;
    public GameObject LoseScreen;


    // Update is called once per frame
    private void Awake()
    {
        int stage_number = SceneManager.GetActiveScene().buildIndex;
        switch (stage_number)
        {
            case 1:
                BeginGameR1();
                break;
            case 2:
                BeginGameR2();
                break;
            case 3:
                StartCoroutine(BeginGameR3());
                break;
            default:

                break;

        }
        /*
        if (instance == null) //To check the existence of the GM to avoid two instances of GM
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        */

        if (!GameObject.FindGameObjectWithTag("MM"))
        {
            var mManger = Instantiate(musicPrefab, transform.position, Quaternion.identity);
            mManger.name = musicPrefab.name;
            DontDestroyOnLoad(mManger);
        }

    }

    private void Update()
    {
        GameObject chest_check = GameObject.FindGameObjectWithTag("Chest"); //Check if the chest_closed object is destroyed

        if(game_round == 3) //for stage 3, destory the camera watching the "loading" canvas and start using the character's camera view
        {
            if (!MapCreated && GameObject.FindGameObjectWithTag("MainCamera"))
            {
                Destroy(GameObject.Find("Loading Scene"));
                MapCreated = true;
            }   //if maze finish generating, delete the camera
        }

        if (RestartFlag)    // a restart is triggered
        {
            RestartGame();
        }        

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
        RestartFlag = true;//command to restart game
    }    

    public void restartLevel()
    {
        string current_scene = EditorSceneManager.GetActiveScene().name;
        EditorSceneManager.LoadScene(current_scene);
    }

    private IEnumerator BeginGameR3()   //for stage 3 init
    {
        StartCoroutine(Delay(3));
        mazeInstance = Instantiate(mazePrefab) as Maze;
        yield return StartCoroutine(mazeInstance.Generate());
        enemyPrefab = R1EnemyPrefab;
        playerInstance = Instantiate(playerPrefab) as GameObject;
        chest = chestPrefab.GetComponent(typeof(OpenChest)) as OpenChest;
        player = playerPrefab.GetComponent(typeof(OwnCharacterController)) as OwnCharacterController;
        player.SetLocation(mazeInstance.GetCell(mazeInstance.RandomCoordinates));
		chest = chestPrefab.GetComponent(typeof(OpenChest)) as OpenChest;
		chest.SetLocation(mazeInstance.GetCell(mazeInstance.RandomCoordinates));
    }

    private IEnumerator RestartGameR3(int escaped_count)   
    {
        StartCoroutine(Delay(3));
        mazeInstance = Instantiate(mazePrefab) as Maze;
        yield return StartCoroutine(mazeInstance.Generate());
        enemyPrefab = R1EnemyPrefab;
        playerInstance = Instantiate(playerPrefab) as GameObject;
        chest = chestPrefab.GetComponent(typeof(OpenChest)) as OpenChest;
        player = playerPrefab.GetComponent(typeof(OwnCharacterController)) as OwnCharacterController;
        player.SetLocation(mazeInstance.GetCell(mazeInstance.RandomCoordinates));
        escapeTime -= escaped_count * escapeTimeReduce;
        success_escape = escaped_count;
		chest = chestPrefab.GetComponent(typeof(OpenChest)) as OpenChest;
		chest.SetLocation(mazeInstance.GetCell(mazeInstance.RandomCoordinates));
    }

    private void BeginGameR2()  //for stage 2 init
    {
        StartCoroutine(Delay(3));
        mazeInstance = R2Maze;
        player = playerPrefab.GetComponent(typeof(OwnCharacterController)) as OwnCharacterController;
        chest = chestPrefab.GetComponent(typeof(OpenChest)) as OpenChest;
        enemyPrefab = R1EnemyPrefab;
        enemy = enemyPrefab.GetComponent(typeof(testControl)) as testControl;
        //player.SetLocation(R2Maze.GetCell(mazeInstance.RandomCoordinates));
        //chest.SetLocation(R2Maze.GetCell(mazeInstance.RandomCoordinates));
        //StartCoroutine(spawnEnemy(5));
    }

    private void BeginGameR1()  // for stage 1 init
    {
        StartCoroutine(Delay(3));
        mazeInstance = R1Maze;
        chest = chestPrefab.GetComponent(typeof(OpenChest)) as OpenChest;
        player = playerPrefab.GetComponent(typeof(OwnCharacterController)) as OwnCharacterController;
        enemyInstance = Instantiate(R1EnemyPrefab) as GameObject;
        enemy = R1EnemyPrefab.GetComponent(typeof(testControl)) as testControl;
    }


    private void RestartGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        RestartFlag = false;
    }

    public void goToStage(int stage_number)
    {
        switch (stage_number)
        {
            case 1:
                SceneManager.LoadScene(1);
                BeginGameR1();
                break;
            case 2:
                SceneManager.LoadScene(2);
                BeginGameR2();
                break;
            case 3:
                SceneManager.LoadScene(3);
                StartCoroutine(BeginGameR3());
                break;
            default:
                SceneManager.LoadScene(0);
                break;
        }
    }

    public void nextStage()
    {
        int stage_number = SceneManager.GetActiveScene().buildIndex;
        switch (stage_number)
        {
            case 0:
                SceneManager.LoadScene(1);
                break;
            case 1:
                SceneManager.LoadScene(2);
                break;
            case 2:
                SceneManager.LoadScene(3);
                StartCoroutine(RestartGameR3(success_escape));
                break;
            default:
                SceneManager.LoadScene(0);
                break;

        }
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

            if (game_round == 3)
            {
                doorOpened = true;
                currentCell = mazeInstance.GetCell(currPos);
                currentCell.OnPlayerEntered();
                Invoke("closeCellDoor", doorOpenTime);
            }
            else if(game_round == 1 && onPosition(currPos))
            {
                doorOpened = true;
                R1Door = GameObject.FindGameObjectWithTag("R1Door").GetComponent<MazeDoor>();
                MazeDoor OtherSideOfDoor = GameObject.FindGameObjectWithTag("R1Door_r").GetComponent<MazeDoor>();
                R1Door.OnPlayerEntered(OtherSideOfDoor);
                Invoke("closeR1Door", doorOpenTime);

            }
        }
    }
    private bool onPosition(IntVector2 currPos)
    {
        IntVector2 L = new IntVector2(2,19);
        IntVector2 R = new IntVector2(1,19);
        if ((L.x == currPos.x) && (L.z == currPos.z)) return true;
        if ((R.x == currPos.x) && (R.z == currPos.z)) return true;
        return false;
    }

    public void closeR1Door()
    {
        MazeDoor OtherSideOfDoor = GameObject.FindGameObjectWithTag("R1Door_r").GetComponent<MazeDoor>();
        R1Door.OnPlayerExited(OtherSideOfDoor);
        doorOpened = false;
    }

    public void closeCellDoor()
    {
        currentCell.OnPlayerExited();
        doorOpened = false;
    }

	public void wallTransparentSkill(){

        wall = mazeInstance.GetComponents<MazeWall>();
        /*
        for (int i=0; i<wall.Length; i++)
        {
            wall[i].transSkills();
        }
        */
        if(wall != null)
            wall[1].transSkills();
    }

	public void revertWallTransSkill(){
        wall = mazeInstance.GetComponents<MazeWall>();
        /*
        for (int i = 0; i < wall.Length; i++)
        {
            wall[i].revertTransSkill();
        }
        */
        if (wall != null)
            wall[1].revertTransSkill();
    }

    public void control_chest()
    {
        if (!chest_opened)
        {
            chest_opened = chest.GetComponent<OpenChest>().openChest();
        }

    }

    public void death()
    {
        player.Death();
    }

    public void mazeShow()
    {
        mazeInstance.GetComponent<Maze>().enabled = true;
        mazeInstance.showAll();
        mazeInstance.enabled = true;
    }
    public void mazeHide()
    {
        mazeInstance.GetComponent<Maze>().enabled = false;
        mazeInstance.hideAll();
        mazeInstance.enabled = false;
    }

    IEnumerator Delay(int second)
    {
        yield return new WaitForSeconds(second);
    }
}
