using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class Minimap : MonoBehaviour
{
  public GameObject minimap;
  public GameObject map;
  public GameObject miniPlayer;
  private Vector3 player_position_map;
  private Vector3 player_position_global;

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
      minimap.SetActive(true);
      miniPlayer.SetActive(true);
    }
    else
    {
      minimap.SetActive(false);
      miniPlayer.SetActive(false);
    }

    player_position_global = gameObject.transform.parent.transform.position;

    Vector3 player_position_diff = map.transform.position - player_position_global;

    miniPlayer.transform.localPosition = -player_position_diff;
  }
}
