using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class Minimap : MonoBehaviour
{
    private bool map_key_pressed = false;
    private bool map_enabled = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        map_key_pressed = Input.GetKeyDown(KeyCode.M);

        if (map_key_pressed)
        {
            map_enabled = !map_enabled;
        }

        //if (map_enabled)
        //{
        //    gameObject.SetActive(true);
        //}
        //else
        //{
        //    gameObject.SetActive(false);
        //}

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            gameObject.transform.Rotate(0, 0, 5);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            gameObject.transform.Rotate(0, 0, -5);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            gameObject.transform.Rotate(5, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            gameObject.transform.Rotate(-5, 0, 0);
        }
    }
}
