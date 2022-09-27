using MediatR;

namespace user.application.features.users.commands.DeleteUser
{
    public class DeleteUserCommands : IRequest<int>
    {
        public int id { get; set; }
    }
}
