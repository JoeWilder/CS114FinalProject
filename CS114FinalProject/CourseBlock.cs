using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS114FinalProject
{
    public class CourseBlock
    {
        DayOfWeek day = DayOfWeek.Monday;
        int time = 11;

        public bool compat = true;

        public CourseBlock(DayOfWeek d, int t)
        {
            t = this.time;
            d= this.day;
        }
    }
}
