using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Events;
using Sitecore.SecurityModel;
using Sitecore.Rules;

namespace CoreLib.Rules
{
   public class ItemEventHander
    {
       protected void OnItemAdded(object sender, EventArgs args) {
           Assert.ArgumentNotNull(sender, "sender");
           Assert.ArgumentNotNull(args, "args");
           var item = Event.ExtractParameter(args, 0) as Item;
           if (item != null) {
               RunItemAddedRules(item);
           }
       }

       private static void RunItemAddedRules(Item item) { 
           RunRules(item, "/sitecore/system/Settings/Rules/DemoMVC/Item Added Rules");
       }

       private static void RunRules(Item item, string path)
       {
           Item item2;
           Assert.ArgumentNotNull(path, "path");
           using (new SecurityDisabler()) {
               item2 = item.Database.GetItem(path);
               if (item2 == null) {
                   return;
               }

               var context2 = new RuleContext
               {
                   Item = item
               };

               var ruleContext = context2;
               var rules = RuleFactory.GetRules<RuleContext>(item2, "Rule");
               if (rules != null) {
                   rules.Run(ruleContext);
               }
           }
       }
    }
}
