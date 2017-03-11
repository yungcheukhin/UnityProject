using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : MonoBehaviour {

    public float distanceToActivate;
    public float setOpenCloseTimer;

    float distance;
    float openCloseTimer;

    bool isSwitchable;
    bool isOpen;

    GameObject player;

    void Awake()
    {

        isSwitchable = false;
        openCloseTimer = 0;
        player = GameObject.FindGameObjectWithTag("Player");

    }

    void OnMouseUp()
    {

        if (openCloseTimer <= 0 && isSwitchable)
            isOpen = !isOpen;

    }

    void Update()
    {

        distance = Vector3.Distance(this.transform.position, player.transform.position);

        if (distance <= distanceToActivate)
            isSwitchable = true;
        else
            isSwitchable = false;

        openCloseTimer -= Time.deltaTime;

        if (openCloseTimer <= 0)
            openCloseTimer = 0;

        if (isOpen)
        {
            /*animation["Open"].wrapMode = WrapMode.Once;
            animation.Play("Open");
            openCloseTimer = setOpenCloseTimer;*/
        }

        if (!isOpen)
        {
            /*animation.Play("Close");
            animation["Close"].wrapMode = WrapMode.Once;
            openCloseTimer = setOpenCloseTimer;*/
        }

    }
}
