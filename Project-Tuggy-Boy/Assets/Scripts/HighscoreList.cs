using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighscoreList : MonoBehaviour {

	public GameObject highscoreEntry;

	// Use this for initialization
	void Start () {

		int totalSeconds = 0;
		int seconds = 0;
		int minutes = 0;

		for (int i = 0; i < 5; i++) {

			if (PlayerPrefs.HasKey("highscore" + i) == true) {

				GameObject go = (GameObject)Instantiate(highscoreEntry);
				go.transform.SetParent(this.transform, false);
				go.transform.Find("Place").GetComponent<Text>().text = (i + 1).ToString();
				//go.transform.Find("Score").GetComponent<Text>().text = PlayerPrefs.GetInt("highscore" + i).ToString();

				totalSeconds = PlayerPrefs.GetInt("highscore" + i);

				seconds = totalSeconds % 60;
				minutes = totalSeconds / 60;

				if (minutes < 10) {

					go.transform.Find("Score").GetComponent<Text>().text = "0" + minutes.ToString() + " min " + seconds.ToString() + " sec";
				}
				else {

					go.transform.Find("Score").GetComponent<Text>().text = minutes.ToString() + " min " + seconds.ToString() + " sec";
				}



				go.transform.Find("Name").GetComponent<Text>().text = PlayerPrefs.GetString("highscoreName" + i);

			}
			else {
				
				GameObject go = (GameObject)Instantiate(highscoreEntry);
				go.transform.SetParent(this.transform, false);
				go.transform.Find("Place").GetComponent<Text>().text = (i + 1).ToString();
				go.transform.Find("Score").GetComponent<Text>().text = "";
				go.transform.Find("Name").GetComponent<Text>().text = "";
			}
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
