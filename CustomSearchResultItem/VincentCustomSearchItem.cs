using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomSearchResultItem
{
    using Sitecore.ContentSearch;
    using Sitecore.ContentSearch.SearchTypes;

    public class VincentCustomSearchItem : SearchResultItem
    {
        [DateTimeFormatterAttribute(DateTimeFormatterAttribute.DateTimeKind.ServerTime)]
        [IndexField("AdvertPublishStart")]
        public DateTime PublishStart
        {
            get;
            set;
        }
    }
}
