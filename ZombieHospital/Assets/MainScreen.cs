using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScreen : MonoBehaviour {

    GameObject floorCam;
    GameObject menuCam;

    Camera mainCam;

    Boolean startText;
    public static Boolean onMenu;

    Rect startRect = new Rect(Screen.width - 1180, Screen.height - 435, 370, 70);
    Rect exitRect = new Rect(Screen.width - 1155, Screen.height - 350, 325, 70);

    // Use this for initialization
    void Start () {
        floorCam = GameObject.Find("FloorCamera");
        menuCam = GameObject.Find("TitleCam");
        mainCam = Camera.main;
        mainCam.transform.position = menuCam.transform.position;
        startText = true;
        onMenu = true;
    }
	
	// Update is called once per frame
	void Update () {
		if(mainCam.transform.position == menuCam.transform.position)
        {
            startText = true;
        }
	}

    void OnGUI()
    {
        if (startText)
        {
            GUI.backgroundColor = Color.clear;
            Time.timeScale = 1.0F;
            if (GUI.Button(startRect, " "))
            {
                mainCam.transform.position = floorCam.transform.position;
                startText = false;
                onMenu = false;
                LevelChange.setLevel(1);
                PlayerCharacter.setMaxHealth(10);
                PlayerCharacter.setHealth(10);
                PlayerCharacter.setAttack(2);
                PlayerCharacter.setDefense(0);
            }

            if(GUI.Button(exitRect, " "))
            {
                Application.Quit();
            }
        }
    }

}
