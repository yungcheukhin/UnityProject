using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class Teleport : MonoBehaviour {

    private GameObject GM;
    //Scene Change Boolean
    public bool toScene2 = false;
    public bool toScene3 = false;

    public void Awake()
    {
        GM = GameObject.FindGameObjectWithTag("GM");

        //Teleport to the correct level after opening the chest
        if (GM.GetComponent<GameMaster>().game_round == 1)
        {
            toScene2 = true;
        }
        else if (GM.GetComponent<GameMaster>().game_round == 2)
        {
            toScene3 = true;
        }
        else if (GM.GetComponent<GameMaster>().game_round == 3)
        {
            toScene3 = true;
        }
    }
}
