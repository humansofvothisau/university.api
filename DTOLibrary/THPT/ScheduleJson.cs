using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLibrary.THPT
{
    public class Schedules
    {
        public string Date { get; set; }
        public string Morning { get; set; }
        public string Afternoon { get; set; }
    }
    public class ScheduleJson
    {
        public Schedules[] Schedule { get; set; }
        public string Note { get; set; }
    }
}
