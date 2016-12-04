using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


class Monster : MonoBehaviour
{
    private int modifier;

    private static int attack = 1;
    private static int health = 10;
    private static int defense = 0;
    
    public Monster(int a, int h, int d)
    {
        attack = a;
        health = h;
        defense = d;
    }

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
    
}

