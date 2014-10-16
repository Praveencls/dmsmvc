using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLib.Interface.Base;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;

namespace CoreLib.Interface.Callouts
{
    /// <summary>
    /// <para>Path: /sitecore/templates/User Defined/Callouts/Text With Image Callout</para>
    /// <para>Help: </para>
    /// </summary>
    public partial interface ITextWithImageCallout : IGlassBase
    {

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Callout Image</para>
        /// <para>Field Type: Image</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Callout Image")]
        Image CalloutImage { get; set; }

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Callout Text</para>
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Callout Text")]
        string CalloutText { get; set; }

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: CTA Link</para>
        /// <para>Field Type: General Link</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("CTA Link")]
        Link CTALink { get; set; }


    }

}
