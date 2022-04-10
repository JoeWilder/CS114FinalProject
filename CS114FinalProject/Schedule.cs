using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS114FinalProject
{
    public class Schedule
    {

        private int ranking = 5;
        public List<string> thecourses;
        public string stringcourses;

        public Schedule( List<string> c_rows, int rank)
        {
            thecourses = c_rows;
            ranking = rank;
            stringcourses = (c_rows[0] + ","+c_rows[1] + "," + c_rows[2] + "," + c_rows[3] + "," + c_rows[4]);
        }

        public override string ToString()
        {
            return "[" + thecourses[0] + "," + thecourses[1] + "," + thecourses[2] + "," + thecourses[3] + "," + thecourses[4] + "]";

        }

        public override bool Equals(object obj)
        {
            return ((Schedule)obj).stringcourses == stringcourses;
        }
        public override int GetHashCode()
        {
            return stringcourses.GetHashCode();
        }
        /*public List<string> getCourses()
        {
            return ();
        }
        */
    }
}
