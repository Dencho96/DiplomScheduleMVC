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
        public ActionResult Index()
        {
            using (Diplom_VovkEntities db = new Diplom_VovkEntities())
            {
                var result = db.Schedule.Include(x => x.Group).Include(x => x.Auditory).Include(x => x.Day).Include(x => x.Pair).Include(x => x.Subject).Include(x => x.Teacher).OrderBy(x => x.Group.GroupID).ToList();
                return View(result.OrderBy(x => x.Day.DayID).ToList());
            }
        }

        public ActionResult AdminPanel()
        {
            return View();
        }

    }
}