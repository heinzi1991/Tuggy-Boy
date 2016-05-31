using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GUIHealth : MonoBehaviour {

	//public Image heartImage;
	public GameObject heartImage;
	private static List<GameObject> heartList = new List<GameObject>();

	// Use this for initialization
	void Start () {

		int heartCount = GameManager.getHeartCount ();

		Debug.Log("HeartCount: " + heartCount);

		for (int i = 0; i < heartCount; i++) {

			GameObject newHeart = Instantiate(heartImage) as GameObject;
			newHeart.name = "heart" + i;
			newHeart.transform.position = new Vector3(-1.0f + 0.2f * i, -0.8f, 0.0f);
			newHeart.transform.SetParent(this.transform, false);
			heartList.Add(newHeart);
		}
		Debug.Log("Created Hearts");
	
	}
	
	// Update is called once per frame
	void Update () {

		if (heartList.Count == 0) {

			Time.timeScale = 0;
			Debug.Log("ITS GAME OVER");
		}
	}

	public static int getLifes () {

		return heartList.Count;
	}
		
}
