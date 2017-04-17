using Sitecore.ContentSearch.SearchTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.ContentSearch;

namespace CustomSearchResultItem
{
    public class SampleItemModel: SearchResultItem
    {
       
        [IndexField("title")]
        public string Title
        {
            get;
            set;
        }
    }
}
