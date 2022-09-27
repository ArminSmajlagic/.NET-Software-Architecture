using FluentValidation;

namespace user.application.features.users.commands.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(x => x.id)
                .NotNull()
                .WithMessage("Id must be specified.");
        }
    }
}
