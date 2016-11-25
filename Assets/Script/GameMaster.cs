using UnityEngine;
using UnityEditor.SceneManagement;
using System.Collections;


public class GameMaster : MonoBehaviour {

    
    public float offsetY = 40;
    public float sizeX  = 100;
    public float sizeY = 40;
    public Transform musicPrefab;
    bool RestartFlag = false;   //true if the game needa restart
    public Maze mazePrefab;
    private Maze mazeInstance;

    // Update is called once per frame
    private void Start ()
    {
       if(!GameObject.FindGameObjectWithTag("MM"))
        {
            var mManger = Instantiate(musicPrefab, transform.position, Quaternion.identity);
            mManger.name = musicPrefab.name;
            DontDestroyOnLoad(mManger);
        }
        CreateMaze();
	}
    
    private void Update()
    {
        if (RestartFlag)
        {
            ResetMaze();
            restartLevel();
        }
    } 

    void OnGUI()
    {
        string player_name = PlayerPrefs.GetString("player_name");
        int currentHealth = GameObject.Find("MAX").GetComponent<CharacterHealth>().current_health;
        GUI.Box(new Rect(Screen.width / 2 - sizeX / 2, offsetY, sizeX, sizeY), player_name + "\n" + "Health: " + currentHealth);
    }

    private void CreateMaze()
    {
        mazeInstance = Instantiate(mazePrefab) as Maze;
        StartCoroutine(mazeInstance.Generate());
    }   //generate Maze

    private void ResetMaze()
    {
        StopAllCoroutines();
        Destroy(mazeInstance.gameObject);
        ResetMaze();
    }    //destory maze if it needa restart game

    public void setRestart()
    {
        RestartFlag = true;
    }    //command to restart game

    public void restartLevel()
    {
        string current_scene = EditorSceneManager.GetActiveScene().name;
        EditorSceneManager.LoadScene(current_scene);
    }

}
