using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLib.Interface.Item_Types;
using Glass.Mapper.Sc.Configuration.Attributes;

namespace CoreLib.Models.Item_Types
{
    /// <summary>
    /// <para>Path: /sitecore/templates/User Defined/Item Type/Site Root</para>
    /// <para>Help: </para>
    /// </summary>
    [SitecoreType(TemplateId = "05fc1df4-6163-4c0e-a692-7852425e0624", AutoMap = true)]
    public partial class SiteRoot : GlassBase, ISiteRoot
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


        // fields for template Site Settings

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Profile Path</para>
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Profile Path")]
        public virtual string ProfilePath { get; set; }


        // fields for template Site Root


    }
}
