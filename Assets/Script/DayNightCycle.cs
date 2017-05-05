using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class DayNightCycle : MonoBehaviour {

    public float time;
    public TimeSpan currentTime;
    public Transform SunLocation;
    public Light Sun;
    public int days;

    //public float intensity;
    public Material midnight;
    public Material morning;
    public Material noon;
    public Material afternoon;
    public Material sunset;
    public Material night;

    public int speed;

	void Update ()
    {
        ChangeTime();
	}

    public void ChangeTime()
    {
        time += Time.deltaTime * speed;
        if(time > 86400)
        {
            days += 1;
            time = 0;
        }
        currentTime = TimeSpan.FromSeconds(time);

        SunLocation.rotation = Quaternion.Euler(new Vector3((time - 21600) / 86400 * 360, 0, 0));
        if (time < 43200)
        {
            //intensity = 1 - (43200 - time) / 43200;
        }
        else
        {
            //intensity = 1 - (43200 - time) / 43200*-1;
        }

        //Sky at different time periods
        if (time < 18000)
        {
            RenderSettings.skybox = midnight;
        }
        if (time >= 18000 && time < 39600)
        {
            RenderSettings.skybox = morning;
        }
        if (time >= 39600 && time < 46800)
        {
            RenderSettings.skybox = noon;
        }
        if (time >= 46800 && time < 64800)
        {
            RenderSettings.skybox = afternoon;
        }
        if (time >= 64800 && time < 70200)
        {
            RenderSettings.skybox = sunset;
        }
        if (time >= 70200)
        {
            RenderSettings.skybox = night;
        }
        
        //Sun.intensity = intensity;
    }
}
