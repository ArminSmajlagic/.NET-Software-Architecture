using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace user.application.features.users.queries.GetUserByUsername
{
    public class GetUserByUsernameQueryValidator : AbstractValidator<GetUserByUsernameQuery>
    {
        public GetUserByUsernameQueryValidator()
        {
            RuleFor(x=>x.username)
                .NotEmpty()
                .WithMessage("Username must not be empty")
                .MinimumLength(5)
                .WithMessage("There are no usernames with length bellow 5 characters");
        }
    }
}
