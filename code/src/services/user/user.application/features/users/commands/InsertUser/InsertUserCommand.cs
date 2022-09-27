using MediatR;

namespace user.application.features.users.commands.InsertUser
{
    public class InsertUserCommand : IRequest<int>
    {
        public string username { get; set; }
        public string password { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string country { get; set; }
        public string zip_code { get; set; }
    }
}
