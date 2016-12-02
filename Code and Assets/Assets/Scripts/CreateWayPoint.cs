using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

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

                string footprint_prefab = "footprint_black";

                // Tutorial Level
                if (SceneManager.GetActiveScene().buildIndex == 2)
                {
                    footprint_prefab = "footprint_green";
                }

                GameObject print = Instantiate(Resources.Load(footprint_prefab)) as GameObject;
                //GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                print.transform.parent = wayPoints.transform;
                print.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 0.26f, this.transform.position.z);
                print.transform.Rotate(0, 0, -other.transform.eulerAngles.y);
                //print.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
				cubeExist = true;
			}
		}
	}
}
