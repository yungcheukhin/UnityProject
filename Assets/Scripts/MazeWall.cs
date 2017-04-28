using UnityEngine;

public class MazeWall : MazeCellEdge {

	public Transform wall;

    Color trans_color = new Color(1.0f, 1.0f, 1.0f, 0.09f);
    Color revertTransColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);

    public override void Initialize (MazeCell cell, MazeCell otherCell, MazeDirection direction) {
		base.Initialize (cell, otherCell, direction);
        cell.room.settings.wallMaterial.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        wall.GetComponent<Renderer>().material = cell.room.settings.wallMaterial;

    }
	public override void transSkills(){
        cell.room.settings.wallMaterial.color = trans_color;
        wall.GetComponent<Renderer>().material = cell.room.settings.wallMaterial;

	}

	public override void revertTransSkill(){
        cell.room.settings.wallMaterial.color = revertTransColor;
        wall.GetComponent<Renderer>().material = cell.room.settings.wallMaterial;
	}
}