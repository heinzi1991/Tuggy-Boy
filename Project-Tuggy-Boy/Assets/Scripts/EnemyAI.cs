using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	private GameObject target;
	private NavMeshAgent agent;
	private RaycastHit hit;
	private GameObject[] escapePoints;

	private GameManager gameManager;
	private EnemyManager enemyManager;
	private CameraShake screenShake;
	private DestroyCollectObject destroyObject;

	private Vector3 targetPoint;
	private Quaternion targetRotation;


	private int index;

	void Awake() {

		agent = GetComponent<NavMeshAgent> ();
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
		screenShake = GameObject.Find("FPSController").GetComponentInChildren<CameraShake>();
		destroyObject = GameObject.Find("FPSController").GetComponent<DestroyCollectObject>();
	}

	void Start() {

		target = GameObject.FindGameObjectWithTag("Player");
		escapePoints = GameObject.FindGameObjectsWithTag("Escape");

		index = Random.Range(0, escapePoints.Length);
	}

	void Update() {

		targetPoint = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z) - transform.position;
		targetRotation = Quaternion.LookRotation(-targetPoint, Vector3.up);
		transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime);

		if (destroyObject.getPowerUp() == false && destroyObject.getSaveMode() == false) {

			agent.SetDestination(target.transform.position);
		}
		else {

			agent.SetDestination(escapePoints[index].transform.position);
		}
	}

	void OnTriggerEnter(Collider other) {

		if (other.name == "FPSController") {
		
			gameManager.DestroyHeart();

			int index = this.name.IndexOf("_");
			string count = this.name.Substring(index + 1, 1);
			int spawnIndex = int.Parse(count);

			enemyManager.Decrement(spawnIndex);

			screenShake.LongShake(0.5f);

			Destroy(this.gameObject);
		}

	}
}