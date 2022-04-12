//JK starts
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
        public List<int> thecoursesMRID;
        //use thecoursesMRID for all referneces

        public List<string> thecourses;
        public string stringcourses;


        public Schedule( List<string> c_rows, List<int> MRID, int rank)
        {
            thecourses = c_rows;
            thecoursesMRID = MRID;
            ranking = rank;
            stringcourses = (c_rows[0] + ","+c_rows[1] + "," + c_rows[2] + "," + c_rows[3] + "," + c_rows[4]);
            sortmanually();        
        }

        //thecoursesMRID index 0 holds a matchrows index number ,
        //which each hold the catalog c row number that contains all course info
        public void sortmanually()
        {
            int temp;
            for(int d = 0; d<thecoursesMRID.Count; d++)
            {
                for(int f = 0; f< thecoursesMRID.Count - 1; f++)
                {
                    if(Logic.c[Logic.matchrows[thecoursesMRID[f]], 0].CompareTo(Logic.c[Logic.matchrows[thecoursesMRID[f+1]], 0]) > 0)
                    {
                        temp = thecoursesMRID[f];
                        thecoursesMRID[f] = thecoursesMRID[f + 1];
                        thecoursesMRID[f + 1] = temp;

                    }
                }

            }
        }


        public List<string> getNamesinOrder()
        {
            List<string> names = new List<string>();
            for(int i = 0; i<thecoursesMRID.Count; i++)
            {
                names.Add(Logic.c[Logic.matchrows[ thecoursesMRID[i] ], 0]);

            }
            return names;
        }

        public string getNamesinOrder_string()
        {
            List<string> names = new List<string>();
            for (int i = 0; i < thecoursesMRID.Count; i++)
            {
                names.Add(Logic.c[Logic.matchrows[thecoursesMRID[i]], 0]);

            }
            return (names[0] + ",    " + names[1] + ",    "+names[2] + ",    "+names[3] + ",    "+names[4]);
        }

        public string getWhen(int courseOrderNumber)//pass in the number in the mrid list 0-4
        {
            List<string> w = new List<string>();
            int xt = Int32.Parse(Logic.c[Logic.matchrows[thecoursesMRID[courseOrderNumber]], 5]);

            for (int n = 0; n< xt; n++)
            {
                w.Add(Logic.c[Logic.matchrows[thecoursesMRID[courseOrderNumber]], 6+n]);
            }

            if (xt == 1)      { return ("       "+ w[0]) + ".    ";  }
            else if (xt ==2)  { return (w[0] + "," + w[1]) + ".  "; }
            else if (xt == 3) { return (w[0] + "," + w[1] + ", " + w[2] + ".  "); }
            else if (xt == 4) { return (w[0] + "," + w[1] + ", " + w[2] + ", " + w[3] + ".  "); }
            else { return (w.ToString()); }
            
        }

        public List<string> getWhen_FullSched()
        {
            List<string> full = new List<string>();

            for(int o = 0; o < thecoursesMRID.Count(); o++)
            {
                full.Add(getWhen(o));
            }

            return full;
        }
        
        public string getWhen_FullSched_string()
        {
            return (getWhen(0)+"   "+getWhen(1)+"   "+getWhen(2)+"   "+getWhen(3)+"   "+getWhen(4));
        }


        public void PrintSchedule_outoforder()
        {
            foreach(string c in thecourses)
            {
                Console.Write(c + "_");
            }
            Console.WriteLine("");
        }

        public override string ToString()
        {
            return "[" + thecourses[0] + "," + thecourses[1] + "," + thecourses[2] + "," + thecourses[3] + "," + thecourses[4] + "]";
            //NOT in order to match ids
        }

        public override bool Equals(object obj)
        {
            return ((Schedule)obj).stringcourses == stringcourses;
        }
        public override int GetHashCode()
        {
            return stringcourses.GetHashCode();
        }
       

        ~Schedule()
        { }

    }
}
//JK ends