//------------------------------------------------------------------------------------------------- 
// <copyright file="HasPublishingRestrictionsExtension.cs" company="Sitecore Shared Source">
// Copyright (c) Sitecore.  All rights reserved.
// </copyright>
// <summary>
// Implements the Sitecore.Data.Items.Item.HasPublishingRestrictions() extension method.
// </summary>
// <license>
// http://sdn.sitecore.net/Resources/Shared%20Source/Shared%20Source%20License.aspx
// </license>
// <url>http://trac.sitecore.net/Library/</url>
//-------------------------------------------------------------------------------------------------

namespace Sitecore.Sharedsource.Data.Items.Item
{
  using System;

  /// <summary>
  /// Extension method for Sitecore.Data.Items.Item to determine whether any of the
  /// ancestors of an item or a version of that item has publishing restrictions.
  /// Use the Sitecore.Sharedsource.Data.Items.Item namespace to use this method.
  /// </summary>
  public static class HasPublishingRestrictionsExtension
  {
    /// <summary>
    /// Extension method to Sitecore.Data.Items.Item to indicate whether an item  or a
    /// version of an item or any of its ancestors has publishing restrictions. Does
    /// not check publishing targets.
    /// </summary>
    /// <param name="me">The item to check.</param>
    /// <param name="checkAncestors">Whether to check ancestors of the item for
    /// publishing restrictions (does not check version publishing restrictions).
    /// </param>
    /// <param name="requireLatest">Whether to check if this version of the item has
    /// publishing restrictions.</param>
    /// <returns>True if the item or any of its ancestors has publishing restrictions.
    /// </returns>
    public static bool HasPublishingRestrictions(
      this Sitecore.Data.Items.Item me, 
      bool checkAncestors,
      bool requireLatest)
    {
      Sitecore.Diagnostics.Assert.IsNotNull(me, "item");

      if (!me.Publishing.IsPublishable(DateTime.Now, checkAncestors))
      {
        return true;
      }

      if (!requireLatest)
      {
        return false;
      }

      if (!me.IsLatest())
      {
        return true;
      }

      Sitecore.Data.Items.Item publishable = 
        me.Publishing.GetValidVersion(DateTime.Now, true);

      if (publishable == null || !me.IsSameRevision(publishable))
      {
        return true;
      }

      return false;
    }

    /// <summary>
    /// Extension method to Sitecore.Data.Items.Item to indicate whether an item  or a
    /// version of an item or any of its ancestors has publishing restrictions.
    /// </summary>
    /// <param name="me">The item to check.</param>
    /// <param name="checkAncestors">Whether to check ancestors of the item for
    /// publishing restrictions (does not check version publishing restrictions).
    /// </param>
    /// <param name="checkRevision">Whether to check if this version of the item has
    /// publishing restrictions.</param>
    /// <param name="target">Publishing target to check.</param>
    /// <returns>
    /// True if the item or any of its ancestors has publishing restrictions.
    /// </returns>
    public static bool HasPublishingRestrictions(
      this Sitecore.Data.Items.Item me,
      bool checkAncestors,
      bool checkRevision, 
      Sitecore.Sharedsource.Publishing.PublishingTarget target)
    {
      if (me.HasPublishingRestrictions(checkAncestors, checkRevision))
      {
        return true;
      }

      if (!target.IsRelevant(me))
      {
        return true;
      }

      return false;
    }
  }
}
