using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Razor.Tokenizer.Symbols;

namespace SkillManagement.Models
{
    public class Skill
    {
        [Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int SkillId { get; set; }
        [Required]
        public string SkillName { get; set; }
        public List<Keyword> Keywords { get; set; } = new List<Keyword>(); // many to many
	public string Description { get; set; } //one skill = one description
	public User User { get; set; } // one skill = one user
    }
}