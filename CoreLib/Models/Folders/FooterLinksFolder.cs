using CoreLib.Interface.Folders;
using CoreLib.Models.Base;
using Glass.Mapper.Sc.Configuration.Attributes;

namespace CoreLib.Models.Folders
{
    [SitecoreType(TemplateId = "4aebcef2-11c9-4134-912f-550f73baa317", AutoMap = true)]
    public partial class FooterLinksFolder : GlassBase, IFooterLinksFolder
    {
    }
}
