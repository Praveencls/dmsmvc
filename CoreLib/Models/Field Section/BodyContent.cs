using CoreLib.Interface.Field_Section;
using CoreLib.Models.Base;
using Glass.Mapper.Sc.Configuration.Attributes;

namespace CoreLib.Models.Field_Section
{
    /// <summary>
    /// <para>Path: /sitecore/templates/User Defined/Field Section/BodyContent</para>
    /// <para>Help: </para>
    /// </summary>
    [SitecoreType(TemplateId = "0c8b8ed4-40ce-46ac-89cb-4f4dc8e36f43", AutoMap = true)]
    public partial class BodyContent : GlassBase, IBodyContent
    {


        // fields for template BodyContent

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Content Text</para>
        /// <para>Field Type: Rich Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Content Text")]
        public virtual string ContentText { get; set; }


    }
}
