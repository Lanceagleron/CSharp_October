// See https://aka.ms/new-console-template for more information

string place = "Coding Dojo";


Console.WriteLine($"Hello world from {place}");

Random rand = new Random();
for(int val = 0; val < 1; val++)
{
    //Prints the next random value between 2 and 8
    Console.WriteLine($"this is a random number {rand.Next(2,8)}");
}

Console.WriteLine("**************");

int numRings = 5;
if (numRings >= 5)
{
    Console.WriteLine("You are welcome to join the party");
}
else if (numRings > 2)
{
    Console.WriteLine($"Decent...but {numRings} rings aren't enough");
}
else
{
    Console.WriteLine("Go win some more rings");
}

Console.WriteLine("**************");

string name = "Kobe";
if (numRings >= 5 && name == "Kobe")
{
  Console.WriteLine($"Welcome to the party {name}, congratulations on your {numRings} championships!");
}

Console.WriteLine("**************");

//loops

// loop from 1 to 5 including 5
for (int i = 1; i <= 5; i++)
{
    Console.WriteLine(i);
}

Console.WriteLine("**************");

// loop from 1 to 5 excluding 5
for (int i = 1; i < 5; i++)
{
    Console.WriteLine(i);
}

Console.WriteLine("**************");

int start = 0;
int end = 5;
// loop from start to end including end
for (int i = start; i <= end; i++)
{
    Console.WriteLine(i);
}
// loop from start to end excluding end
for (int i = start; i < end; i++)
{
    Console.WriteLine(i);
}

Console.WriteLine("**************");

int x = 1;
while (x < 6)
{
    Console.WriteLine(x);
    x = x + 1;
}

Console.WriteLine("**************");