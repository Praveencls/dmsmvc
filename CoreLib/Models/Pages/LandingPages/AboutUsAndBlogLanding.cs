using CoreLib.Interface.Pages.LandingPages;
using CoreLib.Models.Base;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;

namespace CoreLib.Models.Pages.LandingPages
{
    /// <summary>
    /// <para>Path: /sitecore/templates/User Defined/Pages/Landing Pages/About Us and Blog Landing</para>
    /// <para>Help: </para>
    /// </summary>
    [SitecoreType(TemplateId = "d4e7f499-30ef-4313-9d5c-fe386f479dab", AutoMap = true)]
    public partial class AboutUsAndBlogLanding : GlassBase, IAboutUsAndBlogLanding
    {
        // fields for template Base

        // fields for template HomeBase

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Copyright</para>
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Copyright")]
        public virtual string Copyright { get; set; }

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Logo</para>
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Logo")]
        public virtual string Logo { get; set; }

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Name</para>
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Name")]
        public virtual string Name { get; set; }

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Search Label</para>
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Search Label")]
        public virtual string SearchLabel { get; set; }

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Tole Free Number</para>
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Tole Free Number")]
        public virtual string ToleFreeNumber { get; set; }

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

        // fields for template Banner

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Banner Image</para>
        /// <para>Field Type: Image</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Banner Image")]
        public virtual Image BannerImage { get; set; }

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Banner Link</para>
        /// <para>Field Type: General Link</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Banner Link")]
        public virtual Link BannerLink { get; set; }

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Banner Text</para>
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Banner Text")]
        public virtual string BannerText { get; set; }

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Show Banner</para>
        /// <para>Field Type: Checkbox</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Show Banner")]
        public virtual bool ShowBanner { get; set; }

        // fields for template BodyContent

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Content Text</para>
        /// <para>Field Type: Rich Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Content Text")]
        public virtual string ContentText { get; set; }

        // fields for template BodyTitle

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Content SubTitle</para>
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Content SubTitle")]
        public virtual string ContentSubTitle { get; set; }

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Content Title</para>
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Content Title")]
        public virtual string ContentTitle { get; set; }

        // fields for template Breadcrumb

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Breadcrumb Title</para>
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Breadcrumb Title")]
        public virtual string BreadcrumbTitle { get; set; }

        // fields for template Css

        // fields for template Menu

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Hide In Menu</para>
        /// <para>Field Type: Checkbox</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Hide In Menu")]
        public virtual bool HideInMenu { get; set; }

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Menu Title</para>
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Menu Title")]
        public virtual string MenuTitle { get; set; }

        // fields for template Overviews

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Abstract</para>
        /// <para>Field Type: Multi-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Abstract")]
        public virtual string Abstract { get; set; }

        // fields for template Related

        // fields for template Script

        // fields for template Seo

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Google Analytics</para>
        /// <para>Field Type: Multi-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Google Analytics")]
        public virtual string GoogleAnalytics { get; set; }

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Other</para>
        /// <para>Field Type: Multi-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Other")]
        public virtual string Other { get; set; }

        // fields for template Sidebar

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Callout Type</para>
        /// <para>Field Type: Droplist</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Callout Type")]
        public virtual string CalloutType { get; set; }

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

        // fields for template Site Section

        // fields for template About Us and Blog Landing
    }
}