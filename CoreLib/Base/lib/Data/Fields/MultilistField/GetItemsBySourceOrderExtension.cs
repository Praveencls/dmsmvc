//------------------------------------------------------------------------------------------------- 
// <copyright file="GetItemsBySourceOrderExtension.cs" company="Sitecore Shared Source">
// Copyright (c) Sitecore.  All rights reserved.
// </copyright>
// <summary>Defines the GetItemsBySourceOrderExtension type.</summary>
// <license>
// http://sdn.sitecore.net/Resources/Shared%20Source/Shared%20Source%20License.aspx
// </license>
// <url>http://trac.sitecore.net/Library/</url>
//-------------------------------------------------------------------------------------------------

namespace Sitecore.Sharedsource.Data.Fields.MultilistField
{
  using System.Collections.Generic;

  /// <summary>
  /// Extension method for Sitecore.Data.Fields.MultlistField to return the selected
  /// items in the order in which they are specified by the source property of the
  /// field definition item rather than the order selected by the user.
  /// </summary>
  public static class GetItemsBySourceOrderExtension
  {
    /// <summary>
    /// Return the items selected in the multilist field in the order specified by the
    /// source property of the field definition item rather than the order selected by
    /// the user.
    /// </summary>
    /// <param name="me">The multilist field.</param>
    /// <returns>The items selected in the multilist field in the order specified by
    /// the source property of the field definition item.</returns>
    public static Sitecore.Data.Items.Item[] GetItemsBySourceOrder(
      this Sitecore.Data.Fields.MultilistField me)
    {
      Sitecore.Diagnostics.Assert.IsNotNull(me, "me");
      List<Sitecore.Data.Items.Item> userOrdered =
        new List<Sitecore.Data.Items.Item>(me.GetItems());

      if (me.Count < 2)
      {
        return userOrdered.ToArray();
      }

      Sitecore.Data.Items.Item source =
        userOrdered[0].Database.GetItem(me.InnerField.Source);

      if (source == null)
      {
        return userOrdered.ToArray();
      }

      return GetChildrenInOrder(source, userOrdered);
    }

    /// <summary>
    /// Returns the children that exist in the list in the order in which they appear
    /// under the parent item according to the sorting rule for the parent.
    /// </summary>
    /// <param name="parent">The parent item.</param>
    /// <param name="list">The list of children of the parent to sort.</param>
    /// <returns>
    /// The children that exist in the list in the order in which they appear under the
    /// parent item according to the sorting rule for the parent.
    /// </returns>
    public static Sitecore.Data.Items.Item[] GetChildrenInOrder(
      Sitecore.Data.Items.Item parent,
      List<Sitecore.Data.Items.Item> list)
    {
      List<Sitecore.Data.Items.Item> sourceOrdered =
        new List<Sitecore.Data.Items.Item>();

      foreach (Sitecore.Data.Items.Item child in parent.Children)
      {
        for (int i = 0; i < list.Count; i++)
        {
          if (child.ID != list[i].ID)
          {
            continue;
          }

          sourceOrdered.Add(list[i]);
          list.Remove(list[i]);
          break;
        }
      }

      return sourceOrdered.ToArray();
    }
  }
}
