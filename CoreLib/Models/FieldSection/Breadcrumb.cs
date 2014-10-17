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
    /// <para>Path: /sitecore/templates/User Defined/Field Section/Breadcrumb</para>
    /// <para>Help: </para>
    /// </summary>
    [SitecoreType(TemplateId = "7ba8b608-3c69-4289-b7d2-5366d008a6a1", AutoMap = true)]
    public partial class Breadcrumb : GlassBase, IBreadcrumb
    {


        // fields for template Breadcrumb

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Breadcrumb Title</para>
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Breadcrumb Title")]
        public virtual string BreadcrumbTitle { get; set; }


    }
}
