using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Glass.Mapper.Sc.Configuration.Attributes;

namespace CoreLib.Interface.Base
{
    /// <summary>
    /// <para>Path: /sitecore/templates/User Defined/Base/PageBase</para>
    /// <para>Help: </para>
    /// </summary>
    public partial interface IPageBase : IGlassBase
    {

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Include In Navigation</para>
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Include In Navigation")]
        string IncludeInNavigation { get; set; }

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Navigation Image</para>
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Navigation Image")]
        string NavigationImage { get; set; }

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Navigation Title</para>
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Navigation Title")]
        string NavigationTitle { get; set; }


    }
}
