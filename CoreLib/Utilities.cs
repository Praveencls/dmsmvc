using System;
using System.Collections.Specialized;
using System.Text;
using Sitecore.Web.UI.HtmlControls;
using Page = System.Web.UI.Page;

namespace CoreLib
{
    //http://getfishtank.ca/blog/sublayout-driven-javascript-in-sitecore
    public class Utilities
    {
        public static void AddJS(Page page, string url, string receivingControlId = "JsPlaceholder")
        {
            AddJS(page, url, new NameValueCollection(), receivingControlId);
        }
        public static void AddJS(Page page, string url, NameValueCollection nvc, string receivingControlId = "JsPlaceholder")
        {
            if (page == null || String.IsNullOrEmpty(url) || nvc == null || String.IsNullOrEmpty(receivingControlId)) return;
            var attributeBuilder = new StringBuilder();
            foreach (var key in nvc.AllKeys)
            {
                attributeBuilder.AppendFormat(" {0}={1}", key, nvc[key]);
            }
            var script = String.Format("<script src=\"{0}\" {1} type=\"text/javascript\"></script>", url, attributeBuilder);
            page.FindControl(receivingControlId).Controls.Add(new Literal(script));
        }
    }
}
