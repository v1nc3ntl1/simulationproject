using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulateGetChildren
{
  using System.Diagnostics;
  using Sitecore.Collections;
  using Sitecore.Data;
  using Sitecore.Data.Items;
  using Sitecore.Diagnostics;
  using Sitecore.Links;

  public class ItemSimulation
    {
      public void ListItemChildren()
      {
        Database masterDatabase = Sitecore.Configuration.Factory.GetDatabase("master");
        if (masterDatabase != null)
        {
          //Get Item nm1124 
          Item nm1124Item = masterDatabase.GetItem(new ID("{91594D09-E4C0-458D-8C3E-3FD60413D352}"));

          if (nm1124Item != null)
          {
            ChildList children = nm1124Item.GetChildren();

            if (children != null && children.Count > 0)
            {
              this.Log(string.Format("Listing Item : {0}{{{1}}} \nListing Children :", nm1124Item.Name, nm1124Item.ID.ToString()));
              foreach (Item child in children)
              {
                this.Log(string.Format("\t\tChild Item : {0}{{{1}}} [{2}]", child.Name, child.ID.ToString(), LinkManager.GetItemUrl(child)));
              }
            }
          }
        }
      }

      public void Log(string message)
      {
        StackTrace st = new StackTrace();
        StackFrame sf = st.GetFrame(0);
        
        message = string.Format("{0}.{1} | {2} \n", this.GetType().FullName, sf.GetMethod().Name, message);
        Sitecore.Diagnostics.Log.Debug(message);
      }
    }
}
