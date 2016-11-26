using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Character
{
    class PlayerCharacter : Character
    {
        private int statPoints;
        private Boolean item = false;
        private int locationX;
        private int locationY;
        private int level;
        private int distance = 0;

        public PlayerCharacter(int h, int a, int d) : base(h, a, d)
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

        public void attackMonster(Monster m)
        {
            if (m.getHealth()>0)
            {
                if (attack > m.getDefense())
                    m.setHealth(attack-m.getDefense());
            }
        }
    }
}
