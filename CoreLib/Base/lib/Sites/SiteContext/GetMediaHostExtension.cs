//------------------------------------------------------------------------------------------------- 
// <copyright file="GetMediaHostExtension.cs" company="Sitecore Shared Source">
// Copyright (c) Sitecore.  All rights reserved.
// </copyright>
// <summary>Implements the Sitecore.Sites.SiteContext.GetMediaHost() extension method.</summary>
// <license>
// http://sdn.sitecore.net/Resources/Shared%20Source/Shared%20Source%20License.aspx
// </license>
// <url>http://trac.sitecore.net/Library/</url>
//-------------------------------------------------------------------------------------------------

namespace Sitecore.Sharedsource.Sites.SiteContext
{
  using System;

  /// <summary>
  /// Extension to Sitecore.Sites.SiteContext to return the media host.
  /// </summary>
  public static class GetMediaHostExtension
  {
    /// <summary>
    /// The name of media host attribute in the site definition.
    /// </summary>
    public const string MediaHostAttribute = "mediaHost";

    /// <summary>
    /// Retrieve the hostname, potentially including a protocol, to use in media URLs.
    /// </summary>
    /// <param name="me">The site referencing the media.</param>
    /// <returns>The hostname to use in media URLs, or an empty string.</returns>
    public static string GetMediaHost(
      this Sitecore.Sites.SiteContext me)
    {
      Sitecore.Diagnostics.Assert.IsNotNull(me, "me");

      if (Sitecore.Context.Database == null
        || String.IsNullOrEmpty(me.Properties[MediaHostAttribute]))
      {
        return null;
      }

      return me.Properties[MediaHostAttribute];
    }
  }
}
