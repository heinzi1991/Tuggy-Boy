using UnityEngine;
using System.Collections;

public class CreateWayPoint : MonoBehaviour {

	private bool cubeExist = false;
	private GameObject wayPoints;
	// Use this for initialization
	void Awake () {

		wayPoints = GameObject.Find("WayPoints");
	}



	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerExit(Collider other) {

		if(other.name == "OVRPlayerController") {

			if (cubeExist == false) {

				GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
				cube.transform.parent = wayPoints.transform;
				cube.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 0.16f, this.transform.position.z);
				cube.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
				cubeExist = true;
			}
		}
	}
}
