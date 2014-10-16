namespace CoreLib.Interface.Base
{
    using Glass.Mapper.Sc.Configuration.Attributes;

    /// <summary>
    /// <para>Path: /sitecore/templates/User Defined/Base/HomeBase</para>
    /// <para>Help: </para>
    /// </summary>
    public partial interface IHomeBase : IGlassBase
    {

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Copyright</para>
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Copyright")]
        string Copyright { get; set; }

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Logo</para>
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Logo")]
        string Logo { get; set; }

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Name</para>
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Name")]
        string Name { get; set; }

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Search Label</para>
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Search Label")]
        string SearchLabel { get; set; }

        /// <summary>
        /// <para>Title: </para>
        /// <para>Field Name: Tole Free Number</para>
        /// <para>Field Type: Single-Line Text</para>
        /// <para>Help: </para>
        /// </summary>
        [SitecoreField("Tole Free Number")]
        string ToleFreeNumber { get; set; }


    }

   

}
