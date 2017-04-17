using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
  using System.Collections.ObjectModel;
  using System.Data;
  using System.Security.Cryptography.X509Certificates;

  class SimulateEnumerable
  {
    static void Main(string[] args)
    {
      var employee1 = getEmployeEnumerable();
      var employee2 = getEmployeEnumerable2();

      if (employee1.Any())
      {
        Console.WriteLine("Has employee1");
      }

      if (employee2.Any())
      {
        Console.WriteLine("Has employee2");
      }
      Console.ReadLine();
    }

    private static IEnumerable<string> getEmployeEnumerable()
    {
      var employees = new Collection<string>()
      {
        "vincent",
        "meng han"
      };
      foreach (var employee in employees)
      {
        yield return employee;
      }
    }

        private static IEnumerable<string> getEmployeEnumerable2()
        {
          var employee = new Collection<string>()
          {
            "vincent",
            "meng han"
          };

          if (employee.Count > 2)
          {
            yield return "1";
          }
        }
  }
}
