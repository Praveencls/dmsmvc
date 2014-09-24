//------------------------------------------------------------------------------------------------- 
// <copyright file="ErrorRedirector.cs" company="Sitecore Shared Source">
// Copyright (c) Sitecore.  All rights reserved.
// </copyright>
// <summary>Defines the ErrorRedirector type.</summary>
// <license>
// http://sdn.sitecore.net/Resources/Shared%20Source/Shared%20Source%20License.aspx
// </license>
// <url>//TODO: URL</url>
//-------------------------------------------------------------------------------------------------

namespace Sitecore.Sharedsource.Web.UI.WebControls
{
  using System.Web.UI;

  /// <summary>
  /// Error management Web control.
  /// </summary>
  public class ErrorRedirector : Sitecore.Web.UI.WebControls.StandardErrorControl
  {
    /// <summary>
    /// Required for error controls.
    /// </summary>
    /// <returns>Cloned object.</returns>
    public override Sitecore.Web.UI.WebControls.ErrorControl Clone()
    {
      return (Sitecore.Web.UI.WebControls.ErrorControl) MemberwiseClone();
    }

    /// <summary>
    /// Web control implementation method.
    /// </summary>
    /// <param name="output">Output stream.</param>
    protected override void DoRender(HtmlTextWriter output)
    {
      Sitecore.Diagnostics.Log.Error(this.Message, this);
      ErrorHelper helper = new ErrorHelper();

      if (helper.ShouldRedirect())
      {
        helper.Redirect();
      }
      else
      {
        base.DoRender(output);
      }
    }
  }
}
