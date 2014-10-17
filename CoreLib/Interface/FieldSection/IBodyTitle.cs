using CoreLib.Interface.Base;
using Glass.Mapper.Sc.Configuration.Attributes;

namespace CoreLib.Interface.FieldSection
{
    /// <summary>
    /// <para>Path: /sitecore/templates/User Defined/Field Section/BodyTitle</para>
    /// <para>Help: </para>
    /// </summary>
    public partial interface IBodyTitle : IGlassBase
    {

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Content SubTitle</para>
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Content SubTitle")]
        string ContentSubTitle { get; set; }

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Content Title</para>
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Content Title")]
        string ContentTitle { get; set; }


    }
}
