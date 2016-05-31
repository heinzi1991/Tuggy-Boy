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

	private Text collectCounText;
	private static int heartCount;

	private int tempHealthCount;

	void Awake() {

		heartCount = healthCount;
		tempHealthCount = healthCount;
		collectCounText = gui.GetComponentInChildren<Text>();
	}
		
	// Use this for initialization
	void Start () {
		
		collectCounText.text = "-- / " + collectCount;
	}
	
	// Update is called once per frame
	void Update () {

		collectCounText.text = DestroyCollectObject.getDestroy () + " / " + collectCount;


		/*if (healthCount > GUIHealth.getLifes()) {

			GameObject.Find("Enemy(Clone)").transform.position = new Vector3(28.84f, 1.27f, 19.07f);
		}*/


		if (DestroyCollectObject.getDestroy() == collectCount) {

			SceneManager.LoadScene ("Start Menu");
		}
	}

	public static int getHeartCount () {

		return heartCount;
	} 
}