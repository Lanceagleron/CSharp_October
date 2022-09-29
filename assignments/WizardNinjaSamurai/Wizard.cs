public class Wizard : Human
{
    public Wizard(string name) : base(name)
    {
        Health = 50;
        Intelligence = 25;
    }

    public override int Attack(Human target)
    {
        int damage = 3 * Intelligence;
        Health += damage;
        target.Health -= damage;
        Console.WriteLine($"{Name} attacked {target.Name} for {damage} damage!");
        return target.Health;
    }
    public virtual int Heal(Human target)
    {
        int heal = 3 * Intelligence;
        target.Health += heal;
        Console.WriteLine($"{Name} Healed {target.Name} for {heal} HP!");
        return target.Health;
    }
}