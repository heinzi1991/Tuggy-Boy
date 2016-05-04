using UnityEngine;
using System.Collections;

public class DestroyCollectObject : MonoBehaviour {

	void OnCollisionEnter (Collision col) {

		if(col.gameObject.name == "CollectObject") {

			Debug.Log ("HELLO");
			Destroy (col.gameObject);
		}
	}
}
