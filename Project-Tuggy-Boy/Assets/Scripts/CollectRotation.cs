using UnityEngine;
using System.Collections;

public class CollectRotation : MonoBehaviour {

	private float angle;
	private float speed = 3.0f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (gameObject.tag == "PowerUp") {

			angle += 25 * Time.deltaTime * speed;
			transform.eulerAngles = new Vector3(30, angle, 0);
		}
		else {

			angle += 25 * Time.deltaTime * speed;
			transform.eulerAngles = new Vector3(0, angle, 0);
		}


	}
}
