namespace Character
{
    class Character
    {
        private int health;
        private int attack;
        private int defense;

        public Character(int h, int a, int d)
        {
            health = h;
            attack = a;
            defense = d;
        }

        public int getHealth()
        {
            return health;
        }

        public int getAttack()
        {
            return attack;
        }

        public int getDefense()
        {
            return defense;
        }

        public void setHealth(int h)
        {
            health = h;
        }

        public void setAttack(int a)
        {
            attack = a;
        }

        public void setDefense(int d)
        {
            defense = d;
        }

        public void attack(object c)
        {
            if (c.getHealth() > 0)
            {
                if (attack > c.getDefense())
                    c.setHealth(attack - c.getDefense());
            }
        }
    }

}
