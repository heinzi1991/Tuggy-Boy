using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using XInputDotNetPure;

public class GameManager : MonoBehaviour {


	public GameObject gui;
	public int collectCount;
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

	private float secondCount = 0.0f;


	void Awake() {

		collectCounText = gui.GetComponentInChildren<Text>();
		fade = GetComponent<Fading>();
		destroyObject = GameObject.Find("OVRPlayerController").GetComponent<DestroyCollectObject>();
	}
		
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
	
	void Update () {

		if (Input.GetButtonDown("Pause")) {

			StartCoroutine(ChangeLevel(1));
		}

		if (isKonami) {

			StartCoroutine(ChangeLevel(13));
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

		UpdateTimerUI();
			
		collectCounText.text = destroyObject.getDestroy () + " / " + collectCount;

		if (destroyObject.getDestroy() == collectCount) {

			if (SceneManager.GetActiveScene().buildIndex == 2) {

				StartCoroutine(ChangeLevel(1));
			}
			else if (SceneManager.GetActiveScene().buildIndex == 9) {
				
				SetTimeToPlayerPref(SceneManager.GetActiveScene().buildIndex);
				StartCoroutine(ChangeLevel(10));
			}
			else {

				PlayerPrefs.SetInt("HealthCount", healthCount);
				SetTimeToPlayerPref(SceneManager.GetActiveScene().buildIndex);
				StartCoroutine(ChangeLevel(SceneManager.GetActiveScene().buildIndex + 1));
			}
		}

		if (healthCount == 0) {

			StartCoroutine(ChangeLevel(12));
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

			//Debug.Log("You fail!");
			currentPos = 0;
		}

	}

	IEnumerator ChangeLevel(int index) {

		GamePad.SetVibration(0, 0.0f, 0.0f);
		float fadeTime = fade.BeginFade(1);
		yield return new WaitForSeconds(fadeTime);
		SceneManager.LoadScene(index);
	}


	public void DestroyHeart() {

		if (PlayerPrefs.GetInt("godMode") == 1) {

			Destroy(GameObject.Find("Heart_" + (healthCount - 1)));
			healthCount--;
		}
	}

	public void UpdateTimerUI() {

		secondCount += Time.deltaTime;
	}

	public void SetTimeToPlayerPref(int levelIndex) {

		switch (levelIndex) {

		case 4:
			PlayerPrefs.SetInt("Time0", (int)secondCount);
			break;

		case 5:
			PlayerPrefs.SetInt("Time1", (int)secondCount);
			break;

		case 6:
			PlayerPrefs.SetInt("Time2", (int)secondCount);
			break;

		case 7:
			PlayerPrefs.SetInt("Time3", (int)secondCount);
			break;

		case 8:
			PlayerPrefs.SetFloat("Time4", (int)secondCount);
			break;

		case 9:
			PlayerPrefs.SetInt("Time5", (int)secondCount);
			break;

		default:
			Debug.Log("Fail Time Save")	;
			break;
		}
	}
}