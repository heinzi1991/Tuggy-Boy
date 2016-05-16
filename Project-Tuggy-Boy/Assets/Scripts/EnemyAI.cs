using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	private GameObject target;
	private NavMeshAgent agent;
	private RaycastHit hit;

	void Awake() {

		agent = GetComponent<NavMeshAgent> ();
	}

	void Start() {

		target = GameObject.FindGameObjectWithTag("Player");
	}

	void Update() {

		agent.SetDestination(target.transform.position);


	}
}