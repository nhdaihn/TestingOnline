using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestingSystem.Models
{
    public class QuestionCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public bool IsActive { get; set; }

        [Required]
        public int CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        [Required]
        public int ModifiedBy { get; set; }

        public DateTime? ModifiebDate { get; set; }


        //[ForeignKey("ModifiedBys"), Column(Order = 1)]
        public virtual User ModifiedBys { get; set; }
        public virtual User CreatedBys { get; set; }


        public virtual ICollection<Question> Questions { get; set; }
    }
}
