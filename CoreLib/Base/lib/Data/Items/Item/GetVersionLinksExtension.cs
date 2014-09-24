//------------------------------------------------------------------------------------------------- 
// <copyright file="GetVersionLinksExtension.cs" company="Sitecore Shared Source">
// Copyright (c) Sitecore.  All rights reserved.
// </copyright>
// <summary>
// Implements the Sitecore.Data.Items.Item.GetVersionLinks() extension method.
// </summary>
// <license>
// http://sdn.sitecore.net/Resources/Shared%20Source/Shared%20Source%20License.aspx
// </license>
// <url>http://trac.sitecore.net/Library/</url>
//-------------------------------------------------------------------------------------------------

namespace Sitecore.Sharedsource.Data.Items.Item
{
  using System;
  using System.Collections.Generic;

  /// <summary>
  /// Extension method for Sitecore.Data.Items.Item to retrieve valid links in a
  /// version of an item.
  /// </summary>
  public static class GetVersionLinksExtension
  {
    /// <summary>
    /// Return the valid links in the specified version of the item.
    /// </summary>
    /// <param name="me">The item containing the links.</param>
    /// <returns>The valid links in the specified version of the item.</returns>
    public static Sitecore.Links.ItemLink[] GetVersionLinks(
      this Sitecore.Data.Items.Item me)
    {
      Sitecore.Diagnostics.Assert.IsNotNull(me, "item");
      List<Sitecore.Links.ItemLink> links = new List<Sitecore.Links.ItemLink>();
      List<Sitecore.Data.ID> processed = new List<Sitecore.Data.ID>();

      foreach (Sitecore.Links.ItemLink itemLink in me.Links.GetAllLinks())
      {
        if (processed.Contains(itemLink.TargetItemID))
        {
          continue;
        }

        if (me.IsValidLink(itemLink))
        {
          links.Add(itemLink);
        }

        processed.Add(itemLink.TargetItemID);
      }

      return links.ToArray();
    }

    /// <summary>
    /// Returns True if the link exists in the specified version of the item.
    /// </summary>
    /// <param name="me">The item to check.</param>
    /// <param name="link">The link record.</param>
    /// <returns>True if the link exists in the specified version of the item, False
    /// otherwise.</returns>
    public static bool IsValidLink(
      this Sitecore.Data.Items.Item me, 
      Sitecore.Links.ItemLink link)
    {
      Sitecore.Diagnostics.Assert.IsNotNull(me, "item");
      Sitecore.Diagnostics.Assert.IsNotNull(link, "link");

      // If the link is in a different database
      if (String.Compare(
        link.SourceDatabaseName, 
        me.Database.Name, 
        StringComparison.OrdinalIgnoreCase) != 0)
      {
        return false;
      }

      // If the source field is unknown.
      if (link.SourceFieldID == Sitecore.Data.ID.Null)
      {
        me.Fields.ReadAll();

        foreach (Sitecore.Data.Fields.Field checkField in me.Fields)
        {
          if (!checkField.Value.Contains(link.TargetItemID.ToString()))
          {
            continue;
          }

          string message = String.Format(
            "{0} : Link to {1} in {2} of {3}, but field has Null ID in links database",
            me,
            link.TargetItemID,
            checkField.Name,
            me.Paths.FullPath);
          Sitecore.Diagnostics.Log.Warn(message, me);
          return false;
        }

        string error = String.Format(
          "{0} : link database record from {1} to {2}, but field has Null ID in links database and no field value contains reference",
          me,
          me.Paths.FullPath,
          link.TargetItemID);
        Sitecore.Diagnostics.Log.Warn(error, me);
        return false;
      }

      // The field containing the link.
      Sitecore.Data.Fields.Field field = me.Fields[link.SourceFieldID];

      // The field does not exist.
      if (field == null)
      {
        return false;
      }

      // The link must be in a previous version of the item.
      if (field.Value.Contains(link.TargetItemID.ToString())
        || field.Value.Contains(link.TargetItemID.ToShortID().ToString()))
      {
        return true;
      }

      return false;
    }
  }
}