using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {


	public GameObject gui;
	public EnemyManager enemyManager;
	public int collectCount;
	public GameObject player;
	public int healthCount;
	public GameObject heartImage;

	private Text collectCounText;

	void Awake() {

		collectCounText = gui.GetComponentInChildren<Text>();
	}
		
	// Use this for initialization
	void Start () {
		
		collectCounText.text = "-- / " + collectCount;

		for (int i = 0; i < healthCount; i++) {

			GameObject newHeart = Instantiate(heartImage) as GameObject;
			newHeart.name = "Heart_" + i;
			newHeart.transform.position = new Vector3(-1.0f + 0.2f * i, -0.8f, 0.0f);
			newHeart.transform.SetParent(gui.transform, false);
		}
	}
	
	// Update is called once per frame
	void Update () {

		collectCounText.text = DestroyCollectObject.getDestroy () + " / " + collectCount;

		if (DestroyCollectObject.getDestroy() == collectCount) {

			SceneManager.LoadScene ("Start Menu");
		}

		if (healthCount == 0) {

			SceneManager.LoadScene("GameOverScene");
		}
	}

	public void DestroyHeart() {

		Destroy(GameObject.Find("Heart_" + (healthCount - 1)));
		healthCount--;
	}
}