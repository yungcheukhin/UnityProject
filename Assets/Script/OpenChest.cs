using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : MonoBehaviour {

    public float distanceToActivate;
    public float setOpenCloseTimer;
    public GameObject open_chest_prefab;

    private float distance;
    private float openCloseTimer;
    private bool isSwitchable;
    private bool isOpen;
    private GameObject player;
    private GameObject close_chest;
    private GameObject open_chest_object;

    void Awake()
    {

        isSwitchable = false;
        openCloseTimer = 0;
        player = GameObject.FindGameObjectWithTag("Player");
        close_chest = GameObject.FindGameObjectWithTag("Chest");

    }

    public bool openChest()
    {

        if (openCloseTimer <= 0 && isSwitchable)
        {
            isOpen = !isOpen;
            return true;
        }
        return false;


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
            open_chest_object = GameObject.Instantiate(open_chest_prefab, this.transform.position, this.transform.rotation);
            Destroy(close_chest);
        }
    }
}
