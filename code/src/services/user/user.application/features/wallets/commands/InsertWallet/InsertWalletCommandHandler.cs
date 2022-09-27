using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using user.application.contracts.persistence;
using user.domain.entities;

namespace user.application.features.wallets.commands.InsertWallet
{
    public class InsertWalletCommandHandler : IRequestHandler<InsertWalletCommand,int>
    {
        private readonly ILogger<InsertWalletCommandHandler> logger;
        private readonly IMapper mapper;
        private readonly IWalletRepository repository;
        public InsertWalletCommandHandler(ILogger<InsertWalletCommandHandler> logger, IMapper mapper, IWalletRepository repository)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.repository = repository;
        }
        public async Task<int> Handle(InsertWalletCommand request, CancellationToken cancellationToken)
        {
            var mappedEntity = mapper.Map<Wallet>(request);

            var result = await repository.Insert(mappedEntity);

            return result.id;
        }
    }
}
