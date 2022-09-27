using FluentValidation;
using user.application.features.wallets.commands.InsertWallet;

namespace user.application.features.wallets.commands.InsertUser
{
    internal class InsertWalletComandValidator: AbstractValidator<InsertWalletCommand>
    {
        public InsertWalletComandValidator()
        {
            RuleFor(x => x.card_name)
                 .NotEmpty()
                 .WithMessage("card_name must be definied");

            RuleFor(x => x.card_number)
                .NotEmpty()
                .WithMessage("card_number must be definied");

            RuleFor(x => x.cvv)
                .NotEmpty()
                .WithMessage("cvv must be definied");

            RuleFor(x => x.expiration)
                .NotEmpty()
                .WithMessage("expiration date must be definied");
        }
    }
}
