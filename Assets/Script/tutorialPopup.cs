using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorialPopup : MonoBehaviour
{

    public bool mouseclick = false;
    public bool mouseclick1 = false;
    public bool wasd = false;
    public bool useskill = false;
    public bool opendoor = false;
    public bool openchest = false;

    // Use this for initialization
    void Start()
    {
        //welcome();
        GameObject g = new GameObject("welcomeo");
        Canvas canvas = g.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        CanvasScaler cs = g.AddComponent<CanvasScaler>();
        cs.uiScaleMode = CanvasScaler.ScaleMode.ConstantPixelSize;
        cs.scaleFactor = 1.0f;
        cs.referencePixelsPerUnit = 100f;
        GraphicRaycaster gr = g.AddComponent<GraphicRaycaster>();

        GameObject panel = new GameObject("Panel");
        panel.AddComponent<CanvasRenderer>();
        Image i = panel.AddComponent<Image>();
        Color backg = new Color32(255, 255, 255, 95);
        i.color = backg;
        RectTransform panelrec = panel.GetComponent<RectTransform>();
        panelrec.sizeDelta = new Vector2(200, 100);
        panelrec.position = new Vector3(-200, 100, 0);

        GameObject welcomeText = new GameObject("welcomeText");
        welcomeText.AddComponent<CanvasRenderer>();
        Text t = welcomeText.AddComponent<Text>();
        t.text = "Welcome To Dark Maze! \n \n" + "This tutorial will teach you how to control your character and use different skills. Left click your mouse to continue.";
        t.fontSize = 14;
        t.color = Color.black;
        t.font = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
        t.alignment = TextAnchor.MiddleCenter;
        welcomeText.GetComponent<RectTransform>().sizeDelta = new Vector2(190, 100);
        welcomeText.GetComponent<RectTransform>().position = new Vector3(0, 0, 0);

        panel.transform.SetParent(g.transform, false);
        welcomeText.transform.SetParent(panel.transform, false);

        Time.timeScale = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            mouseclick = true;
        }
        if (mouseclick == true)
        {
            Time.timeScale = 1.0f;
            //mouseclick = false;
            if (mouseclick1 == false)
            {
                DestroyObject(GameObject.Find("welcomeo"));
                wasdshow();
                tips();
                mouseclick1 = true;
            }
        }

        if(Input.GetKeyDown("w") && wasd == false && mouseclick1 == true)
        {
            DestroyObject(GameObject.Find("wasdo"));
            wasd = true;
            skillshow();
        }

        if (Input.GetKeyDown("e") && useskill == false && wasd == true && mouseclick1 == true)
        {
            DestroyObject(GameObject.Find("skillo"));
            useskill = true;
            opendoorshow();
        }

        if (Input.GetKeyDown("q") && opendoor == false && wasd == true && useskill == true && mouseclick1 == true)
        {
            DestroyObject(GameObject.Find("opendooro"));
            opendoor = true;
            openchestshow();
        }

    }

    public void wasdshow()
    {
        GameObject g = new GameObject("wasdo");
        Canvas canvas = g.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        CanvasScaler cs = g.AddComponent<CanvasScaler>();
        cs.uiScaleMode = CanvasScaler.ScaleMode.ConstantPixelSize;
        cs.scaleFactor = 1.0f;
        cs.referencePixelsPerUnit = 100f;
        GraphicRaycaster gr = g.AddComponent<GraphicRaycaster>();
        /*g.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 3.0f);
        g.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 3.0f);*/

        GameObject panel = new GameObject("Panel");
        panel.AddComponent<CanvasRenderer>();
        Image i = panel.AddComponent<Image>();
        Color backg = new Color32(255, 255, 255, 95);
        i.color = backg;
        RectTransform panelrec = panel.GetComponent<RectTransform>();
        panelrec.sizeDelta = new Vector2(200, 100);
        panelrec.position = new Vector3(-200, 100, 0);

        GameObject wText = new GameObject("wasdText");
        wText.AddComponent<CanvasRenderer>();
        Text t = wText.AddComponent<Text>();
        t.text = "Please press 'W/A/S/D' to move your character.\n" + "You can move your cursor to adjust your direction.\n" + "Try to walk and get next hint.";
        t.fontSize = 14;
        t.color = Color.black;
        t.font = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
        t.alignment = TextAnchor.MiddleCenter;
        wText.GetComponent<RectTransform>().sizeDelta = new Vector2(190, 100);
        wText.GetComponent<RectTransform>().position = new Vector3(0, 0, 0);

        panel.transform.SetParent(g.transform, false);
        wText.transform.SetParent(panel.transform, false);
    }

    public void skillshow()
    {
        GameObject g = new GameObject("skillo");
        Canvas canvas = g.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        CanvasScaler cs = g.AddComponent<CanvasScaler>();
        cs.uiScaleMode = CanvasScaler.ScaleMode.ConstantPixelSize;
        cs.scaleFactor = 1.0f;
        cs.referencePixelsPerUnit = 100f;
        GraphicRaycaster gr = g.AddComponent<GraphicRaycaster>();

        GameObject panel = new GameObject("Panel");
        panel.AddComponent<CanvasRenderer>();
        Image i = panel.AddComponent<Image>();
        Color backg = new Color32(255, 255, 255, 95);
        i.color = backg;
        RectTransform panelrec = panel.GetComponent<RectTransform>();
        panelrec.sizeDelta = new Vector2(200, 100);
        panelrec.position = new Vector3(-200, 100, 0);

        GameObject wText = new GameObject("opendoorText");
        wText.AddComponent<CanvasRenderer>();
        Text t = wText.AddComponent<Text>();
        t.text = "Please press 'E' to use the skill.\n" + "The skill effect will sustain for 3 seconds.\n" + "Tips: you can hold SHIFT while walking to run.";
        t.fontSize = 14;
        t.color = Color.black;
        t.font = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
        t.alignment = TextAnchor.MiddleCenter;
        wText.GetComponent<RectTransform>().sizeDelta = new Vector2(190, 100);
        wText.GetComponent<RectTransform>().position = new Vector3(0, 0, 0);

        panel.transform.SetParent(g.transform, false);
        wText.transform.SetParent(panel.transform, false);
    }

    public void opendoorshow()
    {
        GameObject g = new GameObject("opendooro");
        Canvas canvas = g.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        CanvasScaler cs = g.AddComponent<CanvasScaler>();
        cs.uiScaleMode = CanvasScaler.ScaleMode.ConstantPixelSize;
        cs.scaleFactor = 1.0f;
        cs.referencePixelsPerUnit = 100f;
        GraphicRaycaster gr = g.AddComponent<GraphicRaycaster>();

        GameObject panel = new GameObject("Panel");
        panel.AddComponent<CanvasRenderer>();
        Image i = panel.AddComponent<Image>();
        Color backg = new Color32(255, 255, 255, 95);
        i.color = backg;
        RectTransform panelrec = panel.GetComponent<RectTransform>();
        panelrec.sizeDelta = new Vector2(200, 100);
        panelrec.position = new Vector3(-200, 100, 0);

        GameObject wText = new GameObject("opendoorText");
        wText.AddComponent<CanvasRenderer>();
        Text t = wText.AddComponent<Text>();
        t.text = "Please press 'Q' to open the door.\n\n Beware of the enemy and \n RUN FOR YOUR LIFE.";
        t.fontSize = 14;
        t.color = Color.black;
        t.font = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
        t.alignment = TextAnchor.MiddleCenter;
        wText.GetComponent<RectTransform>().sizeDelta = new Vector2(190, 100);
        wText.GetComponent<RectTransform>().position = new Vector3(0, 0, 0);

        panel.transform.SetParent(g.transform, false);
        wText.transform.SetParent(panel.transform, false);
    }

    public void openchestshow()
    {
        GameObject g = new GameObject("openchesto");
        Canvas canvas = g.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        CanvasScaler cs = g.AddComponent<CanvasScaler>();
        cs.uiScaleMode = CanvasScaler.ScaleMode.ConstantPixelSize;
        cs.scaleFactor = 1.0f;
        cs.referencePixelsPerUnit = 100f;
        GraphicRaycaster gr = g.AddComponent<GraphicRaycaster>();

        GameObject panel = new GameObject("Panel");
        panel.AddComponent<CanvasRenderer>();
        Image i = panel.AddComponent<Image>();
        Color backg = new Color32(255, 255, 255, 95);
        i.color = backg;
        RectTransform panelrec = panel.GetComponent<RectTransform>();
        panelrec.sizeDelta = new Vector2(200, 100);
        panelrec.position = new Vector3(-200, 100, 0);

        GameObject wText = new GameObject("opendoorText");
        wText.AddComponent<CanvasRenderer>();
        Text t = wText.AddComponent<Text>();
        t.text = "Please press 'F' to open the chest.\n\n" + "Tips: you can hold SHIFT while walking to run.";
        t.fontSize = 14;
        t.color = Color.black;
        t.font = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
        t.alignment = TextAnchor.MiddleCenter;
        wText.GetComponent<RectTransform>().sizeDelta = new Vector2(190, 100);
        wText.GetComponent<RectTransform>().position = new Vector3(0, 0, 0);

        panel.transform.SetParent(g.transform, false);
        wText.transform.SetParent(panel.transform, false);
    }

    public void tips()
    {
        GameObject g = new GameObject("tipso");
        Canvas canvas = g.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        CanvasScaler cs = g.AddComponent<CanvasScaler>();
        cs.uiScaleMode = CanvasScaler.ScaleMode.ConstantPixelSize;
        cs.scaleFactor = 1.0f;
        cs.referencePixelsPerUnit = 100f;
        GraphicRaycaster gr = g.AddComponent<GraphicRaycaster>();

        GameObject panel = new GameObject("Panel");
        panel.AddComponent<CanvasRenderer>();
        Image i = panel.AddComponent<Image>();
        Color backg = new Color32(255, 255, 255, 95);
        i.color = backg;
        RectTransform panelrec = panel.GetComponent<RectTransform>();
        panelrec.sizeDelta = new Vector2(140, 120);
        panelrec.position = new Vector3(300, 100, 0);

        GameObject wText = new GameObject("opendoorText");
        wText.AddComponent<CanvasRenderer>();
        Text t = wText.AddComponent<Text>();
        t.text = "Quick Tips! \n \n 'W/A/S/D' : move \n 'Shift' : Run \n 'E' : Skill \n 'Q' : Open Door \n 'F' : Open Chest";
        t.fontSize = 14;
        t.color = Color.black;
        t.font = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
        t.alignment = TextAnchor.MiddleCenter;
        wText.GetComponent<RectTransform>().sizeDelta = new Vector2(130, 100);
        wText.GetComponent<RectTransform>().position = new Vector3(0, 0, 0);

        panel.transform.SetParent(g.transform, false);
        wText.transform.SetParent(panel.transform, false);
    }
}
