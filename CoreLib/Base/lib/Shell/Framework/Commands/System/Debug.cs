//------------------------------------------------------------------------------------------------- 
// <copyright file="Debug.cs" company="Sitecore Shared Source">
// Copyright (c) Sitecore.  All rights reserved.
// </copyright>
// <summary>Defines the Debug type.</summary>
// <license>
// http://sdn.sitecore.net/Resources/Shared%20Source/Shared%20Source%20License.aspx
// </license>
// <url>http://trac.sitecore.net/Library/</url>
//-------------------------------------------------------------------------------------------------

//TODO: Prompt "do you want to debug the home item?" or do something else if no item is selected or the selected item has no layout details.

namespace Sitecore.Sharedsource.Shell.Framework.Commands.System
{
  using global::System;

  /// <summary>
  /// Replacement for system:debug command to provide a Content Editor ribbon
  /// command.
  /// </summary>
  [Serializable]
  public class Debug : Sitecore.Shell.Framework.Commands.Command
  {
    /// <summary>
    /// Execute the debug command.
    /// </summary>
    /// <param name="context">The command context.</param>
    public override void Execute(
      Sitecore.Shell.Framework.Commands.CommandContext context)
    {
      // Prompt to save if necessary.
      Context.ClientPage.ClientResponse.CheckModified(false);

      // Database selected by user.
      Sitecore.Data.Database contentDatabase = Context.ContentDatabase;

      // Database associated with item selected by user.
      if ((context.Items != null) && (context.Items.Length == 1))
      {
        contentDatabase = context.Items[0].Database;
      }

      // Default URL for context (shell) site.
      Sitecore.Text.UrlString webSiteUrl = 
        Sitecore.Sites.SiteContext.GetWebSiteUrl();

      // Enable debugging.
      webSiteUrl.Add("sc_debug", "1");

      if ((context.Items != null) && (context.Items.Length == 1))
      {
        Sitecore.Data.Items.Item item = context.Items[0];

        if (item.Visualization.Layout != null)
        {
          // Set the item to debug.
          webSiteUrl.Add("sc_itemid", item.ID.ToString());
        }

        // Set the language to debug.
        webSiteUrl.Add("sc_lang", item.Language.ToString());
      }

      // Set the database to debug.
      if (contentDatabase != null)
      {
        webSiteUrl.Add("sc_database", contentDatabase.Name);
      }

      // Enable profiling.
      webSiteUrl.Add("sc_prof", "1");
      
      // Enable tracing.
      webSiteUrl.Add("sc_trace", "1");

      // Enable rendering information.
      webSiteUrl.Add("sc_ri", "1");

      // Show the debugging window.
      Context.ClientPage.ClientResponse.Eval("window.open('" + webSiteUrl + "', '_blank')");
    }
  }
}