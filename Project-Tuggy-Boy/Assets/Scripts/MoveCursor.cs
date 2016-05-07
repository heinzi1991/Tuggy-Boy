using UnityEngine;
using System.Collections;

public class MoveCursor : MonoBehaviour {

	public string HorizontalAxe;
	public string VerticalAxe;
	float cursor_speed = 0.3f;
	Light ActivationLight;
	public string SubmitButton;
	float warp_lag = 0.5f;
	GameObject main_cam;
	int AxeOrientation = 1;
	float changeLifeLag = 0.1f;
	bool can_change_life = true;
	public AudioSource ToAndBack;
	public AudioSource piep;

	// Use this for initialization
	void Start () {

		Cursor.visible = false;
		//ActivationLight = GameObject.FindGameObjectWithTag("ActivationLight").GetComponent<Light>();
		main_cam = GameObject.FindGameObjectWithTag("MainCamera");

	}

	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit ();
		}

	}

	void FixedUpdate()
	{
		if(Input.GetAxis(HorizontalAxe) != 0)
			GetComponent<Rigidbody>().AddForce(new Vector2(1, 0) * cursor_speed * AxeOrientation * Input.GetAxis(HorizontalAxe) / Time.deltaTime);
		if(Input.GetAxis(VerticalAxe) != 0)
			GetComponent<Rigidbody>().AddForce(new Vector2(0, 1) * cursor_speed * AxeOrientation * Input.GetAxis(VerticalAxe) / Time.deltaTime);

		if(Input.GetAxis(HorizontalAxe) == 0 && Input.GetAxis(VerticalAxe) == 0)
			GetComponent<Rigidbody>().velocity = Vector2.zero;
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		ActivationLight.enabled = true;
	}
	void OnTriggerExit2D(Collider2D coll)
	{
		ActivationLight.enabled = false;
	}

	void OnTriggerStay2D(Collider2D coll)
	{
		if(Input.GetButton(SubmitButton))
		{
			if(coll.gameObject.tag == "DuelButton")
			{
				PlayerPrefs.SetInt("Multiplayer", 1);
				PlayerPrefs.SetInt("Singleplayer", 0);
				Invoke ("warpToGame", warp_lag);
				ToAndBack.Play();
			}
			else if(coll.gameObject.tag == "StartGame")
			{
				PlayerPrefs.SetInt("Multiplayer", 0);
				PlayerPrefs.SetInt("Singleplayer", 1);
				Invoke ("warpToSingleGame", warp_lag);
				ToAndBack.Play();
			}
			else if(coll.gameObject.tag == "GameOptions")
			{
				main_cam.GetComponent<Animator>().SetTrigger("MenuToGameOptions");
				this.transform.position = GameObject.FindGameObjectWithTag("GameOptionsPosition").transform.position;
				GetComponent<Animator>().SetTrigger("options");
				AxeOrientation = -1;
				ToAndBack.Play ();
			}
			else if(coll.gameObject.tag == "GameOptionsToMenu")
			{
				main_cam.GetComponent<Animator>().SetTrigger("GameOptionsToMenu");
				this.transform.position = GameObject.FindGameObjectWithTag("MainMenuPosition").transform.position;
				GetComponent<Animator>().SetTrigger("menu");
				AxeOrientation = 1;
				ToAndBack.Play();
			}
			else if(coll.gameObject.tag == "QuitButton")
				Application.Quit ();
		}
	}

	void resetChangeLife(){can_change_life = true;}

	void warpToGame()
	{
		// Maybe depended on what level chosen
		Application.LoadLevel(PlayerPrefs.GetString("PlayerScene"));
	}

	void warpToSingleGame()
	{
		Application.LoadLevel("Arena_sp_circle");
	}
}
