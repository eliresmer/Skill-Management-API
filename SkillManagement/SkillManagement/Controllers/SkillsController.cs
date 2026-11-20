using SkillManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace SkillManagement.Controllers {
	public class SkillsController : Controller {
		private readonly SkillManagementDBContext db = new SkillManagementDBContext();
		// GET: Skills
		public ActionResult Index() {
			List <Skill> skills= db.Skills
				.Include(s => s.Keywords)
                .Include(s => s.User)
				.ToList();
			return View(skills);
		}
	}
}