using MediatR;

namespace user.application.features.users.commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<int>
    {
        public int id { get; set; }
        public string? username { get; set; }
        public string? password { get; set; }
        public string? first_name { get; set; }
        public string? last_name { get; set; }
        public string? country { get; set; }
        public string? zip_code { get; set; }
    }
}
