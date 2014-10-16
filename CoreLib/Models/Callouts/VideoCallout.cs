using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLib.Interface.Callouts;
using CoreLib.Models.Base;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;

namespace CoreLib.Models.Callouts
{
    /// <summary>
    /// <para>Path: /sitecore/templates/User Defined/Callouts/VideoCallout</para>
    /// <para>Help: </para>
    /// </summary>
    [SitecoreType(TemplateId = "b5fcc0a8-d052-488f-8664-1a6d93859bc7", AutoMap = true)]
    public partial class VideoCallout : GlassBase, IVideoCallout
    {


        // fields for template VideoCallout

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Video Script</para>
        /// <para>Field Type: Multi-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Video Script")]
        public virtual string VideoScript { get; set; }

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Video Source</para>
        /// <para>Field Type: General Link</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Video Source")]
        public virtual Link VideoSource { get; set; }


    }
}
