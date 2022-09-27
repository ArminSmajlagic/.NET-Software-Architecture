using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace user.application.features.wallets.commands.UpdateWallet
{
    public class UpdateWalletCommand : IRequest<int>
    {
        public int id { get; set; }
        public string? card_name { get; set; }
        public string? card_number { get; set; }
        public string? cvv { get; set; }
        public string? expiration { get; set; }
    }
}
