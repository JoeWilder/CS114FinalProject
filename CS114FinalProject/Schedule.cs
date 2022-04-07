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
        public List<int> catalogrows;

        public Schedule( List<int> c_rows, int rank)
        {
            catalogrows = c_rows;
            ranking = rank;
        }

        /*public List<string> getCourses()
        {
            return ();
        }
        */
    }
}
