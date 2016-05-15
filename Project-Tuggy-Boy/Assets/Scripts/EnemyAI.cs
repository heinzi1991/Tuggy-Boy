using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	public Transform target;

	private NavMeshAgent agent;

	void Start() {

		agent = gameObject.GetComponent<NavMeshAgent> ();
		agent.SetDestination(target.position);
	}
}