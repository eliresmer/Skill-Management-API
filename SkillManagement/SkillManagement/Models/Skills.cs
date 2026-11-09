using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Razor.Tokenizer.Symbols;

namespace SkillManagement.Models
{
    public class Skills
    {
        [Key]
        [Required]
        public int SkillId { get; set; }
        [Required]
        public string SkillName { get; set; }

        public List<UserSkills> UserSkills { get; set; } = new List<UserSkills>();
        public List<Keywords> Keywords { get; set; } = new List<Keywords>();
        public List<Descriptions> Descriptions { get; set; } = new List<Descriptions>   ();
    }
}