using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerCountDown : MonoBehaviour {

    public float timeLeft = 300.0f;
    public Text CountTimeText;
    public GameObject LoseCanvas;
    public GameObject GM_Prefab;

    void Update()
    {
        timeLeft -= Time.deltaTime;
        CountTimeText.text = "Time Left:" + Mathf.Round(timeLeft);
        if (timeLeft < 0)
        {
            GM_Prefab.GetComponent<GameMaster>().NoTime();
        }
    }


}
