using System.Text.Json.Serialization;

abstract class Item : Inventory
{
    [JsonInclude] public string Name;
    [JsonInclude] public float Weight;
}