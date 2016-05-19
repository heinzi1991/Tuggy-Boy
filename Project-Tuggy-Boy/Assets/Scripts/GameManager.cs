using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {


	public GameObject gui;
	public EnemyManager enemyManager;
	public int collectCount;
	public GameObject player;

	private Text guiText;


	// Use this for initialization
	void Start () {
	
		guiText = gui.GetComponentInChildren<Text>();
		guiText.text = "-- / " + collectCount;

	}
	
	// Update is called once per frame
	void Update () {

		guiText.text = DestroyCollectObject.getDestroy () + " / " + collectCount;

		if (DestroyCollectObject.getDestroy() == collectCount) {

			SceneManager.LoadScene ("Start Menu");
		}

	}
}
