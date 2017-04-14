﻿using UnityEngine;

public class MazeWall : MazeCellEdge {

	public Transform wall;

	public override void Initialize (MazeCell cell, MazeCell otherCell, MazeDirection direction) {
		base.Initialize (cell, otherCell, direction);
		wall.GetComponent<Renderer>().material = cell.room.settings.wallMaterial;
	}
	public override void transSkills(){
		wall.GetComponent<Renderer>().material.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
		Debug.Log("Wall Transparented");

	}

	public override void revertTransSkill(){
        wall.GetComponent<Renderer>().material = cell.room.settings.wallMaterial;
		Debug.Log("Wall Normaled");
	}


}