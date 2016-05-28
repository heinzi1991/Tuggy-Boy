using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {


	public GameObject gui;
	public EnemyManager enemyManager;
	public int collectCount;
	public GameObject player;

	private Text collectCounText;
	private Image[] hearts;

	void Awake() {
		
		collectCounText = gui.GetComponentInChildren<Text>();
		hearts = gui.GetComponentsInChildren<Image>();
	}
		
	// Use this for initialization
	void Start () {

		collectCounText.text = "-- / " + collectCount;

	}
	
	// Update is called once per frame
	void Update () {

		collectCounText.text = DestroyCollectObject.getDestroy () + " / " + collectCount;

		if (DestroyCollectObject.getDestroy() == collectCount) {

			SceneManager.LoadScene ("Start Menu");
		}

	}
}
