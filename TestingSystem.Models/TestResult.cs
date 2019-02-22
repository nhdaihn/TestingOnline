using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TestingSystem.Models
{
    public class TestResult
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TestResultID { get; set; }


        [ForeignKey("Candidates")]
        public int CandidatesID { get; set; }
        public virtual Candidate Candidates { get; set; }




        [ForeignKey("Tests")]
        public int TestID { get; set; }
        public virtual Test Tests { get; set; }

        [Required]
        public int Score { get; set; }

        [Required]
        public string Description { get; set; }

    }
}
