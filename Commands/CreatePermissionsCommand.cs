using WebApiChallengeCQRS.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace WebApiChallengeCQRS.Commands
{
    public class CreatePermissionsCommand : IRequest<Permissions>
    {
        [Required] public string EmployeeForename { get; set; }
        [Required] public string EmployeeSurname { get; set; }
        [Required] public int PermissionType { get; set; }
        [Required] public DateTime PermissionDate { get; set; }

        public CreatePermissionsCommand(string employeeForename, string employeeSurname, int permissionType, DateTime permissionDate)
        {
            EmployeeForename = employeeForename;
            EmployeeSurname = employeeSurname;
            PermissionType = permissionType;
            PermissionDate = permissionDate;
        }
    }
}
