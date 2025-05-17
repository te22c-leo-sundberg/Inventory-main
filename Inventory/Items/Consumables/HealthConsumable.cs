class HealthConsumable : Consumable
{
    public HealthConsumable() { }
    public HealthConsumable(string name, float weight, int maxUses, float conStr)
    {
        Name = name;
        Weight = weight;
        MaxUses = maxUses;
        CurrentUses = maxUses;
        ConsumableStrength = conStr;
    }
    public void UseHealthConsumable(Player target) //Gets the players health, then sets the players health to the fetched health plus the 10 the potion heals.
    {
        if (CurrentUses > 0)
        {
            target.SetHealth(target.GetHealth() + 10);
            CurrentUses--;
        }
    }
}