using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace battleSystem
{
    class battle
    {
        static void Main(string[] args)
        {

            int enemy_vitality = 5;
            int enemy_attack = 4;
            int enemy_defense = 2;


            int player_vitality = 10;
            int player_attack = 5;
            int player_defense = 2;
            int playerHP = player_vitality;



            string action;

            System.Console.WriteLine("The player has encountered an enemy.\n");
            do
            {

                System.Console.WriteLine("___________________________\n");
                System.Console.WriteLine("|Player HP: " + playerHP +  " |" + "Enemy HP: " + enemy_vitality + "|\n");

                System.Console.WriteLine ("|_____________|___________|");
                System.Console.WriteLine("\n");
                System.Console.WriteLine("\n");


                System.Console.WriteLine("Type in the action that you would like to do:\n");
                System.Console.WriteLine("Attack \n");
                System.Console.WriteLine("Use item \n");
                System.Console.WriteLine( "Flee \n");
                System.Console.WriteLine("\n");

                action = Console.ReadLine();

                if (action == "attack" || action == "Attack")
                {


                    System.Console.WriteLine("The player has decided to attack. \n");
                    enemy_vitality = enemy_vitality - (player_attack - enemy_defense);
                    System.Console.WriteLine("The enemy takes damage \n");
                    System.Console.WriteLine( "The enemy attacks the player \n");
                    System.Console.WriteLine(" The player takes damage\n");
                    playerHP = playerHP - (enemy_attack - player_defense);
                    System.Console.WriteLine("\n");

                }
                else if (action == "flee" || action == "Flee")
                {
                    break;
                }
                else
                {
                    System.Console.WriteLine("\n");
                    System.Console.WriteLine("Invalid option was entered. \n");
                }

            } while (enemy_vitality >= 1 && playerHP >= 1);



            if (enemy_vitality <= 0)
            {
                enemy_vitality = 0;
                System.Console.WriteLine( "___________________________\n");
                System.Console.WriteLine("|Player HP: " + playerHP + "|" + "Enemy HP: " + enemy_vitality + "|\n");

                System.Console.WriteLine("|_____________|___________|\n");
                System.Console.WriteLine("\n");
                System.Console.WriteLine("\n");


                System.Console.WriteLine("The enemy has died\n");
                System.Console.WriteLine("The player has healed one point of health and has earned a point to increase a stat point.\n");
                playerHP++;

                do
                {

                    System.Console.WriteLine("___Player stats___\n");
                    System.Console.WriteLine("Vitality: " + player_vitality + "\n");
                    System.Console.WriteLine("Attack: " + player_attack + "\n");
                    System.Console.WriteLine("Defense: " + player_defense + "\n");
                    System.Console.WriteLine("Hit points: " + playerHP + "/" + player_vitality + "\n");
                    System.Console.WriteLine("\n");


                    System.Console.WriteLine("Choose a stat that you would like to increase:\n");
                    System.Console.WriteLine("Vitality\n");
                    System.Console.WriteLine("Attack\n");
                    System.Console.WriteLine("Defense\n");
                    System.Console.WriteLine("\n");

                    action = Console.ReadLine();

                    if (action == "vitality" || action == "vitality")
                    {
                        player_vitality++;
                        System.Console.WriteLine("The player's vitality increased by one point.\n");
                        break;
                    }
                    if (action == "Attack" || action == "attack")
                    {
                        player_attack++;
                        System.Console.WriteLine("The player's attack increased by one point.\n");
                        break;

                    }
                    else if (action == "defense" || action == "defense")
                    {

                        player_defense++;
                        System.Console.WriteLine("The player's defense increased by one point.\n");
                        break;
                    }
                } while (action != "vitality" || action != "Vitality");

                System.Console.WriteLine("\n");
                System.Console.WriteLine("___Player stats___\n");
                System.Console.WriteLine("Vitality: " + player_vitality + "\n");
                System.Console.WriteLine("Attack: " + player_attack + "\n");
                System.Console.WriteLine("Defense: " + player_defense + "\n");
                System.Console.WriteLine("Hit points: " + playerHP + "/" + player_vitality + "\n");

            }
            else if (player_vitality <= 0)
            {
                player_vitality = 0;
                System.Console.WriteLine( "___________________________\n");
                System.Console.WriteLine("|Player HP: " + player_vitality + " |" + "Enemy HP: " + enemy_vitality + "|" + "\n");

                System.Console.WriteLine("|_____________|___________|");
                System.Console.WriteLine("\n");
                System.Console.WriteLine("\n");
                System.Console.WriteLine("The player has died");
            }
            else
            {
                System.Console.WriteLine("\n");
                System.Console.WriteLine("The player has fled from the battle.\n");
            }





        }
    }
}
