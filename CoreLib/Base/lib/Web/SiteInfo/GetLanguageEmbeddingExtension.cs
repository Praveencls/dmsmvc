//------------------------------------------------------------------------------------------------- 
// <copyright file="XmlMembershipProvider.cs" company="Sitecore Shared Source">
// Copyright (c) Sitecore.  All rights reserved.
// </copyright>
// <summary>
// Implements Sitecore.Web.SiteInfo.GetLanguageEmbedding() extension method type.
// </summary>
// <license>
// http://sdn.sitecore.net/Resources/Shared%20Source/Shared%20Source%20License.aspx
// </license>
// <url>http://trac.sitecore.net/Library/</url>
//-------------------------------------------------------------------------------------------------

namespace Sitecore.Sharedsource.Web.SiteInfo
{
  using System;

  /// <summary>
  /// Implements the Sitecore.Web.SiteInfo.GetLanguageEmbedding()
  /// extension method.
  /// </summary>
  public static class GetLanguageEmbeddingExtension
  {
    /// <summary>
    /// The name of the attribute in the site definition that controls
    /// language embedding.
    /// </summary>
    public const string LanguageEmbeddingAttribute = "languageEmbedding";

    /// <summary>
    /// Indicates whether language embedding in URLs is enabled for the site.
    /// </summary>
    /// <param name="me">The site to check.</param>
    /// <returns>True, false, or undefined depending on the languageEmbedding
    /// attribute of the site.
    /// </returns>
    public static Sitecore.Tristate GetLanguageEmbedding(
      this Sitecore.Web.SiteInfo me)
    {
      Sitecore.Diagnostics.Assert.IsNotNull(me, "me");
      string setting = me.Properties[LanguageEmbeddingAttribute];

      if (Sitecore.Context.Database == null || String.IsNullOrEmpty(setting))
      {
        return Tristate.Undefined;
      }

      if (Sitecore.MainUtil.GetBool(setting, false))
      {
        return Tristate.True;
      }

      return Tristate.False;
    }
  }
}
