public class Dragon
{
    public Dragon(string name, string type, int health, int damage, int armor)
    {
        Type = type;
        Name = name;
        Health = health;
        Damage = damage;
        Armor = armor;
    }

    public string Type { get; set; }

    public string Name { get; set; }

    public int Health { get; set; }

    public int Damage { get; set; }

    public int Armor { get; set; }
}