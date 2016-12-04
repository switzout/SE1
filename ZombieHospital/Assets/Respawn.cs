using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

    GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Doug");
	}
	
	// Update is called once per frame
	void Update () {
		if(PlayerCharacter.getHealth() <= 0)
        {
            player.transform.position = this.transform.position;
            PlayerCharacter.setHealth(10);
        }
	}
}
