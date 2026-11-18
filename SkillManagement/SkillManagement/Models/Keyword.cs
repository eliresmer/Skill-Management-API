using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SkillManagement.Models
{
    public class Keyword
    {
        [Key, StringLength(100)]
        [Display(Name = "Keyword")]
        public string Key{ get; set; } = string.Empty;

        public int SkillID { get; set; }
        public Skill Skill { get; set; } = null; //one skill has many keywords
    }
}