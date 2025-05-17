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
Enemy enemy = new("John John", 100, 3, 6);
Inventory i = new();

while (gameLoop) //Runs the main methods and codes for my game
{
    if (m.GetGameState() == "Map") //Runs my mapmover method.
    {
        m.MainLoop();
    }
    else if (m.GetGameState() == "Combat")
    {
        c.CombatLoop(player, enemy);
        if (enemy.GetHealth() <= 0) //Switches loop if enemy dies. Simple code to end the combat loop, I don't want to complicate this code any more than I have. 
        {
            m.UpdateGameState("Map");
        }
    }
}

Console.ReadLine();

