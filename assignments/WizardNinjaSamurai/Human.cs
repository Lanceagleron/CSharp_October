public class Human
{
    // Properties for Human
    public string Name {get; set;}
    public int Strength {get; set;}
    public int Intelligence {get; set;}
    public int Dexterity {get; set;}
    public int Health {get; set;}
    // Add a constructor that takes a value to set Name, and set the remaining fields to default values
    public Human (string name, int strength, int intelligence, int dexterity, int health)
    {
        Name = name;
        Strength = strength;
        Intelligence = intelligence;
        Dexterity = dexterity;
        Health = health;
    }
    // Add a constructor to assign custom values to all fields
    public Human(string name)
    {
        Name = name;
        Strength = 3;
        Intelligence = 3;
        Dexterity = 3;
        Health = 100;
    }
    // Build Attack method
    
    public virtual int Attack(Human target)
    {
        int damage = Strength * 3;
        target.Health -= damage;
        Console.WriteLine($"{Name} attacked {target.Name} for {damage} damage!");
        return target.Health;
    }
}

