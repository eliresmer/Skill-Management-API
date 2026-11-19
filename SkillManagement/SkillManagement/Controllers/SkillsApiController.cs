using System.Collections.Generic;
using System.Data.Entity;          
using System.Linq;
using System.Web.Http;
using SkillManagement.Models;

namespace SkillManagement.Controllers
{
    public class SkillsApiController : ApiController
    {
        private readonly SkillManagementDBContext db = new SkillManagementDBContext();

        // GET api/SkillsApi
        public IHttpActionResult GetSkills()
        {
            var skills = db.Skills
                .Select(s => new {
                    s.SkillId,
                    s.SkillName,
                    s.Description,
                    UserName = s.User.UserName,
                    Keywords = s.Keywords.Select(k => k.Key)
                })
                .ToList();
            return Ok(skills);
        }

        // GET api/SkillsApi/5
        public IHttpActionResult GetSkill(int id)
        {
            var skill = db.Skills
                .Where(s => s.SkillId == id)
                .Select(s => new {
                    s.SkillId,
                    s.SkillName,
                    s.Description,
                    UserName = s.User.UserName,
                    Keywords = s.Keywords.Select(k => k.Key)
                })
                .FirstOrDefault();

            if (skill == null) return NotFound();         
            return Ok(skill);                              
        }

        // POST api/SkillsApi   → create
        public IHttpActionResult PostSkill(SkillInput input)
        {
            if (input == null || !ModelState.IsValid)
                return BadRequest(ModelState);            

            var skill = new Skill
            {
                SkillName = input.SkillName,
                Description = input.Description
            };

            if (input.UserId.HasValue)
            {
                skill.User = db.Users.Find(input.UserId.Value);
                if (skill.User == null)
                    return BadRequest("No user with that id");
            }

            AddKeywords(skill, input.Keywords);

            db.Skills.Add(skill);
            db.SaveChanges();                            
            return Created("api/SkillsApi/" + skill.SkillId,
                           new { skill.SkillId, skill.SkillName });          }

        // PUT api/SkillsApi/5   
        public IHttpActionResult PutSkill(int id, SkillInput input)
        {
            if (input == null || !ModelState.IsValid)
                return BadRequest(ModelState);

                      var skill = db.Skills
                .Include(s => s.Keywords)
                .Include(s => s.User)
                .FirstOrDefault(s => s.SkillId == id);
            if (skill == null) return NotFound();

            skill.SkillName = input.SkillName;
            skill.Description = input.Description;

            if (input.UserId.HasValue)
            {
                var user = db.Users.Find(input.UserId.Value);
                if (user == null) return BadRequest("No user with that id");
                skill.User = user;
            }
            else
            {
                skill.User = null;                                  
            }

            skill.Keywords.Clear();                       
            db.SaveChanges();
            return Ok(new { skill.SkillId, skill.SkillName });
        }

        // DELETE api/SkillsApi/5
        public IHttpActionResult DeleteSkill(int id)
        {
            var skill = db.Skills.Find(id);
            if (skill == null) return NotFound();

            db.Skills.Remove(skill);
            db.SaveChanges();
            return Ok();
        }

        // Clean the words, skip blanks and duplicates, reuse existing keywords
        private void AddKeywords(Skill skill, List<string> words)
        {
            if (words == null) return;

            var cleaned = words
                .Where(w => !string.IsNullOrWhiteSpace(w))
                .Select(w => w.Trim().ToLower())          
                .Distinct();                              

            foreach (var key in cleaned)
            {
                var keyword = db.Keywords.Find(key) ?? new Keyword { Key = key };
                skill.Keywords.Add(keyword);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) db.Dispose();                   
            base.Dispose(disposing);
        }
    }
}