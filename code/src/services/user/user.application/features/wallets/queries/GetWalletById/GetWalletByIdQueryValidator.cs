using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace user.application.features.wallets.queries.GetWalletById
{
    public class GetWalletByIdQueryValidator : AbstractValidator<GetWalletByIdQuery>
    {
        public GetWalletByIdQueryValidator()
        {
            RuleFor(x => x.id)
                .NotNull()
                .WithMessage("Id must be specified");
        }
    }
}
