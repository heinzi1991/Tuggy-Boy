using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {


	public GameObject gui;
	public EnemyManager enemyManager;
	public int collectCount;
	public GameObject player;

<<<<<<< HEAD
	private Text guiText;
	private Image[] hearts;

	void Awake() {
		
		guiText = gui.GetComponentInChildren<Text>();
		hearts = gui.GetComponentsInChildren<Image>();
	}


	// Use this for initialization
	void Start () {

		//Debug.Log(hearts);

		guiText.text = "-- / " + collectCount;
=======
  private Text collectCounText;

	// Use this for initialization
	void Start () {
	
		collectCounText = gui.GetComponentInChildren<Text>();
		collectCounText.text = "-- / " + collectCount;
>>>>>>> origin/master

	}
	
	// Update is called once per frame
	void Update () {

		collectCounText.text = DestroyCollectObject.getDestroy () + " / " + collectCount;

		if (DestroyCollectObject.getDestroy() == collectCount) {

			SceneManager.LoadScene ("Start Menu");
		}

	}
}
