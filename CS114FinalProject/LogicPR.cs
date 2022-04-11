using System;
using System.Collections.Generic;
using System.Linq;

namespace CS114FinalProject
{
    public static class LogicPR
    {
        public static void PossibleSchedule() //PR
        {


            //int schedulesize = 5; // can change to number of searches
            List<string> CurrentCourses = new List<string>(5);
            List<int> CurrentCoursesID = new List<int>(5);
            List<string> College = new List<string>() { "CS-114", "CS-115", "CS-116", "CS-215", "CS-219" }; //temporary
            //int ranktemp = 5;

            for (int i = 0; i < College.Count; i++)
            {
                for (int e = 0; e < College.Count; e++)
                {
                    for (int d = 0; d < College.Count; d++)
                    {
                        for (int c = 0; c < College.Count; c++)
                        {
                            for (int b = 0; b < College.Count; b++)
                            {
                                for (int a = 0; a < College.Count; a++)
                                {


                                    //Console.WriteLine($"{College[a]} + {College[b]} + {College[c]} + {College[d]} + {College[e]}");
                                    int ranktemp = 5;

                                    string CourseString = College[a] + College[b] + College[c] + College[d] + College[e];
                                    Console.WriteLine(CourseString);

                                    if (ListHasDuplicates(CourseString) == true)
                                    {
                                        continue;
                                        

                                    }


                                    Console.WriteLine(CourseString);
                                    // CurrentCourses = new List<string> { Logic.c[Logic.matchrows[a], 0], Logic.c[Logic.matchrows[b], 0], Logic.c[Logic.matchrows[c], 0], Logic.c[Logic.matchrows[d], 0], Logic.c[Logic.matchrows[e], 0] };



                                    
                                }
                            }
                        }
                    }
                }
            }
        }
             

            
        public static bool ListHasDuplicates(string stuff)
        {
            bool result = false;



            result = (stuff.Split().Count() == stuff.Split().Distinct().Count());
            Console.WriteLine(result);
            return !result;
        }
    }
}
            
