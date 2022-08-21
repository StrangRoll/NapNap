using System;

namespace Task
{
    class Weapon
    {
        private int _bullets;
        private int _bulletsPerShoot;

        public bool CanShoot => _bullets > 0;

        public void Shoot()
        {
            if (CanShoot)
                _bullets -= _bulletsPerShoot;
        }
    }
}