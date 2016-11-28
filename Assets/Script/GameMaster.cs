using UnityEngine;
using UnityEditor.SceneManagement;
using System.Collections;


public class GameMaster : MonoBehaviour {

    
    public float offsetY = 40;
    public float sizeX  = 100;
    public float sizeY = 40;
    public Transform musicPrefab;
    bool RestartFlag = false;   //true if the game needa restart

    ///////////////////////////maze variable//////////////////////////
    public Maze mazePrefab;
    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    private OwnCharacterController player ;
    private testControl enemy;
    private Maze mazeInstance;
    private GameObject playerInstance;
    private GameObject enemyInstance;
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
        player = playerPrefab.GetComponent(typeof(OwnCharacterController)) as OwnCharacterController;
        enemy = enemyPrefab.GetComponent(typeof(testControl)) as testControl;
        player.SetLocation(mazeInstance.GetCell(mazeInstance.RandomCoordinates));

    }

    private void RestartGame()
    {
        StopAllCoroutines();
        Destroy(mazeInstance.gameObject);
    }

    public void PreviousLocation ()
    {
        Queue previous_locations = new Queue();
        int max_size = 15;

        if(previous_locations.Count >= max_size)
        {
            previous_locations.Dequeue();
        }

        previous_locations.Enqueue(GameObject.FindGameObjectWithTag("Player").transform);
    }

}
