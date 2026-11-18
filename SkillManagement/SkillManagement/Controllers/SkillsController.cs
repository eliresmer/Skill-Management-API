using SkillManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SkillManagement.Controllers {
	public class SkillsController : Controller {
		private readonly SkillManagementDBContext db = new SkillManagementDBContext();
		// GET: Skills
		public ActionResult Index() {
			List  <Skill> skills= db.Skills.ToList();
			return View(skills);
		}
	}
}