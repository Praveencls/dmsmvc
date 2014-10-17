
using CoreLib.Interface.Base;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;


namespace CoreLib.Interface.FieldSection
{
    /// <summary>
    /// <para>Path: /sitecore/templates/User Defined/Field Section/Banner</para>
    /// <para>Help: </para>
    /// </summary>
    public partial interface IBanner : IGlassBase
    {

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Banner Image</para>
        /// <para>Field Type: Image</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Banner Image")]
        Image BannerImage { get; set; }

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Banner Link</para>
        /// <para>Field Type: General Link</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Banner Link")]
        Link BannerLink { get; set; }

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Banner Text</para>
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Banner Text")]
        string BannerText { get; set; }

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Show Banner</para>
        /// <para>Field Type: Checkbox</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Show Banner")]
        bool ShowBanner { get; set; }


    }
}
