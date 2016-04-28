using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadScript : MonoBehaviour {

	Text text;
	public int loadScore;

	// Use this for initialization
	void Start () {

		text = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {

		text.text = loadScore + " %";
	
	}
}
