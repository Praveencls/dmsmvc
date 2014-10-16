using CoreLib.Interface.Folders;
using CoreLib.Models.Base;
using Glass.Mapper.Sc.Configuration.Attributes;

namespace CoreLib.Models.Folders
{
    [SitecoreType(TemplateId = "a55b2bc3-2ced-47f6-9ad7-0da4fb514d6b", AutoMap = true)]
    public partial class HeaderLinksFolder : GlassBase, IHeaderLinksFolder
    {
    }
}
