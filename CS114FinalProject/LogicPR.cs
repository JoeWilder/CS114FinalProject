using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS114FinalProject
{
    public static class LogicPR
    {
        public static List<Schedule> possibleSchedules;

        public static int schedulesize = 5; // can change to number of searches 
        public static List<string> CurrentCourses;

        public static List<string> BufferCourses = new List<string>(5) { "tseT", "tests", "buffer", "Strings", "here" };

        public static List<string> CurrentCoursesNoSect;
      
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
                                    //Console.WriteLine($"{a} + {b} + {c} + {d} + {e}");

                                    if (Logic.compat[a, b] == "Y" && Logic.compat[a, c] == "Y" && Logic.compat[a, d] == "Y" && Logic.compat[a, e] == "Y" &&
                                            Logic.compat[b, c] == "Y" && Logic.compat[b, d] == "Y" && Logic.compat[b, e] == "Y" && Logic.compat[c, d] == "Y" &&
                                            Logic.compat[c, e] == "Y" && Logic.compat[d, e] == "Y")
                                    {
                                        Console.WriteLine("All 5 sections compatable with all others");

                                        CurrentCourses = new List<string> { Logic.c[Logic.matchrows[a], 0], Logic.c[Logic.matchrows[b], 0],
                                            Logic.c[Logic.matchrows[c], 0], Logic.c[Logic.matchrows[d], 0], Logic.c[Logic.matchrows[e], 0] };
                                        
                                        
                                        //removing section number from temporary list (NoSection one)
                                        CurrentCoursesNoSect = new List<string> { Logic.c[Logic.matchrows[a], 0], Logic.c[Logic.matchrows[b], 0],
                                            Logic.c[Logic.matchrows[c], 0], Logic.c[Logic.matchrows[d], 0], Logic.c[Logic.matchrows[e], 0] };

                                        for (int num = 0; num < CurrentCoursesNoSect.Count(); num++)
                                        {
                                            int mk = CurrentCoursesNoSect.ElementAt(num).LastIndexOf("-");
                                            CurrentCoursesNoSect[num] = CurrentCoursesNoSect.ElementAt(num).Remove(mk);
                                        }

                                        IEnumerable<string> distinctcurrcourses = CurrentCoursesNoSect.Distinct();
                                        if (distinctcurrcourses.Count() == CurrentCoursesNoSect.Count())
                                        {
                                            //Console.WriteLine($"{a} + {b} + {c} + {d} + {e}");
                                            Console.WriteLine("No Duplicate Courses. sorting list to elim dupe SCHEDULES later");
                                            //todo could just use sort and forloop below instead of Distinct()
                                            CurrentCourses.Sort();

                                            int count = 0;
                                            for (int g = 0; g<CurrentCourses.Count()-1; g++)
                                            {
                                                if (CurrentCourses.ElementAt(g) == BufferCourses.ElementAt(g))
                                                {
                                                    count++;
                                                }
                                            }

                                            //if (count < 5)//if NOT all the same classes
                                            //{
                                                Schedule sch = new Schedule(CurrentCourses, 5);
                                                possibleSchedules.Add(sch);
                                                BufferCourses = CurrentCourses;
                                            //}
                                            //else// if(count > 4)  //if all classes are the same as buffer
                                            //{
                                                BufferCourses = CurrentCourses;

                                            //}




                                        }

                                    }



                                }
                            }
                        }
                    }
                }

                        
            }
        }

        public static void findDuplicateSchedules()
        {

            foreach(Schedule sch in possibleSchedules)
            {
                foreach(string cour in sch.thecourses)
                {
                    Console.Write(cour + "_");
                }
                Console.WriteLine("");
            }

            



        }





    }
}
