﻿using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class Minimap : MonoBehaviour
{
 	public GameObject[] mini_map_floors;
  	public GameObject map_first_floor;
  	public GameObject miniPlayer;
  	private Vector3 player_position_map;
  	private Vector3 player_position_global;
    private int frames = 0;
    private int mini_floor_index = 0;


    // Use this for initialization
    void Start () {

  	}
	
	// Update is called once per frame
	void Update ()
    {

        foreach (GameObject floor in mini_map_floors)
        {
          floor.SetActive(false);
        }
        miniPlayer.SetActive(false);

        frames++;

        if (frames % 10 == 0)
        {
            //player_position_global = player.transform.position;
            player_position_global = gameObject.transform.parent.transform.position;

            Vector3 player_position_diff = map_first_floor.transform.position - player_position_global;

            miniPlayer.transform.localPosition = new Vector3(-player_position_diff.x, 0.5f, -player_position_diff.z);

            // Selet right minimap
            mini_floor_index = Mathf.FloorToInt(player_position_global.y / 3f);
        }

        // Toggle visibility of the map
	    if (CrossPlatformInputManager.GetButton("Minimap") && mini_floor_index < mini_map_floors.Length)
        {
          mini_map_floors[mini_floor_index].SetActive(true);
          miniPlayer.SetActive(true);
        }


  }
}
