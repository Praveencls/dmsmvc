//------------------------------------------------------------------------------------------------- 
// <copyright file="GetUrlExtension.cs" company="Sitecore Shared Source">
// Copyright (c) Sitecore.  All rights reserved.
// </copyright>
// <summary>
// Implements the Sitecore.Data.Items.Item.GetUrl() extension method.
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
  /// Extension method for Sitecore.Data.Items.Item to return the URL of 
  /// a content or media item.
  /// Use the Sitecore.Sharedsource.Data.Items.Item namespace to use this method.
  /// </summary>
  public static class GetUrlExtension
  {
    /// <summary>
    /// Extension method for Sitecore.Data.Items.Item to return the URL of the item or
    /// media item.
    /// </summary>
    /// <param name="item">The content or media item.</param>
    /// <returns>The URL of the content or media item.</returns>
    public static string GetUrl(this Sitecore.Data.Items.Item item)
    {
      return item.GetUrl(true);
    }

    /// <summary>
    /// Extension method for Sitecore.Data.Items.Item to return the URL of the item or
    /// media item.
    /// </summary>
    /// <param name="item">The content or media item.</param>
    /// <param name="except">Whether to throw an exception if the item is neither a
    /// media nor a content item.</param>
    /// <returns>The URL of the content or media item.</returns>
    /// <exception cref="ArgumentException"><c>ArgumentException</c> - Item is neither
    /// content nor media.</exception>
    public static string GetUrl(
      this Sitecore.Data.Items.Item item, 
      bool except)
    {
      string url = String.Empty;

      if (item.Paths.IsMediaItem)
      {
        Sitecore.Data.Items.MediaItem media =
          new Sitecore.Data.Items.MediaItem(item);
        url = Sitecore.StringUtil.EnsurePrefix(
          '/',
          Sitecore.Resources.Media.MediaManager.GetMediaUrl(media));

        // If the shared source LinkProvider is in place and configured to lowercase URLs
        object property = Sitecore.Reflection.ReflectionUtil.GetProperty(
          Sitecore.Links.LinkManager.Provider,
          "Lowercase");

        if (property != null && Sitecore.MainUtil.GetBool(property, false))
        {
          url = url.ToLower();
        }

        return url;
      }

      if (except && !item.Paths.IsContentItem)
      {
        throw new ArgumentException(
          item.Paths.FullPath + " is not a content item.");
      }

      return Sitecore.Links.LinkManager.GetItemUrl(item);
    }
  }
}
