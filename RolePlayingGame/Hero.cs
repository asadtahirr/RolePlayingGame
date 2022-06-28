using System;
using System.Collections.Generic;
using System.Text;

namespace RolePlayingGame
{
    class Hero
    {
        public string heroName;                         // this is the name of player
        public float heroStrength;                    // this is the player's strength with which it will attack the monsters
        public float heroDefence;                     // this is the player's defence with which it will defend it self from the monster's attack
        public float totalHealth;                  // this is the total health of the player
        public float currentHealth;                   // this is the current health of the player which updates according to the attacks
        public Weapon Weaponequipped;               // this will track which weapon the user is equipped with at any time
        public Armour Armourequipped;               // this will track which armour the user is equipped with at any time
        public int totalWins;               // this is the number of total wins by the player
        public int totalLoss;               // this is the number of total losses by the player

        public Hero(string heroName, float heroStrength, float heroDefence, float totalHealth, float currentHealth, Weapon weaponequipped, Armour armourequipped, int totalWins, int totalLoss)
        {
            this.heroName = heroName;
            this.heroStrength = heroStrength;
            this.heroDefence = heroDefence;
            this.totalHealth = totalHealth;
            this.currentHealth = currentHealth;
            Weaponequipped = weaponequipped;
            Armourequipped = armourequipped;
            this.totalWins = totalWins;
            this.totalLoss = totalLoss;
        }

        public void DisplayStats()                     // this method displays the overall current stats of the player
        {
            Console.WriteLine("Name: " + heroName);
            Console.WriteLine("Player's Strength: " + heroStrength);
            Console.WriteLine("Player's Defence: " + heroDefence);
            Console.WriteLine("Player's Total Health: " + totalHealth);
            Console.WriteLine("Player's Current Health: " + currentHealth);
            Console.WriteLine("Total Wins: " + totalWins);
            Console.WriteLine("Total Loss: " + totalLoss);
        }

        public void ShowInventory()                                     // this method display's the current inventory that the player has
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Weapon Equipped: \n\nName: " + Weaponequipped.nameOfWeapon + "\nPower: " + Weaponequipped.powerOfWeapon);
            Console.WriteLine("\n\nArmour Equipped: \n\nName: " + Armourequipped.nameOfArmour + "\nPower: " + Armourequipped.armourPower);
        }

        public void EquipWeapon(Weapon newWeapon)                       // this method will allow the user to change the equipped weapon of the player
        {
            Weaponequipped = newWeapon;                                 // we replace the equipped weapon with a new one
        }
        public void EquipArmour(Armour newArmour)                       // this method will allow the user to change the equipped armour of the player
        {
            Armourequipped = newArmour;                                 // we replace the equipped armour with a new one
        }
    }
}
