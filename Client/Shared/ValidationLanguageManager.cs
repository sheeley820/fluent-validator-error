using System.Globalization;
using FluentValidation.Resources;

namespace WorkingWithRadzenStudi.Client.Shared;

public class ValidationLanguageManager : ILanguageManager
{
  public string GetString(string key, CultureInfo culture = null)
    => key switch
    {
      "RequiredValidator" => "{PropertyName} is required. Please {Resolution}.",
      "MaximumLengthValidator" => "{PropertyName} can't exceed {MaxLength} characters.",
      "GreaterThanValidator" => "{PropertyName} must be greater than {ComparisonValue}.",
      "LessThanValidator" => "{PropertyName} must be less than {ComparisonValue}.",
      "GreaterThanOrEqualValidator" => "{PropertyName} can't be less than {ComparisonValue}.",
      "LessThanOrEqualValidator" => "{PropertyName} can't be greater than {ComparisonValue}.",
      "EmailValidator" => "{PropertyName} is not a valid email address.",
      "UrlValidator" => "{PropertyName} is not a valid URL.",
      "HexColorValidator" => "{PropertyName} is not a valid hex color.",
      "RangeUninvertedValidator" => "{PropertyName} must be less than {RangeEndPropertyName}.",
      "UniquelyNamedAllValidator" => "{PropertyName} names must be unique. Please enter a new name.",
      "UniquelyNamedValidator" => "{PropertyName} names must be unique. Please enter a new name.",
      "NoDuplicatesValidator" => "{PropertyName} must be unique. Please remove or modify any duplicates.",
      "EndsWithValidator" => "{PropertyName} must end with \"{EndsWithValue}\".",
      "MinimumLengthValidator" => "{PropertyName} must be longer than {MinLength} character(s).",
      _ => throw new NotImplementedException()
    };

  // No support for other cultures yet. We have many unique messages that aren't covered by
  // FluentValidation's built-in translations.
  public bool Enabled { get => false; set => throw new NotSupportedException(); }
  public CultureInfo Culture { get => null; set => throw new NotSupportedException(); }
}