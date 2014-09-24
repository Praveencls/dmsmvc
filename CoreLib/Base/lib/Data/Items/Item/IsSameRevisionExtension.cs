//------------------------------------------------------------------------------------------------- 
// <copyright file="IsSameRevisionExtension.cs" company="Sitecore Shared Source">
// Copyright (c) Sitecore.  All rights reserved.
// </copyright>
// <summary>
// Implements the Sitecore.Data.Items.Item.IsSameRevisionExtension() extension method.
// </summary>
// <license>
// http://sdn.sitecore.net/Resources/Shared%20Source/Shared%20Source%20License.aspx
// </license>
// <url>http://trac.sitecore.net/Library/</url>
//-------------------------------------------------------------------------------------------------

namespace Sitecore.Sharedsource.Data.Items.Item
{
  /// <summary>
  /// Extension to Sitecore.Data.Items.Item to compare the revision identifier in two
  /// items.
  /// Use the Sitecore.Sharedsource.Data.Items.Item namespace to use this method.
  /// </summary>
  public static class IsSameRevisionExtension
  {
    /// <summary>
    /// Returns true if the two items share a common revision identifider,  commonly to
    /// check if the same revision is the latest in the master and a publishing target
    /// database. Each change to an item creates a new revision identifier, which  is a
    /// GUID as opposed to the numeric version identifier.
    /// </summary>
    /// <param name="me">This item.</param>
    /// <param name="compare">The item to compare against.</param>
    /// <returns>True if the items share a common revision identifier.</returns>
    public static bool IsSameRevision(
      this Sitecore.Data.Items.Item me,
      Sitecore.Data.Items.Item compare)
    {
      Sitecore.Diagnostics.Assert.IsNotNull(me, "me");
      Sitecore.Diagnostics.Assert.IsNotNull(compare, "compare");
      return me.Statistics.Revision == compare.Statistics.Revision;
    }
  }
}
