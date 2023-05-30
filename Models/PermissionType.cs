using System.ComponentModel.DataAnnotations;

namespace WebApiChallengeCQRS.Models
{
    public class PermissionType
    {
        public int Id { get; set; }
        [Required] public string Description { get; set; }

        public virtual List<Permissions>? Permissions { get; set; }
    }
}
