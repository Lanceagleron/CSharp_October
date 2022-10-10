List<Eruption> eruptions = new List<Eruption>()
{
    new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
    new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
    new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
    new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
    new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
    new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
    new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
    new Eruption("Santorini", 46,"Greece", 367, "Shield Volcano"),
    new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
    new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
    new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
    new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
    new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
};
// Example Query - Prints all Stratovolcano eruptions
// IEnumerable<Eruption> stratovolcanoEruptions = eruptions.Where(c => c.Type == "Stratovolcano");
// PrintEach(stratovolcanoEruptions, "Stratovolcano eruptions.");
// Execute Assignment Tasks here!
 
// Helper method to print each item in a List or IEnumerable.This should remain at the bottom of your class!
static void PrintEach(IEnumerable<dynamic> items, string msg = "")
{
    Console.WriteLine("\n" + msg);
    foreach (var item in items)
    {
        Console.WriteLine(item.ToString());
    }
}

// Use LINQ to find the first eruption that is in Chile and print the result.
Eruption? firsteruption = eruptions.FirstOrDefault(e => e.Location == "Chile");

Console.WriteLine(firsteruption);

Console.WriteLine("***************************************************************************");

// Find the first eruption from the "Hawaiian Is" location and print it. If none is found, print "No Hawaiian Is Eruption found."
Eruption? hawaiiEruptions = eruptions.FirstOrDefault(e => e.Location == "Hawaiial Is");
if(hawaiiEruptions != null)
{
    Console.WriteLine(hawaiiEruptions);
}
else
{
    Console.WriteLine("No Hawaiian Is Eruption found.");
}

Console.WriteLine("***************************************************************************");

// Find the first eruption that is after the year 1900 AND in "New Zealand", then print it.
Eruption? firsteruptioninnewzealand = eruptions.FirstOrDefault(e => e.Location == "New Zealand");

Console.WriteLine(firsteruptioninnewzealand);

Console.WriteLine("***************************************************************************");

// Find all eruptions where the volcano's elevation is over 2000m and print them.

List<Eruption> filteredvolcanoes = eruptions.OrderByDescending(e => e.Location).ToList();

filteredvolcanoes = eruptions.Where(e => e.ElevationInMeters >= 2000).ToList();

PrintEach(filteredvolcanoes);

Console.WriteLine("***************************************************************************");

// Find all eruptions where the volcano's name starts with "L" and print them. Also print the number of eruptions found.

var total = 0;
filteredvolcanoes = eruptions.Where(e => e.Volcano.StartsWith("L")).ToList();

total = filteredvolcanoes.Count(e => e.Volcano.StartsWith("L"));


PrintEach(filteredvolcanoes);
Console.WriteLine($"total num = {total}");
Console.WriteLine("***************************************************************************");

// Find the highest elevation, and print only that integer (Hint: Look up how to use LINQ to find the max!)

// Eruption? highestelevation = eruptions.FirstOrDefault(e => e.ElevationInMeters == eruptions.Max(e => e.ElevationInMeters));
var maxelevation = eruptions.Max(e => e.ElevationInMeters);

// Console.WriteLine(highestelevation);
Console.WriteLine($"highest elevation is {maxelevation}");

Console.WriteLine("***************************************************************************");

// Use the highest elevation variable to find a print the name of the Volcano with that elevation.
Eruption? highestelevation = eruptions.FirstOrDefault(e => e.ElevationInMeters == eruptions.Max(e => e.ElevationInMeters));
Console.WriteLine(highestelevation);

Console.WriteLine("***************************************************************************");

// Print all Volcano names alphabetically.
filteredvolcanoes = eruptions.OrderBy(e => e.Volcano).ToList();
PrintEach(filteredvolcanoes);

Console.WriteLine("***************************************************************************");

// Print all the eruptions that happened before the year 1000 CE alphabetically according to Volcano name.
filteredvolcanoes = eruptions.Where(e => e.Year < 1000).OrderBy(e => e.Volcano).ToList();

PrintEach(filteredvolcanoes);

Console.WriteLine("***************************************************************************");
// BONUS: Redo the last query, but this time use LINQ to only select the volcano's name so that only the names are printed.
var nameofvolcanoes = eruptions.Where(e => e.Year < 1000).Select(e => e.Volcano).OrderBy(volcano => volcano).ToList();
PrintEach(nameofvolcanoes);
