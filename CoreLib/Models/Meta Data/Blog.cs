using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLib.Interface.Meta_Data;
using Glass.Mapper.Sc.Configuration.Attributes;

namespace CoreLib.Models.Meta_Data
{
    /// <summary>
    /// <para>Path: /sitecore/templates/User Defined/Meta Data/Blog</para>
    /// <para>Help: </para>
    /// </summary>
    [SitecoreType(TemplateId = "3838998e-8b96-49a0-a4f9-bf86e467ad88", AutoMap = true)]
    public partial class Blog : GlassBase, IBlog
    {


        // fields for template Blog

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Blog Description</para>
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Blog Description")]
        public virtual string BlogDescription { get; set; }

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Blog Meta</para>
        /// <para>Field Type: Multi-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Blog Meta")]
        public virtual string BlogMeta { get; set; }

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Blog ShortDescription</para>
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Blog ShortDescription")]
        public virtual string BlogShortDescription { get; set; }

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Blog Title</para>
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Blog Title")]
        public virtual string BlogTitle { get; set; }

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Category</para>
        /// <para>Field Type: Droplist</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Category")]
        public virtual string Category { get; set; }

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Image</para>
        /// <para>Field Type: Image</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Image")]
        public virtual Image Image { get; set; }

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Modified</para>
        /// <para>Field Type: Datetime</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Modified")]
        public virtual DateTime Modified { get; set; }

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: PostedOn</para>
        /// <para>Field Type: Datetime</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("PostedOn")]
        public virtual DateTime PostedOn { get; set; }

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Published</para>
        /// <para>Field Type: Checkbox</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Published")]
        public virtual bool Published { get; set; }

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Tags</para>
        /// <para>Field Type: Droplist</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Tags")]
        public virtual string Tags { get; set; }

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: UrlSlug</para>
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("UrlSlug")]
        public virtual string UrlSlug { get; set; }


    }
}
