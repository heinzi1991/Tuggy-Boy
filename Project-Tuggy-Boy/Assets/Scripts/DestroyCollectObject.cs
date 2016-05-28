using UnityEngine;
using System.Collections;

public class DestroyCollectObject : MonoBehaviour {

	public GameObject collectParticle;
	public GameObject powerUpParticle;

	private static bool powerUp;
	private static int destroy = 0;

	void OnCollisionEnter (Collision col) {

		if(col.gameObject.tag == "CollectObject") {

			GameObject clone = (GameObject)Instantiate(collectParticle, new Vector3(transform.position.x, transform.position.y, transform.position.z + 1), collectParticle.transform.rotation);
			Destroy (col.gameObject);
			destroy++;
			Destroy (clone, 3.0f);
		}

		if (col.gameObject.tag == "PowerUp") {

			GameObject clone = (GameObject)Instantiate(powerUpParticle, new Vector3(transform.position.x, transform.position.y, transform.position.z + 1), powerUpParticle.transform.rotation);
			Destroy (col.gameObject);
			StartCoroutine(Waiting());
			Destroy (clone, 3.0f);
		}
	}

	public static int getDestroy() {

		return destroy;
	}

	public static bool getPowerUp() {

		return powerUp;
	}

	IEnumerator Waiting() {

		powerUp = true;
		yield return new WaitForSeconds(5.0f);
		powerUp = false;
	}


}
