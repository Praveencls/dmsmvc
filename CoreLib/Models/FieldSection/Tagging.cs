using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLib.Interface.FieldSection;
using CoreLib.Models.Base;
using Glass.Mapper.Sc.Configuration.Attributes;

namespace CoreLib.Models.FieldSection
{
    /// <summary>
    /// <para>Path: /sitecore/templates/User Defined/Field Section/Tagging</para>
    /// <para>Help: </para>
    /// </summary>
    [SitecoreType(TemplateId = "23b0a5cd-d3fa-46ed-9cf7-d07a8224eb60", AutoMap = true)]
    public partial class Tagging : GlassBase, ITagging
    {


        // fields for template Tagging

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Categories</para>
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Categories")]
        public virtual string Categories { get; set; }

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Keywords</para>
        /// <para>Field Type: Multi-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Keywords")]
        public virtual string Keywords { get; set; }

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Level</para>
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Level")]
        public virtual string Level { get; set; }


    }
}
