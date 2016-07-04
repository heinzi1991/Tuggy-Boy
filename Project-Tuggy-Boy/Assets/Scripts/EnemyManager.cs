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

		//Debug.Log("EnemyCounterLength: " + enemyCounter.Length);

		int spawnPointIndex = Random.Range(0, spawnPoints.Length);

		if (counters[spawnPointIndex] == enemyCounter[spawnPointIndex]) {

			return;
		}

		GameObject newEnemy = (GameObject)Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
		newEnemy.name = "Enemy_" + spawnPointIndex;

		enemyCounter[spawnPointIndex] += 1;
	}

	public void Decrement(int spawnIndex) {

		enemyCounter[spawnIndex] -= 1;
	}
		

}
