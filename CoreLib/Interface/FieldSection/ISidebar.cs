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
    /// <para>Path: /sitecore/templates/User Defined/Field Section/Sidebar</para>
    /// <para>Help: </para>
    /// </summary>
    public partial interface ISidebar : IGlassBase
    {

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Callout Type</para>
        /// <para>Field Type: Droplist</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Callout Type")]
        string CalloutType { get; set; }


    }
}
