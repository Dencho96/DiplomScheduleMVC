using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DiplomScheduleMVC.Models;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DiplomScheduleMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int groupId=0)
        {
            using (Diplom_VovkEntities db = new Diplom_VovkEntities())
            {
                //ViewData["GroupList"] = Groups;
                //SelectList groups = new SelectList(db.Schedule.Include(x => x.Group).ToList(), "GroupID", "GroupName");

                ViewData["group"] = db.Group.ToList();
                ViewBag.groupId = groupId;
                //ViewBag.Groups = groups;
                var result = db.Schedule.Include(x => x.Group).Include(x => x.Auditory).Include(x => x.Day).Include(x => x.Pair).Include(x => x.Subject).Include(x => x.Teacher).OrderBy(x => x.Group.GroupID).ToList();
                if (groupId==0)
                {
                    return View();
                }
                else
                {
                    return View(result
                        .OrderBy(x => x.Day.DayID)
                        .Where(b => b.GroupID == groupId)
                        .ToList());

                }
            }
        }

        public ActionResult AdminPanel()
        {
            return View();
        }

    }
}