using UnityEngine;
using System.Collections;

public class GodModeManager : MonoBehaviour {

	private string godMode = "GODMODE";

	private int counter = 0;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (PlayerPrefs.GetInt("godModeActive") == 0) {

			if (counter == 7) {

				PlayerPrefs.SetInt("godModeActive", 1);
			}
		} 
			
		foreach(KeyCode vKey in System.Enum.GetValues(typeof(KeyCode))) {

			if (Input.GetKey(vKey)) {

				if (counter != 7) {

					if (godMode[counter].ToString() == vKey.ToString()) {

						counter++;
					}
				}
			}
		}
	
	}
}
