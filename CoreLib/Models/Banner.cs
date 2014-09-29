using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLib.Interface;
using CoreLib.Models.Base;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
namespace CoreLib.Models
{
     [SitecoreType(TemplateId = "{B0F09F27-2D7B-4484-BE5A-BC91B09F0D61}", AutoMap = true)]
    public class Banner : GlassBase, IBanner
    {
        #region IBanner Members

        // fields for template Banner
        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Banner Image</para>
        /// <para>Field Type: Image</para>
        /// <para>Help: </para>
        /// </summary>
        public Image BannerImage
        {
            get;
            set;
        }

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Banner Text</para>
        /// <para>Field Type: Image</para>
        /// <para>Help: </para>
        /// </summary>
        public string BannerText
        {
            get;
            set;
        }

        #endregion
    }
}
