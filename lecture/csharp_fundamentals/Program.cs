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

//array
// Declaring an array of length 5, initialized by default to all zeroes
int[] numArray = new int[5];
// Declaring an array with pre-populated values
// For Arrays initialized this way, the length is determined by the size of the given data
int[] numArray2 = {1,2,3,4,6};

//Accessing Arrays
//Arrays are zero-indexed. This means that the first value within an array is stored at index 0. The second value within an Array resides at index 1, and so on.  

int[] arrayOfInts = {1, 2, 3, 4, 5};
Console.WriteLine(arrayOfInts[0]);    // The first number lives at index 0.
Console.WriteLine(arrayOfInts[1]);    // The second number lives at index 1.
Console.WriteLine(arrayOfInts[2]);    // The third number lives at index 2.
Console.WriteLine(arrayOfInts[3]);    // The fourth number lives at index 3.
Console.WriteLine(arrayOfInts[4]);    // The fifth and final number lives at index 4.

Console.WriteLine("**************");

string[] myCars = new string[] { "Mazda Miata", "Ford Model T", "Dodge Challenger", "Nissan 300zx"};
// The 'Length' property tells us how many values are in the Array (4 in our example here). 
// We can use this to determine where the loop ends: Length-1 is the index of the last value. 
for (int idx = 0; idx < myCars.Length; idx++)
{
    Console.WriteLine($"I own a {myCars[idx]}");
}

Console.WriteLine("**************");

//foreach
foreach (string car in myCars)
{
    // We no longer need the index, because variable 'car' already represents each indexed value
    Console.WriteLine($"I own a {car}");
}

Console.WriteLine("**************");

//list
//Initializing an empty list of Motorcycle Manufacturers
List<string> bikes = new List<string>();
//Use the Add function in a similar fashion to push
bikes.Add("Kawasaki");
bikes.Add("Triumph");
bikes.Add("BMW");
bikes.Add("Moto Guzzi");
bikes.Add("Harley Davidson");
bikes.Add("Suzuki");
//Accessing a generic list value is the same as you would an array
Console.WriteLine(bikes[2]); //Prints "BMW"
Console.WriteLine($"We currently know of {bikes.Count} motorcycle manufacturers.");

Console.WriteLine("**************");

//itereate through a list 
//Using our list of motorcycle manufacturers from before
//we can easily loop through the list of them with a C-style for loop
//this time, however, Count is the attribute for a number of items.
Console.WriteLine("The current manufacturers we have seen are:");
for (var idx = 0; idx < bikes.Count; idx++)
{
    Console.WriteLine("-" + bikes[idx]);
}
// Insert a new item between a specific index
bikes.Insert(2, "Yamaha");
//Removal from Generic List
//Remove is a lot like Javascript array pop, but searches for a specified value
//In this case we are removing all manufacturers located in Japan
bikes.Remove("Suzuki");
bikes.Remove("Yamaha");
bikes.RemoveAt(0); //RemoveAt has no return value however
//The updated list can then be iterated through using a foreach loop
Console.WriteLine("List of Non-Japanese Manufacturers:");
foreach (string manu in bikes)
{
    Console.WriteLine("-" + manu);
}

Console.WriteLine("**************");

//dictionary
Dictionary<string,string> profile = new Dictionary<string,string>();
//Almost all the methods that exists with Lists are the same with Dictionaries
profile.Add("Name", "Speros");
profile.Add("Language", "PHP");
profile.Add("Location", "Greece");
Console.WriteLine("Instructor Profile");
Console.WriteLine("Name - " + profile["Name"]);
Console.WriteLine("From - " + profile["Location"]);
Console.WriteLine("Favorite Language - " + profile["Language"]);

Console.WriteLine("**************");

foreach (KeyValuePair<string,string> entry in profile)
{
    Console.WriteLine(entry.Key + " - " + entry.Value);
}

Console.WriteLine("**************");

//The var keyword takes the place of a type in type-inference
foreach (var entry in profile)
{
    Console.WriteLine(entry.Key + " - " + entry.Value);
}

//function
static void SayHello()
{
    Console.WriteLine("Hello how are you doing today?");
}
SayHello();

Console.WriteLine("**************");
//function parameters

static void SayHello2(string firstName)
{
    Console.WriteLine($"Hello, {firstName}, how are you doing today?");
}

SayHello2("Andrew");


Console.WriteLine("**************");

//function with default parameter value

static void SayHello3(string firstName = "buddy")
{
    Console.WriteLine($"Hey {firstName}");
}
// We can call it without providing any arguments and the default value will be used...
SayHello3();
// ...or we can call it with an argument and that argument's value will be used
SayHello3("Yoda");

Console.WriteLine("**************");

static string SayHello4(string firstName = "buddy")
{
    return $"Hey {firstName}";
}
string greeting;
greeting = SayHello4();
Console.WriteLine(greeting);