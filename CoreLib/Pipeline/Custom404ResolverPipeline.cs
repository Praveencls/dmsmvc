using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Pipelines.HttpRequest;

namespace CoreLib.Pipeline
{
    //http://briancaos.wordpress.com/2013/03/21/sitecore-404-without-302/
    /*
     The processor is added just after the ItemResolver. The ItemResolver returns null if the item is not found.
     We then switch the missing item with our 404 item:
     */
    public class Custom404ResolverPipeline : HttpRequestProcessor
    {
        public override void Process(HttpRequestArgs args)
        {
            Assert.ArgumentNotNull(args, "args");

            // Do nothing if the item is actually found
            if (Sitecore.Context.Item != null || Sitecore.Context.Database == null)
            return;

            // all the icons and media library items
    // for the sitecore client need to be ignored
            if (args.Url.FilePath.StartsWith("/-/"))
              return;

            // Get the 404 not found item in Sitecore.
            // You can add more complex code to get the 404 item
            // from multisite solutions. In a production
            // environment you would probably get the item from
            // your website configuration.
            Item notFoundPage = Sitecore.Context.Database.GetItem("{DA2788DA-B560-41FE-981B-325215BE5381}");
            if (notFoundPage == null)
              return;

            // Switch to the 404 item
            Sitecore.Context.Item = notFoundPage;
        }
    }
}
