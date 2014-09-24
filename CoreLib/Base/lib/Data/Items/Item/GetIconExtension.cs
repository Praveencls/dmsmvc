//------------------------------------------------------------------------------------------------- 
// <copyright file="GetIconExtension.cs" company="Sitecore Shared Source">
// Copyright (c) Sitecore.  All rights reserved.
// </copyright>
// <summary>
// Implements the Sitecore.Data.Items.Item.GetIcon() extension method.
// </summary>
// <license>
// http://sdn.sitecore.net/Resources/Shared%20Source/Shared%20Source%20License.aspx
// </license>
// <url>http://trac.sitecore.net/Library/</url>
//-------------------------------------------------------------------------------------------------

namespace Sitecore.Sharedsource.Data.Items.Item
{
  /// <summary>
  /// Extension method for Sitecore.Data.Items.Item to return the icon associated
  /// with the item.
  /// Use the Sitecore.Sharedsource.Data.Items.Item namespace to use this method.
  /// </summary>
  public static class GetIconExtension
  {
    /// <summary>
    /// Extension method for Sitecore.Data.Items.Item to return the icon associated
    /// with the item,  expanding paths as necessary.
    /// </summary>
    /// <param name="me">The item associated with the icon.</param>
    /// <returns>The path to or URL of the icon.</returns>
    public static string GetIcon(this Sitecore.Data.Items.Item me)
    {
      string icon = me.Appearance.Icon;

      if (icon.StartsWith("~"))
      {
        return Sitecore.StringUtil.EnsurePrefix('/', icon);
      }
      
      if (!(icon.StartsWith("/") || icon.Contains(":")))
      {
        icon = Sitecore.Resources.Images.GetThemedImageSource(icon);
      }

      // Check for the Lowercase property of http://trac.sitecore.net/LinkProvider/
      object property = Sitecore.Reflection.ReflectionUtil.GetProperty(
        Sitecore.Links.LinkManager.Provider,
        "Lowercase");

      if (property != null && Sitecore.MainUtil.GetBool(property, false))
      {
        icon = icon.ToLower();
      }

      //TODO: hostname from link provider?
      return icon;
    }
  }
}
