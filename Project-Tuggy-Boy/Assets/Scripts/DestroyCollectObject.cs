using UnityEngine;
using System.Collections;

public class DestroyCollectObject : MonoBehaviour {

	private static int destroy = 0;

	void OnCollisionEnter (Collision col) {

		if(col.gameObject.name == "CollectObject") {

			Destroy (col.gameObject);
			destroy++;
		}
	}

	public static int getDestroy() {

		return destroy;
	}
}
