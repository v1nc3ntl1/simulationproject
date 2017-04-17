using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomCloning
{
    using System.Collections.Specialized;
    using Sitecore.Install.Framework;

    public class CustomPostStep : Sitecore.Install.Framework.IPostStep
    {
        public void Run(ITaskOutput output, NameValueCollection metaData)
        {
            var metaDataString = new StringBuilder();

            if (metaData != null)
            {
                foreach (var key in metaData.AllKeys)
                {
                    metaDataString.AppendFormat("key : {0}, value : {1} \n", key, metaData[key]);
                }
            }
            
            output.Alert(string.Format("Custom Post step fired with metadata : {0}", metaDataString));
        }
    }
}
