using UnityEngine;

public class MazeWall : MazeCellEdge {

	public Transform wall;

    Color trans_color = new Color(1.0f, 1.0f, 1.0f, 0.09f);

	public override void Initialize (MazeCell cell, MazeCell otherCell, MazeDirection direction) {
		base.Initialize (cell, otherCell, direction);
        cell.room.settings.wallMaterial.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

        wall.GetComponent<Renderer>().material = cell.room.settings.wallMaterial;

        //cell.room.settings.wallMaterial.color = trans_color;
        //wall_trans.GetComponent<Renderer>().material = cell.room.settings.wallMaterial;

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

    /*
    public override void wall_hide()
    {
        gameObject.SetActive(false);
    }

    public override void wall_show()
    {
        gameObject.SetActive(true);
    }
    */


}