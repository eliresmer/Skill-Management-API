using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SkillManagement.Models
{
    public class Users
    {
        [Key]
        [Required]
        public int UserId { get; set; }

        [Required]
        public string UserName { get; set; }    

        public string passwordHash { get; set; }

        public Boolean IsAdmin { get; set; }

        public List<UserSkills> UserSkills { get; set; } = new List<UserSkills>();

    }
}