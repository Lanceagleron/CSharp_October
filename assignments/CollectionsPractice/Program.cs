int [] array = {0,1,2,3,4,5,6,7,8,9};

string [] names = {"Tim", "Martin", "Nikki", "Sara"};

bool [] altBetweeenTandF = {true, false, true, false, true, false, true, false, true, false};



List<string> icecream = new List<string>();
icecream.Add("chocolate");
icecream.Add("strawberry");
icecream.Add("vanilla");
icecream.Add("cookiesncream");
icecream.Add("rockyroad");

foreach (string flavor in icecream)
{
    Console.WriteLine(flavor);
}

Console.WriteLine(icecream.Count);

Console.WriteLine("**************");

icecream.Remove(icecream[2]);

foreach (string flavor in icecream)
{
    Console.WriteLine(flavor);
}

Console.WriteLine(icecream.Count);

Console.WriteLine("**************");


for(int val = 0; val < icecream.Count; val++)
{

}

Dictionary<string , string> profile = new Dictionary<string , string>();
for(int i = 0;i < names.Length; i++)
{
    Random rand = new Random();
    int randomflavor = rand.Next(icecream.Count);
    profile.Add (names[i], icecream[randomflavor]);
}


foreach (KeyValuePair<string, string> entry in profile) {
    Console.WriteLine("User Name: {0} Flavor: {1}", entry.Key, entry.Value); // Print Username and Flavor for each dict entry
}

