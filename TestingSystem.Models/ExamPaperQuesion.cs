using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestingSystem.Models
{
    public class ExamPaperQuesion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ExamPaperQuesionID { get; set; }
        [Required]
        public int QuestionID { get; set; }
        [Required]
        public int ExamPaperID { get; set; }

        public virtual Question Question{ get; set; }
        public virtual ExamPaper ExamPaper { get; set; }
    }
}
