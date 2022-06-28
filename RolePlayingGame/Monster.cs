using System;
using System.Collections.Generic;
using System.Text;

namespace RolePlayingGame
{
    class Monster       
    {
        public string monsterName;                  // this is the name of monster
        public float monsterStrength;               // this is the monster's strength with which it will attack the player
        public float totalHealth;                   // this is the total health of the monster
        public float currentHealth;                 // this is the current health of the monster which updates according to the attacks

        public Monster(string monsterName, float monsterStrength, float totalHealth, float currentHealth)
        {
            this.monsterName = monsterName;
            this.monsterStrength = monsterStrength;
            this.totalHealth = totalHealth;
            this.currentHealth = currentHealth;
        }
    }
}
