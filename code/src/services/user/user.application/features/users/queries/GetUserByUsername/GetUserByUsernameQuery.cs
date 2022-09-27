using MediatR;

namespace user.application.features.users.queries.GetUserByUsername
{
    public class GetUserByUsernameQuery: IRequest<UserVM>
    {
        public string username { get; set; }

    }
}
