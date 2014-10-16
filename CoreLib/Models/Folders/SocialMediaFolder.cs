using CoreLib.Interface.Folders;
using CoreLib.Models.Base;
using Glass.Mapper.Sc.Configuration.Attributes;

namespace CoreLib.Models.Folders
{
    [SitecoreType(TemplateId = "4703abf4-3279-46f1-b5cb-a77ddecb452d", AutoMap = true)]
    public partial class SocialMediaFolder : GlassBase, ISocialMediaFolder
    {
    }
}
