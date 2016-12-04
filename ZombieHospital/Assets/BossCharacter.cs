using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCharacter : MonoBehaviour {

    private static int health;
    private static int defense;
    private static int attack;

    public static void setHealth(int newHealth)
    {
        health = newHealth;
    }

    public static void setDefense(int newDefense)
    {
        defense = newDefense;
    }

    public static void setAttack(int newAttack)
    {
        attack = newAttack;
    }

    public static int getHealth()
    {
        return health;
    }

    public static int getAttack()
    {
        return attack;
    }

    public static int getDefense()
    {
        return defense;
    }

    // Use this for initialization
    void Start () {
        health = 30;
        defense = 10;
        attack = 8;
        this.GetComponent<Collider2D>().enabled = true;
        this.GetComponent<SpriteRenderer>().enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (getHealth() <= 0)
        {
            this.GetComponent<Collider2D>().enabled = false;
            this.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
