using AutoMapper;
using user.application.features.users;
using user.application.features.users.commands.InsertUser;
using user.application.features.users.commands.UpdateUser;
using user.application.features.wallets;
using user.application.features.wallets.commands.InsertWallet;
using user.application.features.wallets.commands.UpdateWallet;
using user.domain.entities;

namespace user.application.mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserVM>().ReverseMap();
            CreateMap<User, UpdateUserCommand>().ReverseMap();
            CreateMap<User, InsertUserCommand>().ReverseMap();

            CreateMap<Wallet, WalletVM>().ReverseMap();
            CreateMap<Wallet, InsertWalletCommand>().ReverseMap();
            CreateMap<Wallet, UpdateWalletCommand>().ReverseMap();
        }
    }
}
