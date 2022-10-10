static void randomArray()
{
    Random randNum = new Random();
    int[] randomArray = new int[10];
    int sum = randomArray[0];
    
    for (int i = 0; i < randomArray.Length; i++)
    {
        randomArray[i] = randNum.Next(5, 26);
        sum += randomArray[i];
    }

    foreach(int num in randomArray)
        {
            Console.WriteLine(num);
        }

    int min = randomArray[0];
    int max = randomArray[0];
    for (int j = 0; j < 10; j++)
    {
        if (randomArray[j] < min)
        {
            min = randomArray[j];
        }
        if (randomArray[j] > max)
        {
            max = randomArray[j];
        }
    }
    Console.WriteLine("[***********]");
    Console.WriteLine(min);
    Console.WriteLine("[***********]");
    Console.WriteLine(max);
    Console.WriteLine("[***********]");
    Console.WriteLine(sum);
    Console.WriteLine("[***********]");
}

randomArray();
Console.WriteLine("--------------------------------------------------------");

static void CoinFlip()
{
    Random rand = new Random();
    string postResults = "";
    int flip = rand.Next(1, 3);
    {
        if (flip == 1)
        {
            postResults = "heads";
        }
        if (flip == 2)
        {
            postResults = "tails";
        }
    }
    Console.WriteLine(postResults);
}

CoinFlip();
Console.WriteLine("--------------------------------------------------------");

static void Names()
{
    string[] nameArray = { "Todd", "Tiffany", "Charlie", "Geneva", "Sydney" };
    Random rand = new Random();
    String temp = "";
    for (int i = 0; i < nameArray.Length; i++)
    {

        int index = rand.Next(i, nameArray.Length);
        temp = nameArray[i];
        nameArray[i] = nameArray[index];
        nameArray[index] = temp;
        Console.WriteLine("Index {0} has {1}", i, nameArray[i]);

    }
    List<string> longNamesList = new List<string>();
    for (int i = 0; i < nameArray.Length; i++)
    {
        if (nameArray[i].Length > 5)
        {
            longNamesList.Add(nameArray[i]);
        }
    }
    string[] longNames = longNamesList.ToArray();
    for (int i = 0; i < longNames.Length; ++i)
    {
        System.Console.WriteLine(longNames[i]);
    }
    Console.WriteLine(longNames);
}

Names();
Console.WriteLine("--------------------------------------------------------");