using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeOnItemSaveHandler
{
  using System.IO;

  public class FakeOnItemSave2
  {
    private static int _times = 0;
      public void OnItemSave(object e, EventArgs ea)
      {
        _times += 1;
        System.Diagnostics.Debug.WriteLine(string.Format("OnItemSave2 is being called {0:N} times", _times));
        throw new ArgumentException();
      }
    }
}
