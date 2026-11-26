using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillManagement.Models
{
    public class User
    {
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int UserId { get; set; }

	[Required]
	public string UserName { get; set; }

	public string passwordHash { get; set; }

	public Boolean IsAdmin { get; set; }

	public ICollection<Skill> Skills { get; set; } = new List<Skill>(); //one user has many skills

    }
}