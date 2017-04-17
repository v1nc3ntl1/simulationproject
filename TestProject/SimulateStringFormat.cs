using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
  using System.Collections.ObjectModel;
  using System.Data;
  using System.Linq.Expressions;
  using System.Security.Cryptography.X509Certificates;
  using TestDLL;

  class SimulateStringFormat
  {
    private static void Main(string[] args)
    {
      TestDLL.OuterClass.InnerClass a = new OuterClass.InnerClass();
      Console.WriteLine(a.Method1());
      Console.ReadLine();

      IIndexable value = null;
      Console.WriteLine(string.Format("value : {0}", value));
      value = new Indexable();
      Console.WriteLine(string.Format("value : {0}", value.Value));
      Console.ReadLine();

      try
      {
        try
        {
          int x = 0;
          int y = 10 / x;


        }
        catch (DivideByZeroException ex)
        {
          Console.WriteLine("inner");
          throw;
        }
      }
      catch (DivideByZeroException ex)
      {
        Console.WriteLine("outer");
      }
      Console.ReadLine();
    }

    public class Indexable : IIndexable
    {
      public object Value { get; set; } 
    }

    public interface IIndexable
    {
      object Value { get; set; }
    }
  }
}
