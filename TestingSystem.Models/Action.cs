using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TestingSystem.Models
{
    public class Action
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ActionId { get; set; }

        [Required]
        public string ActionName { get; set; }

        public string Description { get; set; }


        public virtual ICollection<RoleAction> RoleActions { get; set; }
    }
}
