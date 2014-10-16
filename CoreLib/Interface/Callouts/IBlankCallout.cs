using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLib.Interface.Base;
using Glass.Mapper.Sc.Configuration.Attributes;

namespace CoreLib.Interface.Callouts
{
    /// <summary>
    /// <para>Path: /sitecore/templates/User Defined/Callouts/BlankCallout</para>
    /// <para>Help: </para>
    /// </summary>
    public partial interface IBlankCallout : IGlassBase
    {

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Content</para>
        /// <para>Field Type: Rich Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Content")]
        string Content { get; set; }


    }

}
