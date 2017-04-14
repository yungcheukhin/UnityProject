using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorialPopup : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //start first canvas
        //backgroundcanvas
        GameObject g = new GameObject();
        Canvas canvas = g.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.WorldSpace;
        CanvasScaler cs = g.AddComponent<CanvasScaler>();
        cs.scaleFactor = 10.0f;
        GraphicRaycaster gr = g.AddComponent<GraphicRaycaster>();
        g.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 3.0f);
        g.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 3.0f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
