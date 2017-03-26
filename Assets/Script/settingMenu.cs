using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settingMenu : MonoBehaviour {

    public GameObject settingCanvas;
    public GameObject pauseCanvas;
        public bool isShowing;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isShowing == false)
        {
            settingCanvas.SetActive(false);
        }
    }

    public void opensetting()
    {
        settingCanvas.SetActive(true);
        pauseCanvas.SetActive(false);
        isShowing = true;
    }

    public void closesetting()
    {
        settingCanvas.SetActive(false);
        pauseCanvas.SetActive(true);
        isShowing = false;
    }

    public void mute(bool mutevalue)
    {
        //AudioListener.volume = 1;
        //if(mutevalue)
        if (mutevalue == true)
        {
            AudioListener.volume = 1;
        }
        else
        {
            AudioListener.volume = 0;
        }
    }

    public void volumeslider(float vol)
    {
        AudioListener.volume = vol;
    }
}
