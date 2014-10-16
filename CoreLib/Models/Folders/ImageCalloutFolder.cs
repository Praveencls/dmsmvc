using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLib.Interface.Folders;
using CoreLib.Models.Base;
using Glass.Mapper.Sc.Configuration.Attributes;

namespace CoreLib.Models.Folders
{
    [SitecoreType(TemplateId = "001acf96-bc0a-4da6-af41-dc056880d7dc", AutoMap = true)]
    public partial class ImageCalloutFolder : GlassBase, IImageCalloutFolder
    {
    }
}
