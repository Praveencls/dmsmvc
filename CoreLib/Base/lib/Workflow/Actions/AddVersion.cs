using System;

namespace Sitecore.Sharedsource.Workflow.Actions
{
  /// <summary>
  /// Workflow action to add a version of the item.
  /// </summary>
  public class AddVersion
  {
    #region Private members.

    /// <summary>
    /// The state in which to place the old (unpublished) version of the item.
    /// </summary>
    private string targetState = null;

    /// <summary>
    /// The state in which to place the new version of the item.
    /// </summary>
    private string nextState = null;

    #endregion 

    #region Protected properties

    /// <summary>
    /// The item involved in the workflow.
    /// </summary>
    protected Sitecore.Data.Items.Item DataItem
    {
      get;
      set;
    }

    /// <summary>
    /// The workflow action definition item.
    /// </summary>
    protected Sitecore.Data.Items.Item ActionItem
    {
      get;
      set;
    }

    #endregion 

    #region Public properties

    /// <summary>
    /// The state in which to place the new version of the item.
    /// </summary>
    public string TargetState
    {
      get
      {
        //TODO: refactor
        //TODO: add workflow comment
        if (this.targetState == null)
        {
          this.targetState = this.ActionItem["Target State"];
        }

        if (String.IsNullOrEmpty(this.targetState))
        {
          Sitecore.Data.Items.Item workflow = null;
          Sitecore.Data.Items.Item loop = this.ActionItem;

          while (workflow == null && loop != null)
          {
            if (loop.TemplateID == Sitecore.TemplateIDs.Workflow)
            {
              workflow = loop;
            }

            loop = loop.Parent;
          }

          if (workflow != null)
          {
            string query = String.Format(
              ".//*[@@templateid='{0}' and @Final = '1']",
              Sitecore.TemplateIDs.WorkflowState);
            Sitecore.Data.Items.Item[] states = workflow.Axes.SelectItems(query);

            if (states != null && states.Length == 1)
            {
              this.targetState = states[0].ID.ToString();
            }
          }
        }

        return this.targetState;
      }

      set
      {
        this.targetState = value;
      }
    }

    #endregion 

    #region Public methods

    /// <summary>
    /// Workflow action implementation.
    /// </summary>
    /// <param name="args">Workflow action pipeline arguments.</param>
    public void Process(Sitecore.Workflows.Simple.WorkflowPipelineArgs args)
    {
      Sitecore.Diagnostics.Assert.IsNotNull(args, "args");
      Sitecore.Diagnostics.Assert.IsNotNull(args.DataItem, "args.DataItem");
      Sitecore.Diagnostics.Assert.IsNotNull(args.ProcessorItem, "args.ProcessorItem");
      Sitecore.Diagnostics.Assert.IsNotNull(
        args.ProcessorItem.InnerItem, 
        "args.ProcessorItem.InnerItem");
      this.DataItem = args.DataItem;
      this.ActionItem = args.ProcessorItem.InnerItem;

      // Add a new version.
      Sitecore.Data.Items.Item newVersion = this.DataItem.Versions.AddVersion();
      newVersion.Editing.BeginEdit();

      //TODO: determine if necessary
      // Ensure new version is publishable.
      newVersion.Fields[Sitecore.FieldIDs.HideVersion].Value = String.Empty;
      this.DataItem.Editing.BeginEdit();

      // Hide the old version.
      this.DataItem.Fields[Sitecore.FieldIDs.HideVersion].Value = "1";

      // Move the old version to the specified state
      // or the final state of the workflow.
      if (!String.IsNullOrEmpty(this.TargetState))
      {
        // args.nextStateId is the state Sitecore would move the old version to.
        args.NextStateId = Sitecore.Data.ID.Parse(this.TargetState);
      }

      // Move the new version to the next state associated with the current workflow command.
      if (String.IsNullOrEmpty(this.NextState))
      {
        newVersion.Fields[Sitecore.FieldIDs.WorkflowState].Value = args.NextStateId.ToString();
      }
      else
      {
        newVersion.Fields[Sitecore.FieldIDs.WorkflowState].Value = this.NextState;
      }

      newVersion.Editing.EndEdit();
      this.DataItem.Editing.EndEdit();

      if (Sitecore.Context.IsBackgroundThread || !Sitecore.Context.ClientPage.IsEvent)
      {
        return;
      }

      string message = String.Format(
        "item:load(id={0},version={1},language={2})",
        this.DataItem.ID,
        this.DataItem.Versions.Count,
        this.DataItem.Language);
      Sitecore.Context.ClientPage.ClientResponse.Timer(message, 2);
    }

    public string NextState
    {
      get
      {
        if (this.nextState == null)
        {
          this.nextState = this.ActionItem["NextState"];
        }

        return this.nextState;
      }

      set
      {
        this.nextState = value;
      }
    }

    #endregion
  }
}
