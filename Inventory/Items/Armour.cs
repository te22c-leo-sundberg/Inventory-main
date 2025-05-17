using System.Text.Json.Serialization;

class Armour : Item
{
    [JsonInclude] private float Protection;
    [JsonInclude] private float Speed;
    [JsonInclude] private int AttackBoost;
    public Armour() { }
    public Armour(string name, float weight, float prot, float speed, int atkBoost) //Constructor for armour class.
    {
        Name = name;
        Weight = weight;
        Protection = prot;
        Speed = speed;
        AttackBoost = atkBoost;
    }
}