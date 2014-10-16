namespace CoreLib.Interface.Base
{
    using Glass.Mapper.Sc.Configuration.Attributes;

    /// <summary>
    /// <para>Path: /sitecore/templates/User Defined/Base/MetaBase</para>
    /// <para>Help: </para>
    /// </summary>
    public partial interface IMetaBase : IGlassBase
    {

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Custom Meta Tags</para>
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Custom Meta Tags")]
        string CustomMetaTags { get; set; }

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Meta Description</para>
        /// <para>Field Type: Multi-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Meta Description")]
        string MetaDescription { get; set; }

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Meta Title</para>
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Meta Title")]
        string MetaTitle { get; set; }

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Robots No Follow</para>
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Robots No Follow")]
        string RobotsNoFollow { get; set; }

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Robots No Index</para>
        /// <para>Field Type: Checkbox</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Robots No Index")]
        bool RobotsNoIndex { get; set; }


    }
}
