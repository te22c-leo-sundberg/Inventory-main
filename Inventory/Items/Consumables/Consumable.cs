using System.Text.Json.Serialization;

class Consumable : Item
{
    [JsonInclude] public int MaxUses;
    [JsonInclude] public int CurrentUses;
    [JsonInclude] public float ConsumableStrength;

}