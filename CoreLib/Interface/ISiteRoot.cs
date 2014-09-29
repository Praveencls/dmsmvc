using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLib.Interface.Base;

namespace CoreLib.Interface
{
    public partial interface ISiteRoot : IGlassBase, IBase, IHomeBase, IBanner, IBodyContent, IBodyTitle, IBreadcrumb, ICss, IScript, ISeo, ISiteSettings
    {
    }
}
