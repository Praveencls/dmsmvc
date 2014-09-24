//------------------------------------------------------------------------------------------------- 
// <copyright file="GetNotFoundItemExtension.cs" company="Sitecore Shared Source">
// Copyright (c) Sitecore.  All rights reserved.
// </copyright>
// <summary>Defines the Sitecore.Sites.SiteContext.GetNotFoundItem() extension method.</summary>
// <license>
// http://sdn.sitecore.net/Resources/Shared%20Source/Shared%20Source%20License.aspx
// </license>
// <url>http://trac.sitecore.net/Library/</url>
//-------------------------------------------------------------------------------------------------

namespace Sitecore.Sharedsource.Sites.SiteContext
{
  using System;

  /// <summary>
  /// Extension to Sitecore.Sites.SiteContext to return the not found item for a site.
  /// </summary>
  public static class GetNotFoundItemExtension
  {
    /// <summary>
    /// The name of the attribute in the site definition.
    /// </summary>
    public const string NotFoundAttribute = "notFound";

    /// <summary>
    /// Retrieve the item to handle 404 conditions based on the notFound attribute of
    /// the site definition, or Null.
    /// </summary>
    /// <param name="me">This Sitecore.Context.SiteContext.</param>
    /// <returns>The not found item for the site, or Null.</returns>
    public static Sitecore.Data.Items.Item GetNotFoundItem(
      this Sitecore.Sites.SiteContext me)
    {
      Sitecore.Diagnostics.Assert.IsNotNull(me, "me");

      if (Sitecore.Context.Database == null
        || String.IsNullOrEmpty(me.Properties[NotFoundAttribute]))
      {
        return null;
      }

      string path = me.StartPath + me.Properties[NotFoundAttribute];
      Sitecore.Data.Items.Item notFound = 
        Sitecore.Context.Database.GetItem(path);
      Sitecore.Diagnostics.Assert.IsNotNull(notFound, path);
      return notFound;
    }
  }
}
