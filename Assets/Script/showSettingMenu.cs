using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showSettingMenu : MonoBehaviour {

    MainMenuSetting setting;
    private bool flag = false;

    void Start() {
        setting = GameObject.Find("SettingMenu").GetComponent<MainMenuSetting>();
        Cursor.visible = true;
    }

    void Update () {
        if (flag)
            setting.openmenu();
        else
            setting.closemenu();
    }
    public void setFlag()
    {
        if (flag) flag = false;
        else flag = true;
        
    }
}
