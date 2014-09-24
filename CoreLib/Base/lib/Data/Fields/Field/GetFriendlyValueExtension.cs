//------------------------------------------------------------------------------------------------- 
// <copyright file="GetFriendlyValueExtension.cs" company="Sitecore Shared Source">
// Copyright (c) Sitecore.  All rights reserved.
// </copyright>
// <summary>
// Defines the Sitecore.Sharedsource.Data.Fields.Field.GetFriendlyValueExtension type.</summary>
// <license>
// http://sdn.sitecore.net/Resources/Shared%20Source/Shared%20Source%20License.aspx
// </license>
// <url>http://trac.sitecore.net/Library/</url>
//-------------------------------------------------------------------------------------------------

namespace Sitecore.Sharedsource.Data.Fields.Field
{
  using System;

  /// <summary>
  /// Extension method for Sitecore.Data.Fields.Field to return 
  /// the friendly value of the field.
  /// </summary>
  public static class GetFriendlyValueExtension
  {
    /// <summary>
    /// Retrieve the friendly value of a field.
    /// </summary>
    /// <param name="me">The field.</param>
    /// <returns>The friendly value of the field.</returns>
    public static string GetFriendlyValue(
      this Sitecore.Data.Fields.Field me)
    {
      switch (me.Type)
      {
        case "general link":
        case "date":
        case "datetime":
        case "image":
        case "integer":
        case "multi-line text":
        case "number":
        case "rich text":
        case "single-line text":
          return Sitecore.Web.UI.WebControls.FieldRenderer.Render(
            me.Item, 
            me.Name);
        case "file":
          Sitecore.Data.Fields.ImageField media = 
            new Sitecore.Data.Fields.ImageField(me, me.Type);

          if (media == null || media.MediaItem == null)
          {
            return String.Empty;
          }

          string extension = 
            new Sitecore.Data.Items.MediaItem(media.MediaItem).Extension;
          string url = Sitecore.Resources.Media.MediaManager.GetMediaUrl(
            media.MediaItem);

          if (Sitecore.Configuration.Settings.ImageTypes.Contains(extension))
          {
            return String.Format(
              @"<img src=""{0}"" alt=""{1}"" />",
              url,
              media.MediaItem.Fields["alt"]);
          }

          return String.Format(
            @"<a href=""{0}"">{1}</a>",
            Sitecore.Resources.Media.MediaManager.GetMediaUrl(media.MediaItem),
            media.MediaItem.Name);
        case "checkbox":
        case "checklist":
        case "droplist":
        case "grouped droplink":
        case "grouped droplist":
        case "multilist":
        case "treelist":
        case "treelistex":
        case "droplink":
        case "droptree":
        case "icon":
        case "iframe":
        case "tristate":
        case "internal link":
        case "password":
          throw new ArgumentException("Unsupported field type");
        default:
          throw new ArgumentException("Unknown field type: " + me.Type);
      }
    }
  }
}
