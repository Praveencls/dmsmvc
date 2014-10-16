using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLib.Interface.Callouts;
using CoreLib.Models.Base;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;

namespace CoreLib.Models.Callouts
{
    /// <summary>
    /// <para>Path: /sitecore/templates/User Defined/Callouts/Text With Image Callout</para>
    /// <para>Help: </para>
    /// </summary>
    [SitecoreType(TemplateId = "9d742cd4-0a5d-4914-b00e-a813fbb8ce38", AutoMap = true)]
    public partial class TextWithImageCallout : GlassBase, ITextWithImageCallout
    {


        // fields for template Text With Image Callout

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Callout Image</para>
        /// <para>Field Type: Image</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Callout Image")]
        public virtual Image CalloutImage { get; set; }

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Callout Text</para>
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Callout Text")]
        public virtual string CalloutText { get; set; }

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: CTA Link</para>
        /// <para>Field Type: General Link</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("CTA Link")]
        public virtual Link CTALink { get; set; }


    }
}
