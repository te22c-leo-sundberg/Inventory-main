class ManaConsumable : Consumable
{
    public ManaConsumable() { }
    public ManaConsumable(string name, int maxUses, float conStr)
    {
        Name = name;
        MaxUses = maxUses;
        CurrentUses = maxUses;
        ConsumableStrength = conStr;
    }
    public void UseManaConsumable(Player target)//Gets the players mana, then sets the players mana to the fetched mana plus the 10 the potion gives.
    {
        if (CurrentUses > 0)
        {
            target.SetMana(target.GetMana() + 10);
            CurrentUses--;
        }
    }
}