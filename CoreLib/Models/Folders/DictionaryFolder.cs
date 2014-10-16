using CoreLib.Interface.Folders;
using CoreLib.Models.Base;
using Glass.Mapper.Sc.Configuration.Attributes;

namespace CoreLib.Models.Folders
{
    [SitecoreType(TemplateId = "fb6d977c-370b-422b-a8ad-c82cb5983f82", AutoMap = true)]
    public partial class DictionaryFolder : GlassBase, IDictionaryFolder
    {
    }
}
