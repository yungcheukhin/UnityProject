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

    public float intensity;
    public Color fogDay = Color.grey;
    public Color fogNight = Color.black;

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
            intensity = 1 - (43200 - time) / 43200;
        }
        else
        {
            intensity = 1 - (43200 - time) / 43200*-1;
        }
        RenderSettings.fogColor = Color.Lerp(fogNight, fogDay, intensity * intensity);
        Sun.intensity = intensity;
    }
}
