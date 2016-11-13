using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {

    static int currentHealth = 100;
    public float offsetY = 40;
    public float sizeX = 100;
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
        GUI.Box(new Rect(Screen.width / 2 - sizeX / 2, offsetY, sizeX, sizeY), "Health: " + currentHealth);
    }
}
