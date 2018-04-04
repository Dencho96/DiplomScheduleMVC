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
            using (student05Entities db = new student05Entities())
            {
                var result = db.Schedule.Include(x => x.Group).Include(x => x.Auditory).Include(x => x.Day).Include(x => x.Pair).Include(x => x.Subject).Include(x => x.Teacher).ToList();
                return View(result.OrderBy(x => x.Day.DayID).ToList());
            }
        }

        public ActionResult AdminPanel()
        {
            return View();
        }

    }
}