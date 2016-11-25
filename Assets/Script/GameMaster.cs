using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {

    
    public float offsetY = 40;
    public float sizeX  = 100;
    public float sizeY = 40;
    public Transform musicPrefab;
    bool RestartFlag = false;   //true if the game 

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
        
    } 

    void OnGUI()
    {
        int currentHealth = GameObject.Find("MAX").GetComponent<CharacterHealth>().current_health;
        GUI.Box(new Rect(Screen.width / 2 - sizeX / 2, offsetY, sizeX, sizeY), "Health: " + currentHealth);
    }

    private void CreateMaze() { }   //generate Maze
    private void ResetMaze() { }    //destory maze if it needa restart game
    public void setRestart() { }    //

}
