using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenu : MonoBehaviour {

    public GameObject menu;
    public bool isShowing;
    public bool settingisshowing;
    //GameObject.Find("name of the gameobject holding the script with the bool").GetComponent<name of the script holding the bool>().IsLightOn
    //GameObject.Find("PauseMenu").GetComponent<pauseMenu>().isShowing

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(isShowing == false || GameObject.Find("SettingMenu").GetComponent<settingMenu>().isShowing)
        {
            menu.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Escape) && !GameObject.Find("SettingMenu").GetComponent<settingMenu>().isShowing)
        {
            if(isShowing == false)
            {
                Time.timeScale = 0.0f;
                menu.SetActive(true);
                isShowing = true;
                Cursor.visible = true;
            }
            else
            {
                Time.timeScale = 1.0f;
                menu.SetActive(false);
                isShowing = false;
                Cursor.visible = false;
            }
        }
	}

    public void resume()
    {
        Time.timeScale = 1.0f;
        menu.SetActive(false);
        isShowing = false;
        Cursor.visible = false;
    }
}
