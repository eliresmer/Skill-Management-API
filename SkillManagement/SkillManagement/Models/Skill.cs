using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Razor.Tokenizer.Symbols;

namespace SkillManagement.Models
{
    public class Skill
    {
        [Key]
        [Required]
        public int SkillId { get; set; }
        [Required]
        public string SkillName { get; set; }
        public ICollection<Keyword> Keywords { get; set; } = new List<Keyword>(); //one skill has many keywords (parent)
	public string Description { get; set; } //one skill = one description
	public User User { get; set; } // one skill = one user
    }
}