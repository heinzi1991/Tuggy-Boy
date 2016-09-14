using UnityEngine;
using System.Collections;

public class SetHealthCount : MonoBehaviour {

	public int healthCount;

	// Use this for initialization
	void Start () {
	
		PlayerPrefs.SetInt("HealthCount", healthCount);
		PlayerPrefs.SetInt("Time0", 0);
		PlayerPrefs.SetInt("Time1", 0);
		PlayerPrefs.SetInt("Time2", 0);
		PlayerPrefs.SetInt("Time3", 0);
		PlayerPrefs.SetInt("Time4", 0);
		PlayerPrefs.SetInt("Time5", 0);

	}

}
