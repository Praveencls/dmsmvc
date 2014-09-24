//------------------------------------------------------------------------------------------------- 
// <copyright file="TagValidator.cs" company="Sitecore Shared Source">
// Copyright (c) Sitecore.  All rights reserved.
// </copyright>
// <summary>
// Defines the Sitecore.Sharedsource.Data.Validators.FieldValidators.TagValidator type.
// </summary>
// <license>
// http://sdn.sitecore.net/Resources/Shared%20Source/Shared%20Source%20License.aspx
// </license>
// <url>http://trac.sitecore.net/Library/</url>
//-------------------------------------------------------------------------------------------------

namespace Sitecore.Sharedsource.Data.Validators.FieldValidators
{
  using System;
  using System.Runtime.Serialization;
  using HtmlAgilityPack;
  using Sitecore.Data.Validators;
  
  /// <summary>
  /// Field validator to disallow specific HTML tags.
  /// </summary>
  [Serializable] 
  public class TagValidator : Sitecore.Data.Validators.StandardValidator 
  {
    /// <summary>
    /// Initializes a new instance of the TagValidator class.
    /// </summary>
    public TagValidator()
    {
    }

    /// <summary>
    /// Initializes a new instance of the TagValidator class.
    /// </summary>
    /// <param name="info">Serialization information.</param>
    /// <param name="context">Streaming context.</param>
    public TagValidator( 
      SerializationInfo info,
      StreamingContext context) : base(info, context) 
    { 
    }

    /// <summary>
    /// Name of this validator.
    /// </summary>
    public override string Name 
    { 
      get 
      {
        return "HTML Tag Validator";
      } 
    } 

   /// <summary>
   /// Maximum error level returned by this validator.
   /// </summary>
   /// <returns>The maximum error level returned by this validator.</returns>
    protected override ValidatorResult GetMaxValidatorResult() 
    { 
      return GetFailedResult(ValidatorResult.Error);
    } 

    /// <summary>
    /// Evaluate the validator against a field value.
    /// </summary>
    /// <returns>Valid or validation error level.</returns>
    protected override ValidatorResult Evaluate() 
    {
      string disallowed = this.Parameters["DisallowedTags"];

      if (String.IsNullOrEmpty(this.ControlValidationValue)
        || String.IsNullOrEmpty(disallowed))
      { 
        return ValidatorResult.Valid; 
      }

      string[] tags = Sitecore.StringUtil.Split(
        disallowed, 
        '|', 
        true);

      if (tags == null || tags.Length < 1)
      {
        return ValidatorResult.Valid; 
      }

      HtmlDocument doc = new HtmlDocument();
      doc.LoadHtml(this.ControlValidationValue);

      foreach (string tag in tags)
      {
        if (String.IsNullOrEmpty(tag))
        {
          continue;
        }

        var nodes = doc.DocumentNode.SelectNodes("//" + tag);

        if (nodes != null && nodes.Count > 0)
        {
          this.Text = "Invalid HTML tag: " + tag;
          return GetFailedResult(ValidatorResult.Error);
        }
      }

      return ValidatorResult.Valid; 
    } 
  } 
}