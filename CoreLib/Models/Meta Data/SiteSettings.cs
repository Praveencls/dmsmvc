using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLib.Interface.Meta_Data;
using Glass.Mapper.Sc.Configuration.Attributes;

namespace CoreLib.Models.Meta_Data
{
    /// <summary>
    /// <para>Path: /sitecore/templates/User Defined/Meta Data/Site Settings</para>
    /// <para>Help: </para>
    /// </summary>
    [SitecoreType(TemplateId = "aa68153a-f5c1-4e6b-a37d-6ed2986e3e96", AutoMap = true)]
    public partial class SiteSettings : GlassBase, ISiteSettings
    {


        // fields for template Site Settings

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Profile Path</para>
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Profile Path")]
        public virtual string ProfilePath { get; set; }


    }
}
