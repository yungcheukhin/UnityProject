using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AccessName : MonoBehaviour {

    void saveName()
    {
        string myName = GameObject.Find("Username").GetComponent<UnityEngine.UI.Text>().text;

        PlayerPrefs.SetString("player_name", myName);
    }

}
