using System;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;


class guiBattle : MonoBehaviour
{

    String enemyHealth = "";
    String pcHealth = "";
    String[] battleText = new String[3];

    Boolean showText = true;
    Boolean isBattling = true;
    Boolean playerAttack = false;
    Boolean enemyAttack = false;

    int damage;
    int newHealth;
    int index;

    Rect enemyRect = new Rect(Screen.width - 420, 20, 120, 50);
    Rect pcRect = new Rect(400, Screen.height - 50, 120, 70);
    Rect attackTextRect = new Rect(Screen.width - 550, Screen.height - 100, 200, 100);
    Rect attackRect = new Rect(Screen.width - 325, Screen.height - 125, 100, 75);
    Rect fleeRect = new Rect(Screen.width - 200, Screen.height - 125, 100, 75);
    Texture2D texture = new Texture2D(100, 100);
    Camera[] cams = new Camera[2];

    public void AttackMonster()
    {
        if (Monster.getHealth() > 0)
        {
            if (PlayerCharacter.getAttack() > Monster.getDefense())
            {
                damage = PlayerCharacter.getAttack() - Monster.getDefense();
                newHealth = Monster.getHealth() - damage;
                Monster.setHealth(newHealth);
                enemyHealth = "Enemy Health: " + Monster.getHealth();
                index = 1;
            }
        }
    }

    public void AttackPlayer()
    {
        if (PlayerCharacter.getHealth() > 0)
        {
            if (Monster.getAttack() > PlayerCharacter.getDefense())
            {
                damage = Monster.getAttack() - PlayerCharacter.getDefense();
                newHealth = PlayerCharacter.getHealth() - damage;
                PlayerCharacter.setHealth(newHealth);
                pcHealth = "Enemy Health: " + PlayerCharacter.getHealth();
                index = 2;
            }
        }
    }

    public void Flee()
    {
        cams[1].enabled = false;
        cams[0].enabled = true;
        cams[0].depth = Camera.main.depth + 1;
        showText = false;
        Monster.setHealth(10);
        PlayerCharacter.setHealth(10);
    }

    public void Item()
    {

    }

    void Start()
    {
        enemyHealth = "Enemy Health: " + Monster.getHealth();
        pcHealth = "Player Health: " + PlayerCharacter.getHealth();
        showText = false;
        Camera.GetAllCameras(cams);

    }

    void Update()
    {
        if (cams[1].isActiveAndEnabled)
        {
            showText = true;
        }

        if (Monster.getHealth() == 0)
        {

            cams[1].enabled = false;
            cams[0].enabled = true;
            cams[0].depth = Camera.main.depth + 1;
            showText = false;
            Monster.setHealth(10);
            enemyHealth = "Enemy Health: " + Monster.getHealth();

            PlayerCharacter.setHealth(10);
            pcHealth = "Enemy Health: " + PlayerCharacter.getHealth();
        }
    }

    void OnGUI()
    {
        if (showText)
        {
            GUIStyle HUDStyle = new GUIStyle(GUI.skin.label);
            HUDStyle.normal.textColor = Color.red;
            HUDStyle.fontSize = 18;

            GUIStyle buttonStyle = new GUIStyle(GUI.skin.button);
            buttonStyle.fontSize = 18;

            GUI.Label(enemyRect, enemyHealth, HUDStyle);
            GUI.Label(pcRect, pcHealth, HUDStyle);

            if (GUI.Button(attackRect, "Attack", buttonStyle))
            {
                AttackMonster();
                if (Monster.getHealth() > 0)
                    AttackPlayer();
            }

            if(GUI.Button(fleeRect, "Flee", buttonStyle))
            {
                Flee();
            }
        }
    }
}

