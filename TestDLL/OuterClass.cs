using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDLL
{
  public class OuterClass
  {
    public class InnerClass
    {
      public string Method1()
      {
        return "Method1";
      }

      public static string Method2()
      {
        return "Method2";
      }
    }
  }
}
