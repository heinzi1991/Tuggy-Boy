using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public Maze mazePrefab;
	public UnityStandardAssets.Characters.FirstPerson.FirstPersonController playerPrefab;

	private Maze mazeInstance;
	private UnityStandardAssets.Characters.FirstPerson.FirstPersonController playerInstance;





	private void Start () {
		StartCoroutine(BeginGame());
	}
	
	private void Update () {
		if(Input.GetKeyDown(KeyCode.Space)) {
			RestartGame();
		}
	}

	private IEnumerator BeginGame() {
		mazeInstance = Instantiate(mazePrefab) as Maze;
		yield return StartCoroutine (mazeInstance.Generate ());
		playerInstance = Instantiate (playerPrefab) as UnityStandardAssets.Characters.FirstPerson.FirstPersonController;
		playerInstance.SetLocation (mazeInstance.GetCell (mazeInstance.RandomCoordinates));
		Camera.main.enabled = false;
	}

	private void RestartGame() {
		StopAllCoroutines ();
		Destroy(mazeInstance.gameObject);

		if(playerInstance != null) {

			Destroy (playerInstance.gameObject);
		}
		Camera.main.enabled = true;
		StartCoroutine(BeginGame());
		//BeginGame ();
	}
}
