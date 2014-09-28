using System.Linq;
using System.Text;
using CoreLib.Interface.Base;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;

namespace CoreLib.Interface
{
    /// <summary>
    /// <para>Path: /sitecore/templates/User Defined/Field Section/Banner</para>
    /// <para>Help: </para>
    /// </summary>
    public partial interface IBanner : IGlassBase
    {
        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Image</para>
        /// <para>Field Type: Image</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Banner Image")]
        Image BannerImage { get; set; }

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Text</para>
        /// <para>Field Type: Rich Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Banner Text")]
        string BannerText { get; set; }
    }
}
