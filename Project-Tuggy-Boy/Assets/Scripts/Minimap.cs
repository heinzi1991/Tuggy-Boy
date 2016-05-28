using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class Minimap : MonoBehaviour
{
    public GameObject map;
    private Vector3 map_player_position;
    private Vector3 global_player_position;

	// Use this for initialization
	void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
        // Toggle visibility of the map
        if (Input.GetKey(KeyCode.M))
        {
            map.SetActive(true);
        }
        else
        {
            map.SetActive(false);
        }

        gameObject.GetComponentInParent<Transform>

    }
}
