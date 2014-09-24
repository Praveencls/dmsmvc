//------------------------------------------------------------------------------------------------- 
// <copyright file="Logger.cs" company="Sitecore Shared Source">
// Copyright (c) Sitecore.  All rights reserved.
// </copyright>
// <summary>Defines the Sitecore.Sharedsource.Diagnostics.Logger type.</summary>
// <license>
// http://sdn.sitecore.net/Resources/Shared%20Source/Shared%20Source%20License.aspx
// </license>
// <url>http://trac.sitecore.net/Library/</url>
//-------------------------------------------------------------------------------------------------

namespace Sitecore.Sharedsource.Diagnostics
{
  using System;

  /// <summary>
  /// Logging utility.
  /// </summary>
  public class Logger
  {
    #region Public constructors

    /// <summary>
    /// Initializes a new instance of the Logger class.
    /// </summary>
    /// <param name="owner">The object to associate with log messages.</param>
    public Logger(object owner)
    {
      this.Owner = owner;
    }

    #endregion

    #region Protected properties

    /// <summary>
    /// Gets or sets the object to associate with logged messages.
    /// </summary>
    protected object Owner
    {
      get;
      set;
    }

    #endregion

    #region Public static methods

    /// <summary>
    /// Format the parameters.
    /// </summary>
    /// <param name="parameters">The parameters to format.</param>
    /// <returns>The formatted parameters.</returns>
    public static string[] FormatParameters(params object[] parameters)
    {
      string[] parsed = new string[parameters.Length];

      for (int i = 0; i < parameters.Length; i++)
      {
        if (parameters[i] == null)
        {
          parsed[i] = "null";
        }
        else
        {
          Sitecore.Data.Items.Item item = parameters[i] as Sitecore.Data.Items.Item;

          if (item != null)
          {
            parsed[i] = item.Paths.FullPath;
          }
          else
          {
            Sitecore.Data.Database database = parameters[i] as Sitecore.Data.Database;

            if (database != null)
            {
              parsed[i] = database.Name;
            }
            else if (Sitecore.Data.ID.IsID(parameters[i].ToString()))
            {
              if (Sitecore.Context.Database != null 
                && Sitecore.Context.Database.GetItem(parameters[i].ToString()) != null)
              {
                parsed[i] = Sitecore.Context.Database.GetItem(parameters[i].ToString()).Paths.FullPath;
              }
              else
              {
                parsed[i] = parameters[i].ToString();
              }
            }
          }
        }

        if (parsed[i] == null)
        {
          parsed[i] = parameters[i].ToString();
        }
      }

      return parsed;
    }

    #endregion

    #region Public methods

    /// <summary>
    /// Log an exception.
    /// </summary>
    /// <param name="exception">The exception.</param>
    /// <returns>The exception message.</returns>
    public string Exception(Exception exception)
    {
      string message = this.Join(exception.Message);
      Sitecore.Diagnostics.Log.Error(message, exception, this.Owner);
      Sitecore.Diagnostics.Log.Error(exception.StackTrace, this.Owner);
      return message;
    }

    /// <summary>
    /// Write an informational message to the log, and return that message.
    /// </summary>
    /// <param name="format">A message or string format pattern (
    /// <see cref="String.Format(string, object[])">String.Format</see>).</param>
    /// <param name="parameters">Optional parameters for the format pattern (
    /// <see cref="String.Format(string, object[])">String.Format</see>).</param>
    /// <returns>The logged message.</returns>
    public string Info(string format, params object[] parameters)
    {
      string message = this.Join(format, parameters);
      Sitecore.Diagnostics.Log.Info(message, this.Owner);
      return message;
    }

    /// <summary>
    /// Write a warning to the log, and return that message.
    /// </summary>
    /// <param name="format">The message or string format pattern (
    /// <see cref="String.Format(string, object[])">String.Format()</see>).</param>
    /// <param name="parameters">Optional parameters for the format pattern (
    /// <see cref="String.Format(string, object[])">String.Format()</see>).</param>
    /// <returns>The logged message.</returns>
    public string Warn(string format, params object[] parameters)
    {
      string message = this.Join(format, parameters);
      Sitecore.Diagnostics.Log.Warn(message, this.Owner);
      return message;
    }

    /// <summary>
    /// Write an error to the log, and return that message.
    /// </summary>
    /// <param name="format">A message or string format pattern (
    /// <see cref="String.Format(string, object[])">String.Format()</see>).</param>
    /// <param name="parameters">Optional parameters for the format pattern (
    /// <see cref="String.Format(string, object[])">String.Format()</see>).</param>
    /// <returns>The logged message.</returns>
    public string Error(string format, params object[] parameters)
    {
      string message = this.Join(format, parameters);
      Sitecore.Diagnostics.Log.Error(message, this.Owner);
      return message;
    }

    /// <summary>
    /// Write a debugging message to the log, and return that message.
    /// </summary>
    /// <param name="format">A message or string format pattern (
    /// <see cref="String.Format(string, object[])">String.Format()</see>).</param>
    /// <param name="parameters">Optional parameters for the format pattern (
    /// <see cref="String.Format(string, object[])">String.Format()</see>).</param>
    /// <returns>The logged message.</returns>
    public string Debug(string format, params object[] parameters)
    {
      string message = this.Join(format, parameters);
      Sitecore.Diagnostics.Log.Debug(message, this.Owner);
      return message;
    }

    /// <summary>
    /// Fancy String.Format (<see cref="String.Format(string, object[])" />).
    /// </summary>
    /// <param name="format">The message or format pattern (
    /// <see cref="String.Format(string, object[])">String.Format()</see>)</param>
    /// <param name="parameters">Optional parameters for the format pattern
    /// (<see cref="String.Format(string, object[])">String.Format()</see>).</param>
    /// <returns>A message assembled from the parameters.</returns>
    public string Join(string format, params object[] parameters)
    {
      // If no parameters were passed
      if (parameters == null || parameters.Length < 1)
      {
        return Sitecore.StringUtil.EnsurePostfix(
          '.', 
          this.Owner + " : " + format);
      }

      // Otherwise, convert parameters to strings before formatting.
      string[] parsed = FormatParameters(parameters);
      return Sitecore.StringUtil.EnsurePostfix(
        '.', 
        String.Format(this.Owner + " : " + format, parsed));
    }

    #endregion
  }
}