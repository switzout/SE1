using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScreen : MonoBehaviour {

    GameObject floorCam;
    Camera mainCam;

    Boolean startText;

    Rect startRect = new Rect(Screen.width - 1180, Screen.height - 435, 370, 70);
    Rect exitRect = new Rect(Screen.width - 1155, Screen.height - 350, 325, 70);
    // Use this for initialization
    void Start () {
        floorCam = GameObject.Find("FloorCamera");
        mainCam = Camera.main;

        startText = true;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnGUI()
    {
        if (startText)
        {
            GUI.backgroundColor = Color.clear;
            if (GUI.Button(startRect, " "))
            {
                mainCam.transform.position = floorCam.transform.position;
                startText = false;
            }
            if(GUI.Button(exitRect, " "))
            {
                Application.Quit();
            }
        }
    }

}
