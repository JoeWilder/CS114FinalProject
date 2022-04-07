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
            List<string> CurrentCourses;
            

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
                                    
                                    //CurrentCourses = { c[Logic.matchrows[a],0].ToString()}

                                }
                            }
                        }
                    }
                }



                        
            }
        }
    
        
    }
}
