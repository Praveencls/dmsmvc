using CoreLib.Interface.Base;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;

namespace CoreLib.Interface.Callouts
{
    /// <summary>
    /// <para>Path: /sitecore/templates/User Defined/Callouts/Promo</para>
    /// <para>Help: </para>
    /// </summary>
    public partial interface IPromo : IGlassBase
    {

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Promo Image</para>
        /// <para>Field Type: Image</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Promo Image")]
        Image PromoImage { get; set; }

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Promo Link</para>
        /// <para>Field Type: General Link</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Promo Link")]
        Link PromoLink { get; set; }


    }
}
