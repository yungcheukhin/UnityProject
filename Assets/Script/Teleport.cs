using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class Teleport : MonoBehaviour {
    private GameMaster GM;

    public void Awake()
    {
        GM = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        StartCoroutine(win());

        //Teleport to the correct level after opening the chest
    }

    IEnumerator win()
    {
        showWinningCanvas();
        yield return new WaitForSeconds(6);
        hideWinningCanvas();
        GM.nextStage();
    }

    private void showWinningCanvas()
    {

    }

    private void hideWinningCanvas()
    {

    }

}
