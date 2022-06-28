using System;
using System.Collections.Generic;
using System.Text;

namespace RolePlayingGame
{
    class Fight
    {
        public float HeroTurn(float powerOfWeapon, float heroStrength)                   // this method returns the damage done by player
        {
            return heroStrength + powerOfWeapon;                                            // calculating damage = player's Strength - Power of equipped weapon
        }


        public float MonsterTurn(float monsterStrength, float heroDefence, float armourPower)                      // this method returns the damage done by monster
        {
            return monsterStrength - (heroDefence + armourPower);                       // calculating damage = Monster's strength - (player's defence + player's equipped armour power)
        }

        public bool IsWon(Hero player, Monster monster)                                 // this method returns true which means that the player has won
        {
            if(monster.currentHealth <= 0)                                  // checking if the current health of the monster is 0 or less
            {
                RemoveMonsterfromList(monster);                               // we remove that specific monster from the list
                player.totalWins++;                                             // we increase the number of total wins by 1
                Console.WriteLine(player.heroName + " has won the game!!!");        // display the message
                return true;                                                        // return true indicates the player has won
            }
            return false;                                                           // return false indicates the player has not won meaning the game is continued
        }

        public bool IsLost(Hero player, Monster monster)                                // this method returns true which means that the player has won
        {
            if(player.currentHealth <= 0)                                                     // checking if the current health of the player is 0 or less
            {
                player.currentHealth = player.totalHealth;                               // we reset the health of the player to it's maximum old value
                player.totalLoss++;                                                     // we increase the number of losses by 1
                Game.monsterNumber = 0;                                                 // we reset the number of monster to fight with
                Game.createMonsterList();                                               // we call the method to repopulat the list of monsters
                Console.WriteLine(player.heroName + " has lost the game!!!");               // Display the message
                return true;                                                                // return true, meaning that the player has lost
            }
            return false;                                                                       // return false, meaning that the player has not lost and battle is continued
        }

        public void RemoveMonsterfromList(Monster m)                        // this method removes the defeated monster from the list
        {
            Game.monsterNumber++;                                           // we increase the number of monster to indicate we have surpassed this one
        }

    }
}
