class Combat
{
    List<Enemy> Enemies = [];
    bool CombatStart = true;

    public void CombatLoop(Character player, Character enemy)
    {
        if (CombatStart)//Runs only at the start of combat then makes combatStart false. I would then add some code at the end of combat that makes it true again.
        {
            player.SetHealth(9999); //Heals player to full health. Tells you the name of what you encountered
            Console.WriteLine("You have encountered a " + enemy.GetName() + ".");
            CombatStart = false;
        }
        int input = GetInt("What do you wish to do? Attack = [1]", 1, 1);
        if (input == 1)
        {
            enemy.TakeDamage(enemy.DamageTaken(player.Attack()));
        }
        if (enemy.GetHealth() > 0)
        {

        }
        player.TakeDamage(player.DamageTaken(enemy.Attack()));
    }

    int GetInt(string text, int minNum, int maxNum)//Uses tryparse to get an int, and continuously runs this code until you choose a valid option. Each failed time will tell you what you did wrong.
    {
        Console.WriteLine(text);
        int output = 0;
        bool success = false;
        while (!success)
        {
            string input = Console.ReadLine();
            success = int.TryParse(input, out output); //Will turn false if you input anything that is not a number.
            if (output < minNum) //The while loop will finish completely even if success is true becaues you input a number
            {
                Console.WriteLine("Too low of a number!"); //Check if the number is within your range of correct numbers.
                success = false;
            }
            else if (output > maxNum)
            {
                Console.WriteLine("Too high of a number!"); //Check if the number is within your range of correct numbers.
                success = false;
            }
        }
        return output; //Once the while loop ends, it returns output.
    }
}