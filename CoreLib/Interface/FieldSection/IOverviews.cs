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
    /// <para>Path: /sitecore/templates/User Defined/Field Section/Overviews</para>
    /// <para>Help: </para>
    /// </summary>
    public partial interface IOverviews : IGlassBase
    {

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Abstract</para>
        /// <para>Field Type: Multi-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Abstract")]
        string Abstract { get; set; }


    }
}
