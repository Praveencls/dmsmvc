using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLib.Interface.Field_Section;
using CoreLib.Models.Base;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;

namespace CoreLib.Models.Field_Section
{
    /// <summary>
    /// <para>Path: /sitecore/templates/User Defined/Field Section/Banner</para>
    /// <para>Help: </para>
    /// </summary>
    [SitecoreType(TemplateId = "b0f09f27-2d7b-4484-be5a-bc91b09f0d61", AutoMap = true)]
    public partial class Banner : GlassBase, IBanner
    {


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


    }
}
