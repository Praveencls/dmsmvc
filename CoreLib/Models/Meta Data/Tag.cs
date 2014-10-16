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
    /// <para>Path: /sitecore/templates/User Defined/Meta Data/Tag</para>
    /// <para>Help: </para>
    /// </summary>
    [SitecoreType(TemplateId = "4dfa47ae-1ea1-4543-9072-ce32f061d12b", AutoMap = true)]
    public partial class Tag : GlassBase, ITag
    {


        // fields for template Tag

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Tag Name</para>
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Tag Name")]
        public virtual string TagName { get; set; }


    }
}
