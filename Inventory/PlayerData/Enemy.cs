using System.Text.Json.Serialization;
class Enemy : Character
{

    public override int Attack()
    {
        Console.WriteLine(GetName() + " body scratched you for " + base.Attack() + " damage.");
        return base.Attack();
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
