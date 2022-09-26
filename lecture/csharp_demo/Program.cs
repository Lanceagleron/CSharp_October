string word = "hello C#!";
int number = 33;
double pi = 3.1415;
bool is_Lie = false;

Console.WriteLine(word);

int [] arr = new int[7]; 
int count = 0;
for (int i = 0; i < arr.Length; i++){
    arr[i] = count;
    count++;
    Console.WriteLine(arr[i]);
}

List<string> names = new List<string>();
names.Add("Collin");
names.Add("Nicholas");
names.Add("Toni Montana");

Console.WriteLine(names[1]);

Dictionary<int, string> candies = new Dictionary<int, string>();
candies.Add(1,"Sneakers Peanut");
candies.Add(2,"Kit-Kat");
candies.Add(3,"Nerds");

Console.WriteLine("Candy#2" + candies[2]);

foreach(KeyValuePair<int, string> entry in candies){
    Console.WriteLine(entry.Key + " : " + entry.Value);
}

static void hihi(){
    Console.WriteLine("Hello C#");
}

hihi();