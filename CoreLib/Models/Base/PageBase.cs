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
    /// <para>Path: /sitecore/templates/User Defined/Base/PageBase</para>
    /// <para>Help: </para>
    /// </summary>
    [SitecoreType(TemplateId = "8d3be095-ea65-4db0-b3db-eff4f9e575b3", AutoMap = true)]
    public partial class PageBase : GlassBase, IPageBase
    {


        // fields for template PageBase

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Include In Navigation</para>
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Include In Navigation")]
        public virtual string IncludeInNavigation { get; set; }

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Navigation Image</para>
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Navigation Image")]
        public virtual string NavigationImage { get; set; }

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Navigation Title</para>
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Navigation Title")]
        public virtual string NavigationTitle { get; set; }


    }
}
