using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighscoreList : MonoBehaviour {

	public GameObject highscoreEntry;

	// Use this for initialization
	void Start () {

		for (int i = 0; i < 5; i++) {

			if (PlayerPrefs.HasKey("highscore" + i) == true) {

				GameObject go = (GameObject)Instantiate(highscoreEntry);
				go.transform.SetParent(this.transform, false);
				go.transform.Find("Place").GetComponent<Text>().text = (i + 1).ToString();
				go.transform.Find("Score").GetComponent<Text>().text = PlayerPrefs.GetInt("highscore" + i).ToString();
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
