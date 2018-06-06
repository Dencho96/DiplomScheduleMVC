using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiplomScheduleMVC.Models;

namespace DiplomScheduleMVC.Models
{
    public class ViewListIndexHome
    {
        public List<Day> DayList;
        public List<Group> GroupList;
        public List<Schedule> ScheduleList;
        public List<Pair> PairList;
        public List<Teacher> TeacherList;
        public List<Auditory> AuditoryList;
        public List<Subject> SubjectList;
    }
}