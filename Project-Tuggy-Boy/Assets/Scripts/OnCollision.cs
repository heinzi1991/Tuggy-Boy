using UnityEngine;
using System.Collections;

public class OnCollision : MonoBehaviour {

	void OnCollisionEnter(Collision col) {

		Debug.Log ("Enter called");
	}

	void OnCollisionStay(Collision col) {

		Debug.Log ("Stay occuring..");
	}

	void OnCollisionExit(Collision col) {

		Debug.Log ("Exit called");
	}
}
