using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace orders.appliaction.features.orders.commands.CheckoutOrder
{
    public class CheckoutOrderCommandValidator : AbstractValidator<CheckoutOrderCommand>
    {
        public CheckoutOrderCommandValidator()
        {
            RuleFor(x => x.username)
                .NotEmpty()
                .WithMessage("{Username} is required.")
                .MaximumLength(20)
                .WithMessage("{Username} must not exceed 20 characters.");

            RuleFor(x => x.user_id)
                .NotNull()
                .WithMessage("{user_id} is required.")
                .GreaterThan(0)
                .WithMessage("ID must be above 0 so that apropriate user can be detected.");

            RuleFor(x => x.payment_id)
                .NotNull()
                .WithMessage("{payment_id} is required.")
                .GreaterThan(0)
                .WithMessage("ID must be above 0 so that apropriate payment can be detected.");
        }
    }
}
