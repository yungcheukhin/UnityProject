using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenu : MonoBehaviour {

    public GameObject menu;
    public bool isShowing;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(isShowing == false)
        {
            menu.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(isShowing == false)
            {
                Time.timeScale = 0.0f;
                menu.SetActive(true);
                isShowing = true;
            }
            else
            {
                Time.timeScale = 1.0f;
                menu.SetActive(false);
                isShowing = false;
            }
        }
	}

    public void resume()
    {
        Time.timeScale = 1.0f;
        menu.SetActive(false);
        isShowing = false;
    }
}
