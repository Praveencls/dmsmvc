using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sitecore.Pipelines.ExpandInitialFieldValue;

namespace CoreLib
{
    //http://sitecore-scribbles.blogspot.in/2012/02/sitecore-custom-token-for-display-name.html

    public class DisplayNameToken : ExpandInitialFieldValueProcessor
    {
        public override void Process(ExpandInitialFieldValueArgs args)
        {
            if (args.SourceField.Value.Contains("$displayname"))
            {
                args.Result = args.TargetItem.Name.ToTitleCase();
            }
        }
    }
}
