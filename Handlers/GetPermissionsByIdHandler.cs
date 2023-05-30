using WebApiChallengeCQRS.Commands;
using WebApiChallengeCQRS.Models;
using WebApiChallengeCQRS.Repositories;
using MediatR;
using System.Security;
using WebApiChallengeCQRS.Queries;

namespace WebApiChallengeCQRS.Handlers
{
    public class GetPermissionsByIdHandler : IRequestHandler<GetPermissionsByIdQuery, Permissions>
    {
        private readonly IPermissionsRepository _permissionsRepository;

        public GetPermissionsByIdHandler(IPermissionsRepository permissionsRepository)
        {
            _permissionsRepository = permissionsRepository;
        }

        public async Task<Permissions> Handle(GetPermissionsByIdQuery query, CancellationToken cancellationToken)
        {
            return await _permissionsRepository.GetPermissionsByIdAsync (query.Id);

        }
    }
}
