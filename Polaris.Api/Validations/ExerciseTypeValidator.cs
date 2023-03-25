using FluentValidation;
using Polaris.Api.Models;

namespace Polaris.Api.Validations;

public class ExerciseTypeValidator: AbstractValidator<ExerciseType>
{
    public ExerciseTypeValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
    }
}