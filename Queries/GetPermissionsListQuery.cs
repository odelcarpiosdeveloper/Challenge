using WebApiChallengeCQRS.Models;
using MediatR;

namespace WebApiChallengeCQRS.Queries
{
    public class GetPermissionsListQuery : IRequest<List<Permissions>>
    {
    }
}
