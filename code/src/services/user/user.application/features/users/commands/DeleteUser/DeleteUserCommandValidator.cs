using FluentValidation;

namespace user.application.features.users.commands.DeleteUser
{
    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommands>
    {
        public DeleteUserCommandValidator()
        {
            RuleFor(x=>x.id)
                .NotNull()
                .WithMessage("Id must be defined");
        }
    }
}
