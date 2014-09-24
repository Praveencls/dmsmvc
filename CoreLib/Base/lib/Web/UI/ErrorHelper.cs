//------------------------------------------------------------------------------------------------- 
// <copyright file="ErrorHelper.cs" company="Sitecore Shared Source">
// Copyright (c) Sitecore.  All rights reserved.
// </copyright>
// <summary>Defines the Sitecore.Sharedsource.Web.UI.ErrorHelper type.</summary>
// <license>
// http://sdn.sitecore.net/Resources/Shared%20Source/Shared%20Source%20License.aspx
// </license>
// <url>http://trac.sitecore.net/Library/</url>
//-------------------------------------------------------------------------------------------------

namespace Sitecore.Sharedsource.Web.UI
{
  using System;
  using System.Configuration;
  using System.Web.Configuration;

  /// <summary>
  /// Redirect the browser to an error page depending on configuration.
  /// </summary>
  public class ErrorHelper
  {
    /// <summary>
    /// Represents the /configuration/system.web/customErrors section of web.config.
    /// </summary>
    private CustomErrorsSection config = null;

    /// <summary>
    /// The URL to which to redirect the user agent in the case of HTTP 500 errors.
    /// </summary>
    private string error500url = null;

    /// <summary>
    /// Gets the /configuration/system.web/customErrors section of web.config.
    /// </summary>
    public CustomErrorsSection Config
    {
      get
      {
        if (this.config == null)
        {
          Configuration doc =
            WebConfigurationManager.OpenWebConfiguration("/");
          this.config =
            (CustomErrorsSection)doc.GetSection("system.web/customErrors");
          Sitecore.Diagnostics.Assert.IsNotNull(this.config, "customErrors");
        }

        return this.config;
      }
    }

    /// <summary>
    /// Gets the URL to which to redirect the user agent in the case of HTTP 500
    /// errors.
    /// </summary>
    public string Error500Url
    {
      get
      {
        if (this.error500url == null && this.Config != null)
        {
          CustomError error500 = 
            this.Config.Errors.Get(500.ToString(
            System.Globalization.CultureInfo.InvariantCulture));

          if (error500 != null && !String.IsNullOrEmpty(error500.Redirect))
          {
            this.error500url = error500.Redirect;
          }

          if (string.IsNullOrEmpty(this.error500url))
          {
            this.error500url = this.Config.DefaultRedirect;
          }
        }

        return this.error500url;
      }
    }

    /// <summary>
    /// Determine whether the server should redirect the user agent in case of HTTP 500
    /// errors.
    /// </summary>
    /// <returns>True if the /configuration/system.web/customErrors element is On or
    /// RemoteOnly and the request is not local.</returns>
    public bool ShouldRedirect()
    {
      if (this.Config == null
        || this.Config.Mode == System.Web.Configuration.CustomErrorsMode.On
        || (this.Config.Mode == System.Web.Configuration.CustomErrorsMode.RemoteOnly
          && !System.Web.HttpContext.Current.Request.IsLocal))
      {
        return true;
      }

      return false;
    }

    /// <summary>
    /// Redirect the user agent to the error page.
    /// </summary>
    public void Redirect()
    {
      if (String.IsNullOrEmpty(this.Error500Url))
      {
        Sitecore.Web.WebUtil.RedirectToErrorPage(
          "//TODO: replace with friendly error message");
      }
      else
      {
        Sitecore.Web.WebUtil.Redirect(
          this.Error500Url + "?aspxerrorpath="
          + Sitecore.Web.WebUtil.GetLocalPath(Sitecore.Context.RawUrl));
      }
    }
  }
}
