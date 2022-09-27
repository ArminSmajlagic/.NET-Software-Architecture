using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using user.application.contracts.persistence;
using user.application.features.users.queries.GetUserById;

namespace user.application.features.users.queries.GetUsersById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery,UserVM>
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
        public async Task<UserVM> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await reposiotry.GetById(request.id);

            if (user == null)
            {
                logger.LogInformation($"User with id: {request.id} could not be found!");
                return null;
            }

            var mappedUser = mapper.Map<UserVM>(user);

            return mappedUser;
        }
    }
}
