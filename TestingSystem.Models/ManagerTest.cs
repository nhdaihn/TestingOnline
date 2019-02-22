using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingSystem.Models
{
    public class ManagerTest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Tests")]
        public int TestID { get; set; }
        public virtual Test Tests { get; set; }

        [ForeignKey("Users")]
        public int UserId { get; set; }
        public virtual User Users { get; set; }

        [Required]
        public byte Type { get; set; }


    }
}
