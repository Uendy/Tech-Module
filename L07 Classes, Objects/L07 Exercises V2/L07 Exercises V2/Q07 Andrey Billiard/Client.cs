using System.Collections.Generic;
public class Client
{
    public string Name { get; set; }
    public Dictionary<string, int> ShoppingList { get; set; } //key = productName value = quantity bought
    public double Bill { get; set; }
}