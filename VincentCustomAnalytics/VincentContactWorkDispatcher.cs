using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VincentCustomAnalytics
{
  using Sitecore.Analytics.Aggregation.Data.Contact;
  using Sitecore.Analytics.Data;

  public class VincentContactWorkDispatcher : ContactWorkDispatcher
  {
    public override bool TryGetNext(out ContactWorkItem workItem)
    {
      workItem = new ContactWorkItem(EmptyGuid.Value.Guid, ProcessingReason.Updated);

      return true; 
    }

    public override void MarkProcessed(ContactWorkItem item)
    {
      
    }
  }
}
