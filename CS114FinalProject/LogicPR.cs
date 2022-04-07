using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS114FinalProject
{
    class LogicPR
    {
        static public void PossibleSchedule()
        {
            int schedulesize = 5; // can change to number of searches 
            List<string> CurrentCourses = new List<string>(5);
            List<int> CurrentCoursesID = new List<int>(5);
            int ranktemp = 5;

            for(int i = 0; i < Logic.nummatches; i++)
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
                                    Console.WriteLine($"{a} + {b} + {c} + {d} + {e}");
                                    ranktemp = 5;

                                    

                                    CurrentCourses = new List<string> { Logic.c[Logic.matchrows[a],0], Logic.c[Logic.matchrows[b], 0], Logic.c[Logic.matchrows[c], 0],Logic.c[Logic.matchrows[d], 0],Logic.c[Logic.matchrows[e], 0] };
                                    
                                    for(int z = 0; z<(CurrentCourses.Count - 1); z++) {
                                        for(int v = 0; v < CurrentCourses.ElementAt(z).Count(); v++)
                                        {
                                            Console.WriteLine(CurrentCourses.ElementAt(z).ElementAt(v) + "_ and z+1 v _" + CurrentCourses.ElementAt(z + 1).ElementAt(v));

                                            //bigger ascii number is later in alphabet
                                            if (CurrentCourses.ElementAt(z).ElementAt(v) > CurrentCourses.ElementAt(z+1).ElementAt(v)) {
                                                //take out z+1, and insert it at z
                                                Console.WriteLine(CurrentCourses.ElementAt(z).ElementAt(v) + "_ and z+1 v _" + CurrentCourses.ElementAt(z + 1).ElementAt(v));
                                                
                                            }

                                        }

                                    }

                                    //alternatively, bubble sort the list^ and check dupes in a row..

                                   /* foreach (string s in CurrentCourses)
                                    {
                                        if (CurrentCourses.FindAll(s).Count > 1)
                                        {
                                            ranktemp -= CurrentCourses.FindAll(s).Count;  //need to make sure a vs b doesnt minus b va a too,,, no yeah keep that
                                        }
                                    }
                                   */

                                    //init new object with rank and list fo courses IF rak is still above 3 or sth


                                }  //abcde forloops
                            }
                        }
                    }
                }//abcde 

            }//i loop


        }//method
    
        
    }
}
