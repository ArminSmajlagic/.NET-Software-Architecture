using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using user.application.contracts.persistence;

namespace user.application.features.users.queries.GetUsers
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUsersQuery,List<UserVM>>
    {
        private readonly IMapper mapper;
        private readonly IUserRepository reposiotry;
        private readonly ILogger<GetUserByIdQueryHandler> logger;

        public GetUserByIdQueryHandler(IMapper mapper, IUserRepository reposiotry, ILogger<GetUserByIdQueryHandler> logger)
        {
            this.mapper = mapper;
            this.reposiotry = reposiotry;
            this.logger = logger;
        }
        public async Task<List<UserVM>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await reposiotry.GetAll();

            var mappedUsers = mapper.Map<List<UserVM>>(users);

            if (!string.IsNullOrEmpty(request.country))
            {
                mappedUsers = mappedUsers.Where(x=>x.country==request.country).ToList();
            }

            if(!string.IsNullOrEmpty(request.username))
            {
                mappedUsers = mappedUsers.Where(x => x.username == request.username).ToList();

            }

            if (!string.IsNullOrEmpty(request.firstname))
            {
                mappedUsers = mappedUsers.Where(x => x.first_name == request.firstname).ToList();
            }

            return mappedUsers;
        }
    }
}
