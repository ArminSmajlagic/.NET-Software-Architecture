using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace user.application.features.wallets.queries.GetWallets
{
    public class GetWalletsQuery : IRequest<List<WalletVM>>
    {
    }
}
