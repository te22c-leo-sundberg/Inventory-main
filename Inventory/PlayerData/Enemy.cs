using System.Text.Json.Serialization;
class Enemy : Character
{

    public override int Attack() //overrides the virtual attack in character to also do a write line for the monsters attack. 
    {
        int attack = base.Attack();
        Console.WriteLine(GetName() + " body slammed you for " + attack + " damage.");
        return attack;
    }

    public Enemy() { }

    public Enemy(string name, int hp, int minAttack, int maxAttack)
    {
        Name = name;
        Hp = hp;
        MinAttack = minAttack;
        MaxAttack = maxAttack;
    }
}
