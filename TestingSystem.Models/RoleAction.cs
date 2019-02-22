using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestingSystem.Models
{
    public class RoleAction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Roles")]
        public int RoleId { get; set; }

        [Required]
        [ForeignKey("Action")]
        public int ActionId { get; set; }
        

        [Required]
        [DefaultValue(false)]
        public bool IsTrue { get; set; }




        public virtual Roles Roles { get; set; }
        public virtual Action Action { get; set; }
    }
}
