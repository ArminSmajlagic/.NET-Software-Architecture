using FluentValidation;
using user.application.features.wallets.commands.UpdateWallet;

namespace user.application.features.wallets.commands.UpdateUser
{
    internal class UpdateWalletComandValidator : AbstractValidator<UpdateWalletCommand>
    {
        public UpdateWalletComandValidator()
        {
            RuleFor(X=>X.id)
                .NotNull()
                .WithMessage("Id must be defined")
                .GreaterThan(0)
                .WithMessage("Id must be above 0 to be valid.");
        }
    }
}
