using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VincentCustomAnalytics
{
  using Sitecore.Data;
  using Sitecore.Shell.Framework.Commands;

  public static class EmptyGuid
  {
    public static readonly ID Value;

    static EmptyGuid()
    {
      Value = ID.NewID;
    }
  }
}
