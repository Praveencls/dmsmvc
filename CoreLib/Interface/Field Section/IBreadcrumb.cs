using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLib.Interface.Base;
using Glass.Mapper.Sc.Configuration.Attributes;

namespace CoreLib.Interface.Field_Section
{
    /// <summary>
    /// <para>Path: /sitecore/templates/User Defined/Field Section/Breadcrumb</para>
    /// <para>Help: </para>
    /// </summary>
    public partial interface IBreadcrumb : IGlassBase
    {

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Breadcrumb Title</para>
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Breadcrumb Title")]
        string BreadcrumbTitle { get; set; }


    }
}
