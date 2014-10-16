using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLib.Interface.Base;
using Glass.Mapper.Sc.Configuration.Attributes;

namespace CoreLib.Interface.Meta_Data
{
    /// <summary>
    /// <para>Path: /sitecore/templates/User Defined/Meta Data/Tag</para>
    /// <para>Help: </para>
    /// </summary>
    public partial interface ITag : IGlassBase
    {

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Tag Name</para>
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Tag Name")]
        string TagName { get; set; }


    }
}
