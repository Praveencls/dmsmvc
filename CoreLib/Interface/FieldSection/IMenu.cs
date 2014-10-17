using CoreLib.Interface.Base;
using Glass.Mapper.Sc.Configuration.Attributes;

namespace CoreLib.Interface.FieldSection
{
    /// <summary>
    /// <para>Path: /sitecore/templates/User Defined/Field Section/Menu</para>
    /// <para>Help: </para>
    /// </summary>
    public partial interface IMenu : IGlassBase
    {

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Hide In Menu</para>
        /// <para>Field Type: Checkbox</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Hide In Menu")]
        bool HideInMenu { get; set; }

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Menu Title</para>
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Menu Title")]
        string MenuTitle { get; set; }


    }
}
