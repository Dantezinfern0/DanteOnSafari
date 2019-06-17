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
            Console.WriteLine("Type in: Species, Location");
            input = Console.ReadLine();
          var data = input.Split(',');
          var newAnimal = new Animal
          {
            Species = data[0],
            LocationOfLastSeen = data[1]
          };
          // db.SafariVacation.Add(newAnimal);
          db.SaveChanges();
          Console.WriteLine($"Successfully Saved {newAnimal.Species}");

        }
      }
    }
  }
}
