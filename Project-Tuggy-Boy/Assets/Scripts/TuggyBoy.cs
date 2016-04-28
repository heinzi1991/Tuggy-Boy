using UnityEngine;
using System.Collections;

public class TuggyBoy : MonoBehaviour {

	private Vector3 MovingDirection = Vector3.up;

	void Update() {

		gameObject.transform.Translate(MovingDirection * Time.smoothDeltaTime);

		if (gameObject.transform.position.y > 1) {

			MovingDirection = Vector3.down;
		}
		else if (gameObject.transform.position.y < 0) {

			MovingDirection = Vector3.up;
		}
	}
}
