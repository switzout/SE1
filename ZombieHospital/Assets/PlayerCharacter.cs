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
        private int locationX;
        private int locationY;
        private int level;
        private int distance = 0;
        static Vector3 savedPosition;

        void Awake()
        {
            DontDestroyOnLoad(transform.gameObject);    
        }    

        public PlayerCharacter(int h, int a, int d)
        { 

        }

        public int getStatPoints()
        {
            return statPoints;
        }

        public int getDistance()
        {
            return distance;
        }

        public Boolean getItem()
        {
            return item;
        }

        public int getLocationX()
        {
            return locationX;
        }

        public int getLocationY()
        {
            return locationY;
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

        public void setLocationX(int x)
        {
            locationX = x;
        }

        public void setLocationY(int y)
        {
            locationY = y;
        }

        public void setLevel(int l)
        {
            level = l;
        }

        public void setDistance(int d)
        {
            distance = distance + d;
            //add if condition from battle to set distance to 0
        }

      /*  public void attackMonster(Monster m)
        {
            if (m.getHealth()>0)
            {
                if (attack > m.getDefense())
                    m.setHealth(attack-m.getDefense());
            }
        }*/
    }
//}
