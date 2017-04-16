using UnityEngine;

public class MazeWall : MazeCellEdge {

	public Transform wall;

	public override void Initialize (MazeCell cell, MazeCell otherCell, MazeDirection direction) {
		base.Initialize (cell, otherCell, direction);
        cell.room.settings.wallMaterial.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

        wall.GetComponent<Renderer>().material = cell.room.settings.wallMaterial;

        //Color color_l = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        //wall.GetComponent<Renderer>().material.SetColor("Standard", color_l);

    }
	public override void transSkills(){
        cell.room.settings.wallMaterial.color = new Color(1.0f, 1.0f, 1.0f, 0.09f);
        wall.GetComponent<Renderer>().material = cell.room.settings.wallMaterial;
        Debug.Log("Wall Transparented");

	}

	public override void revertTransSkill(){
        cell.room.settings.wallMaterial.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        wall.GetComponent<Renderer>().material = cell.room.settings.wallMaterial;
		Debug.Log("Wall Normaled");
	}


}