using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loopWall : MonoBehaviour {

	public Transform wall;
	//public Material wallMaterial1, wallMaterial2, wallMaterial3, wallMaterial4, wallMaterial5, wallMaterial6, wallMaterial7, wallMaterial8, wallMaterial9, wallMaterial10, wallMaterial11, wallMaterial12, wallMaterial13, wallMaterial14, wallMaterial15, wallMaterial16, wallMaterial17, wallMaterial18;
	//public Material wallMaterial21, wallMaterial22, wallMaterial23, wallMaterial24, wallMaterial25, wallMaterial26, wallMaterial27, wallMaterial28, wallMaterial29, wallMaterial30, wallMaterial31, wallMaterial32, wallMaterial33, wallMaterial34, wallMaterial35, wallMaterial36, wallMaterial37, wallMaterial38;
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
