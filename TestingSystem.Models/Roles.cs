using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestingSystem.Models
{
    public class Roles
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleId { get; set; }

        [Required]
        public string RoleName { get; set; }

        public string Description { get; set; }

        public virtual ICollection<User> User { get; set; }

        public virtual ICollection<RoleAction> RoleActions { get; set; }

    }
}
