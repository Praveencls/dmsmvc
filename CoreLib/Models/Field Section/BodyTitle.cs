using CoreLib.Interface.Field_Section;
using CoreLib.Models.Base;
using Glass.Mapper.Sc.Configuration.Attributes;

namespace CoreLib.Models.Field_Section
{
    /// <summary>
    /// <para>Path: /sitecore/templates/User Defined/Field Section/BodyTitle</para>
    /// <para>Help: </para>
    /// </summary>
    [SitecoreType(TemplateId = "3b1ccfe7-417b-472e-a71d-2225b251e2c3", AutoMap = true)]
    public partial class BodyTitle : GlassBase, IBodyTitle
    {


        // fields for template BodyTitle

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Content SubTitle</para>
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Content SubTitle")]
        public virtual string ContentSubTitle { get; set; }

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Content Title</para>
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Content Title")]
        public virtual string ContentTitle { get; set; }


    }
}
