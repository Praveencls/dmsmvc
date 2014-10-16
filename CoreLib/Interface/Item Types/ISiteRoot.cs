using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLib.Models;
using CoreLib.Models.Base;
using CoreLib.Models.FieldSection;
using CoreLib.Models.MetaData;

namespace CoreLib.Interface.Item_Types
{

    /// <summary>
    /// <para>Path: /sitecore/templates/User Defined/Item Type/Site Root</para>
    /// <para>Help: </para>
    /// </summary>
    public partial interface ISiteRoot : IGlassBase, IBase, IHomeBase, IBanner, IBodyContent, IBodyTitle, IBreadcrumb, ICss, IScript, ISeo, ISiteSettings
    {


    }
}
