using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using user.application.contracts.persistence;
using user.application.features.wallets.commands.DeleteWallet;

namespace user.application.features.wallets.commands.DeleteUser
{
    public class DeleteWalletCommandHandler : IRequestHandler<DeleteWalletCommand, int>
    {
        private readonly ILogger<DeleteWalletCommandHandler> logger;
        private readonly IMapper mapper;
        private readonly IWalletRepository repository;

        public DeleteWalletCommandHandler(ILogger<DeleteWalletCommandHandler> logger, IMapper mapper, IWalletRepository repository)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.repository = repository;
        }
        public async Task<int> Handle(DeleteWalletCommand request, CancellationToken cancellationToken)
        {
            var result = await repository.Remove(request.id);

            if (result == null)
                return 0;

            return result.id;

        }
    }
}
