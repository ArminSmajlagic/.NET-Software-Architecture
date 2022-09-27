using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using user.application.contracts.persistence;
using user.domain.entities;

namespace user.application.features.users.commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, int>
    {
        private readonly ILogger<UpdateUserCommandHandler> logger;
        private readonly IMapper mapper;
        private readonly IUserRepository repository;

        public UpdateUserCommandHandler(ILogger<UpdateUserCommandHandler> logger, IMapper mapper, IUserRepository repository)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.repository = repository;
        }
        public async Task<int> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<User>(request);
            var respons = await repository.Update(entity);

            if (respons!=null)
            {
                logger.LogInformation($"User with user id : {request.id} was not successfully updated.");

                return 0;
            }

            logger.LogInformation($"User with user id : {respons.id} was successfully updated.");

            return respons.id;
        }
    }
}
