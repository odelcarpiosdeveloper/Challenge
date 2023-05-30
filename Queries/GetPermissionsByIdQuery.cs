using WebApiChallengeCQRS.Models;
using MediatR;

namespace WebApiChallengeCQRS.Queries
{
    public class GetPermissionsByIdQuery : IRequest<Permissions>
    {
        public int Id { get; set; }
    }
}
