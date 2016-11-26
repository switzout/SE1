using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Character
{
    class Monster : Character
    {
        private int modifier;

        public Monster(int h, int a, int d) : base(h, a, d)
        {

        }

        public int getModifier()
        {
            return modifier;
        }

        public void setModifier(int m)
        {
            modifier = m;
        }

        public void attackPlayer(PlayerCharacter pc)
        {
            if (attack > pc.getDefense())
            {
                pc.setHealth(attack - pc.getDefense()); 
            }
        }
    }
}
