using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loopWall : MonoBehaviour {

	Color trans_color = new Color(1.0f, 1.0f, 1.0f, 0.09f);
	Color revertTransColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
	public static int size = 31;
	public Material[] Mat = new Material[size];

	public void transAll () {
		for(int i = 0; i<size; i++)
		{
			if (Mat[i] != null)
				Mat[i].color = trans_color;
		}

	}

	public void unTransAll () {
		for (int i = 0; i < size; i++)
		{
			if (Mat[i] != null)
				Mat[i].color = revertTransColor;
		}
	}
}
