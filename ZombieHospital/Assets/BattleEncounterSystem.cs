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
    GameObject miniBoss;
    GameObject mainBoss;
    GameObject battleCam;
    GameObject gunBattleCam;
    GameObject miniBossCam;
    GameObject gunMiniBossCam;
    GameObject bossCam;
    GameObject gunBossCam;
    Camera[] cams = new Camera[2];
    Vector2 initPos;
    Vector2 nextPos;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Doug");
        miniBoss = GameObject.Find("MiniBoss");
        mainBoss = GameObject.Find("Boss");
        battleCam = GameObject.Find("BattleScene1Cam");
        gunBattleCam = GameObject.Find("GunBattleCam");
        miniBossCam = GameObject.Find("MiniBossCam");
        bossCam = GameObject.Find("BossCam");
        gunBossCam = GameObject.Find("GunBossCam");
        counter = 0;
        battle = new System.Random();
        encounter = battle.Next(20, 50);
        initPos = player.transform.position;
        Camera.GetAllCameras(cams);
        print(cams[0].tag);
        print(cams[1].tag);
        cams[1].enabled = false;
        cams[0].depth = Camera.main.depth + 1;
    }

    void FixedUpdate()
    {

    }

    void OnTriggerEnter2D(Collider2D hit)
    {
        if(hit.gameObject == miniBoss.gameObject)
        {
            cams[0].enabled = false;
            cams[1].enabled = true;
            cams[1].transform.position = miniBossCam.transform.position;
            cams[1].depth = Camera.main.depth + 1;
            counter = 0;
        }

        if (hit.gameObject == mainBoss.gameObject)
        {
            if (PlayerCharacter.getItem())
            {
                cams[0].enabled = false;
                cams[1].enabled = true;
                cams[1].transform.position = gunBossCam.transform.position;
                cams[1].depth = Camera.main.depth + 1;
                counter = 0;
            }
            else
            {
                cams[0].enabled = false;
                cams[1].enabled = true;
                cams[1].transform.position = bossCam.transform.position;
                cams[1].depth = Camera.main.depth + 1;
                counter = 0;
            }
        }
    }

	void LateUpdate () {
        nextPos = player.transform.position;

        if(initPos != nextPos)
        {
            counter++;
        }

        if (cams[0].isActiveAndEnabled)
        {
            if (counter >= encounter)
            {
                counter = 0;
                if (PlayerCharacter.getItem())
                {
                    cams[0].enabled = false;
                    cams[1].enabled = true;
                    cams[1].transform.position = gunBattleCam.transform.position;
                    cams[1].depth = Camera.main.depth + 1;
                    encounter = battle.Next(20, 50);
                }
                else
                {
                    cams[0].enabled = false;
                    cams[1].enabled = true;
                    cams[1].transform.position = battleCam.transform.position;
                    cams[1].depth = Camera.main.depth + 1;
                    encounter = battle.Next(20, 50);
                }
            }
        }
        initPos = player.transform.position;
	}
}
