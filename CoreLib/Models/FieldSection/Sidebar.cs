using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLib.Interface.FieldSection;
using CoreLib.Models.Base;
using Glass.Mapper.Sc.Configuration.Attributes;

namespace CoreLib.Models.FieldSection
{
    /// <summary>
    /// <para>Path: /sitecore/templates/User Defined/Field Section/Sidebar</para>
    /// <para>Help: </para>
    /// </summary>
    [SitecoreType(TemplateId = "eaf6c332-eef8-4bdf-a036-684375789365", AutoMap = true)]
    public partial class Sidebar : GlassBase, ISidebar
    {


        // fields for template Sidebar

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Callout Type</para>
        /// <para>Field Type: Droplist</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Callout Type")]
        public virtual string CalloutType { get; set; }


    }
}
