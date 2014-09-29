using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLib.Interface.Base;
using CoreLib.Models.Base;

namespace CoreLib.Interface
{
    public partial interface ISiteSection : IGlassBase, IBase, IBanner, IHomeBase, IMetaBase, IPageBase, IBodyContent, IBodyTitle
        , IBreadcrumb, ICss, IMenu, IOverviews, IRelated, IScript, ISeo, ISidebar, ITagging
    {
    }
}
