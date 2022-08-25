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
IEnumerable<Eruption> stratovolcanoEruptions = eruptions.Where(c => c.Type == "Stratovolcano");
PrintEach(stratovolcanoEruptions, "Stratovolcano eruptions.");
// Execute Assignment Tasks here!

//Use LINQ to find the first eruption that is in Chile and print the result.
Eruption? chilevolcanoEruptions = eruptions.FirstOrDefault(c => c.Location == "Chile");

if(chilevolcanoEruptions != null)
{
    Console.WriteLine($"Chile volcano eruptions are {chilevolcanoEruptions}");
}

//Find the first  eruption from the "Hawaiian Is" location and print it. If none is found, print "No Hawaiian Is Eruption found."
Eruption? hawaiianEruption = eruptions.FirstOrDefault(c => c.Location == "Hawaiian Is");

if(hawaiianEruption != null)
{
    Console.WriteLine($"Hawaiin eruptions are {hawaiianEruption.Volcano}");
}
else
    Console.WriteLine( "No HawaiianIs Eruption found.");


//Find the first eruption that is after the year 1900 AND in "New Zealand", then print it.
Eruption? newZealandEruption = eruptions.FirstOrDefault(c => c.Year > 1900 && c.Location == "New Zealand");
if(newZealandEruption != null)
{
    Console.WriteLine($"New zealnad eruptions are :{newZealandEruption}");
}

//Find all eruptions where the volcano's elevation is over 2000m and print them.
IEnumerable<Eruption> allEruptions = eruptions.Where(c => c.ElevationInMeters > 2000);

foreach(Eruption e in allEruptions)
{
    Console.WriteLine($"Volcanoes greater than 2000m elevation are: {e}");
}


//Find all eruptions where the volcano's name starts with "Z" and print them.
IEnumerable<Eruption> zEruptions = eruptions.Where(c => c.Volcano.StartsWith("Z")).ToList();
foreach(Eruption z in zEruptions)
{
    Console.WriteLine(z.Volcano);
}

//Find the highest elevation, and print only that integer (Hint: Look up how to use LINQ to find the max!)

IEnumerable<Eruption> highElevation = eruptions.OrderByDescending(c => c.ElevationInMeters);

int highest = eruptions.Max(c => c.ElevationInMeters);

Eruption? highestElevation = eruptions.FirstOrDefault(c => c.ElevationInMeters == highest);

if(highestElevation != null)
{
    Console.WriteLine( $" highest elevation is : {highestElevation.ElevationInMeters.ToString()}" );
}

//Use the highest elevation variable to find a print the name of the Volcano with that elevation.
IEnumerable<Eruption> high1Elevation = eruptions.OrderByDescending(c => c.ElevationInMeters);

int highest1 = eruptions.Max(c => c.ElevationInMeters);

Eruption? highestElevation1 = eruptions.FirstOrDefault(c => c.ElevationInMeters == highest1);

if(highestElevation1 != null)
{
    Console.WriteLine($"Volcano with highest elevation is :{highestElevation1.Volcano.ToString()}");
}

//Print all Volcano names alphabetically.
IEnumerable<Eruption> alphaEruptions = eruptions.OrderBy(c => c.Volcano);

Console.WriteLine("All volcanoes alphabetically are :");
foreach(Eruption alpha in alphaEruptions)
{
    
    Console.WriteLine(alpha.Volcano);
}


//Print all the eruptions that happened before the year 1000 CE alphabetically according to Volcano name.
IEnumerable<Eruption> a1Eruptions = eruptions.Where(c => c.Year < 1000).OrderBy(c => c.Volcano);
foreach(Eruption a1 in a1Eruptions)
{
    Console.WriteLine(a1.Volcano);
}

// Helper method to print each item in a List or IEnumerable.This should remain at the bottom of your class!
static void PrintEach(IEnumerable<dynamic> items, string msg = "")
{
    Console.WriteLine("\n" + msg);
    foreach (var item in items)
    {
        Console.WriteLine(item.ToString());
    }
}
