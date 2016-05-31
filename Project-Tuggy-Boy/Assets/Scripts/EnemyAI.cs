using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	private GameObject target;
	private NavMeshAgent agent;
	private RaycastHit hit;
	private GameObject[] escapePoints;

	private int index;

	void Awake() {

		agent = GetComponent<NavMeshAgent> ();
	}

	void Start() {

		target = GameObject.FindGameObjectWithTag("Player");
		escapePoints = GameObject.FindGameObjectsWithTag("Escape");

		index = Random.Range(0, escapePoints.Length);
	}

	void Update() {

		if (DestroyCollectObject.getPowerUp() == false) {

			agent.SetDestination(target.transform.position);
		}
		else {

			agent.SetDestination(escapePoints[index].transform.position);
		}
	}

	void OnTriggerEnter(Collider other) {

		if (other.name == "FPSController") {

			Debug.Log("I killed the player!");
		}
	}
}