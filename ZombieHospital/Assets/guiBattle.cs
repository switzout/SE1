using System;
using UnityEngine;


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

    Rect enemyRect = new Rect(Screen.width - 650, 150, 120, 50);
    Rect pcRect = new Rect(550, Screen.height - 250, 120, 70);
    Rect attackTextRect = new Rect(Screen.width - 550, Screen.height - 100, 200, 100);
    Rect attackRect = new Rect(Screen.width - 600, Screen.height - 200, 100, 75);
    Rect fleeRect = new Rect(Screen.width - 475, Screen.height - 200, 100, 75);
    Rect itemRect = new Rect(Screen.width - 350, Screen.height - 200, 100, 75);
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
                pcHealth = "Player Health: " + PlayerCharacter.getHealth();
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
        enemyHealth = "Enemy Health: " + Monster.getHealth();
        PlayerCharacter.setHealth(10);
        pcHealth = "Player Health: " + PlayerCharacter.getHealth();
    }

    public void UseItem()
    {
        Monster.setHealth(0);
        PlayerCharacter.setItem(false);
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
            pcHealth = "Player Health: " + PlayerCharacter.getHealth();
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

            if (PlayerCharacter.getItem())
            {
                if(GUI.Button(itemRect, "Use Item", buttonStyle))
                {
                    UseItem();
                }
            }

            if (GUI.Button(attackRect, "Attack", buttonStyle))
            {
                AttackMonster();
                if (Monster.getHealth() > 0)
                {
                    
                    AttackPlayer();
                }
            }

            if(GUI.Button(fleeRect, "Flee", buttonStyle))
            {
                Flee();
            }
        }
    }
}

