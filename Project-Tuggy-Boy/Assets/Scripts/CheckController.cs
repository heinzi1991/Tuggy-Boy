using UnityEngine;
using System.Collections;

public class CheckController : MonoBehaviour {

	// Use this for initialization
	void Start () {

		if (Input.GetJoystickNames().Length == 0) {

			Debug.Log ("No Controller");
			//WaitForSeconds (10);
			Application.Quit();
		}
	
	}
	
	// Update is called once per frame
	/*void Update () {


		if (Input.GetJoystickNames().Length == 0) {

			Debug.Log("Please plug your Controller again.");
		}
	
	}*/
}
