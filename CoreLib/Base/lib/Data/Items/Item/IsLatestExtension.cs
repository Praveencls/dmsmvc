//------------------------------------------------------------------------------------------------- 
// <copyright file="IsLatestExtension.cs" company="Sitecore Shared Source">
// Copyright (c) Sitecore.  All rights reserved.
// </copyright>
// <summary>
// Implements the Sitecore.Data.Items.Item.IsLatest() extension method.
// </summary>
// <license>
// http://sdn.sitecore.net/Resources/Shared%20Source/Shared%20Source%20License.aspx
// </license>
// <url>http://trac.sitecore.net/Library/</url>
//-------------------------------------------------------------------------------------------------

namespace Sitecore.Sharedsource.Data.Items.Item
{
  /// <summary>
  /// Extension method for Sitecore.Data.Items.Item to indicate whether a revision 
  /// of an item is the latest.
  /// Use the Sitecore.Sharedsource.Data.Items.Item namespace to use this method.
  /// </summary>
  public static class IsLatestExtension
  {
    /// <summary>
    /// Return true if this revision of the item is the latest.
    /// </summary>
    /// <param name="me">The item to check.</param>
    /// <returns>True if the revision of the item is the latest.</returns>
    public static bool IsLatest(this Sitecore.Data.Items.Item me)
    {
      Sitecore.Diagnostics.Assert.IsNotNull(me, "me");
      Sitecore.Data.Items.Item latest = me.Database.GetItem(
        me.ID,
        me.Language,
        Sitecore.Data.Version.Latest);

      if (latest == null)
      {
        return false;
      }

      return me.IsSameRevision(latest);
    }
  }
}
