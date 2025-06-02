using AFTT.Common.Models.Request.Presentation.Missions;
using FluentValidation;

namespace AFTT.Storefront.Validators;

public class MissionCreationValidator : AbstractValidator<MissionCreateRequest>
{
    public MissionCreationValidator()
    {

    }
}
