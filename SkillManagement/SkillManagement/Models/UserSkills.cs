using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SkillManagement.Models
{
    public class UserSkills
    {
        public int UserID { get; set; }
        public Users User { get; set; } = null;

        public int SkillID { get; set; }
        public Skills Skill { get; set; } = null;
    }
}