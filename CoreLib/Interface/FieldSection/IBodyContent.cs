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
    /// <para>Path: /sitecore/templates/User Defined/Field Section/BodyContent</para>
    /// <para>Help: </para>
    /// </summary>
    public partial interface IBodyContent : IGlassBase
    {

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Content Text</para>
        /// <para>Field Type: Rich Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Content Text")]
        string ContentText { get; set; }


    }
}
