using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {

    static int currentHealth = 100;
    float offsetY = 40;
    float sizeX = 100;
    float sizeY = 40;
    
	// Update is called once per frame
	void Update () {
       
	}

    void OnGUI()
    {
        GUI.Box(new Rect(Screen.width / 2 - sizeX / 2, offsetY, sizeX, sizeY), "Health: " + currentHealth);
    }
}
