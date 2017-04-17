using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulateCost
{
  using System.Collections;
  using System.Collections.ObjectModel;
  using System.Security.Cryptography.X509Certificates;

  class Program
  {
    static void Main(string[] args)
    {
      string value = string.Empty;
      do
      {
        Console.WriteLine("Enter your selection : ");
        Console.WriteLine("Press (D) for Lazy loading. ");
        Console.WriteLine("Press (N) for Do object creation first. ");
        
        value = Console.ReadLine();
      }
      while (!string.Equals(value, "d", StringComparison.InvariantCultureIgnoreCase) && !string.Equals(value, "n", StringComparison.InvariantCultureIgnoreCase));

      if (string.Equals(value, "d", StringComparison.InvariantCultureIgnoreCase))
      {
        for (int counter = 0; counter < 10; counter++)
        {
          DoNormal();
          DoArrayList();
          DoList();
          DoLoop();
          Console.WriteLine();
        }
      } else if (string.Equals(value, "n", StringComparison.InvariantCultureIgnoreCase))
      {
        for (int counter = 0; counter < 10; counter++)
        {
          DoNormal();
          DoArrayList();
          DoList();
          DoLoop();
          Console.WriteLine();
        }
      }

      Console.ReadLine();
    }

    private static void DoLoop()
    {
      long startTick = DateTime.Now.Ticks;
      Collection<Exception> allExceptions = null;
      for (int counter = 0; counter < 10000; counter++)
      {
        if (allExceptions == null)
          allExceptions = new Collection<Exception>();

      }
      long endTick = DateTime.Now.Ticks;
      Console.WriteLine(string.Format("If else with 10000 loop takes {0:F4} of ticks of performance cost", (endTick - startTick)));
    }

    private static void DoNormal()
    {
      long startTick = DateTime.Now.Ticks;
      var allExceptions = new Collection<Exception>();
      long endTick = DateTime.Now.Ticks;

      Console.WriteLine(string.Format("Create collection object takes {0:F4} of ticks of performance cost", (endTick - startTick)));
    }

    private static void DoArrayList()
    {
      long startTick = DateTime.Now.Ticks;
      var allExceptions = new ArrayList();
      long endTick = DateTime.Now.Ticks;

      Console.WriteLine(string.Format("Create arraylist object takes {0:F4} of ticks of performance cost", (endTick - startTick)));
    }

    private static void DoList()
    {
      long startTick = DateTime.Now.Ticks;
      var allExceptions = new List<Exception>();
      long endTick = DateTime.Now.Ticks;

      Console.WriteLine(string.Format("Create List<Exception> object takes {0:F4} of ticks of performance cost", (endTick - startTick)));
    }
  }
}
