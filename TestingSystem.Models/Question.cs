using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestingSystem.Models
{
    public class Question
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuestionID { get; set; }
        [Required]
        public string Content { get; set; }
        public string Image  { get; set; }
        [Required]
        public int Level { get; set; }
        [Required]
        public int CategoryID { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public int CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }

        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }


        public virtual User CreaterUser { get; set; }
        public virtual User ModifiedUser { get; set; }



        public virtual ICollection<Answer> Answers { get; set; }
        public virtual QuestionCategory QuestionCategory { get; set; }
        public ICollection<ExamPaperQuesion> ExamPaperQuesions { get; set; }
    }
}