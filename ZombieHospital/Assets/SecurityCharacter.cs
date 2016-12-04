using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCharacter : MonoBehaviour {

    private static int health = 0;
    private static int defense = 10;
    private static int attack = 12;

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
        setHealth(25);
        setDefense(5);
        setAttack(6);
        this.GetComponent<Collider2D>().enabled = true;
        this.GetComponent<SpriteRenderer>().enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
		if(getHealth() <= 0)
        {
            this.GetComponent<Collider2D>().enabled = false;
            this.GetComponent<SpriteRenderer>().enabled = false;
        }
	}
}
