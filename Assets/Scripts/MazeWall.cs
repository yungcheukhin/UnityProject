using UnityEngine;

public class MazeWall : MazeCellEdge {

	public Transform wall;

	public override void Initialize (MazeCell cell, MazeCell otherCell, MazeDirection direction) {
		base.Initialize (cell, otherCell, direction);
		wall.GetComponent<Renderer>().material = cell.room.settings.wallMaterial;
	}
	public void transSkills(){
		wall.GetComponent<Renderer>().material.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
		Debug.Log("Wall Transparent");

	}

	public void revertTransSkill(){
		wall.GetComponent<Renderer>().material = cell.room.settings.wallMaterial;
		Debug.Log("Wall Normal");
	}
}