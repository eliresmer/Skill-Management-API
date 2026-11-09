using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SkillManagement.Models
{
    public class Descriptions
    {
        [Key]
        public int DescriptionID { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Text { get; set; } = string.Empty;

        
        public int SkillID { get; set; }
        public Skills Skill { get; set; } = null;
    }
}