using System;

namespace Task
{
    class Weapon
    {
        private int damage;
        private int bullets;

        public void Fire(Player player)
        {
            if (bullets > 0)
            {
                player.TakeDamage(damage);
                bullets -= 1;
            }
        }
    }

    class Player
    {
        private int health;

        public void TakeDamage(int damage)
        {
            if (damage > 0)
                health -= damage;
        }
    }

    class Bot
    {
        private Weapon Weapon;

        public void OnSeePlayer(Player player)
        {
            Weapon.Fire(player);
        }
    }
}