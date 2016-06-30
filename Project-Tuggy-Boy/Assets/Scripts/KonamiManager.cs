using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class KonamiManager : MonoBehaviour {

	// Use this for initialization
	IEnumerator Start () {

		AudioSource audio = GetComponent<AudioSource>();

		audio.Play();
		yield return new WaitForSeconds(15);
		audio.Stop();

		SceneManager.LoadScene("Start Menu");
	
	}

}
