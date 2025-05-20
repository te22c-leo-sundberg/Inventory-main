using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text.Json;

Console.InputEncoding = System.Text.Encoding.UTF8;
Console.OutputEncoding = System.Text.Encoding.UTF8;

bool gameLoop = true;

MapMover m = new();
Combat c = new();
Player player = new("Player", 100, 25, 4.5f, 4, 8);
Enemy enemy1 = new("Crawler", 100, 3, 6);
Bulky enemy2 = new("Unpredictable", 100, 3, 6, 2, 5);
Inventory i = new();

while (gameLoop) //Runs the main methods and codes for my game
{
    if (m.GetGameState() == "Map") //Runs my mapmover method.
    {
        m.MainLoop();
    }
    else if (m.GetGameState() == "Combat")
    {
        int chance = Random.Shared.Next(2, 3);
        if (chance == 1)
        {
            c.CombatLoop(player, enemy1);
            if (enemy1.GetHealth() <= 0) //Switches loop if enemy dies. Simple code to end the combat loop, I don't want to complicate this code any more than I have. 
            {
                m.UpdateGameState("Map");
            }
        }
        else
        {
            c.CombatLoop(player, enemy2);
            if (enemy2.GetHealth() <= 0) //Switches loop if enemy dies. Simple code to end the combat loop, I don't want to complicate this code any more than I have. 
            {
                m.UpdateGameState("Map");
            }
        }
    }
}

Console.ReadLine();

