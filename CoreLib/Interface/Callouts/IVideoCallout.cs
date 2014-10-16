using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLib.Interface.Base;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;

namespace CoreLib.Interface.Callouts
{
    /// <summary>
    /// <para>Path: /sitecore/templates/User Defined/Callouts/VideoCallout</para>
    /// <para>Help: </para>
    /// </summary>
    public partial interface IVideoCallout : IGlassBase
    {

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Video Script</para>
        /// <para>Field Type: Multi-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Video Script")]
        string VideoScript { get; set; }

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Video Source</para>
        /// <para>Field Type: General Link</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Video Source")]
        Link VideoSource { get; set; }


    }
}
