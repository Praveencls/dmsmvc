//------------------------------------------------------------------------------------------------- 
// <copyright file="WebUtil.cs" company="Sitecore Shared Source">
// Copyright (c) Sitecore.  All rights reserved.
// </copyright>
// <summary>Defines the Sitecore.Sharedsource.Web.WebUtil type.</summary>
// <license>
// http://sdn.sitecore.net/Resources/Shared%20Source/Shared%20Source%20License.aspx
// </license>
// <url>http://trac.sitecore.net/Library/</url>
//-------------------------------------------------------------------------------------------------

namespace Sitecore.Sharedsource.Web
{
  using System;
  using System.Web;
  using Sitecore.Sharedsource.Sites.SiteContext;

  /// <summary>
  /// Web utilities.
  /// </summary>
  public class WebUtil
  {
    /// <summary>
    /// Transform a media URL (include hostname, replace ~/media with /~/media,
    /// and lowercase depending on configuration).
    /// </summary>
    /// <param name="original">The original URL.</param>
    /// <returns>The transformed URL.</returns>
    public static string TransformMediaUrl(string original)
    {
      if (String.IsNullOrEmpty(original))
      {
        return original;
      }

      bool lowercase = false;
      object property = Sitecore.Reflection.ReflectionUtil.GetProperty(
        Sitecore.Links.LinkManager.Provider,
        "Lowercase");

      if (property != null)
      {
        lowercase = Sitecore.MainUtil.GetBool(property, false);
      }

      return TransformMediaUrl(original, lowercase);
    }

    /// <summary>
    /// Transform a media URL (include hostname, replace ~/media with /~/media,
    /// and lowercase depending on configuration).
    /// </summary>
    /// <param name="original">The original URL.</param>
    /// <param name="lowercase">Whether to lowercase the URL 
    /// (excluding the query string).</param>
    /// <returns>The transformed URL.</returns>
    public static string TransformMediaUrl(string original, bool lowercase)
    {
      if (String.IsNullOrEmpty(original))
      {
        return original;
      }

      return TransformMediaUrl(original, lowercase, GetMediaHost());
    }

    /// <summary>
    /// Transform a media URL (include hostname, replace ~/media with /~/media,
    /// and lowercase depending on configuration).
    /// </summary>
    /// <param name="original">The original URL.</param>
    /// <param name="lowercase">Whether to lowercase the URL 
    /// (excluding the query string).</param>
    /// <param name="hostname">The protocol and media host (http://localhost),
    /// or an empty string.</param>
    /// <returns>The transformed URL.</returns>
    public static string TransformMediaUrl(
      string original, 
      bool lowercase, 
      string hostname)
    {
      if (String.IsNullOrEmpty(original))
      {
        return original;
      }

      string updated = original;

      if (lowercase)
      {
        updated = Sitecore.Sharedsource.Web.WebUtil.LowercaseUrl(updated);
      }

      updated = Sitecore.StringUtil.EnsurePrefix('/', updated);

      if (!String.IsNullOrEmpty(hostname))
      {
        if (hostname.Contains(":"))
        {
          updated = hostname + updated;
        }
        else
        {
          updated = HttpContext.Current.Request.Url.Scheme + "://" + hostname + updated;
        }
      }

      return updated;
    }

    /// <summary>
    /// Get the protocol and hostname (http://localhost) to use for media URLs, 
    /// or an empty string.
    /// </summary>
    /// <returns>The protocol and hostname to use for media URLs, or an empty string.</returns>
    public static string GetMediaHost()
    {
      Sitecore.Diagnostics.Assert.IsNotNull(Sitecore.Context.Site, "Sitecore.Context.Site");
      string mediaHost = Sitecore.Context.Site.GetMediaHost();

      if (String.IsNullOrEmpty(mediaHost))
      {
        // If the shared source LinkProvider is in place and specifies a media host
        object mediaHostProp = Sitecore.Reflection.ReflectionUtil.GetProperty(
          Sitecore.Links.LinkManager.Provider,
          "MediaHost");

        if (mediaHostProp != null)
        {
          mediaHost = mediaHostProp.ToString();
        }
      }

      if (String.IsNullOrEmpty(mediaHost) 
        && Sitecore.Links.LinkManager.Provider.AlwaysIncludeServerUrl)
      {
        mediaHost = HttpContext.Current.Request.Url.Host;
      }

      if (String.IsNullOrEmpty(mediaHost))
      {
        return String.Empty;
      }

      if (!mediaHost.Contains(":"))
      {
        mediaHost = HttpContext.Current.Request.Url.Scheme + "://" + mediaHost;
      }

      return mediaHost;
    }

    /// <summary>
    /// Lowercase the URL excluding the query string parameters.
    /// </summary>
    /// <param name="url">The URL to lowercase.</param>
    /// <returns>The URL in lowercase (except for the query string).</returns>
    public static string LowercaseUrl(string url)
    {
      if (url.Contains("?"))
      {
        int pos = url.IndexOf('?');
        string query = url.Substring(pos);
        url = url.Substring(0, pos).ToLower() + query;
      }
      else
      {
        url = url.ToLower();
      }

      return url;
    }
  }
}