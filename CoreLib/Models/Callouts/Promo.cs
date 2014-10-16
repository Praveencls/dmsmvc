using CoreLib.Interface.Callouts;
using CoreLib.Models.Base;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;

namespace CoreLib.Models.Callouts
{
    /// <summary>
    /// <para>Path: /sitecore/templates/User Defined/Callouts/Promo</para>
    /// <para>Help: </para>
    /// </summary>
    [SitecoreType(TemplateId = "83f8db91-a6a0-42c8-b116-7293116fdb3a", AutoMap = true)]
    public partial class Promo : GlassBase, IPromo
    {


        // fields for template Promo

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Promo Image</para>
        /// <para>Field Type: Image</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Promo Image")]
        public virtual Image PromoImage { get; set; }

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Promo Link</para>
        /// <para>Field Type: General Link</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Promo Link")]
        public virtual Link PromoLink { get; set; }


    }
}
