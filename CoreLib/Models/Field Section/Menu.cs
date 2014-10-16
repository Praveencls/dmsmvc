using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLib.Interface.Field_Section;
using CoreLib.Models.Base;
using Glass.Mapper.Sc.Configuration.Attributes;

namespace CoreLib.Models.Field_Section
{
    /// <summary>
    /// <para>Path: /sitecore/templates/User Defined/Field Section/Menu</para>
    /// <para>Help: </para>
    /// </summary>
    [SitecoreType(TemplateId = "d90d5301-fa23-4482-ab2d-e056fb0432a5", AutoMap = true)]
    public partial class Menu : GlassBase, IMenu
    {


        // fields for template Menu

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Hide In Menu</para>
        /// <para>Field Type: Checkbox</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Hide In Menu")]
        public virtual bool HideInMenu { get; set; }

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Menu Title</para>
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Menu Title")]
        public virtual string MenuTitle { get; set; }


    }
}
