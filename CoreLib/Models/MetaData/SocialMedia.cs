using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLib.Interface.MetaData;
using CoreLib.Models.Base;
using Glass.Mapper.Sc.Configuration.Attributes;

namespace CoreLib.Models.MetaData
{
    /// <summary>
    /// <para>Path: /sitecore/templates/User Defined/Meta Data/SocialMedia</para>
    /// <para>Help: </para>
    /// </summary>
    [SitecoreType(TemplateId = "89f60534-b6fd-4499-83fc-5ef05f5048b5", AutoMap = true)]
    public partial class SocialMedia : GlassBase, ISocialMedia
    {


        // fields for template SocialMedia

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Text</para>
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Text")]
        public virtual string Text { get; set; }

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Url</para>
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Url")]
        public virtual string Url { get; set; }


    }
}
