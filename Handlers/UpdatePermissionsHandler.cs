using WebApiChallengeCQRS.Commands;
using WebApiChallengeCQRS.Repositories;
using WebApiChallengeCQRS.Models;
using MediatR;

namespace WebApiChallengeCQRS.Handlers
{
    public class UpdatePermissionsHandler : IRequestHandler<UpdatePermissionsCommand, int>
    {
        private readonly IPermissionsRepository _permissionsRepository;
        
        public UpdatePermissionsHandler(IPermissionsRepository permissionsRepository)
        {
            _permissionsRepository = permissionsRepository;
        }

        public async Task<int> Handle(UpdatePermissionsCommand command, CancellationToken cancellationToken)
        {
            var permissions = await _permissionsRepository.GetPermissionsByIdAsync(command.Id);
            if (permissions == null)
                return default;

            permissions.EmployeeForename = command.EmployeeForename;
            permissions.EmployeeSurname = command.EmployeeSurname;
            permissions.PermissionType = command.PermissionType;
            permissions.PermissionDate = command.PermissionDate;
            
            return await _permissionsRepository.UpdatePermissionAsync(permissions);
        }
    }
}
