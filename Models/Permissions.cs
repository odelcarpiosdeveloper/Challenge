using System.ComponentModel.DataAnnotations;

namespace WebApiChallengeCQRS.Models
{
    public class Permissions
    {
        public int Id { get; set; }
        [Required] public string EmployeeForename { get; set; }
        [Required] public string EmployeeSurname { get; set; }
        [Required] public int PermissionType { get; set; }
        [Required] public DateTime PermissionDate { get; set; }
    }
}
