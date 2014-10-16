using CoreLib.Interface.Field_Section;
using CoreLib.Models.Base;
using Glass.Mapper.Sc.Configuration.Attributes;

namespace CoreLib.Models.Callouts
{
    /// <summary>
    /// <para>Path: /sitecore/templates/User Defined/Field Section/Overviews</para>
    /// <para>Help: </para>
    /// </summary>
    [SitecoreType(TemplateId = "7167574a-d0ba-4987-b15c-7288aeb6f32f", AutoMap = true)]
    public partial class Overviews : GlassBase, IOverviews
    {


        // fields for template Overviews

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Abstract</para>
        /// <para>Field Type: Multi-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Abstract")]
        public virtual string Abstract { get; set; }


    }
}
