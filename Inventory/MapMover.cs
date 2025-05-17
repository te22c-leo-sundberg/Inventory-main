using System.Text;

class MapMover
{
    public List<Map> maps = new List<Map>();
    int playerX;
    int playerY;
    int currentFloor = 0;
    bool start = true;
    bool combatStart;
    string gameState = "Map";
    public void MainLoop()
    {
        Console.Clear();
        if (start)
        {
            StartGame();
            start = false;
        }

        maps[GetCurrentFloor()].PrintMap(GetPlayerY(), GetPlayerX()); //Prints the map so the player can visualize where they are etc.
        int input = GetInt("Do you wish to Explore [1], Move [2] or Dig [3]?", 1, 3);//Does a get int to see what the player inputs. Based on that it does different things.
        if (input == 1)
        {
            RoomLogic();
        }
        else if (input == 2)
        {
            Movement();
        }
        else if (input == 3)
        {
            Console.WriteLine("Choose the direction to dig using the arrow keys.");
            maps[GetCurrentFloor()].MakePath(GetDirection(), GetPlayerX(), GetPlayerY());
        }


    }
    public void CombatLoop()
    {
        if (combatStart)
        {
            //Do some code that createas an enemy, sets hp back to full for the player, etc etc. I suggest moving the combat into another class, considering it will use none of the current code and this
            //class is called "MapMover". Maybe do a room class with subclasses for each type of room.
        }
    }
    public void StartGame() //If the game has just started, this will run and generate the first map, put it in the list etc. It then updates the player positions to match the start position of the map.
    {
        Map map = new Map();
        currentFloor = 0;
        map.GenerateMap();
        maps.Add(map);
        SetPlayerX(maps[GetCurrentFloor()].posX);
        SetPlayerY(maps[GetCurrentFloor()].posY);
    }
    public string GetDirection() //Gets the player direction, and will keep going until the player presses one of the arrow keys. The direction is then returned as a string.
    {
        bool success = false;
        while (!success)
        {
            ConsoleKey key = Console.ReadKey().Key;
            if (key == ConsoleKey.DownArrow)
            {
                success = true;
                return "Down";
            }
            else if (key == ConsoleKey.UpArrow)
            {
                success = true;
                return "Up";
            }
            else if (key == ConsoleKey.LeftArrow)
            {
                success = true;
                return "Left";
            }
            else if (key == ConsoleKey.RightArrow)
            {
                success = true;
                return "Right";
            }
        }
        return "";
    }
    public int GetPlayerX() //Returns the playerX in the form of an int.
    {
        return playerX;
    }
    public void SetPlayerX(int X) //Sets the playerX based on what int is put into the method.
    {
        playerX = X;
    }
    public int GetPlayerY()//Returns the playerY in the form of an int.
    {
        return playerY;
    }
    public void SetPlayerY(int Y) //Sets the playerY based on what int is put into the method.
    {
        playerY = Y;
    }
    public int GetCurrentFloor() //Gets the current floor in the form of an int.
    {
        return currentFloor;
    }
    public string GetGameState() //Gets the game state for the main game loop in program in the form of a string.
    {
        return gameState;
    }
    public void UpdateGameState(string newGameState) //Updates the game state used in the main game loop in program to the string inserted into the method.
    {
        gameState = newGameState;
    }
    public void Movement() //Code used to move the player once on the map.
    {
        Console.WriteLine("Move using the arrow keys");
        bool success = false;
        while (!success) //A while loop that only ends after the player inputs a key input, and it is within bounds.
        {
            ConsoleKey key = Console.ReadKey().Key;
            if (key == ConsoleKey.DownArrow)
            {
                MoveDirection(0, 1); //Moves the character down once on the map.
            }
            else if (key == ConsoleKey.UpArrow)
            {
                MoveDirection(0, -1); //Moves the character up once on the map.
            }
            else if (key == ConsoleKey.RightArrow)
            {
                MoveDirection(1, 0); //Moves the character right once on the map.
            }
            else if (key == ConsoleKey.LeftArrow)
            {
                MoveDirection(-1, 0); //Moves the character left once on the map.
            }
        }
        void MoveDirection(int moveX, int moveY) //Moves the player in a direction. If the method that checks collision returns false, it tells the player they are trying to move out of bounds.
        {
            if (maps[currentFloor].IsOnPath(playerX, playerY, moveX, moveY))//If this returns true, the player moves the direction it was supposed to.
            {
                playerX += moveX;
                playerY += moveY;
                success = true; //Success is then turned to true, letting the player select what to do next in the main man loop.
            }
            else
            {
                Console.WriteLine("You cannot move out of bounds!");
            }
        }
    }
    void Ascend()
    { //Saves the players current position to the map for when they return.
        maps[currentFloor].posX = playerX;
        maps[currentFloor].posY = playerY;
        if (currentFloor > 0) //If the player is not at the top floor, changes the player floor by -1 and then updates the player positions to be what they were when he was on that map before.
        {
            Console.WriteLine("You ascend the staircase and end up in a familiar place.");
            currentFloor--;
            SetPlayerX(maps[currentFloor].posX);
            SetPlayerY(maps[currentFloor].posY);
        }
        else //Lets the player know they cannot go up any further
        {
            Console.WriteLine("You're already at the top.");
        }
    }
    void Descend()//Saves the players current position on this map for when they return, then checks if the player is at the last floor of the list. If it is, it creates a new one. 
    {
        maps[currentFloor].posX = playerX;
        maps[currentFloor].posY = playerY;
        if (currentFloor == maps.Count - 1) //This is done to stop bloat and not having my code create a new map if the player is moving between already generated floors.
        {
            Map map = new Map();
            map.GenerateMap();
            maps.Add(map);
        }
        currentFloor++; //Changes what current floor the player is on by +1, then updates it to match the positions the player will take when being on that floor.
        playerX = maps[currentFloor].posX;
        playerY = maps[currentFloor].posY;
    }
    void RoomLogic() // Checks what room the player is currently standing on. Then depending on the room, gives the player different dialogue etc.
    {
        int roomInput = 0;
        if (maps[GetCurrentFloor()].PlayerPos(playerX, playerY) == "Path")
        {
            Console.WriteLine("There is no room here.");
        }
        else if (maps[GetCurrentFloor()].PlayerPos(playerX, playerY) == "Ascend") //Checks for a int between 1 or 2 to see if the player will ascend or do nothing.
        {
            Console.WriteLine("A half broken staircase.The reason you were able to go down here in the first place.");
            roomInput = GetInt("Would you like to Walk up the staircase = [1], or Leave it be = [2]?", 1, 2);
            if (roomInput == 1)
            {
                Ascend();
            }
            else if (roomInput == 2)
            {

            }
        }
        else if (maps[GetCurrentFloor()].PlayerPos(playerX, playerY) == "Descend")//Checks for a int between 1 or 2 to see if the player will descend or do nothing.
        {
            Console.WriteLine("A functional staircase.");
            roomInput = GetInt("Would you like to Walk down the staircase = [1], or Leave it be = [2]?", 1, 2);
            if (roomInput == 1)
            {
                Descend();
            }
            else if (roomInput == 2)
            {

            }
        }
        else if (maps[GetCurrentFloor()].PlayerPos(playerX, playerY) == "Combat" || maps[GetCurrentFloor()].PlayerPos(playerX, playerY) == "Treasure" || maps[GetCurrentFloor()].PlayerPos(playerX, playerY) == "Rest") //Checks for a int between 1 or 2 to see if the player will enter the room and enter combat or do nothing.
        { //I moved all the different room experience codes into here because I will not finish the rest. This leads to the player at least getting a room that works.
            Console.WriteLine("You see a room, some gold and treasure lies at one part of it, but blocking it is what looks to be a monster.");
            roomInput = GetInt("Would you like to Enter the room = [1], or Leave it be = [2]?", 1, 2);
            if (roomInput == 1)
            {
                UpdateGameState("Combat");
            }
            else if (roomInput == 2)
            {

            }
        }
    }
    int GetInt(string text, int minNum, int maxNum) //I have already explained this in combat, this is my reusable get int method.
    {
        Console.WriteLine(text);
        int output = 0;
        bool success = false;
        while (!success)
        {
            string input = Console.ReadLine();
            success = int.TryParse(input, out output);
            if (output < minNum)
            {
                Console.WriteLine("Too low of a number!");
                success = false;
            }
            else if (output > maxNum)
            {
                Console.WriteLine("Too high of a number!");
                success = false;
            }
        }
        return output;
    }

    public MapMover() //Constructor for map mover class
    {

    }
}