using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VincentCustomAnalytics
{
  using Sitecore.Analytics.Aggregation.Pipelines.ContactProcessing;
  using Sitecore.ContentSearch;
  using Sitecore.ContentSearch.Analytics.Aggregators;
  using Sitecore.ContentSearch.Analytics.Models;

  public class VincentContactChangeContactAggregator : ContactChangeContactAggregator
  {
    public VincentContactChangeContactAggregator(string name)
            : base(name)
        {
        }

        protected override IEnumerable<IContactIndexable> ResolveIndexables(ContactProcessingArgs args)
        {
            if (args == null)
                throw new ArgumentNullException("args");
              var reason  = this.GetChangeEventReason(args);
          if (args.ContactId == EmptyGuid.Value)
          {
            yield return new ContactChangeIndexable((IIndexableUniqueId)new Sitecore.ContentSearch.IndexableUniqueId<Guid>(args.ContactId.Guid), reason); 
          }
          else
          {
            var result = base.ResolveIndexables(args);
            foreach (var a in result)
              yield return a;
          }                                                                                                                                              
        }
  }
}
