using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLib.Interface.Base;
using Glass.Mapper.Sc.Configuration.Attributes;

namespace CoreLib.Interface.FieldSection
{
    /// <summary>
    /// <para>Path: /sitecore/templates/User Defined/Field Section/Tagging</para>
    /// <para>Help: </para>
    /// </summary>
    public partial interface ITagging : IGlassBase
    {

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Categories</para>
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Categories")]
        string Categories { get; set; }

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Keywords</para>
        /// <para>Field Type: Multi-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Keywords")]
        string Keywords { get; set; }

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Level</para>
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Level")]
        string Level { get; set; }


    }
}
