using System;
using System.Collections.Generic;
using System.Text;

namespace RolePlayingGame
{
    class Weapon
    {
        public string nameOfWeapon;                     // the name property of the weapon
        public int powerOfWeapon;                       // the power property of the weapon

        public Weapon(string weaponName, int weaponPower)
        {
            this.nameOfWeapon = weaponName;
            this.powerOfWeapon = weaponPower;
        }
    }
}
