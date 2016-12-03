using UnityEngine;
using System;
using System.Collections;

public class LevelChange : MonoBehaviour {
    GameObject player;
    GameObject level1;
    GameObject level2Enter;
    GameObject level3Enter;
    GameObject level4Enter;
    GameObject level2Exit;
    GameObject level3Exit;
    GameObject level4Exit;
    GameObject level1Cam;
    GameObject level2Cam;
    GameObject level3Cam;
    GameObject level4Cam;

    Camera levelCam;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Doug");
        level1 = GameObject.Find("ExitFloor1");
        level2Enter = GameObject.Find("EnterFloor2");
        level3Enter = GameObject.Find("EnterFloor3");
        level4Enter = GameObject.Find("EnterFloor4");
        level2Exit = GameObject.Find("ExitFloor2");
        level3Exit = GameObject.Find("ExitFloor3");
        level4Exit = GameObject.Find("ExitFloor4");
    
        levelCam = Camera.main;
        level1Cam = GameObject.Find("FloorCamera");
        level2Cam = GameObject.Find("Floor2Camera");
        level3Cam = GameObject.Find("Floor3Camera");
        level4Cam = GameObject.Find("Floor4Camera");
    }
	
    void OnTriggerEnter2D(Collider2D hit)
    {
        if(hit.gameObject == level1.gameObject)
        {
            player.transform.position = level2Enter.transform.position;
            Camera.main.transform.position = level2Cam.transform.position;
        }
        
        if(hit.gameObject == level2Enter.gameObject)
        {
            player.transform.position = level1.transform.position;
            Camera.main.transform.position = level1Cam.transform.position;
        }

        if (hit.gameObject == level3Enter.gameObject)
        {
            player.transform.position = level2Exit.transform.position;
            Camera.main.transform.position = level2Cam.transform.position;
        } 

        if (hit.gameObject == level2Exit.gameObject)
        {
            player.transform.position = level3Enter.transform.position;
            Camera.main.transform.position = level3Cam.transform.position;
        }
        
        if(hit.gameObject == level3Exit.gameObject)
        {
            player.transform.position = level4Enter.transform.position;
            Camera.main.transform.position = level4Cam.transform.position;
        }

        if(hit.gameObject == level4Enter.gameObject)
        {
            player.transform.position = level3Exit.transform.position;
            Camera.main.transform.position = level3Cam.transform.position;
        }
    }

	// Update is called once per frame
	void Update () {
	
	}
}
