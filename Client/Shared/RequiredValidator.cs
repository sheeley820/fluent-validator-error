using FluentValidation;
using FluentValidation.Validators;

namespace WorkingWithRadzenStudi.Client.Shared;

public class RequiredValidator<T, TProperty> : PropertyValidator<T, TProperty>
{
  private readonly NotEmptyValidator<T, TProperty> notEmptyValidator;
  private readonly string resolution;

  public RequiredValidator(string resolution)
  {
    notEmptyValidator = new NotEmptyValidator<T, TProperty>();
    this.resolution = resolution;
  }

  public override string Name => "RequiredValidator";

  public override bool IsValid(ValidationContext<T> context, TProperty value)
  {
    if (!notEmptyValidator.IsValid(context, value))
    {
      context.MessageFormatter.AppendArgument("Resolution", resolution);
      return false;
    }

    return true;
  }

  protected override string GetDefaultMessageTemplate(string errorCode)
    => Localized(errorCode, Name);
}
