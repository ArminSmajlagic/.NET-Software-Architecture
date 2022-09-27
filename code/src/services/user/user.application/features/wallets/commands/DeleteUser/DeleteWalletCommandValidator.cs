using FluentValidation;
using user.application.features.wallets.commands.DeleteWallet;

namespace user.application.features.wallets.commands.DeleteUser
{
    public class DeleteWalletCommandValidator : AbstractValidator<DeleteWalletCommand>
    {
        public DeleteWalletCommandValidator()
        {
            RuleFor(x => x.id)
                .NotEmpty()
                .WithMessage("Id must be specified.");
        }
    }
}
