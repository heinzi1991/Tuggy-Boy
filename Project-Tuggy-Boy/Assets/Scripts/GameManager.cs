using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public Maze mazePrefab;
	public UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController playerPrefab;

	private Maze mazeInstance;
	private UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController playerInstance;





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
		playerInstance = Instantiate (playerPrefab) as UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController;
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
	}
}
