using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DependencyDLL;

namespace ConsoleApplication2
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.Write("2 + 3 = " + new Calculator().Add(2, 3));
      Console.ReadLine();
    }
  }
}
