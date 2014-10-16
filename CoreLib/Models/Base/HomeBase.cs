using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLib.Interface.Base;
using Glass.Mapper.Sc.Configuration.Attributes;

namespace CoreLib.Models.Base
{
    /// <summary>
    /// <para>Path: /sitecore/templates/User Defined/Base/HomeBase</para>
    /// <para>Help: </para>
    /// </summary>
    [SitecoreType(TemplateId = "9720d30a-e791-41d2-b52a-14ae5f474ade", AutoMap = true)]
    public partial class HomeBase : GlassBase, IHomeBase
    {


        // fields for template HomeBase

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Copyright</para>
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Copyright")]
        public virtual string Copyright { get; set; }

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Logo</para>
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Logo")]
        public virtual string Logo { get; set; }

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Name</para>
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Name")]
        public virtual string Name { get; set; }

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Search Label</para>
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Search Label")]
        public virtual string SearchLabel { get; set; }

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Tole Free Number</para>
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Tole Free Number")]
        public virtual string ToleFreeNumber { get; set; }


    }
}
