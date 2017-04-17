using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyDLL
{
  public class Calculator
  {
    public virtual int Add(int a, int d)
    {
      return a + d;
    }
  }
}
