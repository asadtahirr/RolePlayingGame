using System;
using System.Collections.Generic;

namespace RolePlayingGame
{
    class Game                      // This class is th main class. All the user interactions are handled within this class
    {
        public static Monster[] listOfMonsters = new Monster[5];          // this is the list of monsters that will hold the records of all the monsters
        public static int monsterNumber = 0;                                // this variable will store the current number of Monster to fight with

        static void Main(string[] args)             // this is the main method
        {
            Start();                // calling the start method to display the game interface
        }

        public static void Start()                      // this is the method where the whole user interaction and game is running.
        {
            createArmorList();                                                      // we are calling this method to populate the armour list
            createWeaponList();                                                     // we are calling this method to populate the weapon list
            createMonsterList();                                                    // we are calling this method to populate the monster list



            Console.Write("Please Enter the Name: ");
            string nameofPlayer = Console.ReadLine();                                  // storing the user input from the user
            
            int gamesPlayed = 0;                                                     // The total number of games played by the user

            // on the line below we are passing the default arguments to create an object of Hero Class as player
            Hero player = new Hero(nameofPlayer, 30, 30, 100, 100, WeaponList.listOfWeapons[0], ArmourList.listOfArmours[0], 0, 0);


            while(true){                                            // while loop that loops endlessly till the end of the game

                // Main Menu Display 

                Console.WriteLine("Main Menu");
                Console.WriteLine("Press 1 for Statistics");
                Console.WriteLine("Press 2 for Inventory");
                Console.WriteLine("Press 3 for Fight");
                Console.Write("Your Choice: ");

                // Main Menu Display

                switch (Console.ReadLine())                                                     // Checking the user input selection
                {
                    case "1":                                                                   // if the user selects 1st option from the main menu  by pressing 1
                        player.DisplayStats();                                                  // we call the player's display method to show the information regarding the player
                        Console.WriteLine("Total Games Played: " + gamesPlayed);                // we also display the total number of games the user has played
                        break; 
                    case "2":                                                                   // if the user selects 2nd option from the main menu  by pressing 2

                        // Inventory Menu Display

                        Console.WriteLine("Press 1 to Equip Weapon");
                        Console.WriteLine("Press 2 to Equip Armour");
                        Console.WriteLine("Press 3 to Show Inventory");
                        Console.WriteLine("Press 4 to Go Back!");
                        Console.Write("Your Choice: ");

                        // Inventory Menu Display 

                        switch (Console.ReadLine())                                             // Checking the user input selection
                        {
                            case "1":                                                           // if the user selects 1st option from the Inventory menu by pressing 1
                                int number = 1;                                                 // this will help us in displaying the number of the Weapon
                                foreach (Weapon w in WeaponList.listOfWeapons)                     // we iterate one by one over each weapon in the list of availble weapons
                                {
                                    Console.WriteLine(number + " -> Name: " + w.nameOfWeapon + ", Power: " + w.powerOfWeapon);           // print the name and power of the weapon
                                    number++;                                                                                    // and we increase the number of the weapon
                                }
                                Console.Write("Your Choice: ");
                                int weaponNumber = Int32.Parse(Console.ReadLine()) - 1;                                     // We take the user's input for weapon selection
                                player.EquipWeapon(WeaponList.listOfWeapons[weaponNumber]);                                    // we pass the selected weapon to the method to equip it
                                break;
                            case "2":                                                               // if the user selects 2nd option from the Inventory menu by pressing 2
                                number = 1;                                                             // this will help us in displaying the number of the Armour
                                foreach (Armour a in ArmourList.listOfArmours)                                     // we iterate one by one over each armour in the list of availble armour
                                {
                                    Console.WriteLine(number + " -> Name: " + a.nameOfArmour + ", Power: " + a.armourPower);           // print the name and power of the armour
                                    number++;                                                                            // and we increase the number of the armour
                                }
                                Console.Write("Your Choice: ");
                                int armourchoice = Int32.Parse(Console.ReadLine()) - 1;                             // We take the user's input for armour selection
                                player.EquipArmour(ArmourList.listOfArmours[armourchoice]);                            // we pass the selected armour to the method to equip it
                                break;
                            case "3":                                                                           // if the user selects 3rd option from the Inventory menu by pressing 3
                                player.ShowInventory();                                                             // we call the method to display the current inventory of the player
                                break;
                            case "4":                                                                           // if the user selects 4th option from the Inventory menu by pressing 4
                                break;                                                                          // we return back to the main menu
                        }
                        break;
                    case "3":                                                                               // if the user selects 3rd option from the main menu by pressing 3
                        
                        if(monsterNumber == 5)                                                                  // we check if there are any more monsters to fight with
                        {
                            Console.WriteLine("No more Monsters Left to Fight!!!");                         // if there are no more monsters to fight with, this message is displayed
                            break;                                                                          // and the user will return back to the main menu
                        }
                        Fight f = new Fight();                                                              // this line creates an object of the fight class to initiate the fight
                        Monster m = listOfMonsters[monsterNumber];                                          // this line selects a monster for us from the list of available monsters
                        
                        Console.WriteLine("Fight has Begun with "+m.monsterName);                      // Fight begins message is displayed to notify

                        bool isPlayerTurn = true;                                                                       // this will be used to check if it is player's turn or not
                        do
                        {
                            Console.WriteLine("");
                            Console.WriteLine("");
                            if (isPlayerTurn)                                                                               // we check if it is player's turn
                            {
                                Console.WriteLine(player.heroName + " is taking his Turn!!!");                              // display a message to notify
                                float damage = f.HeroTurn(player.Weaponequipped.powerOfWeapon, player.heroStrength);        // we pass the values to calculate the damage done to the monster by the player
                                Console.WriteLine("Damage Given to " + m.monsterName + ": " + damage);                      // display the message
                                m.currentHealth -= damage;                                                                  // once the damage is calculated we reduce the monster's health
                                if (f.IsWon(player, m))                                                                     // After the damage we check if the player has won or not
                                    break;                                                                                  // if the player has won, we end the game
                                isPlayerTurn = false;                                                                       // else we continue with Monster's turn
                            }
                            else                                                                      // else it's monster's turn
                            {
                                Console.WriteLine(m.monsterName + "is taking his Turn!!!");                 // display a message to notify
                                float damage = f.MonsterTurn(m.monsterStrength, player.heroDefence, player.Armourequipped.armourPower);                              // we pass the values to calculate the damage done to the player by monster
                                Console.WriteLine("Damage Given to " + player.heroName + ": " + damage);                        // display the message
                                player.currentHealth -= damage;                                     // once the damage is calculated we reduce the player's health
                                if (f.IsLost(player, m))                                              // After the damage we check if the player has lost or not
                                    break;                                                      // if the player has lost, we end the game
                                isPlayerTurn = true;                                                            // else we continue with player's turn
                            }
                            Console.ReadLine();
                        } while (true);
                        gamesPlayed++;                                                      // once a game is finished, we count it up
                        break;
                    default:
                        Console.WriteLine("Invalid Choice!!!");
                        break;
                }
            }


        }


        public static void createMonsterList()                          // This method will create a complete List of Monsters
        {
            if (listOfMonsters.Length > 0)                           // we check if the list already has some monsters or not
            {
                int i = 0;
                while( i < listOfMonsters.Length)                           // if there are any monsters we clear them out first!
                {
                    listOfMonsters[i] = null;
                    i++;
                }
            }

            listOfMonsters[0] = new Monster("Captain Salazaar", 60, 100, 100);                       // this line will create a new monster with 60 strength and 100 health and adds to the list
            listOfMonsters[1] = new Monster("Davy Jones", 80, 100, 100);                             // this line will create a new monster with 80 strength and 100 health and adds to the list
            listOfMonsters[2] = new Monster("Captain Barbosa", 120, 100, 100);                       // this line will create a new monster with 120 strength and 100 health and adds to the list
            listOfMonsters[3] = new Monster("Black Beard", 140, 100, 100);                           // this line will create a new monster with 140 strength and 100 health and adds to the list
            listOfMonsters[4] = new Monster("Jack Sparrow", 160, 100, 100);                          // this line will create a new monster with 160 strength and 100 health and adds to the list
        }

        public static void createWeaponList()                                   // This method will create a List of usable weapons
        {
            WeaponList.listOfWeapons[0] = new Weapon("Bow & Arrow",20);               // this line will creae a weapon of 20 power and add it to the list
            WeaponList.listOfWeapons[1] = new Weapon("Cannon", 40);               // this line will creae a weapon of 40 power and add it to the list                          
            WeaponList.listOfWeapons[2] = new Weapon("Gun", 60);               // this line will creae a weapon of 60 power and add it to the list                          
        }
        public static void createArmorList()                                    // This method will create a List of usable armours
        {
            ArmourList.listOfArmours[0] = new Armour("Leather Jacket", 10);               // this line will creae an armour of 10 armour and add it to the list                          
            ArmourList.listOfArmours[1] = new Armour("Steel Jacket", 20);               // this line will creae an armour of 20 armour and add it to the list                        
            ArmourList.listOfArmours[2] = new Armour("Bullet Proof", 30);               // this line will creae an armour of 30 armour and add it to the list                         
        }
    }
}
