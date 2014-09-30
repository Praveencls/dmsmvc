using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Sitecore;
using Sitecore.Diagnostics;
using Sitecore.Resources.Media;

namespace CoreLib.Pipeline
{
    public class ExtendedMediaRequestHandler : MediaRequestHandler
    {
        protected override bool DoProcessRequest(System.Web.HttpContext context)
        {
            Assert.ArgumentNotNull(context, "context");

            // If we're in a Sitecore internal site (admin, shell etc),
            // then use the base MediaRequestHandler
            if (Sitecore.Context.Domain.Name == "sitecore")
                return base.DoProcessRequest(context);

            MediaRequest request = MediaManager.ParseMediaRequest(context.Request);

            // By default Sitecore will get the first matching 
            // item regardless of the file extension.
            var mediaPath = request.MediaUri.MediaPath;
            var firstGuess = Context.Database.GetItem(mediaPath);

            if (firstGuess == null)
                return false;

            string urlExtenstion = GetFileExtension(context.Request.RawUrl).ToLower();

            // if the extension of the first guess item is 
            // incorrect, then we have some work to do.
            if (firstGuess["Extension"].ToLower() != urlExtenstion)
            {
                // Check if any of the matched item's siblings have
                // a matching path and file extension.
                var siblings = firstGuess.Parent.Children;

                var matches = siblings.Where(t=>t.Paths.Path ==firstGuess.Paths.Path && 
                    t.Fields["Extensioin"].Value.ToLower() == urlExtenstion).ToList();
                    
                    //from sibling in siblings
                    //          where firstGuess.Paths.Path == sibling.Paths.Path &&
                    //                sibling["Extension"].ToLower() == urlExtenstion
                    //          select ;

                if (!matches.Any())
                    return false;

                var selectedItem = matches.First();

                // Now we've identified the correct item, we can
                // reference it by ID rather than path.
                request.MediaUri.MediaPath = selectedItem.ID.ToString();
            }

            Media media = MediaManager.GetMedia(request.MediaUri);

            if (media == null)
                return false;

            return DoProcessRequest(context, request, media);
        }

        private string GetFileExtension(string rawUrl)
        {
            var extension = Path.GetExtension(rawUrl);
            if (extension.Contains('?'))
                extension = extension.Substring(0, extension.IndexOf('?'));

            extension = extension.TrimStart('.');
            return extension;
        }
    }
}
