using System;
using UnityEngine;


class guiBattle : MonoBehaviour
{
    public static Boolean wonBattle;
    String monsterHealth = "";
    String miniBossHealth = "";
    String bossHealth = "";
    String pcHealth = "";
    String[] battleText = new String[3];

    Boolean showText;
    Boolean showMiniBossText;
    Boolean showBossText;

    GameObject miniBossCam;
    GameObject bossCam;
    GameObject gunBossCam;
    GameObject mainMenu;

    int damage;
    int newHealth;
    int originalHealth;

    Rect enemyRect = new Rect(Screen.width - 650, 150, 120, 50);
    Rect pcRect = new Rect(550, Screen.height - 250, 120, 70);
    Rect attackTextRect = new Rect(Screen.width - 550, Screen.height - 100, 200, 100);
    Rect attackRect = new Rect(Screen.width - 600, Screen.height - 200, 100, 75);
    Rect fleeRect = new Rect(Screen.width - 475, Screen.height - 200, 100, 75);
    Rect itemRect = new Rect(Screen.width - 350, Screen.height - 200, 100, 75);
    Camera[] cams = new Camera[2];

    public void PlayerAttack()
    {
        if (Monster.getHealth() > 0 && showText)
        {
            if (PlayerCharacter.getAttack() > Monster.getDefense())
            {
                damage = PlayerCharacter.getAttack() - Monster.getDefense();
                newHealth = Monster.getHealth() - damage;
                Monster.setHealth(newHealth);
                monsterHealth = "Enemy Health: " + Monster.getHealth();
            }
        }
        else if(SecurityCharacter.getHealth() > 0 && showMiniBossText)
        {
            if (PlayerCharacter.getAttack() > SecurityCharacter.getDefense())
            {
                damage = PlayerCharacter.getAttack() - SecurityCharacter.getDefense();
                newHealth = SecurityCharacter.getHealth() - damage;
                SecurityCharacter.setHealth(newHealth);
                miniBossHealth = "Enemy Health: " + SecurityCharacter.getHealth();
            }
        }
        else if(BossCharacter.getHealth() > 0 && showBossText)
        {
            if (PlayerCharacter.getAttack() > BossCharacter.getDefense())
            {
                damage = PlayerCharacter.getAttack() - BossCharacter.getDefense();
                newHealth = BossCharacter.getHealth() - damage;
                BossCharacter.setHealth(newHealth);
                bossHealth = "Boss Health: " + BossCharacter.getHealth();
            }
        }
    }

    public void MonsterAttack()
    {
        if (PlayerCharacter.getHealth() > 0)
        {
            if (Monster.getAttack() > PlayerCharacter.getDefense())
            {
                damage = Monster.getAttack() - PlayerCharacter.getDefense();
                newHealth = PlayerCharacter.getHealth() - damage;
                PlayerCharacter.setHealth(newHealth);
                pcHealth = "Player Health: " + PlayerCharacter.getHealth();
            }
        }
        else
        {
            PlayerCharacter.setHealth(0);
        }
    }

    public void MiniBossAttack()
    {
        if (PlayerCharacter.getHealth() > 0)
        {
            if(SecurityCharacter.getAttack() > PlayerCharacter.getDefense())
            {
                damage = SecurityCharacter.getAttack() - PlayerCharacter.getDefense();
                newHealth = PlayerCharacter.getHealth() - damage;
                PlayerCharacter.setHealth(newHealth);
                pcHealth = "Player Health: " + PlayerCharacter.getHealth();
            }
        }
        else
        {
            PlayerCharacter.setHealth(0);
        }
    }

    public void BossAttack()
    {
        if (PlayerCharacter.getHealth() > 0)
        {
            if (BossCharacter.getAttack() > PlayerCharacter.getDefense())
            {
                damage = BossCharacter.getAttack() - PlayerCharacter.getDefense();
                newHealth = PlayerCharacter.getHealth() - damage;
                PlayerCharacter.setHealth(newHealth);
                pcHealth = "Player Health: " + PlayerCharacter.getHealth();
            }
        }
        else
        {
            PlayerCharacter.setHealth(0);
        }
    }


    public void Flee()
    {
        cams[1].enabled = false;
        cams[0].enabled = true;
        cams[0].depth = Camera.main.depth + 1;
        showText = false;
        showMiniBossText = false;
        Monster.setHealth(10);
        if(SecurityCharacter.getHealth() > 0)
        {
            SecurityCharacter.setHealth(20);
        }
        monsterHealth = "Enemy Health: " + Monster.getHealth();
        PlayerCharacter.setHealth(PlayerCharacter.getMaxHealth());
        pcHealth = "Player Health: " + PlayerCharacter.getHealth();
    }

    public void UseItem()
    {
        Monster.setHealth(0);
        PlayerCharacter.setItem(false);
    }

    void Start()
    {
        monsterHealth = "Enemy Health: " + Monster.getHealth();
        miniBossHealth = "Enemy Health: " + SecurityCharacter.getHealth();
        bossHealth = "Boss Health: " + BossCharacter.getHealth();
        pcHealth = "Player Health: " + PlayerCharacter.getHealth();

        showText = false;
        showMiniBossText = false;
        showBossText = false;

        originalHealth = PlayerCharacter.getMaxHealth();

        Camera.GetAllCameras(cams);
        miniBossCam = GameObject.Find("MiniBossCam");
        bossCam = GameObject.Find("BossCam");
        gunBossCam = GameObject.Find("GunBossCam");
        mainMenu = GameObject.Find("TitleCam");
    }

    void Update()
    {
        originalHealth = PlayerCharacter.getMaxHealth();

        if (cams[1].isActiveAndEnabled)
        {
            if (cams[1].transform.position == miniBossCam.transform.position)
            {
                showMiniBossText = true;
            }
            else if(cams[1].transform.position == gunBossCam.transform.position ||
                cams[1].transform.position == bossCam.transform.position)
            {
                showBossText = true;
            }
            else
            {
                showText = true;
            }
        }
        
        if(PlayerCharacter.getHealth() <= 0)
        {

            MainScreen.onMenu = true;
            cams[1].enabled = false;
            cams[0].enabled = true;
            cams[0].depth = Camera.main.depth + 1;
            
            cams[0].transform.position = mainMenu.transform.position;
            showText = false;
            wonBattle = false;
            showMiniBossText = false;
            showBossText = false;
            Monster.setHealth(10);
            SecurityCharacter.setHealth(20);
            BossCharacter.setHealth(30);
        }


        if (Monster.getHealth() <= 0 && showText)
        {

            cams[1].enabled = false;
            cams[0].enabled = true;
            cams[0].depth = Camera.main.depth + 1;
            showText = false;
            wonBattle = true;
            Monster.setHealth(10);
            monsterHealth = "Enemy Health: " + Monster.getHealth();

            PlayerCharacter.setHealth(PlayerCharacter.getMaxHealth());
            pcHealth = "Player Health: " + PlayerCharacter.getHealth();
        }
        else if(SecurityCharacter.getHealth() <= 0 && showMiniBossText)
        {
            cams[1].enabled = false;
            cams[0].enabled = true;
            cams[0].depth = Camera.main.depth + 1;
            showMiniBossText = false;
            wonBattle = true;

            PlayerCharacter.setHealth(PlayerCharacter.getMaxHealth());
            PlayerCharacter.setItem(true);
            pcHealth = "Player Health: " + PlayerCharacter.getHealth();
        }
        else if(BossCharacter.getHealth() <= 0 && showBossText)
        {
            cams[1].enabled = false;
            cams[0].enabled = true;
            cams[0].depth = Camera.main.depth + 1;
            cams[0].transform.position = mainMenu.transform.position;
            showBossText = false;
            wonBattle = false;
            MainScreen.onMenu = true;

            PlayerCharacter.setHealth(PlayerCharacter.getMaxHealth());
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

            GUI.Label(enemyRect, monsterHealth, HUDStyle);
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
                PlayerAttack();
                if (Monster.getHealth() > 0)
                {                    
                    MonsterAttack();
                }
            }

            if(GUI.Button(fleeRect, "Flee", buttonStyle))
            {
                Flee();
            }
        }
        else if (showMiniBossText)
        {
            GUIStyle HUDStyle = new GUIStyle(GUI.skin.label);
            HUDStyle.normal.textColor = Color.red;
            HUDStyle.fontSize = 18;

            GUIStyle buttonStyle = new GUIStyle(GUI.skin.button);
            buttonStyle.fontSize = 18;

            GUI.Label(enemyRect, miniBossHealth, HUDStyle);
            GUI.Label(pcRect, pcHealth, HUDStyle);

            if (GUI.Button(attackRect, "Attack", buttonStyle))
            {
                PlayerAttack();
                if (SecurityCharacter.getHealth() > 0)
                {
                    MiniBossAttack();
                }
            }

            if (GUI.Button(fleeRect, "Flee", buttonStyle))
            {
                Flee();
            }
        }
        else if (showBossText)
        {
            GUIStyle HUDStyle = new GUIStyle(GUI.skin.label);
            HUDStyle.normal.textColor = Color.red;
            HUDStyle.fontSize = 18;

            GUIStyle buttonStyle = new GUIStyle(GUI.skin.button);
            buttonStyle.fontSize = 18;

            GUI.Label(enemyRect, miniBossHealth, HUDStyle);
            GUI.Label(pcRect, pcHealth, HUDStyle);

            if (PlayerCharacter.getItem())
            {
                if (GUI.Button(itemRect, "Use Item", buttonStyle))
                {
                    UseItem();
                }
            }

            if (GUI.Button(attackRect, "Attack", buttonStyle))
            {
                PlayerAttack();
                if (BossCharacter.getHealth() > 0)
                {
                    BossAttack();
                }
            }
        }
    }
}

