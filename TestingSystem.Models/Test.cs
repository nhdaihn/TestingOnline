using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestingSystem.Models
{
    public class Test
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TestID { get; set; }


        [ForeignKey("ExamPapers")]
        public int ExamPaperID { get; set; }
        public virtual ExamPaper ExamPapers { get; set; }

        [ForeignKey("Exams")]
        public int ExamID { get; set; }
        public virtual Exam Exams { get; set; }

        [Required]
        public string TestName { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public string PassingScore { get; set; }
        
        [Required]
        public byte Status { get; set; }

    }
}
