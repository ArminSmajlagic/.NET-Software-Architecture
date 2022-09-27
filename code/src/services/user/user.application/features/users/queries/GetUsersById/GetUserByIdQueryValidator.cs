using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using user.application.features.users.queries.GetUserById;

namespace user.application.features.users.queries.GetUsersById
{
    public class GetUserByIdQueryValidator : AbstractValidator<GetUserByIdQuery>
    {
        public GetUserByIdQueryValidator()
        {
            RuleFor(x=>x.id)
                .NotNull()
                .WithMessage("Id must not be null.")
                .GreaterThan(0)
                .WithMessage("Id 0 is not an valid id.");
        }
    }
}
