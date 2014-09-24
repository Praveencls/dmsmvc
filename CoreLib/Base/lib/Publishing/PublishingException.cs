//------------------------------------------------------------------------------------------------- 
// <copyright file="PublishingException.cs" company="Sitecore Shared Source">
// Copyright (c) Sitecore.  All rights reserved.
// </copyright>
// <summary>Defines the Sitecore.Sharedsource.Publishing.PublishingException type.</summary>
// <license>
// http://sdn.sitecore.net/Resources/Shared%20Source/Shared%20Source%20License.aspx
// </license>
// <url>http://trac.sitecore.net/Library</url>
//-------------------------------------------------------------------------------------------------

namespace Sitecore.Sharedsource.Publishing
{
  using System;

  /// <summary>
  /// Represents a publishing exception.
  /// </summary>
  public class PublishingException : Exception
  {
    /// <summary>
    /// Initializes a new instance of the PublishingException class.
    /// </summary>
    /// <param name="message">Exception message.</param>
    public PublishingException(string message) : 
      base(message + System.Environment.NewLine + System.Environment.StackTrace)
    {
    }
  }
}
