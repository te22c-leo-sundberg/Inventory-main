using System;
using System.Numerics;
using System.Text.Json.Serialization;

class Weapon : Item
{
    [JsonInclude] private int MinDamage;
    [JsonInclude] private int MaxDamage;

    public int Attack() //Unused code, but it generates an int between min and max damage and returns it.
    {
        return Random.Shared.Next(MinDamage, MaxDamage);
    }

    public Weapon() { }

    public Weapon(string name, float weight, int MinDmg, int MaxDmg) //Constructor for armour class.
    {
        Name = name;
        Weight = weight;
        MinDamage = MinDmg;
        MaxDamage = MaxDmg;
    }
}