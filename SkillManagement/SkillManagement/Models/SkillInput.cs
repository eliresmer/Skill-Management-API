using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SkillManagement.Models
{
    public class SkillInput
    {
        [Required] public string SkillName { get; set; }
        public string Description { get; set; }
        public int? UserId { get; set; }
        public List<string> Keywords { get; set; } = new List<string>();
    }
}