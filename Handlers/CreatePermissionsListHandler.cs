using WebApiChallengeCQRS.Commands;
using WebApiChallengeCQRS.Models;
using WebApiChallengeCQRS.Repositories;
using MediatR;
using System.Security;

namespace WebApiChallengeCQRS.Handlers
{
    public class CreatePermissionsListHandler : IRequestHandler<CreatePermissionsCommand, Permissions>
    {
        private readonly IPermissionsRepository _permissionsRepository;
        public CreatePermissionsListHandler(IPermissionsRepository permissionsRepository)
        {
            _permissionsRepository = permissionsRepository;
        }
        public async Task<Permissions> Handle(CreatePermissionsCommand command, CancellationToken cancellationToken)
        {
            var permissions = new Permissions()
            {
                EmployeeForename = command.EmployeeForename,
                EmployeeSurname = command.EmployeeSurname,
                PermissionType = command.PermissionType,
                PermissionDate = command.PermissionDate
            };
            return await _permissionsRepository.AddPermissionAsync(permissions);
        }
    }
}
