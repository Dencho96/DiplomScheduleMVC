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
        //private Diplom_VovkEntities db = new Diplom_VovkEntities();
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
        public PartialViewResult ViewPayDay(int groupId = 0, int numDay = 1, int numPay = 1)
        {
            using (Diplom_VovkEntities db = new Diplom_VovkEntities())
            {
                var result = db.Schedule.Include(x => x.Group).Include(x => x.Auditory).Include(x => x.Day).Include(x => x.Pair).Include(x => x.Subject).Include(x => x.Teacher).OrderBy(x => x.Group.GroupID).ToList();
                // var list = result.Where(a => a.GroupID == groupId && a.DayID == numDay&&a.PairID==numPay).ToList();
                result = result.Where(a => a.GroupID == groupId).Where(a => a.DayID == numDay).Where(a => a.Pair.PairID == numPay).ToList();
                return PartialView(result);
            }
        }

        public ActionResult AdminPanel()
        {
            return View();
        }

    }
}