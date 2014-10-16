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
    /// <para>Path: /sitecore/templates/User Defined/Meta Data/StandardText</para>
    /// <para>Help: </para>
    /// </summary>
    [SitecoreType(TemplateId = "f6151ec3-46dc-4e6a-b711-28f3a0ec6c58", AutoMap = true)]
    public partial class StandardText : GlassBase, IStandardText
    {


        // fields for template StandardText

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Title</para>
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Title")]
        public virtual string Title { get; set; }


    }
}
