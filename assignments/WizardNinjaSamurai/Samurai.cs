public class Samurai : Human
{
    public Samurai(string name) : base (name)
    {
        Health = 200;
    }

    public override int Attack(Human target)
    {
        int damage = Strength * 3;
        if(target.Health <= 50)
        {
            damage = 50;
        }
        Console.WriteLine($"{Name} attacked {target.Name} for {damage} damage!");
        return target.Health;
    }

}