using UnityEngine;

public class EnemyManager : MonoBehaviour {

	public GameObject enemy;
	public float spawnTime = 3f;
	public int[] counters;
	public Transform[] spawnPoints;

	private int[] enemyCounter;

	void Start() {

		enemyCounter = new int[counters.Length];
		InvokeRepeating("Spawn", spawnTime, spawnTime);
	}

	void Spawn() {

		int spawnPointIndex = Random.Range(0, spawnPoints.Length);

		if (counters[spawnPointIndex] == enemyCounter[spawnPointIndex]) {

			return;
		}

		Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);

		enemyCounter[spawnPointIndex] += 1;
	}
}
