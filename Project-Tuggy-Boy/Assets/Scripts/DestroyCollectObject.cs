using UnityEngine;
using System.Collections;

public class DestroyCollectObject : MonoBehaviour {

	public GameObject particle;


	private static int destroy = 0;

	void OnCollisionEnter (Collision col) {

		if(col.gameObject.tag == "CollectObject") {

			Instantiate(particle, new Vector3(transform.position.x, transform.position.y, transform.position.z + 1), particle.transform.rotation);
			Destroy (col.gameObject);
			destroy++;
		}
	}

	public static int getDestroy() {

		return destroy;
	}
}
