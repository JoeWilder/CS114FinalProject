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
                                        
                                        for (int num = 0; num < CurrentCourses.Count(); num++)
                                        {//removing section number
                                            int mk = CurrentCourses.ElementAt(num).LastIndexOf("-");
                                            CurrentCourses[num] = CurrentCourses.ElementAt(num).Remove(mk);
                                        }


                                        IEnumerable<string> distinctcurrcourses = CurrentCourses.Distinct();
                                        if (distinctcurrcourses.Count() == CurrentCourses.Count())
                                        {
                                            //Console.WriteLine($"{a} + {b} + {c} + {d} + {e}");
                                            //Console.WriteLine("No Duplicates Found (in course cs-114 vs cs-114");

                                            if (1 == 2)
                                            {

                                                //need to elim duplicate schedules now tho.. like 01923 AND 93210 should not be allowed //todo



                                                //   Schedule sch = new Schedule(CurrentCourses, 5);
                                                //  possibleSchedules.Add(sch);
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
    
        
    }
}
