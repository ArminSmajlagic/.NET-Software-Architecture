using FluentValidation;

namespace user.application.features.users.commands.InsertUser
{
    public class InsertUserCommandValidator : AbstractValidator<InsertUserCommand>
    {
        public InsertUserCommandValidator()
        {
            RuleFor(x => x.username)
                .NotEmpty()
                .WithMessage("Username must be definied")
                .MinimumLength(5)
                .WithMessage("Username must be larger then 5 characters.")
                .MaximumLength(15)
                .WithMessage("Username must be less then 15 characters.");

            RuleFor(x => x.first_name)
                .NotEmpty()
                .WithMessage("First name must be definied");

            RuleFor(x => x.last_name)
                .NotEmpty()
                .WithMessage("Last name must be definied");

            RuleFor(x => x.country)
                .NotEmpty()
                .WithMessage("Country must be definied");

            RuleFor(x => x.zip_code)
                .NotEmpty()
                .WithMessage("Zip code must be definied");

        }
    }
}
