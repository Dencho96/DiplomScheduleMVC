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
        public ActionResult Index(int groupId=0, int teacherId = 0)
        {
            using (Diplom_VovkEntities db = new Diplom_VovkEntities())
            {
                //ViewData["GroupList"] = Groups;
                //SelectList groups = new SelectList(db.Schedule.Include(x => x.Group).ToList(), "GroupID", "GroupName");

                ViewData["group"] = db.Group.ToList();
                ViewData["teacher"] = db.Teacher.ToList();
                ViewData["dayList"] = db.Day.ToList();
                ViewData["pairList"] = db.Pair.ToList();
                ViewBag.groupId = groupId;
                ViewBag.teacherId = teacherId;
                //ViewBag.Groups = groups;
                var result = db.Schedule.Include(x => x.Group).Include(x => x.Auditory).Include(x => x.Day).Include(x => x.Pair).Include(x => x.Subject).Include(x => x.Teacher).OrderBy(x => x.Group.GroupID).ToList();
                if (groupId==0 && teacherId == 0)
                {
                    return View();
                }
                else if (groupId != 0)
                {
                    return View(result.OrderBy(x => x.Pair.PairID)
                        .Where(b => b.GroupID == groupId)
                        .ToList());

                }
                else if (teacherId != 0)
                {
                    return View(result.OrderBy(x => x.Pair.PairID)
                        .Where(b => b.TeacherID == teacherId)
                        .ToList());
                }
                else
                {
                    return View();
                }
            }
        }


        //public ActionResult ViewIndex(int groupId = 0)
        //{
        //    using (Diplom_VovkEntities db = new Diplom_VovkEntities())
        //    {
        //        ViewListIndexHome mode = new ViewListIndexHome()
        //        {
        //            DayList = db.Day.ToList(),
        //            GroupList = db.Group.ToList(),
        //            ScheduleList = db.Schedule.ToList(),
        //            PairList = db.Pair.ToList(),
        //            TeacherList = db.Teacher.ToList(),
        //            AuditoryList = db.Auditory.ToList(),
        //            SubjectList = db.Subject.ToList()

        //        };
        //        return View(mode);
        //                    //public DayList=new List<Day>(Db);
        //                    //public GroupList;
        //                    //public ScheduleList;
        //                    //public PairList;
        //                    //public TeacherList;
        //                    //public AuditoryList;
        //                    //public SubjectList;                            
        //    }
        //        return View();
        //}
        ////public PartialViewResult ViewPayDay(int groupId = 0, int numDay = 1, int numPay = 1)
        ////{
        ////    using (Diplom_VovkEntities db = new Diplom_VovkEntities())
        ////    {
        ////        var result = db.Schedule.Include(x => x.Group).Include(x => x.Auditory).Include(x => x.Day).Include(x => x.Pair).Include(x => x.Subject).Include(x => x.Teacher).OrderBy(x => x.Group.GroupID).ToList();
        ////        // var list = result.Where(a => a.GroupID == groupId && a.DayID == numDay&&a.PairID==numPay).ToList();
        ////        result = result.Where(a => a.GroupID == groupId).ToList();
        ////        return PartialView(result);
        ////    }
        ////}

        [Authorize]
        public ActionResult AdminPanel()
        {
            return View();
        }

    }
}