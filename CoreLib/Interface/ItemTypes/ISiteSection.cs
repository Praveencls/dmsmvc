using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLib.Interface.Base;
using CoreLib.Interface.FieldSection;
using Glass.Mapper.Sc.Fields;
using CoreLib.Models;

namespace CoreLib.Interface.ItemTypes
{
    /// <summary>
    /// <para>Path: /sitecore/templates/User Defined/Item Type/Site Section</para>
    /// <para>Help: </para>
    /// </summary>
    public partial interface ISiteSection : IGlassBase, IBase, IHomeBase, IMetaBase, IPageBase, IBanner, IBodyContent, IBodyTitle, IBreadcrumb, ICss, IMenu, IOverviews, IRelated, IScript, ISeo, ISidebar, ITagging
    {


    }
}
