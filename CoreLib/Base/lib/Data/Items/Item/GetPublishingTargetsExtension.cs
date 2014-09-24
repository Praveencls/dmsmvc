//------------------------------------------------------------------------------------------------- 
// <copyright file="GetPublishingTargetsExtension.cs" company="Sitecore Shared Source">
// Copyright (c) Sitecore.  All rights reserved.
// </copyright>
// <summary>
// Implements the Sitecore.Data.Items.Item.GetPublishingTargets() extension method.
// </summary>
// <license>
// http://sdn.sitecore.net/Resources/Shared%20Source/Shared%20Source%20License.aspx
// </license>
// <url>http://trac.sitecore.net/Library/</url>
//-------------------------------------------------------------------------------------------------

namespace Sitecore.Sharedsource.Data.Items.Item
{
  using System.Collections.Generic;

  /// <summary>
  /// Sitecore.Data.Items.Item.GetPublishingTargets() extension method.
  ///  Use the Sitecore.Sharedsource.Data.Items.Item namespace to use this method.
  /// </summary>
  public static class GetPublishingTargetsExtension
  {
    /// <summary>
    /// Retrieve the publishing targets associated with the item, or all of the
    /// publishing targets.
    /// </summary>
    /// <param name="me">The item referencing the publishing targets.</param>
    /// <returns>The publishing targets associated with the item.</returns>
    public static Sitecore.Sharedsource.Publishing.PublishingTarget[] GetPublishingTargets(
      this Sitecore.Data.Items.Item me)
    {
      Sitecore.Diagnostics.Assert.IsNotNull(me, "me");
      List<Sitecore.Sharedsource.Publishing.PublishingTarget> targets =
        new List<Sitecore.Sharedsource.Publishing.PublishingTarget>();

      foreach (Sitecore.Sharedsource.Publishing.PublishingTarget target 
        in Sitecore.Sharedsource.Publishing.PublishingTarget.GetPublishingTargets(me.Database))
      {
        if (target.IsRelevant(me))
        {
          targets.Add(target);
        }
      }

      return targets.ToArray();
    }
  }
}
