using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using user.application.contracts.persistence;

namespace user.application.features.users.queries.GetUserByUsername
{
    public class GetUserByUsernameQueryHandler : IRequestHandler<GetUserByUsernameQuery, UserVM>
    {
        private readonly ILogger<GetUserByUsernameQueryHandler> logger;
        private readonly IUserRepository repository;
        private readonly IMapper mapper;

        public GetUserByUsernameQueryHandler(ILogger<GetUserByUsernameQueryHandler> logger, IUserRepository repository, IMapper mapper)
        {
            this.logger = logger;
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<UserVM> Handle(GetUserByUsernameQuery request, CancellationToken cancellationToken)
        {
            var respons = await repository.GetByUsername(request.username);

            if (respons == null)
            {
                logger.LogInformation($"User with username: {request.username} could not be found!");
                return null;
            }

            var mappedUser = mapper.Map<UserVM>(respons);

            return mappedUser;
        }
    }
}
