using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class Vibration : MonoBehaviour {

	// Use this for initialization
	IEnumerator Start () {

		GamePad.SetVibration(0, 1.0f, 1.0f);

		yield return new WaitForSeconds(3);

		GamePad.SetVibration(0, 0.0f, 0.0f);
		Destroy(this.gameObject);
	}
}
