using CoreLib.Interface.Folders;
using CoreLib.Models.Base;
using Glass.Mapper.Sc.Configuration.Attributes;

namespace CoreLib.Models.Folders
{
    [SitecoreType(TemplateId = "252237d0-2b29-4bfc-a2b1-2cd11f9eea7e", AutoMap = true)]
    public partial class ResourceFolder : GlassBase, IResourceFolder
    {
    }
}
