using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

class PlayerCharacter : MonoBehaviour
{
    private static int statPoints;
    private static Boolean item = true;
    private static int level;
    private static int attack = 2;
    private static int defense = 0;
    private static int health = 10;
    private static int maxHealth = health;
   
    public static void setDefense(int d)
    {
        defense = d;
    }

    public static void setAttack(int a)
    {
        attack = a;
    }

    public static void setHealth(int h)
    {
        health = h;
    }

    public static void setMaxHealth(int h)
    {
        maxHealth = h;
    }

    public static void setItem(Boolean haveItem)
    {
        item = haveItem;
    }

    public static int getAttack()
    {
        return attack;
    }

    public static int getDefense()
    {
        return defense;
    }

    public static int getHealth()
    {
        return health;
    }

    public static int getMaxHealth()
    {
        return maxHealth;
    }

    public static Boolean getItem()
    {
        return item;
    }
    
}
