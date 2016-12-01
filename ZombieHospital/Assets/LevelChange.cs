using UnityEngine;
using System.Collections;

public class LevelChange : MonoBehaviour {
    GameObject player;
    GameObject level;
    GameObject level2;
    GameObject level2Cam;

    Camera levelCam;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Doug");
        level = GameObject.Find("EnterFloor2");
        level2 = GameObject.Find("EnterFloor1");
        level2Cam = GameObject.Find("Floor2Camera");
        levelCam = Camera.current;
    }
	
    void OnTrigger2DEnter(Collider2D hit)
    {
        print(hit.gameObject.tag);
        print(level2.gameObject.tag);
        if (hit.gameObject.tag == level2.gameObject.tag)
        {
           
            player.transform.position = level.transform.position;
            levelCam.transform.position = level2Cam.transform.position;
        }

        if (hit.gameObject.tag == "EnterFloor2")
        {
            player.transform.position = level2.transform.position;
        }
    }

	// Update is called once per frame
	void Update () {
	
	}
}
