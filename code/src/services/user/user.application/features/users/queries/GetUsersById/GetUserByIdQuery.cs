using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace user.application.features.users.queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<UserVM>
    {
        public int id { get; set; }

    }
}
