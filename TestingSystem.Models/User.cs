using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestingSystem.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required]
        [ForeignKey("Roles")]
        public int RoleId { get; set; }
        

        [Required]
        [MaxLength(20)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(20)]
        public string Password { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        [Required]
        public byte Status { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Phone { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [MaxLength(200)]
        public string Address { get; set; }

        [Required]
        [MaxLength(200)]
        public string Avatar { get; set; }

        public string Note { get; set; }


        public virtual Roles Roles { get; set; }
        public virtual ICollection<UserGroup> UserGroups { get; set; }


        public virtual ICollection<Candidate> Candidates { get; set; }

        public virtual ICollection<QuestionCategory> QuestionCategoriesCreateUser { get; set; }
        public virtual ICollection<QuestionCategory> QuestionCategoriesModifiedUser { get; set; }


        public virtual ICollection<Question> QuestionCreateUser { get; set; }
        public virtual ICollection<Question> QuestionModifiedUser { get; set; }

        public virtual ICollection<ExamPaper> ExamPapersCreateUser { get; set; }
        public virtual ICollection<ExamPaper> ExamPapersModifiedUser { get; set; }

        public static implicit operator User(int v)
        {
            throw new NotImplementedException();
        }
    }
}
