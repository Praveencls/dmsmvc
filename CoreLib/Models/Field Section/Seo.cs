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
    /// <para>Path: /sitecore/templates/User Defined/Field Section/Seo</para>
    /// <para>Help: </para>
    /// </summary>
    [SitecoreType(TemplateId = "850a4d97-dcfb-49a3-aeac-3fe0caa460e2", AutoMap = true)]
    public partial class Seo : GlassBase, ISeo
    {


        // fields for template Seo

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Google Analytics</para>
        /// <para>Field Type: Multi-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Google Analytics")]
        public virtual string GoogleAnalytics { get; set; }

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Other</para>
        /// <para>Field Type: Multi-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Other")]
        public virtual string Other { get; set; }


    }
}
