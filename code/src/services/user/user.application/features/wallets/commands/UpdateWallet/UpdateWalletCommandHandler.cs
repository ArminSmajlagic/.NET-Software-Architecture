using MediatR;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using user.application.contracts.persistence;
using user.domain.entities;

namespace user.application.features.wallets.commands.UpdateWallet
{
    public class UpdateWalletCommandHandler : IRequestHandler<UpdateWalletCommand, int>
    {
        private readonly ILogger<UpdateWalletCommandHandler> logger;
        private readonly IMapper mapper;
        private readonly IWalletRepository repository;
        public UpdateWalletCommandHandler(ILogger<UpdateWalletCommandHandler> logger, IMapper mapper, IWalletRepository repository)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.repository = repository;
        }
        public async Task<int> Handle(UpdateWalletCommand request, CancellationToken cancellationToken)
        {
            var mappedEntity = mapper.Map<Wallet>(request);

            var result = await repository.Update(mappedEntity);

            return result.id;
        }
    }
}
