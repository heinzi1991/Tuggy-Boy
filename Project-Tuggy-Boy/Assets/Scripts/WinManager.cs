using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using VRStandardAssets.Utils;

public class WinManager : MonoBehaviour {

	[SerializeField] private Reticle m_Reticle;
	[SerializeField] private SelectionRadial m_Radial;
	[SerializeField] private UIFader m_Fader;
	[SerializeField] private SelectionSlider m_Slider;

	public TextMesh[] chars;
	public GameObject[] triangles;

	public GameObject highscoreObject;
	public GameObject congratulationObject;


	private int[] tempArray;
	private string[] letters;
	private int[] highscores;


	private int charCount = 0;
	private int totalTime = 0;
	private int letterCount = 0;
	private int highscoreCounter = 0;
	private int highscorePostion = 0;


	private string highscoreName = "";


	private bool horizontalUse = false;
	private bool verticalUse = false;
	private bool crossXUse = false;
	private bool crossYUse = false;
	private bool isHighscore = false;


	private List<int> highscoreList = new List<int>();


	void Awake() {

		for (int i = 0; i < 6; i++) {

			totalTime += PlayerPrefs.GetInt("Time"+ i);
		}

		for (int i = 0; i < 5; i++) {

			if (PlayerPrefs.HasKey("highscore" + i) == false) {

				isHighscore = true;

				if (i == 0) {
					
					highscorePostion = i;
					break;
				}
				else {

					sortHighscore();
					break;
				}
			}
			else {

				highscoreCounter++;
			}
		}

		if (highscoreCounter == 5) {

			changeHighscores();
		}
	}

	// Use this for initialization
	void Start () {

		if (isHighscore == true) {

			letters = new string[64] {"-", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", 
				"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", 
				"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", " "};

			tempArray = new int[10] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0};

			highscoreObject.transform.Find("Highscore Text").GetComponent<TextMesh>().text = "NEW HIGHSCORE (" + totalTime + ")";
			highscoreObject.SetActive(true);

			chars[charCount].text = letters[letterCount];
			triangles[charCount].SetActive(true);
		}
		else {

			congratulationObject.SetActive(true);
		}



		StartCoroutine("BackToMenu");
	}

	
	// Update is called once per frame
	void Update () {

		/*if (Input.GetAxis("Vertical") != 0) {

			if (verticalUse == false) {

				if (Input.GetAxis("Vertical") < 0) {

					if (letterCount == 0) {

						letterCount = 63;
					}
					else {

						letterCount--;
					}

					verticalUse = true;
				}
				else {

					if (letterCount == 63) {

						letterCount = 0;
					}
					else {

						letterCount++;
					}

					verticalUse = true;
				}
			}
		}

		if (Input.GetAxis("Vertical") == 0) {

			verticalUse = false;
		}*/
	

		if (Input.GetAxis("CrossY") != 0) {

			if (crossYUse == false) {

				if (Input.GetAxis("CrossY") < 0) {

					if (letterCount == 0) {

						letterCount = 63;
					}
					else {

						letterCount--;
					}

					crossYUse = true;
				}
				else {

					if (letterCount == 63) {

						letterCount = 0;
					}
					else {

						letterCount++;
					}

					crossYUse = true;
				}
			}
		}

		if (Input.GetAxis("CrossY") == 0) {

			crossYUse = false;
		}

		/*if (Input.GetAxis("Horizontal") != 0) {

			if (horizontalUse == false) {

				if (Input.GetAxis("Horizontal") < 0) {

					if (charCount == 0) {

						charCount = chars.Length - 1;
						letterCount = 0;
					}
					else {

						charCount--;
						letterCount = 0;
					}

					horizontalUse = true;
				}
				else {

					if (charCount == chars.Length - 1) {

						charCount = 0;
						letterCount = 0;
					}
					else {

						charCount++;
						letterCount = 0;
					}

					horizontalUse = true;
				}
			}
		}

		if (Input.GetAxis("Horizontal") == 0) {

			horizontalUse = false;
		}
		*/
		
		if (Input.GetAxis("CrossX") != 0) {

			if (crossXUse == false) {

				if (Input.GetAxis("CrossX") < 0) {

					if (charCount == 0) {

						triangles[charCount].SetActive(false);
						tempArray[charCount] = letterCount;

						charCount = chars.Length - 1;

						if (tempArray[charCount] != 0) {

							letterCount = tempArray[charCount];
						}
						else {
						
							letterCount = 0;
						}
						
					}
					else {
					
						triangles[charCount].SetActive(false);
						tempArray[charCount] = letterCount;

						charCount--;

						if (tempArray[charCount] != 0) {

							letterCount = tempArray[charCount];
						}
						else {
						
							letterCount = 0;
						}
					}

					crossXUse = true;
				}
				else {

					if (charCount == chars.Length - 1) {
					
						triangles[charCount].SetActive(false);
						tempArray[charCount] = letterCount;

						charCount = 0;

						if (tempArray[charCount] != 0) {

							letterCount = tempArray[charCount];
						}
						else {
						
							letterCount = 0;
						}
					}
					else {
					
						triangles[charCount].SetActive(false);
						tempArray[charCount] = letterCount;

						charCount++;

						if (tempArray[charCount] != 0) {

							letterCount = tempArray[charCount];
						}
						else {
						
							letterCount = 0;
						}
					}

					crossXUse = true;
				}
			}
		}

		if (Input.GetAxis("CrossX") == 0) {

			crossXUse = false;
		}

		chars[charCount].text = letters[letterCount];
		triangles[charCount].SetActive(true);
	}

	IEnumerator BackToMenu() {

		m_Reticle.Show();

		m_Radial.Hide();

		yield return StartCoroutine(m_Fader.InteruptAndFadeIn());
		yield return StartCoroutine(m_Slider.WaitForBarToFill());
		yield return StartCoroutine(m_Fader.InteruptAndFadeOut());

		for (int i = 0; i < 10; i++) {

			if (tempArray[i] != 0) {

				highscoreName += letters[tempArray[i]];
			}				
		}

		highscoreName += chars[charCount].text;

		if (highscoreName == "Debug") {

			clearHighscore();
		}
		else {

			PlayerPrefs.SetInt("highscore" + highscorePostion, totalTime);
			PlayerPrefs.SetString("highscoreName" + highscorePostion, highscoreName);
		}
			
		SceneManager.LoadScene("Start Menu");

	}


	public void getHighscores(string key) {

		if (key == "list") {

			for (int i = 0; i < 5; i++) {

				if (PlayerPrefs.HasKey("highscore" + i) == true) {

					highscoreList.Add(PlayerPrefs.GetInt("highscore" + i));
				}
			}
		}
		else {

			highscores = new int[5];

			for (int i = 0; i < 5; i++) {

				if (PlayerPrefs.HasKey("highscore" + i)) {

					highscores[i] = PlayerPrefs.GetInt("highscore" + i);
				}
			}
		}


	}

	public void changeHighscores() {

		getHighscores("array");

		for (int i = 0; i < 5; i++) {

			if (totalTime <= highscores[i]) {

				isHighscore = true;
				highscorePostion = i;

				for (int j = 4; j > i; j--) {

					PlayerPrefs.SetInt("highscore" + j, PlayerPrefs.GetInt("highscore" + (j - 1)));
					PlayerPrefs.SetString("highscoreName" + j, PlayerPrefs.GetString("highscoreName" + (j - 1)));
				}

				break;
			}
		}
	}

	public void sortHighscore() {

		getHighscores("list");

		int sortCounter = 0;

		for (int i = 0; i < highscoreList.Count; i++) {

			if (totalTime <= highscoreList[i]) {

				highscorePostion = i;

				for (int j = highscoreList.Count; j > i; j--) {

					PlayerPrefs.SetInt("highscore" + j, PlayerPrefs.GetInt("highscore" + (j - 1)));
					PlayerPrefs.SetString("highscoreName" + j, PlayerPrefs.GetString("highscoreName" + (j - 1)));
				}

				break;
			}
			else {

				sortCounter++;
			}
		}

		if (sortCounter == highscoreList.Count) {

			highscorePostion = sortCounter;
		}
	}

	public void clearHighscore() {

		for (int i = 0; i < 5; i++) {

			if (PlayerPrefs.HasKey("highscore" + i) == true) {

				PlayerPrefs.DeleteKey("highscore" + i);
				PlayerPrefs.DeleteKey("highscoreName" + i);
			}
		}
	}
}