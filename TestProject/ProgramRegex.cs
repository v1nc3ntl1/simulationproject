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
  using System.Text.RegularExpressions;

    class ProgramRegex
  {
    static void Main(string[] args)
    {
        var valuelists = new Collection<string>() { "/sitecore", "//sitecore", "//sitecore/home", "/sitecore/home", @"\\sitecore", @"\\sitecore\home" };

        var outputLists = new Dictionary<string, string>();
        foreach (var item in valuelists)
        {
            outputLists.Add(item, new Regex(@"^\/", RegexOptions.Compiled).Replace(item, @"\/"));
        }

        foreach (var item in outputLists)
        {
            Console.WriteLine("key : {0} , value : {1}\n", item.Key, item.Value);
        }

        Console.ReadLine();
    }
  }
}
