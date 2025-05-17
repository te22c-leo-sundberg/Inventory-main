
using System.Text.Json.Serialization;
class Character
{
    [JsonInclude] protected string Name;
    [JsonInclude] protected int Hp;
    [JsonInclude] protected int MaxHp;
    [JsonInclude] protected int MinAttack;
    [JsonInclude] protected int MaxAttack;
    public virtual int Attack() //Creates a virtual int for attack which can be overrode by subclasses to add onto this method.
    {
        return Random.Shared.Next(MinAttack, MaxAttack);
    }

    public string GetName() //Fetches the name in the form of a string
    {
        return Name;
    }
    public void SetName(string name)// Sets the name based on the string put in the method
    {
        Name = name;
    }
    public void SetHealth(int additionalHealth) //Adds the int put in the method on top of health. If health is above max health, reduces it to max health. Also writes out the interaction.
    {

        if (Hp + additionalHealth > MaxHp)
        {
            Console.WriteLine(GetName() + " is at full health.");
            Hp = MaxHp;
        }
        else
        {
            Console.WriteLine(GetName() + " healed " + additionalHealth + " health.");
            Hp += additionalHealth;
        }
    }
    public void TakeDamage(int damage) //Same as the one above except it subtracts. Cannot go below 0 in health.
    {
        Console.WriteLine(damage);
        if (Hp - damage < 0)
        {
            Console.WriteLine(GetName() + " died.");
            Hp = 0;
        }
        else
        {
            Hp -= damage;
            Console.WriteLine(GetName() + " now has " + Hp + " health left.");
        }
    }
    public int GetHealth() //Returns health in the form of an integer
    {
        return Hp;
    }

}