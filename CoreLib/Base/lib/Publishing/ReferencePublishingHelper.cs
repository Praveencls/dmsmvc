//------------------------------------------------------------------------------------------------- 
// <copyright file="ReferencePublishingHelper.cs" company="Sitecore Shared Source">
// Copyright (c) Sitecore.  All rights reserved.
// </copyright>
// <summary>Defines the Sitecore.Sharedsource.Publishing.ReferencePublishingHelper type.</summary>
// <license>
// http://sdn.sitecore.net/Resources/Shared%20Source/Shared%20Source%20License.aspx
// </license>
// <url>http://trac.sitecore.net/Library/</url>
//-------------------------------------------------------------------------------------------------

// TODO: avoid multiple events and cache clearings. 

namespace Sitecore.Sharedsource.Publishing
{
  using System;
  using System.Collections.Generic;
  using Sitecore.Sharedsource.Data.Items.Item;

  /// <summary>
  /// Helper class for publishing items referenced by an item and the item itself.
  /// </summary>
  public class ReferencePublishingHelper
  {
    #region Private members

    /// <summary>
    /// Publishing targets.
    /// </summary>
    private Sitecore.Sharedsource.Publishing.PublishingTarget[] targets = null;

    /// <summary>
    /// Logging facility.
    /// </summary>
    private Sitecore.Sharedsource.Diagnostics.Logger logger;

    #endregion

    #region Public properties

    /// <summary>
    /// Gets or sets a value indicating whether to throw exceptions if the item or an
    /// item it references cannot be published.
    /// </summary>
    public bool ThrowExceptions
    {
      get;
      set;
    }

    /// <summary>
    /// Gets or sets a value indicating whether to require the latest revision of the
    /// item published.
    /// </summary>
    public bool RequireLatestRevision
    {
      get;
      set;
    }
    
    /// <summary>
    /// Gets or sets a value indicating whether to publish the ancestors of each item.
    /// </summary>
    public bool PublishAncestors
    {
      get;
      set;
    }

    /// <summary>
    /// Gets or sets a value indicating whether to publish the descendants of the item.
    /// </summary>
    public bool PublishDescendants
    {
      get;
      set;
    }

    /// <summary>
    /// Gets or sets a value indicating whether to publish the media items referenced by the item.
    /// </summary>
    public bool PublishReferencedMedia
    {
      get;
      set;
    }

    /// <summary>
    /// Gets or sets a value indicating whether to publish items referenced by the
    /// item.
    /// </summary>
    public bool PublishReferencedItems
    {
      get; 
      set;
    }

    /// <summary>
    /// Gets or sets a value indicating whether to require the latest revisions of
    /// referenced items.
    /// </summary>
    public bool RequireLatestReferences
    {
      get;
      set;
    }

    /// <summary>
    /// Gets or sets a value indicating whether to publish required ancestors of
    /// referenced items.
    /// </summary>
    public bool PublishReferencedAncestors
    { 
      get; 
      set;
    }

    /// <summary>
    /// Gets or sets a value indicating whether to require referenced items.
    /// </summary>
    public bool RequireReferencedItems
    { 
      get;
      set;
    }

    /// <summary>
    /// Gets or sets a collection mapping publishing target definition items to
    /// publishing databases.
    /// </summary>
    public Sitecore.Sharedsource.Publishing.PublishingTarget[] PublishingTargets
    {
      get
      {
        if (this.targets == null)
        {
          this.targets = 
            Sitecore.Sharedsource.Publishing.PublishingTarget.GetPublishingTargets();
        }

        return this.targets;
      }

      set
      {
        this.targets = value;
      }
    }

    #endregion

    #region Protected properties

    /// <summary>
    /// Gets the lazy-loading logging facility.
    /// </summary>
    protected Sitecore.Sharedsource.Diagnostics.Logger Logger
    {
      get
      {
        if (this.logger == null)
        {
          this.logger = new Sitecore.Sharedsource.Diagnostics.Logger(this);
        }

        return this.logger;
      }
    }

    #endregion

    #region Public methods

    /// <summary>
    /// Publish the item and potentially the items it references.
    /// </summary>
    /// <param name="item">The item to publish.</param>
    /// <returns>True on success, False on failure.</returns>
    /// <exception cref="PublishingException"><c>PublishingException</c> - Any type of
    /// error.</exception>
    public bool Publish(Sitecore.Data.Items.Item item)
    {
      Sitecore.Diagnostics.Assert.IsNotNull(item, "item");

      if (!this.BuildQueues(item))
      {
        return false;
      }

      if (!this.PublishQueues(item))
      {
        return false;
      }

      if (!this.Validate(item))
      {
        if (this.ThrowExceptions)
        {
          throw new PublishingException("Publishing validation failure.");
        }

        return false;
      }

      return true;
    }

    /// <summary>
    /// Validate that the appropriate versions of the item and all referenced items
    /// exist in all publishing targets.
    /// </summary>
    /// <param name="item">The root item.</param>
    /// <returns>True if the appropriate versions of the item and all referenced items
    /// exist in all publishing targets, False otherwise.</returns>
    protected bool Validate(Sitecore.Data.Items.Item item)
    {
      bool result = true;

      foreach (Sitecore.Sharedsource.Publishing.PublishingTarget target 
        in this.PublishingTargets)
      {
        if (!target.ContainsItem(item, true))
        {
          this.Logger.Info(
            "{0} does not contain latest {1} after publishing", 
            target.Database.Name, 
            item.Paths.FullPath);
          result = false;
        }

        foreach (Sitecore.Data.Items.Item source in target.GetQueuedItems())
        {
          Sitecore.Data.Items.Item compare = item.Database.GetItem(
            source.ID,
            item.Language,
            Sitecore.Data.Version.Latest);

          if (target.ContainsItem(compare, true))
          {
            this.Logger.Info(
              "{0} does not contain latest referenced {1} after publishing", 
              target.Database.Name, 
              compare.Paths.FullPath);
            result = false;
          }
        }
      }

      return result;
    }

    /// <summary>
    /// Publish all publishing queues.
    /// </summary>
    /// <param name="item">The root item.</param>
    /// <returns>True on success, False on any type of error.</returns>
    /// <exception cref="Exception"><c>Exception</c> - any type of error.</exception>
    protected bool PublishQueues(Sitecore.Data.Items.Item item)
    {
      foreach (Sitecore.Sharedsource.Publishing.PublishingTarget target
        in this.PublishingTargets)
      {
        if (!target.IsRelevant(item))
        {
          continue;
        }

        // TODO: how to know if publish pipeline encountered an error? Exception?
        // TODO: try other targets if one fails?
        try
        {
          // TODO: raise begin event?
          Sitecore.Events.Event.RaiseEvent(
            "publish:begin", 
            new object[] { this });
          Sitecore.Publishing.Pipelines.Publish.PublishPipeline.Run(
            target.PublishContext);

          // TODO: raise end event?
          Sitecore.Events.Event.RaiseEvent(
            "publish:end", 
            new object[] { this });
        }
        catch (Exception ex)
        {
          this.Logger.Exception(ex);

          // TODO: raise error event?
          Sitecore.Events.Event.RaiseEvent(
            "publish:end", 
            new object[] { this });

          if (this.ThrowExceptions)
          {
            throw;
          }

          return false;
        }
      }

      return true;
    }

    /// <summary>
    /// Build publishing queues for each publishing target.
    /// </summary>
    /// <param name="item">The item to publish.</param>
    /// <returns>True on success, False on any type of failure.</returns>
    /// <exception cref="PublishingException"><c>PublishingException</c> - Any type of
    /// error.</exception>
    protected bool BuildQueues(Sitecore.Data.Items.Item item)
    {
      foreach (Sitecore.Sharedsource.Publishing.PublishingTarget target 
        in this.PublishingTargets)
      {
        if (!target.IsRelevant(item))
        {
          continue;
        }

        if (this.BuildQueue(item, target))
        {
          return true;
        }

        string message = this.Logger.Error(
          "Error building {0} publishing queue for {1}. ",
          target.Database.Name,
          item);

        if (this.ThrowExceptions)
        {
          throw new PublishingException(message);
        }

        return false;
      }

      return true;
    }

    /// <summary>
    /// Build a publishing queue for the specified item to the specified publishing
    /// target.
    /// </summary>
    /// <param name="item">The item to publish.</param>
    /// <param name="target">The publishing target.</param>
    /// <returns>True on success, False on any type of failure.</returns>
    protected bool BuildQueue(
      Sitecore.Data.Items.Item item, 
      Sitecore.Sharedsource.Publishing.PublishingTarget target)
    {
      if (this.HandlePublishingRestrictions(item, false, target))
      {
        return false;
      }

      target.CreatePublishingContext(item);

      if (this.PublishReferencedItems || this.PublishReferencedMedia)
      {
        if (this.HandleReferences(item, target))
        {
          return false;
        }
      }

      return true;
    }

    /// <summary>
    /// Add items referenced by the specified item to the publishihng queue as
    /// specified by <see cref="PublishReferencedItems" /> and 
    /// <see cref="PublishReferencedMedia" />
    /// </summary>
    /// <param name="item">The item containing the references.</param>
    /// <param name="target">The publishing target.</param>
    /// <returns>True if a referenced item could not be added to the publishing queue
    /// and <see cref="RequireReferencedItems" /> is true.</returns>
    /// <exception cref="PublishingException"><c>PublishingException</c> - Any type of
    /// error.</exception>
    protected bool HandleReferences(
      Sitecore.Data.Items.Item item, 
      PublishingTarget target)
    {
      this.Logger.Info("HandleReferences");

      if (this.AddReferencedItemsToQueue(item, target)
        || !this.RequireReferencedItems)
      {
        return false;
      }

      string message = this.Logger.Warn(
        "Unable to publish all items referenced by {0}", 
        item.Paths.FullPath);

      if (this.ThrowExceptions)
      {
        throw new PublishingException(message);
      }

      this.Logger.Info("HandleReferences returns true");
      return true;
    }

    /// <summary>
    /// Handle the case that the specified item has publishing restrictions.
    /// </summary>
    /// <param name="item">The item to check.</param>
    /// <param name="requireLatest">Whether to also check that the version is the
    /// latest and does not have publishing restrictions.</param>
    /// <returns>True if the item or version has publishing restrictions, False
    /// otherwise.</returns>
    /// <exception cref="PublishingException"><c>PublishingException</c> - Any type of
    /// error.</exception>
    protected bool HandlePublishingRestrictions(
      Sitecore.Data.Items.Item item, 
      bool requireLatest)
    {
      Sitecore.Diagnostics.Assert.IsNotNull(item, "item");

      if (item.HasPublishingRestrictions(true, requireLatest))
      {
        string message = this.Logger.Info(
          "{0} has publishing restrictions.", 
          item);

        if (this.ThrowExceptions)
        {
          throw new PublishingException(message);
        }

        return true;
      }

      return false;
    }

    /// <summary>
    /// Handle publishing restrictions for the specified item.
    /// </summary>
    /// <param name="item">The item to check.</param>
    /// <param name="requireLatest">Whether to require that the item specified is the
    /// latest version of the item.</param>
    /// <param name="target">The publishing target to check.</param>
    /// <returns>True if the item has publishing restrictions.</returns>
    /// <exception cref="PublishingException"><c>PublishingException</c> - Any type of
    /// error.</exception>
    protected bool HandlePublishingRestrictions(
      Sitecore.Data.Items.Item item, 
      bool requireLatest, 
      PublishingTarget target)
    {
      Sitecore.Diagnostics.Assert.IsNotNull(item, "item");

      if (this.HandlePublishingRestrictions(item, requireLatest))
      {
        return true;
      }

      if (item.HasPublishingRestrictions(true, requireLatest, target))
      {
        string message = this.Logger.Info(
          "{0} has item publishing restrictions.",
          item.Paths.FullPath);

        if (this.ThrowExceptions)
        {
          throw new PublishingException(message);
        }

        return true;
      }

      return false;
    }

    /// <summary>
    /// Handle links database references to items that do not exist by logging an error
    /// or throwing an exception.
    /// </summary>
    /// <param name="item">The item that contains the reference.</param>
    /// <param name="referenced">The referenced item, which may be Null.</param>
    /// <param name="link">The link record from the links database.</param>
    /// <returns>True if the referenced item is Null, false otherwise.</returns>
    /// <exception cref="PublishingException"><c>PublishingException</c> - Any type of
    /// error.</exception>
    protected bool HandleNullReference(
      Sitecore.Data.Items.Item item, 
      Sitecore.Data.Items.Item referenced, 
      Sitecore.Links.ItemLink link)
    {
      if (referenced != null)
      {
        return false;
      }

      Sitecore.Data.Fields.Field field = item.Fields[link.SourceFieldID];

      if (field == null)
      {
        return true;
      }

      if (field.Value.Contains(link.TargetItemID.ToString()))
      {
        string message = this.Logger.Info(
          "{0} of {1} contains broken link to {2} : {3}",
          field.Name,
          item, 
          link.TargetItemID, 
          link.TargetPath);

        if (this.ThrowExceptions)
        {
          throw new PublishingException(message);
        }

        return true;
      }

      return true;
    }

    /// <summary>
    /// Add the item to the publishing queue.
    /// </summary>
    /// <param name="item">The referenced item.</param>
    /// <param name="target">The publishing target.</param>
    /// <param name="processed">A list of items already processed (for optimization).
    /// </param>
    /// <returns>True if there was an error adding the item to the publishing queue.
    /// </returns>
    /// <exception cref="PublishingException"><c>PublishingException</c> - Any type of
    /// error.</exception>
    protected bool AddToQueue(
      Sitecore.Data.Items.Item item, 
      PublishingTarget target, 
      HashSet<Sitecore.Data.ID> processed)
    {
      Sitecore.Diagnostics.Assert.IsNotNull(item, "item");
      Sitecore.Diagnostics.Assert.IsNotNull(target, "target");
      Sitecore.Diagnostics.Assert.IsNotNull(processed, "processed");

      // TODO: ensure items other than root not added to procesed until here
      // TODO: check publishing targets including ancestors
      if (processed.Contains(item.ID))
      {
        return true;
      }

      processed.Add(item.ID);

      if (this.HandlePublishingRestrictions(
        item, 
        this.RequireLatestRevision, 
        target))
      {
        return false;
      }

      // TODO: could be a validation/warning issue as well
      if (!target.IsRelevant(item))
      {
        string message = this.Logger.Info(
          "{0} is not relevant to publishing target {1}",
          item,
          target.Database.Name);

        if (this.ThrowExceptions)
        {
          throw new PublishingException(message);
        }

        return false;
      }

      if (target.ContainsItem(item, this.RequireReferencedItems))
      {
        return true;
      }

      if (this.PublishReferencedAncestors
        && !this.AddRequiredAncestorsToQueue(item, target, false, processed))
      {
        string message = this.Logger.Info(
          "Unable to publish ancestors of {0}",
          item);

        if (this.ThrowExceptions)
        {
          throw new PublishingException(message);
        }

        return false;
      }

      target.AddToQueue(item);
      return true;
    }

    /// <summary>
    /// Add the items referenced by the item to the publishing queue as dictated by 
    /// <see cref="PublishReferencedItems" /> and <see cref="PublishReferencedMedia" />
    /// .
    /// </summary>
    /// <param name="item">The item containing the references.</param>
    /// <param name="target">The publishing target.</param>
    /// <returns>True if the appropriate </returns>
    /// <exception cref="PublishingException"><c>PublishingException</c> - Any type of
    /// error.</exception>
    protected bool AddReferencedItemsToQueue(
      Sitecore.Data.Items.Item item, 
      PublishingTarget target)
    {
      this.Logger.Info("AddReferencedItemsToQueue");
      HashSet<Sitecore.Data.ID> processed = 
        new HashSet<Sitecore.Data.ID> { item.ID };

      foreach (Sitecore.Links.ItemLink link in item.GetVersionLinks())
      {
        // If the target item has already been evaluated for queueing.
        if (processed.Contains(link.TargetItemID))
        {
          this.Logger.Info("Processed contains " + link.TargetItemID);
          continue;
        }

        Sitecore.Data.Items.Item referenced = link.GetTargetItem();

        if (referenced != null)
        {
          referenced = referenced.Publishing.GetValidVersion(
            DateTime.Now, 
            true);
        }

        if (referenced == null)
        {
          this.HandleNullReference(item, referenced, link);
          processed.Add(link.TargetItemID);
          continue;
        }

        if (!((referenced.Paths.IsMediaItem && this.PublishReferencedMedia)
          || (this.PublishReferencedItems && !referenced.Paths.IsMediaItem)))
        {
          processed.Add(link.TargetItemID);
          continue;
        }

        if (!this.AddToQueue(referenced, target, processed))
        {
          string message = this.Logger.Info(
            "Unable to publish referenced item {0}.", 
            referenced);

          if (this.ThrowExceptions)
          {
            throw new PublishingException(message);
          }

          return false;
        }
      }

      this.Logger.Info("AddReferencedItemsToQueue returns true");
      return true;
    }

    /// <summary>
    /// Add any unpublished ancestors to the publishing queue.
    /// </summary>
    /// <param name="item">The item to check.</param>
    /// <param name="target">The publishing target to check.</param>
    /// <param name="checkRevision">If True, add the item to the publishing queue if
    /// the revision differs from that in the publishing target.</param>
    /// <param name="processed">List of IDs already processed (for optimization).
    /// </param>
    /// <returns>
    /// True if any required ancestor could not be added to the publishing queue.
    /// </returns>
    protected bool AddRequiredAncestorsToQueue(
      Sitecore.Data.Items.Item item, 
      PublishingTarget target, 
      bool checkRevision,
      HashSet<Sitecore.Data.ID> processed)
    {
      Sitecore.Diagnostics.Assert.IsNotNull(item, "item");
      Sitecore.Diagnostics.Assert.IsNotNull(target, "target");
      Sitecore.Diagnostics.Assert.IsNotNull(processed, "processed");
      Sitecore.Data.Items.Item ancestor = item.Parent;

      while (ancestor.Axes.Level > 1 
        && !target.ContainsItem(ancestor, checkRevision))
      {
        if (!this.AddToQueue(ancestor, target, processed))
        {
          return false;
        }

        ancestor = ancestor.Parent;
      }

      return true;
    }

    #endregion
  }
}

// TODO: except root item, only add to queue if exists/doesn't exist between one and the other, or edition differs
// TODO: separate checkboxes for whether to publish descendants of referenced items, media items, ancestors, etc.
// TODO: add referenced items even if not publishable/methods return false
// TODO: add descendants as appropriate
// TODO: ensure items added to processed list at the right time, ensure queue remains unique
// TODO: check for publishing target vailidity wherever adding to queue, including publishing targets of ancestors.
// TODO: validate regions
// TODO: if item is publishable, but no versions in context language, does sitecore publish the item?
// TODO: test - referenced item not relevant to publishing target
// TODO: when adding ancestors, update processed list - avoid publishing twice
// TODO: ensure ancestors are published even out-of-order
// TODO: events/cache clearing once after all targets? or once after each target? Or some combination thereof?

