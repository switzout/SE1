using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using System.Collections;

public class BattleEncounterSystem : MonoBehaviour {

    //string level = "battleScene";
    int counter;
    int encounter;
    static System.Random battle;
    GameObject player;
    Camera[] cams = new Camera[2];
    Vector2 initPos;
    Vector2 nextPos;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Doug");
        counter = 0;
        battle = new System.Random();
        encounter = battle.Next(10, 20);
        initPos = player.transform.position;
        Camera.GetAllCameras(cams);
        print(cams[0].tag);
        print(cams[1].tag);
        cams[1].enabled = false;
        cams[0].depth = Camera.main.depth + 1;
    }
	
    void Update()
    {

    }

    void FixedUpdate()
    {

    }

	void LateUpdate () {
        nextPos = player.transform.position;
       
      //  encounter = battle.Next(6, 20);
        

        if(initPos != nextPos)
        {
            counter++;
        }

        if (counter >= encounter)
        {
            counter = 0;
            cams[0].enabled = false;
            cams[1].enabled = true;
            cams[1].depth = Camera.main.depth + 1;
            encounter = battle.Next(5, 20);
        }
        initPos = player.transform.position;
	}
}
