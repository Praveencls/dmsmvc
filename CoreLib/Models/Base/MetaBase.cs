using CoreLib.Interface.Base;
using Glass.Mapper.Sc.Configuration.Attributes;

namespace CoreLib.Models.Base
{
    /// <summary>
    /// <para>Path: /sitecore/templates/User Defined/Base/MetaBase</para>
    /// <para>Help: </para>
    /// </summary>
    [SitecoreType(TemplateId = "5d4dc5c0-cbbd-44d4-850e-3de6c8d12cf7", AutoMap = true)]
    public partial class MetaBase : GlassBase, IMetaBase
    {


        // fields for template MetaBase

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Custom Meta Tags</para>
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Custom Meta Tags")]
        public virtual string CustomMetaTags { get; set; }

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Meta Description</para>
        /// <para>Field Type: Multi-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Meta Description")]
        public virtual string MetaDescription { get; set; }

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Meta Title</para>
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Meta Title")]
        public virtual string MetaTitle { get; set; }

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Robots No Follow</para>
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Robots No Follow")]
        public virtual string RobotsNoFollow { get; set; }

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Robots No Index</para>
        /// <para>Field Type: Checkbox</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Robots No Index")]
        public virtual bool RobotsNoIndex { get; set; }


    }
}
