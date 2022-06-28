using System;
using System.Collections.Generic;
using System.Text;

namespace RolePlayingGame
{
    class Armour
    {
        public string nameOfArmour;                       // the name property of an armour
        public float armourPower;                         // the power property of the armour

        public Armour(string armourName, int armourPower)
        {
            this.nameOfArmour = armourName;
            this.armourPower = armourPower;
        }
    }
}
