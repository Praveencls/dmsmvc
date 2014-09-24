//------------------------------------------------------------------------------------------------- 
// <copyright file="NthIndexExtension.cs" company="Sitecore Shared Source">
// Copyright (c) Sitecore.  All rights reserved.
// </copyright>
// <summary>Defines the NthIndexExtension type.</summary>
// <license>
// http://sdn.sitecore.net/Resources/Shared%20Source/Shared%20Source%20License.aspx
// </license>
// <url>http://trac.sitecore.net/Library/</url>
//-------------------------------------------------------------------------------------------------

namespace Sitecore.Sharedsource.SystemString
{
  /// <summary>
  /// Extension to System.String to return the index of the Nth occurrence 
  /// of a character within a string.
  /// </summary>
  public static class NthIndexExtension
  {
    /// <summary>
    /// Return the index of the Nth occurrence of the character within the string, 
    /// or -1.
    /// </summary>
    /// <param name="text">The string containing the character.</param>
    /// <param name="c">The character to search for.</param>
    /// <param name="occurrence">The number of the occurrence, 
    /// such as 3 for the third occurrence.</param>
    /// <returns>
    /// The index of the Nth occurrence of the character within the string, 
    /// or -1.
    /// </returns>
    public static int NthIndex(this string text, char c, int occurrence)
    {
      int loop = 0;
      int index = 0;

      while (loop++ < occurrence && text.IndexOf(c) > -1)
      {
        int increment = text.IndexOf(c) + 1;
        index += increment;
        text = text.Substring(increment);
      }

      if (loop <= occurrence)
      {
        return -1;
      }

      return index - 1;
    }
  }
}