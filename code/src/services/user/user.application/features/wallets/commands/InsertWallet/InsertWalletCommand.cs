using MediatR;

namespace user.application.features.wallets.commands.InsertWallet
{
    public class InsertWalletCommand : IRequest<int>
    {
        public string card_name { get; set; }
        public string card_number { get; set; }
        public string cvv { get; set; }
        public string expiration { get; set; }
    }
}
