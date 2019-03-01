using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestingSystem.Models
{
    public class Answer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AnswerID { get; set; }
        [Required]
        public string AnswerContent { get; set; }
        [Required]
        public bool IsCorrect { get; set; }
        [Required]

        public int QuestionID { get; set; }
        public virtual Question Question { get; set; }
    }
}