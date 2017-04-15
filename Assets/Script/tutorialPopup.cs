using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorialPopup : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        //start first canvas
        //backgroundcanvas
        GameObject g = new GameObject("g");
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
        
        panel.transform.SetParent(g.transform, false);

        GameObject g2 = new GameObject("welcome");
        //g2.transform.parent = i.transform;
        Text t = g2.AddComponent<Text>();
        t.text = "Welcome";
        t.fontSize = 14;
        t.color = Color.black;
        t.font = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
        g2.transform.SetParent(panel.transform, false);
        //g2.GetComponent<RectTransform>().position = new Vector3(-200, 100, 0);


        /*GameObject g2 = new GameObject();
        g2.name = "text";
        g2.transform.parent = g.transform;
        Text t = g2.AddComponent<Text>();
        g2.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 3.0f);
        g2.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 3.0f);
        t.alignment = TextAnchor.MiddleCenter;
        t.horizontalOverflow = HorizontalWrapMode.Overflow;
        t.verticalOverflow = VerticalWrapMode.Overflow;
        Font ArialFont = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
        t.font = ArialFont;
        t.fontSize = 7;
        t.text = "Test";
        t.enabled = true;
        t.color = Color.black;
    

        g.name = "Text Label";
        bool bWorldPosition = false;

        g.GetComponent<RectTransform>().SetParent(this.transform, bWorldPosition);
        g.transform.localPosition = new Vector3(0f, 1f, 0f);
        g.transform.localScale = new Vector3(
                                             1.0f / this.transform.localScale.x * 0.1f,
                                             1.0f / this.transform.localScale.y * 0.1f,
                                             1.0f / this.transform.localScale.z * 0.1f);*/
    }

    // Update is called once per frame
    void Update () {
		
	}
}
