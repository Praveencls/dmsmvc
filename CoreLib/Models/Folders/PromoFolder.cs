using CoreLib.Interface.Folders;
using CoreLib.Models.Base;
using Glass.Mapper.Sc.Configuration.Attributes;

namespace CoreLib.Models.Folders
{
    [SitecoreType(TemplateId = "6e65edce-d6b7-4467-90b6-db07dae68521", AutoMap = true)]
    public partial class PromoFolder : GlassBase, IResourceFolder
    {
    }
}
