using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLib.Interface.Callouts;
using CoreLib.Models.Base;
using Glass.Mapper.Sc.Configuration.Attributes;

namespace CoreLib.Models.Callouts
{
    /// <summary>
    /// <para>Path: /sitecore/templates/User Defined/Callouts/BlankCallout</para>
    /// <para>Help: </para>
    /// </summary>
    [SitecoreType(TemplateId = "ea7973e9-544f-4f11-9b47-60b7a5818e46", AutoMap = true)]
    public partial class BlankCallout : GlassBase, IBlankCallout
    {


        // fields for template BlankCallout

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Content</para>
        /// <para>Field Type: Rich Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Content")]
        public virtual string Content { get; set; }


    }
}
