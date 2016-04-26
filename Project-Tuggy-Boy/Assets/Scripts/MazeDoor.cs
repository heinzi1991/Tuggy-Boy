﻿using UnityEngine;

public class MazeDoor : MazePassage {

	private MazeDoor OtherSideDoor {

		get {

			return otherCell.GetEdge (direction.GetOpposite ()) as MazeDoor;
		}
	}

	public override void Initialize (MazeCell primary, MazeCell other, MazeDirection direction) {

		base.Initialize (primary, other, direction);

		for(int i = 0; i < transform.childCount; i++) {

			Transform child = transform.GetChild (i);
			child.GetComponent<Renderer> ().material = cell.room.settings.wallMaterial;
		}
	}

}
