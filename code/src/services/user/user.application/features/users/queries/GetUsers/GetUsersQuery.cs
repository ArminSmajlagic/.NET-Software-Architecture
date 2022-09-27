using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using user.domain.entities;

namespace user.application.features.users.queries.GetUsers
{
    public class GetUsersQuery : IRequest<List<UserVM>>
    {
        public string? username { get; set; }
        public string? firstname { get; set; }
        public string? country { get; set; }
    }
}
