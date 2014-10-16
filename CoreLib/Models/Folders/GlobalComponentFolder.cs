using CoreLib.Interface.Folders;
using CoreLib.Models.Base;
using Glass.Mapper.Sc.Configuration.Attributes;

namespace CoreLib.Models.Folders
{
    [SitecoreType(TemplateId = "200910ad-5862-43cb-a9a8-6ae60ce7c661", AutoMap = true)]
    public partial class GlobalComponentFolder : GlassBase, IGlobalComponentFolder
    {
    }
}
