using SkillManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SkillManagement.Controllers
{
    public class SkillsController : Controller
    {
        // GET: Skills
        public ActionResult Index()
        {
			SkillManagementDBContext db = new SkillManagementDBContext();
			List<Skill> skills = db.Skills.ToList();
			return View(skills);
        }
    }
}