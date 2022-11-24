using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using user.application.contracts.persistence;

namespace user.application.features.users.commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommands, int>
    {
        private readonly ILogger<DeleteUserCommandHandler> logger;
        private readonly IMapper mapper;
        private readonly IUserRepository repository;

        public DeleteUserCommandHandler(ILogger<DeleteUserCommandHandler> logger, IMapper mapper, IUserRepository repository)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.repository = repository;
        }
        public async Task<int> Handle(DeleteUserCommands request, CancellationToken cancellationToken)
        {
            if (!cancellationToken.IsCancellationRequested)
            {
                logger.LogInformation($"The request has been canceled");

                return 0;
            }
            var respons = await repository.Remove(request.id);

            if (respons == null)
            {
                logger.LogInformation($"User with id: {request.id} was not delete successfuly.");
                
                return 0;
            }

            logger.LogInformation($"User with id: {request.id} was delete successfuly.");

            return respons.id;
        }
    }
}
