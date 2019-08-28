using System;
using System.Linq;

namespace DanteOnSafari
{
  class Program
  {
    static void Main(string[] args)
    {
      var input = "";
      var db = new SafariVacationContext();
      while (input != "quit")
      {
        Console.WriteLine("Do you want to (add) an Animal, (list) Animals you have seen, (update) information about an Animal, or (remove) an Animal from the list?");
        input = Console.ReadLine();
        if (input == "add")
        {
          Console.WriteLine("Type in: Species, How Many Times Seen, and  Location");
          input = Console.ReadLine();
          var data = input.Split(',');
          var newAnimal = new Animal
          {
            Species = data[0],
            CountOfTimesSeen = int.Parse(data[1]),
            LocationOfLastSeen = data[2]
          };
          db.SeenAnimals.Add(newAnimal);
          db.SaveChanges();
          Console.WriteLine($"Successfully Saved {newAnimal.Species}");
        }
        else if (input == "list")
        {
          Console.WriteLine("Here are your records");
          var allAnimals = db.SeenAnimals;
          foreach (var data in allAnimals)
          {
            Console.WriteLine($"{data.Species} seen in the {data.LocationOfLastSeen}, {data.CountOfTimesSeen} times");
          }
        }
        else if (input == "update")
        {

        }
        else if (input == "remove")
        {
          Console.WriteLine("Please Type in the Name of the Species you would like to Remove");
          input = Console.ReadLine();
          var dupe = db.SeenAnimals.FirstOrDefault(f => f.Species == input);
          if (dupe != null)
          {
            db.SeenAnimals.Remove(dupe);
            db.SaveChanges();
          }
        }
      }
    }
  }
}
