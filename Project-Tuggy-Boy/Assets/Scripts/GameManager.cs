using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public Maze mazePrefab;
	public LoadScript loadScript;
	public UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController playerPrefab;

	private Maze mazeInstance;
	private UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController playerInstance;

	private int cellLoad = 0;





	private void Start () {
		StartCoroutine(BeginGame());

		loadScript.loadScore = cellLoad;

	}
	
	private void Update () {
		if(Input.GetKeyDown(KeyCode.Space)) {
			RestartGame();
		}

		loadScript.loadScore = cellLoad;
	}

	private IEnumerator BeginGame() {
		//Camera.main.rect = new Rect (0f, 0f, 1f, 1f);
		mazeInstance = Instantiate(mazePrefab) as Maze;
		yield return StartCoroutine (mazeInstance.Generate ());
		playerInstance = Instantiate (playerPrefab) as UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController;
		playerInstance.SetLocation (mazeInstance.GetCell (mazeInstance.RandomCoordinates));
		Camera.main.enabled = false;
		//Camera.main.clearFlags = CameraClearFlags.Depth;
		//Camera.main.rect = new Rect (0f, 0f, 0.5f, 0.5f);
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
