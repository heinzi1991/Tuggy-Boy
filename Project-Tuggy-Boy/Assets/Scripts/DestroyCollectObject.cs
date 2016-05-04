using UnityEngine;
using System.Collections;

public class DestroyCollectObject : MonoBehaviour {

	void OnCollisionEnter (Collision col) {

		if(col.gameObject.name == "CollectObject") {

			Destroy (col.gameObject);
		}
	}
}
