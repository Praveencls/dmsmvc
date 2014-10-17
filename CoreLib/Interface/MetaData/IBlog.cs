using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Glass.Mapper.Sc.Fields;
using CoreLib.Interface.Base;
using Glass.Mapper.Sc.Configuration.Attributes;

namespace CoreLib.Interface.MetaData
{
    /// <summary>
    /// <para>Path: /sitecore/templates/User Defined/Meta Data/Blog</para>
    /// <para>Help: </para>
    /// </summary>
    public partial interface IBlog : IGlassBase
    {

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Blog Description</para>
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Blog Description")]
        string BlogDescription { get; set; }

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Blog Meta</para>
        /// <para>Field Type: Multi-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Blog Meta")]
        string BlogMeta { get; set; }

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Blog ShortDescription</para>
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Blog ShortDescription")]
        string BlogShortDescription { get; set; }

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Blog Title</para>
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Blog Title")]
        string BlogTitle { get; set; }

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Category</para>
        /// <para>Field Type: Droplist</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Category")]
        string Category { get; set; }

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Image</para>
        /// <para>Field Type: Image</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Image")]
        Image Image { get; set; }

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Modified</para>
        /// <para>Field Type: Datetime</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Modified")]
        DateTime Modified { get; set; }

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: PostedOn</para>
        /// <para>Field Type: Datetime</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("PostedOn")]
        DateTime PostedOn { get; set; }

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Published</para>
        /// <para>Field Type: Checkbox</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Published")]
        bool Published { get; set; }

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Tags</para>
        /// <para>Field Type: Droplist</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Tags")]
        string Tags { get; set; }

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: UrlSlug</para>
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("UrlSlug")]
        string UrlSlug { get; set; }


    }
}
