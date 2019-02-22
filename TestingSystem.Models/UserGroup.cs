using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace TestingSystem.Models
{
    public class UserGroup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }

        [Required]
        [ForeignKey("Group")]
        public int GroupId { get; set; }
        
        [Required]
        public bool IsManager { get; set; }



        public virtual Group Group { get; set; }
        public virtual User User { get; set; }
    }
}
