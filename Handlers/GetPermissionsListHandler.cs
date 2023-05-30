using WebApiChallengeCQRS.Models;
using WebApiChallengeCQRS.Queries;
using WebApiChallengeCQRS.Repositories;
using MediatR;
using System.Numerics;

namespace WebApiChallengeCQRS.Handlers
{
    public class GetPermissionsListHandler : IRequestHandler<GetPermissionsListQuery, List<Permissions>>
    {
        private readonly IPermissionsRepository _permissionsRepository;
        public GetPermissionsListHandler(IPermissionsRepository permissionsRepository)
        {
            _permissionsRepository = permissionsRepository;
        }
        public async Task<List<Permissions>> Handle(GetPermissionsListQuery request, CancellationToken cancellationToken)
        {
            return await _permissionsRepository.GetPermissionsListAsync();
        }
    }
}
