using System.Web;
using CoreLib.Models.ItemTypes;
using Glass.Mapper.Sc;
using Sitecore.Mvc.Helpers;
using Sitecore.Mvc.Presentation;

namespace website.ViewModel
{
    public class HomeViewModel : IRenderingModel
    {
        private ISitecoreContext _context = new SitecoreContext();

        private SitecoreHelper helper;

        public HtmlString BannerText
        {
            get
            {
                return helper.Field("Banner Text");
            }
        }

        #region IRenderingModel Members

        public void Initialize(Rendering rendering)
        {
            SiteRoot = _context.CreateType<SiteRoot>(rendering.Item);
            //helper = Sitecore.Mvc.Helpers.
        }

        #endregion IRenderingModel Members

        public string MyHello { get { return "Hello World"; } }

        public SiteRoot SiteRoot { get; set; }
    }
}