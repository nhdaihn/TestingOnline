using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingSystem.Models
{
    public class Candidate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CandidatesID { get; set; }

        [ForeignKey("Users")]
        public int UserId { get; set; }
        public virtual User Users { get; set; }
    }
}
