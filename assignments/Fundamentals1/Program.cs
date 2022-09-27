// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


// int start = 1;
// int end = 255;
// while (start <= end)
// {
//     Console.WriteLine(start);
//     start = start + 1;
// }

Console.WriteLine("**************");

string fizz = "fizz";
string buzz = "buzz";

for (int i = 1; i<=100; i++)
{
    if (i % 3 == 0)
    {
        Console.WriteLine(fizz);
    }
    else if (i % 5 == 0)
    {
        Console.WriteLine(buzz);
    }
    else
    Console.WriteLine(i);
}

