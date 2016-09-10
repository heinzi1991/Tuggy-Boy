using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {


	public GameObject gui;
	public int collectCount;
	//public GameObject player;
	public int healthCount;
	public GameObject heartImage;

	private Text collectCounText;
	private Fading fade;
	private DestroyCollectObject destroyObject;

	private string[] konamiCode = new string[]{"Up", "Up", "Down", "Down", "Left", "Right", "Left", "Right", "B", "A"};
	private int currentPos = 0;
	private bool isKonami = false;
	private bool crossXUse = false;
	private bool crossYUse = false;


	void Awake() {

		collectCounText = gui.GetComponentInChildren<Text>();
		fade = GetComponent<Fading>();
		destroyObject = GameObject.Find("OVRPlayerController").GetComponent<DestroyCollectObject>();
	}
		
	// Use this for initialization
	void Start () {

		healthCount = PlayerPrefs.GetInt("HealthCount");
		
		collectCounText.text = "-- / " + collectCount;

		for (int i = 0; i < healthCount; i++) {

			GameObject newHeart = Instantiate(heartImage) as GameObject;
			newHeart.name = "Heart_" + i;
			newHeart.transform.position = new Vector3(-1.0f + 0.2f * i, -0.8f, 0.0f);
			newHeart.transform.SetParent(gui.transform, false);
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (isKonami) {

			StartCoroutine(ChangeLevel(12));
		}
			
		if (Input.GetAxis("CrossX") != 0) {

			if (crossXUse == false) {

				checkInput(Input.GetAxis("CrossX"), "crossX");
				crossXUse = true;
			}
		}

		if (Input.GetAxis("CrossX") == 0) {

			crossXUse = false;
		}

		if (Input.GetAxis("CrossY") != 0) {

			if (crossYUse == false) {

				checkInput(Input.GetAxis("CrossY"), "crossY");
				crossYUse = true;
			}
		}

		if (Input.GetAxis("CrossY") == 0) {

			crossYUse = false;
		}

		if (Input.GetButtonDown("Jump")) {

			checkInput(0, "buttonA");
		}

		if (Input.GetButtonDown("Fire1")) {

			checkInput(0, "buttonB");
		}
			
		collectCounText.text = destroyObject.getDestroy () + " / " + collectCount;

		if (destroyObject.getDestroy() == collectCount) {

			if (SceneManager.GetActiveScene().buildIndex == 2) {

				StartCoroutine(ChangeLevel(1));
			}
			else if (SceneManager.GetActiveScene().buildIndex == 9) {

				StartCoroutine(ChangeLevel(10));
			}
			else {

				PlayerPrefs.SetInt("HealthCount", healthCount);
				StartCoroutine(ChangeLevel(SceneManager.GetActiveScene().buildIndex + 1));
			}
		}

		if (healthCount == 0) {

			StartCoroutine(ChangeLevel(11));
		}
	}

	void checkInput(float input, string button) {

		string checkKonami = "";

		if (button == "crossX") {

			if (input < 0) {

				checkKonami = "Left";
			}

			if (input > 0) {

				checkKonami = "Right";
			}
		}

		if (button == "crossY") {

			if (input < 0) {

				checkKonami = "Down";
			}

			if (input > 0) {

				checkKonami = "Up";
			}
		}

		if (button == "buttonA") {

			checkKonami = "A";
		}

		if (button == "buttonB") {

			checkKonami = "B";
		}

		if (checkKonami == konamiCode[currentPos]) {

			currentPos++;

			if ((currentPos + 1) > konamiCode.Length) {

				isKonami = true;
				currentPos = 0;
			}
		}
		else {

			Debug.Log("You fail!");
			currentPos = 0;
		}

	}

	IEnumerator ChangeLevel(int index) {

		float fadeTime = fade.BeginFade(1);
		yield return new WaitForSeconds(fadeTime);
		SceneManager.LoadScene(index);
	}


	public void DestroyHeart() {

		Destroy(GameObject.Find("Heart_" + (healthCount - 1)));
		healthCount--;
	}
}