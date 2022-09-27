using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace user.application.features.wallets.commands.DeleteWallet
{
    public class DeleteWalletCommand : IRequest<int>
    {
        public int id { get; set; }
    }
}
