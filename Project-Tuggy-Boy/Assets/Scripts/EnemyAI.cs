using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	private GameObject target;
	private NavMeshAgent agent;
	private RaycastHit hit;
	private GameObject[] escapePoints;
	private Vector3 spawnPoint;

	private GameManager gameManager;

	private int index;

	void Awake() {

		agent = GetComponent<NavMeshAgent> ();
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}

	void Start() {

		spawnPoint = this.transform.position;
		Debug.Log("spawnPoint: " + spawnPoint);
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

			GetToStartPosition();
			//Debug.Log("I killed the player!");
		}
		//killTarget = false;
	}

	void GetToStartPosition () {

		this.transform.position = spawnPoint;
		gameManager.DestroyHeart();
	}

}