using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using user.application.contracts.persistence;
using user.domain.entities;

namespace user.application.features.users.commands.InsertUser
{
    public class InsertUserCommandHandler : IRequestHandler<InsertUserCommand,int>
    {
        private readonly ILogger<InsertUserCommandHandler> logger;
        private readonly IMapper mapper;
        private readonly IUserRepository repository;

        public InsertUserCommandHandler(ILogger<InsertUserCommandHandler> logger, IMapper mapper, IUserRepository repository)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.repository = repository;
        }
        public async Task<int> Handle(InsertUserCommand request, CancellationToken cancellationToken)
        {
            var mappedEntity = mapper.Map<User>(request);

            var respons = await repository.Insert(mappedEntity);

            if(respons == null)
            {
                logger.LogInformation($"User with usernmae {request.username} has not bean created.");

                return 0;
            }

            logger.LogInformation($"User with usernmae {respons.username} has bean created successfully.");

            return respons.id;
        }
    }
}
