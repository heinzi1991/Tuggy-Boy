using UnityEngine;
using System.Collections;

public class CreateWayPoint : MonoBehaviour {

	private bool cubeExist = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerExit(Collider other) {

		if(other.name == "FPSController") {

			if (cubeExist == false) {

				GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
				cube.transform.position = new Vector3(this.transform.position.x, 0.16f, this.transform.position.z);
				cube.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
				cubeExist = true;
			}
		}
	}
}
