using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLib.Interface.Base;
using Glass.Mapper.Sc.Configuration.Attributes;

namespace CoreLib.Interface.MetaData
{
    /// <summary>
    /// <para>Path: /sitecore/templates/User Defined/Meta Data/SocialMedia</para>
    /// <para>Help: </para>
    /// </summary>
    public partial interface ISocialMedia : IGlassBase
    {

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Text</para>
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Text")]
        string Text { get; set; }

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Url</para>
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Url")]
        string Url { get; set; }


    }
}
