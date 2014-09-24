//------------------------------------------------------------------------------------------------- 
// <copyright file="ExistsInDatabaseExtension.cs" company="Sitecore Shared Source">
// Copyright (c) Sitecore.  All rights reserved.
// </copyright>
// <summary>Implements the Sitecore.Data.Items.Item.ExistsInDatabase() extension method.</summary>
// <license>
// http://sdn.sitecore.net/Resources/Shared%20Source/Shared%20Source%20License.aspx
// </license>
// <url>http://trac.sitecore.net/Library/</url>
//-------------------------------------------------------------------------------------------------

namespace Sitecore.Sharedsource.Data.Items.Item
{
  /// <summary>
  /// ExistsInDatabase() extension method for Sitecore.Data.Items.Item returns
  /// true if the database contains the item or the same revision of the item.
  /// Use the Sitecore.Sharedsource.Data.Items.Item namespace to use this method.
  /// </summary>
  public static class ExistsInDatabaseExtension
  {
    /// <summary>
    /// Returns true if the database contains 
    /// </summary>
    /// <param name="me">The item to check, usually in the master database.</param>
    /// <param name="database">The database to check, usually a publishing target
    /// </param>
    /// <param name="checkRevision">False to confirm item exists, True to confirm item
    /// exists and has same revision.</param>
    /// <returns>True if item exists and optionally contains the same revision.
    /// </returns>
    public static bool ExistsInDatabase(
      this Sitecore.Data.Items.Item me, 
      Sitecore.Data.Database database, 
      bool checkRevision)
    {
      Sitecore.Diagnostics.Assert.IsNotNull(me, "me");
      Sitecore.Diagnostics.Assert.IsNotNull(database, "database");
      Sitecore.Data.Items.Item targetItem = database.GetItem(
        me.ID, 
        me.Language, 
        Sitecore.Data.Version.Latest);

      if (targetItem == null)
      {
        return false;
      }

      if (!checkRevision)
      {
        return true;
      }

      return me.IsSameRevision(targetItem);
    }
  }
}
