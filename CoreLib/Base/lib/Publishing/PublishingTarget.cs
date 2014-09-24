//------------------------------------------------------------------------------------------------- 
// <copyright file="PublishingTarget.cs" company="Sitecore Shared Source">
// Copyright (c) Sitecore.  All rights reserved.
// </copyright>
// <summary>Defines the Sitecore.Sharedsource.Publishing.PublishingTarget type.</summary>
// <license>
// http://sdn.sitecore.net/Resources/Shared%20Source/Shared%20Source%20License.aspx
// </license>
// <url>http://trac.sitecore.net/Library</url>
//-------------------------------------------------------------------------------------------------

namespace Sitecore.Sharedsource.Publishing
{
  using System;
  using System.Collections.Generic;
  using Sitecore.Sharedsource.Data.Items.Item;

  /// <summary>
  /// Represents a publishing target (publishing target definition item and
  /// publishing target database).
  /// </summary>
  public class PublishingTarget
  {
    #region Public constructos

    /// <summary>
    /// Initializes a new instance of the PublishingTarget classs.
    /// </summary>
    /// <param name="item">The publishing target definition item.</param>
    public PublishingTarget(Sitecore.Data.Items.Item item)
    {
      Sitecore.Diagnostics.Assert.IsNotNull(item, "item");
      string databaseName = item[Sitecore.FieldIDs.PublishingTargetDatabase];
      Sitecore.Diagnostics.Assert.IsNotNullOrEmpty(
        databaseName,
        "database name");
      Sitecore.Data.Database database =
        Sitecore.Configuration.Factory.GetDatabase(databaseName);
      Sitecore.Diagnostics.Assert.IsNotNull(database, "database");
      this.Definition = item;
      this.Database = database;
    }

    #endregion

    #region Public properties

    /// <summary>
    /// Gets or sets the publishing context associated with this publishing target. 
    /// Initialize with <see cref="CreatePublishingContext">CreatePublishingContext
    /// </see> before using 
    /// <see cref="GetQueuedItems">GetQueuedItems</see>
    /// and <see cref="AddToQueue">AddToQueue</see>.
    /// </summary>
    public Sitecore.Publishing.Pipelines.Publish.PublishContext PublishContext
    {
      get;
      set;
    }

    /// <summary>
    /// Gets or sets the publishing target definition item.
    /// </summary>
    public Sitecore.Data.Items.Item Definition
    {
      set;
      get;
    }

    /// <summary>
    /// Gets or sets the publishing target database.
    /// </summary>
    public Sitecore.Data.Database Database
    {
      set;
      get;
    }

    #endregion 

    #region Public static methods

    /// <summary>
    /// Return a list of publishing targets corresponding to the publishing target
    /// definition items provided.
    /// </summary>
    /// <param name="items">A list of publishing target definition items.</param>
    /// <returns>A list of publishing targets corresponding to the publishing target
    /// definition items provided.</returns>
    public static PublishingTarget[] GetPublishingTargets(
      Sitecore.Data.Items.Item[] items)
    {
      PublishingTarget[] targets = new PublishingTarget[items.Length];

      for (int i = 0; i < items.Length; i++)
      {
        targets[i] = new PublishingTarget(items[i]);
      }

      return targets;
    }

    /// <summary>
    /// Returns the publishing targets defined in the specified database.
    /// </summary>
    /// <param name="database">The database containing the publishing target definition
    /// items.</param>
    /// <returns>The publishing targets in the specified database.</returns>
    public static PublishingTarget[] GetPublishingTargets(
      Sitecore.Data.Database database)
    {
      Sitecore.Data.Items.Item[] items =
        Sitecore.Publishing.PublishManager.GetPublishingTargets(database).ToArray();
      return GetPublishingTargets(items);
    }

    /// <summary>
    /// Returns the default publishing targets defined in the Master database.
    /// </summary>
    /// <returns>The default publishing targets defined in the Master database.
    /// </returns>
    public static PublishingTarget[] GetPublishingTargets()
    {
      Sitecore.Data.Database master = 
        Sitecore.Configuration.Factory.GetDatabase("master");
      Sitecore.Diagnostics.Assert.IsNotNull(master, "master");
      return GetPublishingTargets(master);
    }

    /// <summary>
    /// Returns True if the item is relevant to the specified publishing target
    /// definition item.
    /// </summary>
    /// <param name="targetDefintion">The publishing target definition item.</param>
    /// <param name="item">The item to check.</param>
    /// <returns>True if the item is relevant to the specified publishing target
    /// definition item.</returns>
    public static bool IsRelevant(
      Sitecore.Data.Items.Item targetDefintion,
      Sitecore.Data.Items.Item item)
    {
      string query =
        "./ancestor-or-self::item[@Publishing groups and not(contains(@Publishing groups,'{0}'))]";
      query = String.Format(query, targetDefintion.ID);
      return item.Axes.SelectSingleItem(query) == null;
    }

    /// <summary>
    /// Returns True if the item is relevant to the specified publishing target
    /// definition item.
    /// </summary>
    /// <param name="target">The publishing target.</param>
    /// <param name="item">The item to check.</param>
    /// <returns>True if the item is relevant to the specified publishing target
    /// definition item.</returns>
    public static bool IsRelevant(
      Sitecore.Sharedsource.Publishing.PublishingTarget target,
      Sitecore.Data.Items.Item item)
    {
      return IsRelevant(target.Definition, item);
    }

    /// <summary>
    /// Returns the publishing targets that do not contain the specified item.
    /// </summary>
    /// <param name="targets">All publishing targets.</param>
    /// <param name="item">The item to check.</param>
    /// <param name="checkRevision">Whether to check the revision of the item.</param>
    /// <returns>A list of publishing targets that do not contain the specified item or
    /// revision.</returns>
    public static PublishingTarget[] GetTargetsWithoutItem(
      PublishingTarget[] targets,
      Sitecore.Data.Items.Item item,
      bool checkRevision)
    {
      List<PublishingTarget> without = new List<PublishingTarget>();

      foreach (PublishingTarget target in targets)
      {
        Sitecore.Data.Items.Item targetItem = 
          target.Database.GetItem(item.ID, item.Language);

        if (targetItem == null 
          || (checkRevision && !item.IsSameRevision(targetItem)))
        {
          without.Add(target);
        }
      }

      return without.ToArray();
    }

    #endregion

    #region Public methods

    /// <summary>
    /// Create a publishing context.
    /// </summary>
    /// <param name="item">The item to publish.</param>
    public void CreatePublishingContext(Sitecore.Data.Items.Item item)
    {
      this.PublishContext = new Sitecore.Publishing.Pipelines.Publish.PublishContext(new Sitecore.Publishing.PublishOptions(
        item.Database, 
        this.Database, 
        Sitecore.Publishing.PublishMode.SingleItem,
        item.Language,
        DateTime.Now)
      {
        RootItem = item
      });
    }

    /// <summary>
    /// Add the item to the publishing queue associated with <see cref="PublishContext">PublishContext</see>.
    /// </summary>
    /// <param name="item">The item to add to the publishing queue.</param>
    public void AddToQueue(Sitecore.Data.Items.Item item)
    {
      Sitecore.Diagnostics.Assert.IsNotNull(this.PublishContext, "PublishContext");
      Sitecore.Diagnostics.Log.Info(this + " : adding " + item.Paths.FullPath, this);

      this.PublishContext.Queue.Add(new[] 
      { 
        new Sitecore.Publishing.Pipelines.Publish.PublishingCandidate(
          item.ID, 
          this.PublishContext.PublishOptions) 
      });
    }

    /// <summary>
    /// Get the items in the publishing queue.
    /// Note that publishing does not clear the queue.
    /// </summary>
    /// <returns>The items in the publishing queue.</returns>
    public Sitecore.Data.Items.Item[] GetQueuedItems()
    {
      Sitecore.Diagnostics.Assert.IsNotNull(this.PublishContext, "PublishContext");
      List<Sitecore.Data.Items.Item> list = new List<Sitecore.Data.Items.Item>();

      foreach (object groups
        in this.PublishContext.Queue.ToArray())
      {
        Sitecore.Publishing.Pipelines.Publish.PublishingCandidate candidate =
          groups as Sitecore.Publishing.Pipelines.Publish.PublishingCandidate;

        if (candidate == null)
        {
          continue;
        }

        Sitecore.Data.Items.Item item = this.PublishContext.PublishOptions.SourceDatabase.GetItem(
          candidate.ItemId,
          this.PublishContext.PublishOptions.Language,
          Sitecore.Data.Version.Latest);
        list.Add(item);
      }

      return list.ToArray();
    }

    /// <summary>
    /// Returns True if the item is relevant to this publishing target.
    /// </summary>
    /// <param name="item">The item to check.</param>
    /// <returns>True if this item is relevant to the publishing target.</returns>
    public bool IsRelevant(Sitecore.Data.Items.Item item)
    {
      return IsRelevant(this, item);
    }

    /// <summary>
    /// Returns True if the publishing target contains the item.
    /// </summary>
    /// <param name="item">The item to evaluate.</param>
    /// <param name="checkRevision">Whether to check the revision identifier, or just
    /// the existence of the item.</param>
    /// <returns>True if the publishinng target contains the item.</returns>
    public bool ContainsItem(
      Sitecore.Data.Items.Item item, 
      bool checkRevision)
    {
      Sitecore.Diagnostics.Assert.IsNotNull(item, "item");
      Sitecore.Data.Items.Item targetItem = this.Database.GetItem(
        item.ID,
        item.Language,
        Sitecore.Data.Version.Latest);

      if (targetItem == null)
      {
        return false;
      }

      if (checkRevision && !item.IsSameRevision(targetItem))
      {
        return false;
      }

      return true;
    }

    #endregion 
  }
}
