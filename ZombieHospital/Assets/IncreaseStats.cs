using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseStats : MonoBehaviour {

    readonly int maxPoints = 4;
    int points;

    string textPoints = "";
    string health = "";
    string attack = "";
    string defense = "";

    GameObject statsCam;
    GameObject[] levels;
    GameObject level1Cam;
    GameObject level2Cam;
    GameObject level3Cam;
    GameObject level4Cam;

    Rect pointsRect = new Rect(Screen.width - 500, Screen.height - 745, 60, 60);
    Rect attackStatRect = new Rect(Screen.width - 775, Screen.height - 470, 200, 70);
    Rect healthStatRect = new Rect(Screen.width - 775, Screen.height - 625, 200, 70);
    Rect defStatRect = new Rect(Screen.width - 775, Screen.height - 320, 200, 70);
    Rect attackRect = new Rect(Screen.width - 690, Screen.height - 480, 100, 90);
    Rect healthRect = new Rect(Screen.width - 690, Screen.height - 630, 100, 90);
    Rect defRect = new Rect(Screen.width - 690, Screen.height - 330, 100, 90);

    // Use this for initialization
    void Start () {
        points = 0;
        statsCam = GameObject.Find("StatsCam");
        levels = new GameObject[]
        {
            GameObject.Find("FloorCamera"),
            GameObject.Find("Floor2Camera"),
            GameObject.Find("Floor3Camera"),
            GameObject.Find("Floor4Camera")};
    }
	
	// Update is called once per frame
	void Update () {
        if (guiBattle.wonBattle)
        {
            Camera.main.transform.position = statsCam.transform.position;
            points = maxPoints;
            textPoints = "" + points;
            health = "" + PlayerCharacter.getMaxHealth();
            attack = "" + PlayerCharacter.getAttack();
            defense = "" + PlayerCharacter.getDefense();
            guiBattle.wonBattle = false;
        }

        if(points <= 0 && !MainScreen.onMenu)
        {
           // print(LevelChange.getLevel() - 1);
            Camera.main.transform.position = levels[LevelChange.getLevel() - 1].transform.position;
        }
	}

    void OnGUI()
    {
        GUIStyle HUDStyle = new GUIStyle(GUI.skin.label);
        HUDStyle.normal.textColor = Color.white;
        HUDStyle.fontSize = 60;

        GUIStyle buttonStyle = new GUIStyle(GUI.skin.button);
        buttonStyle.normal.textColor = Color.white;
        buttonStyle.fontSize = 18;

        if (points > 0)
        {
            GUI.Label(pointsRect, textPoints, HUDStyle);
            GUI.Label(healthStatRect, health, HUDStyle);
            GUI.Label(attackStatRect, attack, HUDStyle);
            GUI.Label(defStatRect, defense, HUDStyle);

            if (GUI.Button(healthRect, "+", buttonStyle))
            {
                PlayerCharacter.setMaxHealth((PlayerCharacter.getMaxHealth() + 1));
                PlayerCharacter.setHealth(PlayerCharacter.getMaxHealth());
                health = "" + PlayerCharacter.getMaxHealth();
                points--;
                textPoints = "" + points;
            }
            if (GUI.Button(attackRect, "+", buttonStyle))
            {
                PlayerCharacter.setAttack(PlayerCharacter.getAttack() + 1);
                attack = "" + PlayerCharacter.getAttack();
                points--;
                textPoints = "" + points;
            }
            if (GUI.Button(defRect, "+", buttonStyle))
            {
                PlayerCharacter.setDefense(PlayerCharacter.getDefense() + 1);
                defense = "" + PlayerCharacter.getDefense();
                points--;
                textPoints = "" + points;
            }
        }
    }
}
