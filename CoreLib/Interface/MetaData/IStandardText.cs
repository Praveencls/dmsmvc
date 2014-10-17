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
    /// <para>Path: /sitecore/templates/User Defined/Meta Data/StandardText</para>
    /// <para>Help: </para>
    /// </summary>
    public partial interface IStandardText : IGlassBase
    {

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Title</para>
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Title")]
        string Title { get; set; }


    }
}
