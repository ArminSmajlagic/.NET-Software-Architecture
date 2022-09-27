using MediatR;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using user.application.contracts.persistence;

namespace user.application.features.wallets.queries.GetWalletById
{
    public class GetWalletByIdQueryHandler : IRequestHandler<GetWalletByIdQuery, WalletVM>
    {
        private readonly ILogger<GetWalletByIdQueryHandler> logger;
        private readonly IMapper mapper;
        private readonly IWalletRepository repository;

        public GetWalletByIdQueryHandler(ILogger<GetWalletByIdQueryHandler> logger, IMapper mapper, IWalletRepository repository)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.repository = repository;
        }
        public async Task<WalletVM> Handle(GetWalletByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await repository.GetById(request.id);

            if (result == null)
                return null;

            var entity = mapper.Map<WalletVM>(result);

            return entity;
        }
    }
}
