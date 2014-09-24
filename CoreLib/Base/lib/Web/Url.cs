//------------------------------------------------------------------------------------------------- 
// <copyright file="Url.cs" company="Sitecore Shared Source">
// Copyright (c) Sitecore.  All rights reserved.
// </copyright>
// <summary>Defines the Url type.</summary>
// <license>
// http://sdn.sitecore.net/Resources/Shared%20Source/Shared%20Source%20License.aspx
// </license>
// <url>http://trac.sitecore.net/Library/</url>
//-------------------------------------------------------------------------------------------------

namespace Sitecore.Sharedsource.Web
{
  using System;
  using System.Collections.Generic;
  using System.Text;
  using Sitecore.Sharedsource.SystemString;

  /// <summary>
  /// Represents a URL.
  /// </summary>
  public class Url
  {
    #region Fields.

    /// <summary>
    /// The name of the language in the prefix of the URL, such as en.
    /// </summary>
    private string languageName;

    /// <summary>
    /// Query string parameters of the URL.
    /// </summary>
    private Sitecore.Collections.SafeDictionary<string> queryStringParameters;

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of the Url class.
    /// </summary>
    /// <param name="urlString">The URL to process.</param>
    public Url(string urlString)
    {
      this.ParseUrlString(urlString);
    }

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets or sets the protocol and hostname, such as http://hostname.
    /// </summary>
    public string Prefix
    {
      get;
      set;
    }

    /// <summary>
    /// Gets or sets the name language for the prefix in the URL, such as /en,  or an
    /// empty string.
    /// </summary>
    public string LanguageName
    {
      get
      {
        if (String.IsNullOrEmpty(this.languageName))
        {
          return this.languageName;
        }

        return Sitecore.StringUtil.EnsurePrefix('/', this.languageName);
      }

      set
      {
        this.languageName = value;
      }
    }

    /// <summary>
    /// Gets or sets the path part of the URL, such as /section/item.
    /// </summary>
    public string Path
    {
      get;
      set;
    }

    /// <summary>
    /// Gets or sets the suffix of the URL, such as .aspx or /.
    /// </summary>
    public string Suffix
    {
      get;
      set;
    }

    /// <summary>
    /// Gets the query string part of the URL, including the question mark.
    /// </summary>
    public string QueryString
    {
      get
      {
        if (this.queryStringParameters == null || this.QueryStringParameters.Count < 1)
        {
          return String.Empty;
        }

        StringBuilder queryString = new StringBuilder();

        foreach (KeyValuePair<string, string> pair in this.QueryStringParameters)
        {
          queryString.Append(pair.Key + '=' + pair.Value + '&');
        }

        return Sitecore.StringUtil.EnsurePrefix(
          '?',
          queryString.ToString()).TrimEnd('&');
      }
    }

    #endregion

    #region Protected Properties

    /// <summary>
    /// Gets or sets a list of query string parameters.
    /// </summary>
    protected Sitecore.Collections.SafeDictionary<string> QueryStringParameters
    {
      get
      {
        if (this.queryStringParameters == null)
        {
          this.queryStringParameters = 
            new Sitecore.Collections.SafeDictionary<string>();
        }

        return this.queryStringParameters;
      }

      set
      {
        this.queryStringParameters = value;
      }
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Clear all properties.
    /// </summary>
    public void Clear()
    {
      this.Prefix = String.Empty;
      this.Suffix = String.Empty;
      this.LanguageName = String.Empty;
      this.Path = String.Empty;
      this.queryStringParameters = null;
    }

    /// <summary>
    /// The URL as a string.
    /// </summary>
    /// <returns>The URL string.</returns>
    public override string ToString()
    {
      return this.Prefix + 
        this.LanguageName + 
        this.Path + 
        this.Suffix + 
        this.QueryString;
    }

    /// <summary>
    /// Parses the URL and sets properties.
    /// </summary>
    /// <param name="urlString">The URL to parse.</param>
    public void ParseUrlString(string urlString)
    {
      this.Clear();
      string remainder = this.ParseQueryString(urlString);
      remainder = this.ParsePrefix(remainder);
      remainder = this.ParseSuffix(remainder);
      remainder = this.ParseLanguage(remainder);
      this.Path = remainder;
    }

    #endregion

    #region Protected Methods

    /// <summary>
    /// Parse the query string part of the URL.
    /// </summary>
    /// <param name="urlString">The URL string.</param>
    /// <returns>
    /// The remainder of the URL, exluding the query string.
    /// </returns>
    protected string ParseQueryString(string urlString)
    {
      int questionMark = urlString.IndexOf('?');

      if (questionMark > -1)
      {
        this.QueryStringParameters = 
          Sitecore.Web.WebUtil.ParseQueryString(urlString);
        urlString = urlString.Substring(0, questionMark);
      }

      return urlString;
    }

    /// <summary>
    /// Parse the suffix part of the URL.
    /// </summary>
    /// <param name="input">The URL string.</param>
    /// <returns>The remainder of the URL, excluding the suffix.</returns>
    protected string ParseSuffix(string input)
    {
      string path = Sitecore.Web.WebUtil.ExtractFilePath(input);

      foreach (string allowed in new[] { "/", ".aspx", ".ashx" })
      {
        if (path.EndsWith(allowed))
        {
          this.Suffix = allowed;
          input = input.Substring(0, input.Length - this.Suffix.Length);
          break;
        }
      }

      return input;
    }

    /// <summary>
    /// Oarse the language part of the URL.
    /// </summary>
    /// <param name="path">The URL string.</param>
    /// <returns>The remainder of the URL, excluding the language.</returns>
    protected string ParseLanguage(string path)
    {
      if (!String.IsNullOrEmpty(path))
      {
        int separator = path.IndexOfAny(new[] { '/', '.' }, 1);

        if (separator < 0)
        {
          separator = path.Length;
        }

        string langName = path.Substring(1, separator - 1);

        if (!String.IsNullOrEmpty(langName))
        {
          Sitecore.Globalization.Language language = null;

          if (Sitecore.Globalization.Language.TryParse(langName, out language))
          {
            this.LanguageName = language.Name;
            path = path.Substring(this.LanguageName.Length);
          }
        }
      }

      return path;
    }

    /// <summary>
    /// Parse the host part of the URL.
    /// </summary>
    /// <param name="input">The URL string.</param>
    /// <returns>The remainder of the URL, excluding the prefix.</returns>
    protected string ParsePrefix(string input)
    {
      if (input.IndexOf(':') < input.IndexOf('/') && !input.StartsWith("/"))
      {
        int thirdSlash = input.NthIndex('/', 3);

        if (thirdSlash > -1)
        {
          this.Prefix = input.Substring(0, thirdSlash);
          input = input.Substring(thirdSlash);
        }
        else
        {
          this.Prefix = input;
          input = String.Empty;
        }
      }

      return input;
    }

    #endregion
  }
}