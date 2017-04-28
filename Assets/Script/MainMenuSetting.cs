using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSetting : MonoBehaviour {

    public GameObject settingmenu;
    public bool isShowing;

    // Update is called once per frame
    /*void Update()
    {
        if (isShowing == false)
        {
            settingmenu.SetActive(false);
        }
    }*/

    void Start()
    {
        settingmenu.SetActive(false);
        isShowing = false;
        Cursor.visible = true;
    }

    public void openmenu()
    {
        settingmenu.SetActive(true);
        isShowing = true;
    }

    public void closemenu()
    {
        settingmenu.SetActive(false);
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
