using MediatR;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using user.application.contracts.persistence;

namespace user.application.features.wallets.queries.GetWallets
{
    public class GetWalletsQueryHandler : IRequestHandler<GetWalletsQuery, List<WalletVM>>
    {
        private readonly ILogger<GetWalletsQueryHandler> logger;
        private readonly IMapper mapper;
        private readonly IWalletRepository repository;

        public GetWalletsQueryHandler(ILogger<GetWalletsQueryHandler> logger, IMapper mapper, IWalletRepository repository)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.repository = repository;
        }
        public async Task<List<WalletVM>> Handle(GetWalletsQuery request, CancellationToken cancellationToken)
        {
            var result = await repository.GetAll();

            var entities = mapper.Map<List<WalletVM>>(result);

            return entities;
        }
    }
}
