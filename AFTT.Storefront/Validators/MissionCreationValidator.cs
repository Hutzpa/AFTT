using AFTT.Common.Models.Request.Presentation.Missions;
using FluentValidation;

namespace AFTT.Storefront.Validators;

public class MissionCreationValidator : AbstractValidator<MissionCreateRequest>
{
    public MissionCreationValidator()
    {
        RuleFor(m => m.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(100).WithMessage("Title must not exceed 100 characters.");

        RuleFor(m => m.Description)
            .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");
    }
}
