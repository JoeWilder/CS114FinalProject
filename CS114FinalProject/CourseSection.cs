using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS114FinalProject
{
    public class CourseSection
    {
        string courseNumSection = "CS-114-09068";
        string courseName = "Intro to Software Engineering";

        int numOfCB = 0;
        public List<CourseBlock> meettimes = new List<CourseBlock>();

        /*
        public CourseBlock cbOne = null;
        public CourseBlock cbTwo = null;
        public CourseBlock cbThree = null;
        */

        //Constructor//
        public CourseSection()
        {
            /* Need to populate data from snhu data */
            //this.courseName = ""; 
            //this.courseNumSection = "";
            //this.meettimes = course section meettimes data from snhu;


            //need to pull course data from snhu into logic static class (?) and use number of CBs here ^ v
            foreach (CourseBlock block in meettimes)
            {
                meettimes.Add(block);
            }

            this.numOfCB = meettimes.Count();

        }

        public string getCourseFull()  // returns string in format "CS-114-09068" 
        {
            return (this.courseNumSection);
        }
        public string getCourseCode()  //string CS-114
        {
            string ephemeral = courseNumSection;
            int where = ephemeral.IndexOf("-");
            ephemeral = ephemeral.Remove(0, (where + 1));
            string output = "";
            return (output);
        }
        public string getCourseNum() // string 114  
        {
            string ephemeral = courseNumSection;
            int where = ephemeral.IndexOf("-");  //first occurence
            ephemeral = ephemeral.Remove(0, (where + 1));
            where = ephemeral.IndexOf("-"); //2nd occ
            ephemeral = ephemeral.Remove(where, (ephemeral.Length - where));

            return (ephemeral);
        }
    }





}
