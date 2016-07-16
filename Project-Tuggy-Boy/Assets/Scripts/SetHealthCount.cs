using UnityEngine;
using System.Collections;

public class SetHealthCount : MonoBehaviour {

	public int healthCount;

	// Use this for initialization
	void Start () {
	
		PlayerPrefs.SetInt("HealthCount", healthCount);
	}

}
