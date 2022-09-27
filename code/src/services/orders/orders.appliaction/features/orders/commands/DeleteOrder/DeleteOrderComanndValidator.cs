using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace orders.appliaction.features.orders.commands.DeleteOrder
{
    public class DeleteOrderComanndValidator : AbstractValidator<DeleteOrderCommand>
    {
        public DeleteOrderComanndValidator()
        {
            RuleFor(x=>x.id)
                .NotNull()
                .WithMessage("ID must is required.")
                .GreaterThan(0)
                .WithMessage("ID must be greated then 0 in order to delete correct order");
        }
    }
}
