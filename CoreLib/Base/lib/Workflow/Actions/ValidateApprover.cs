//------------------------------------------------------------------------------------------------- 
// <copyright file="ValidateApprover.cs" company="Sitecore Shared Source">
// Copyright (c) Sitecore.  All rights reserved.
// </copyright>
// <summary>
// Defines the Sitecore.Sharedsource.Workflow.Actions.ValidateApprover type.
// </summary>
// <license>
// http://sdn.sitecore.net/Resources/Shared%20Source/Shared%20Source%20License.aspx
// </license>
// <url>http://trac.sitecore.net/Library/</url>
//-------------------------------------------------------------------------------------------------

namespace Sitecore.Sharedsource.Workflow.Actions
{
  using System;

  /// <summary>
  /// Workflow action to prevent users from approving their own changes.
  /// </summary>
  public class ValidateApprover
  {
    /// <summary>
    /// Workflow action implementation.
    /// </summary>
    /// <param name="args">Workflow action arguments.</param>
    public void Process(Sitecore.Workflows.Simple.WorkflowPipelineArgs args)
    {
      if (String.Compare(
        args.DataItem.Statistics.UpdatedBy,
        Sitecore.Context.User.Name,
        true) != 0)
      {
        return;
      }

      Sitecore.Web.UI.Sheer.SheerResponse.Alert(
        "You cannot approve your own changes.");
      args.AbortPipeline();
    }
  }
}