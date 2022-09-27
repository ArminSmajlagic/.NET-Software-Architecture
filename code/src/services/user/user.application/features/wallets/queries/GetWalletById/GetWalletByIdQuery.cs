using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace user.application.features.wallets.queries.GetWalletById
{
    public class GetWalletByIdQuery : IRequest<WalletVM>
    {
        public int id { get; set; }
    }
}
