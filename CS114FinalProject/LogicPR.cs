/* Name: LogicPR.cs
 * Purpose: static class to hold funcationality related to creating possible schedule options
 * Author: Paige Robinson  and Jade Kosa
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS114FinalProject
{
    public static class LogicPR
    {
        //List of Schedules to hold all the possible schedules made from given courses
        public static List<Schedule> possibleSchedules;
        //List of strings to hold the current set of 5 courses being evaluated
        public static List<string> CurrentCourses;

        private static List<Schedule> distinctscheduleslist;
        public static int schedulesize = 5; // future implementation 
        private static List<string> BufferCourses = new List<string>(5) { "tseT", "tests", "buffer", "Strings", "here" };
        private static List<string> CurrentCoursesNoSect;
      
        /* Method iterates through every possible combination of 5 courses, creates new Schedule Objects 
            for groups that do not conflict and do not contain duplicate courses */
        public static void FindSchedules()
        {
            possibleSchedules = new List<Schedule>();

            for (int i = 0; i < Logic.nummatches; i++)
            {
                for (int e=0; e < Logic.nummatches; e++)
                {
                    for (int d = 0; d < Logic.nummatches; d++)
                    {
                        for (int c = 0; c < Logic.nummatches; c++)
                        {
                            for (int b = 0; b < Logic.nummatches; b++)
                            {
                                for (int a = 0; a < Logic.nummatches; a++)
                                {
                                    //Console.WriteLine($"{a} + {b} + {c} + {d} + {e}");  //wr

                                    if (Logic.compat[a, b] == "Y" && Logic.compat[a, c] == "Y" && Logic.compat[a, d] == "Y" && Logic.compat[a, e] == "Y" &&
                                            Logic.compat[b, c] == "Y" && Logic.compat[b, d] == "Y" && Logic.compat[b, e] == "Y" && Logic.compat[c, d] == "Y" &&
                                            Logic.compat[c, e] == "Y" && Logic.compat[d, e] == "Y")
                                    {
                                        ///Console.WriteLine("All 5 sections compatable with all others");  //wr

                                        CurrentCourses = new List<string> { Logic.c[Logic.matchrows[a], 0], Logic.c[Logic.matchrows[b], 0],
                                            Logic.c[Logic.matchrows[c], 0], Logic.c[Logic.matchrows[d], 0], Logic.c[Logic.matchrows[e], 0] };
                                        

                                        //removing section number from list  to remove duplicate courses (and course sections)

                                        CurrentCoursesNoSect = new List<string> { Logic.c[Logic.matchrows[a], 0], Logic.c[Logic.matchrows[b], 0],
                                            Logic.c[Logic.matchrows[c], 0], Logic.c[Logic.matchrows[d], 0], Logic.c[Logic.matchrows[e], 0] };

                                        for (int num = 0; num < CurrentCoursesNoSect.Count(); num++)
                                        {
                                            int mk = CurrentCoursesNoSect.ElementAt(num).LastIndexOf("-");
                                            CurrentCoursesNoSect[num] = CurrentCoursesNoSect.ElementAt(num).Remove(mk);
                                        }

                                        IEnumerable<string> distinctcurrcourses = CurrentCoursesNoSect.Distinct();
                                        if (distinctcurrcourses.Count() == CurrentCoursesNoSect.Count())  //if no duplicate courses:
                                        {
                                            ///Console.WriteLine("No Duplicate Courses. sorting list to elim dupe SCHEDULES later");  //wr
                                            CurrentCourses.Sort();

                                            int count = 0;
                                            for (int g = 0; g<CurrentCourses.Count()-1; g++)  //checking for duplicate Schedules part 1
                                            {
                                                if (CurrentCourses.ElementAt(g) == BufferCourses.ElementAt(g))
                                                {
                                                    count++;
                                                }
                                            }

                                            if (count < 5)//if not identical to buffer schedule, create new Schedule object
                                            {
                                                Schedule sch = new Schedule(CurrentCourses, 5);
                                                possibleSchedules.Add(sch);
                                                BufferCourses = CurrentCourses;
                                            }
                                            else
                                            {
                                                BufferCourses = CurrentCourses;

                                            }

                                        }

                                    }



                                }
                            }
                        }
                    }
                }

                        
            }
        }




        /* Method sets possibleSchedules List to NOT include any duplicate schedules */
        public static void findDuplicateSchedules()
        {
            possibleSchedules.Sort((x ,y) => x.ToString().CompareTo(y.ToString()));  
            
            distinctscheduleslist = possibleSchedules.Distinct().ToList();

            possibleSchedules = distinctscheduleslist;
        }

    }

}
