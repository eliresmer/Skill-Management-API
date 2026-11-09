using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SkillManagement.Models
{
    public class UserSkills
    {
        [Key, Column(Order = 0)]
        public int UserID { get; set; }

        [Key, Column(Order = 1)]
        public int SkillID { get; set; }

        public virtual Users User { get; set; }
        public virtual Skills Skill { get; set; }
    }
}