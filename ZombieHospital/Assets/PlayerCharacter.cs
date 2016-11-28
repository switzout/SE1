using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

//namespace Character
//{
class PlayerCharacter : MonoBehaviour
{
    private int statPoints;
    private Boolean item = false;
    private int level;

    public static int attack = 2;
    public static int defense = 0;
    public static int health = 10;
   
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

    public int getStatPoints()
    {
        return statPoints;
    }

    public Boolean getItem()
    {
        return item;
    }

    public int getLevel()
    {
        return level;
    }

    public void setStatPoints(int s)
    {
        statPoints = s;
    }

    public void setItem(Boolean i)
    {
        item = i;
    }

    public void setLevel(int l)
    {
        level = l;
    }
    
}
//}
