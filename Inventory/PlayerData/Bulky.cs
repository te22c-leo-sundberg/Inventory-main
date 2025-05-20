class Bulky : Enemy
{
    int minDefend;
    int maxDefend;
    public override int DamageTaken(int damage)
    {
        int damageReduced = Random.Shared.Next(minDefend, maxDefend);
        Console.WriteLine(Name + " has reduced " + damageReduced + " damage!");
        return base.DamageTaken(damage) - damageReduced;

    }
    public Bulky(string name, int hp, int minAttack, int maxAttack, int minDef, int maxDef)
    {
        Name = name;
        Hp = hp;
        MinAttack = minAttack;
        MaxAttack = maxAttack;
        minDefend = minDef;
        maxDefend = maxDef;
    }
}