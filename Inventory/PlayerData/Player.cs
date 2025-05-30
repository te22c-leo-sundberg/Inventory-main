using System.Text.Json.Serialization;
class Player : Character
{
    int Mana;
    float CarryCapacity;
    float CurrentCarryWeight;
    public int GetMana()
    {
        return Mana;
    }
    public void SetMana(int mana)
    {
        Mana = mana;
    }
    public override int Attack() //Overrides the character virtual int to also double the attack int generated from it, then says a text for how much damage you dealt.
    {
        int attack = base.Attack() * 2;
        Console.WriteLine(GetName() + " swung their sword at the monster for " + attack + " damage.");
        return attack;
    }
    public Player(string name, int hp, int mana, float carryCap, int minAttack, int maxAttack)
    {
        Name = name;
        Hp = hp;
        MaxHp = hp;
        Mana = mana;
        CarryCapacity = carryCap;
        CurrentCarryWeight = 0;
        MinAttack = minAttack;
        MaxAttack = maxAttack;
    }

    public bool CanPickUp(float target) //Checks if the player has enough capacity to pick an item up, this is unused and old though.
    {
        if (CurrentCarryWeight + target > CarryCapacity)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}