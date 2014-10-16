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
    /// <para>Path: /sitecore/templates/User Defined/Field Section/Seo</para>
    /// <para>Help: </para>
    /// </summary>
    public partial interface ISeo : IGlassBase
    {

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Google Analytics</para>
        /// <para>Field Type: Multi-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Google Analytics")]
        string GoogleAnalytics { get; set; }

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Other</para>
        /// <para>Field Type: Multi-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Other")]
        string Other { get; set; }


    }
}
