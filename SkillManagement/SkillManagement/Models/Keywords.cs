using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SkillManagement.Models
{
    public class Keywords
    {
        [Key, StringLength(100)]
        [Display(Name = "Keyword")]
        public string KeywordText { get; set; } = string.Empty;

        
        public int SkillID { get; set; }
        public Skills Skill { get; set; } = null;
    }
}