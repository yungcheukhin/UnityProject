using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loopWall : MonoBehaviour {

	public Transform wall;
	public Material wallMaterial1, wallMaterial2, wallMaterial3, wallMaterial4, wallMaterial5, wallMaterial6, wallMaterial7, wallMaterial8, wallMaterial9, wallMaterial10, wallMaterial11, wallMaterial12, wallMaterial13, wallMaterial14, wallMaterial15, wallMaterial16, wallMaterial17, wallMaterial18;
	public Material wallMaterial21, wallMaterial22, wallMaterial23, wallMaterial24, wallMaterial25, wallMaterial26, wallMaterial27, wallMaterial28, wallMaterial29, wallMaterial30, wallMaterial31, wallMaterial32, wallMaterial33, wallMaterial34, wallMaterial35, wallMaterial36, wallMaterial37, wallMaterial38;
	Color trans_color = new Color(1.0f, 1.0f, 1.0f, 0.09f);
	Color revertTransColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);

	public void transAll () {
		wallMaterial1.color = trans_color;
		wallMaterial2.color = trans_color;
		wallMaterial3.color = trans_color;
		wallMaterial4.color = trans_color;
		wallMaterial5.color = trans_color;
		wallMaterial6.color = trans_color;
		wallMaterial7.color = trans_color;
		wallMaterial8.color = trans_color;
		wallMaterial9.color = trans_color;
		wallMaterial10.color = trans_color;
		wallMaterial11.color = trans_color;
		wallMaterial12.color = trans_color;
		wallMaterial13.color = trans_color;
		wallMaterial14.color = trans_color;
		wallMaterial15.color = trans_color;
		wallMaterial16.color = trans_color;
		wallMaterial17.color = trans_color;
		wallMaterial18.color = trans_color;
		wallMaterial21.color = trans_color;
		wallMaterial22.color = trans_color;
		wallMaterial23.color = trans_color;
		wallMaterial24.color = trans_color;
		wallMaterial25.color = trans_color;
		wallMaterial26.color = trans_color;
		wallMaterial27.color = trans_color;
		wallMaterial28.color = trans_color;
		wallMaterial29.color = trans_color;
		wallMaterial30.color = trans_color;
		wallMaterial31.color = trans_color;
		wallMaterial32.color = trans_color;
		wallMaterial33.color = trans_color;
		wallMaterial34.color = trans_color;
		wallMaterial35.color = trans_color;
		wallMaterial36.color = trans_color;
		wallMaterial37.color = trans_color;
		wallMaterial38.color = trans_color;

	}

	public void unTransAll () {
		wallMaterial1.color = revertTransColor;
		wallMaterial2.color = revertTransColor;
		wallMaterial3.color = revertTransColor;
		wallMaterial4.color = revertTransColor;
		wallMaterial5.color = revertTransColor;
		wallMaterial6.color = revertTransColor;
		wallMaterial7.color = revertTransColor;
		wallMaterial8.color = revertTransColor;
		wallMaterial9.color = revertTransColor;
		wallMaterial10.color = revertTransColor;
		wallMaterial11.color = revertTransColor;
		wallMaterial12.color = revertTransColor;
		wallMaterial13.color = revertTransColor;
		wallMaterial14.color = revertTransColor;
		wallMaterial15.color = revertTransColor;
		wallMaterial16.color = revertTransColor;
		wallMaterial17.color = revertTransColor;
		wallMaterial18.color = revertTransColor;
		wallMaterial21.color = revertTransColor;
		wallMaterial22.color = revertTransColor;
		wallMaterial23.color = revertTransColor;
		wallMaterial24.color = revertTransColor;
		wallMaterial25.color = revertTransColor;
		wallMaterial26.color = revertTransColor;
		wallMaterial27.color = revertTransColor;
		wallMaterial28.color = revertTransColor;
		wallMaterial29.color = revertTransColor;
		wallMaterial30.color = revertTransColor;
		wallMaterial31.color = revertTransColor;
		wallMaterial32.color = revertTransColor;
		wallMaterial33.color = revertTransColor;
		wallMaterial34.color = revertTransColor;
		wallMaterial35.color = revertTransColor;
		wallMaterial36.color = revertTransColor;
		wallMaterial37.color = revertTransColor;
		wallMaterial38.color = revertTransColor;
	}
}
