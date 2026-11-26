using SkillManagement.Models;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SkillManagement.Controllers
{
    public class SkillsApiController : ApiController
    {
	private readonly SkillManagementDBContext db = new SkillManagementDBContext();
	[EnableCors(origins: "http://localhost", headers: "*", methods: "*")]

	public IHttpActionResult GetSkills()
	{
	    //var skills = db.Skills.Select(s => new { s.SkillId, s.SkillName }).ToList();
	    var skills = db.Skills.Select(s => new
	    {
		s.SkillId,
		s.SkillName,
		s.Description,
		UserName = s.User.UserName,
		Keywords = s.Keywords.Select(k => k.Key)
	    }).ToList();


	    return Ok(skills);

	}

	public IHttpActionResult GetSkill(int id)
	{
	    var skill = db.Skills
		    .Where(s => s.SkillId == id)
		    .Select(s => new
		    {
			s.SkillId,
			s.SkillName,
			s.Description,
			UserName = s.User.UserName,
			Keywords = s.Keywords.Select(k => k.Key)
		    })
		    .FirstOrDefault();

	    if (skill == null)
	    {
		return NotFound();
	    }

	    return Ok(skill);




	}
    }
}