using UnityEngine;
using System.Collections;

public class DestroyCollectObject : MonoBehaviour {

	public GameObject collectParticle;
	public GameObject powerUpParticle;
	public AudioClip powerUpSound;
	public AudioClip collectSound;

	private static bool powerUp;
	private static int destroy = 0;

	private AudioSource audioSource;

	void Start() {

		audioSource = GetComponent<AudioSource>();
	}

	void OnCollisionEnter (Collision col) {

		if(col.gameObject.tag == "CollectObject") {

			//audioSource.clip = collectSound;
			audioSource.PlayOneShot(collectSound, 1.0f);
			GameObject clone = (GameObject)Instantiate(collectParticle, new Vector3(transform.position.x, transform.position.y, transform.position.z + 1), collectParticle.transform.rotation);
			Destroy (col.gameObject);
			destroy++;
			Destroy (clone, 3.0f);
		}

		if (col.gameObject.tag == "PowerUp") {

			//audioSource.clip = powerUpSound;
			audioSource.PlayOneShot(powerUpSound, 1.0f);
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
