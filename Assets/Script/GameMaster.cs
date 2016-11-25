using UnityEngine;
using UnityEditor.SceneManagement;
using System.Collections;

public class GameMaster : MonoBehaviour {

    
    public float offsetY = 40;
    public float sizeX  = 80;
    public float sizeY = 40;

    public Transform musicPrefab;
    
	// Update is called once per frame
	void Start ()
    {
       if(!GameObject.FindGameObjectWithTag("MM"))
        {
            var mManger = Instantiate(musicPrefab, transform.position, Quaternion.identity);
            mManger.name = musicPrefab.name;
            DontDestroyOnLoad(mManger);
        }
	}
    void OnGUI()
    {
        string player_name = PlayerPrefs.GetString("player_name");
        int currentHealth = GameObject.Find("MAX").GetComponent<CharacterHealth>().current_health;
        GUI.Box(new Rect(Screen.width / 2 - sizeX / 2, offsetY, sizeX, sizeY), player_name+"\n"+"Health: " + currentHealth);
    }
}
