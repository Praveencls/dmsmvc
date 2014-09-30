using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Pipelines.RenderField;

namespace CoreLib.Pipeline
{
    //http://briancaos.wordpress.com/2011/03/13/creating-fallback-values-using-the-renderfield-pipeline/
    public class GetFallbackValue
    {
        public void Process(RenderFieldArgs args)
        {
            Assert.ArgumentNotNull(args, "args");
            if (args.Result.FirstPart == string.Empty && Sitecore.Context.Site.DisplayMode != Sitecore.Sites.DisplayMode.Edit)
                args.Result.FirstPart = FallbackValue(args.Item, args.FieldName.ToLower(), "en");
        }

        private string FallbackValue(Item item, string fieldName, string fallbackLanguage)
        {
            Item fallbackItem = item.Database.GetItem(item.ID, Sitecore.Globalization.Language.Parse(fallbackLanguage));
            return fallbackItem[fieldName];
        }
     }
}
