class Inventory
{

    public List<Item> Items = [];
    public List<Consumable> Consumables = [];
    public void Display()
    {
        Console.WriteLine("Your inventory contains:");
        for (int i = 0; i < Items.Count; i++)
        {
            Console.WriteLine($"{i}) {Items[i].Name}");
        }
    }
    public void WeightCheck()
    {
        float n = Items.Sum(item => item.Weight);
        Console.WriteLine(n);
    }
    public bool AddItem(Item item, float capacity)
    {
        float n = Items.Sum(item => item.Weight);
        if (n + item.Weight > capacity)
        {
            return false;
        }
        else
        {
            Items.Add(item);
            return true;
        }
    }
    public void Discard()
    {
        Display();
        int n = GetInt("What item would you like to discard?");
        Console.WriteLine($"Discarded {Items[n].Name}");
        Items.RemoveAt(n);
    }
    int GetInt(string text)
    {
        Console.WriteLine(text);
        int output = 0;
        bool success = false;
        while (!success)
        {
            string input = Console.ReadLine();
            success = int.TryParse(input, out output);
            if (output < 0)
            {
                Console.WriteLine("Too low of a number!");
                success = false;
            }
            else if (output >= Items.Count)
            {
                Console.WriteLine("Too high of a number!");
                success = false;
            }
        }
        return output;
    }
}