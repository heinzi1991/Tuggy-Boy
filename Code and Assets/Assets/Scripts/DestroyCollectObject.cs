using UnityEngine;
using System.Collections;

public class DestroyCollectObject : MonoBehaviour {

	public GameObject collectParticle;
	public GameObject powerUpParticle;
	public AudioClip powerUpSound;
	public AudioClip collectSound;

	private bool powerUp = false;
	private int destroy = 0;
	private bool save = false;

	private bool isTriggered = false;

	private AudioSource audioSource;

	void Start() {

		audioSource = GetComponent<AudioSource>();
	}

	void OnCollisionEnter (Collision col) {

		if(col.gameObject.tag == "CollectObject") {

			audioSource.PlayOneShot(collectSound, 1.0f);
			GameObject clone = (GameObject)Instantiate(collectParticle, new Vector3(transform.position.x, transform.position.y, transform.position.z + 1), collectParticle.transform.rotation);
			Destroy (col.gameObject);
			destroy++;
			Destroy (clone, 3.0f);
		}

		if (col.gameObject.tag == "PowerUp") {

			audioSource.PlayOneShot(powerUpSound, 1.0f);
			GameObject clone = (GameObject)Instantiate(powerUpParticle, new Vector3(transform.position.x, transform.position.y, transform.position.z + 1), powerUpParticle.transform.rotation);
			Destroy (col.gameObject);
			StartCoroutine(Waiting());
			Destroy (clone, 3.0f);
		}
	}

	void OnTriggerEnter (Collider col) {

		if (col.gameObject.tag == "SaveRoom") {

			if (isTriggered == false) {

				if (save) {

					save = false;
				}
				else {

					save = true;
				}

				isTriggered = true;
			}
		}
	}

	void OnTriggerExit (Collider col) {

		if (col.gameObject.tag == "SaveRoom") {

			isTriggered = false;
		}
	}

	public int getDestroy() {

		return destroy;
	}

	public bool getPowerUp() {

		return powerUp;
	}

	public bool getSaveMode() {

		return save;
	}

	IEnumerator Waiting() {

		powerUp = true;
		yield return new WaitForSeconds(5.0f);
		powerUp = false;
	}
}
