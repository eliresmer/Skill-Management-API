using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.Ajax.Utilities;
using SkillManagement.Models;

namespace SkillManagement.Controllers
{
    public class SkillsController : ApiController
    {
        private readonly SkillManagementDBContext db = new SkillManagementDBContext();

        public IHttpActionResult GetSkills()
        {
            var skills = db.Skills.Select(s => new { s.SkillId, s.SkillName }).ToList();
            return Ok(skills);

        }

        public IHttpActionResult GetSkill(int id)
        {
            var skill = db.Skills
                .Where(s => s.SkillId == id )
                .Select(s => new { s.SkillId, s.SkillName })
                .FirstOrDefault();

            if (skill == null)
            {
            return NotFound();
            }
            
            return Ok(skill);
            



        }
    }
}