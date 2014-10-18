using CoreLib.Interface.Pages.DetailPages;
using CoreLib.Models.Base;
using Glass.Mapper.Sc.Configuration.Attributes;

namespace CoreLib.Models.Pages.DetailPages
{
    /// <summary>
    /// <para>Path: /sitecore/templates/User Defined/Pages/Detail Pages/About Us and Blog Sub Page</para>
    /// <para>Help: </para>
    /// </summary>
    [SitecoreType(TemplateId = "dee8f8db-f79d-4cd4-ac00-f4feb4560e55", AutoMap = true)]
    public partial class AboutUsAndBlogSubPage : GlassBase, IAboutUsAndBlogSubPage
    {
        // fields for template Base

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

        // fields for template PageBase

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Include In Navigation</para>
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Include In Navigation")]
        public virtual string IncludeInNavigation { get; set; }

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Navigation Image</para>
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Navigation Image")]
        public virtual string NavigationImage { get; set; }

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Navigation Title</para>
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Navigation Title")]
        public virtual string NavigationTitle { get; set; }

        // fields for template Content Item

        // fields for template About Us and Blog Sub Page
    }
}