public class Ninja : Human
{

    public Ninja(string name) : base(name)
    {
        Dexterity = 75;
    } 
    
    public override int Attack(Human target)
    {
        Random rand = new Random();
        int damage = Dexterity;
        if(rand.Next(10) < 2)
        {
            damage +=10;
        }
        target.Health -= damage;
        if(target.Health <=0)
        {
            target.Health =0;
        }
        Console.WriteLine($"{Name} attacked {target.Name} for {damage} damage!");
        return target.Health;
    }

    public virtual int Steal(Human target)
    {
        int damage = 5;
        target.Health -= damage;
        Health += damage;
        Console.WriteLine($"{Name} Stole HP from {target.Name} for {damage} HP!");
        return target.Health;
    }
}