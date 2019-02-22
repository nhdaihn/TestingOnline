using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestingSystem.Models
{
    public class Group
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GroupId { get; set; }

        [Required]
        public string GroupName { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public DateTime UpdatedDate { get; set; }

        public string Description { get; set; }

        public ICollection<UserGroup> UserGroups { get; set; }
    }
}
