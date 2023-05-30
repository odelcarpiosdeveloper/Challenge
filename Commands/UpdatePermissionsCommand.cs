using System.ComponentModel.DataAnnotations;
using MediatR;

namespace WebApiChallengeCQRS.Commands
{
    public class UpdatePermissionsCommand : IRequest<int>
    {
        public int Id { get; set; }
        [Required] public string EmployeeForename { get; set; }
        [Required] public string EmployeeSurname { get; set; }
        [Required] public int PermissionType { get; set; }
        [Required] public DateTime PermissionDate { get; set; }

        public UpdatePermissionsCommand(int id, string employeeForename, string employeeSurname, int permissionType, DateTime permissionDate)
        {
            Id = id;
            EmployeeForename = employeeForename;
            EmployeeSurname = employeeSurname;
            PermissionType = permissionType;
            PermissionDate = permissionDate;
        }
    }
}
