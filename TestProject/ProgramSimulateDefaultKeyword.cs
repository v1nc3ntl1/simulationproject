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

  class ProgramSimulateDefaultKeyword
  {
    static void Main(string[] args)
    {
      Console.WriteLine("default keyword of type long:" + default(long).ToString("N"));
      Console.ReadLine();
    }
  }

}
