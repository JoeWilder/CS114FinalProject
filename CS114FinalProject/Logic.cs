using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS114FinalProject
{
    public static class Logic
    {

        public static DayOfWeek d = DayOfWeek.Monday;
        public static int t = 1230;

        public static List<CourseSection> CourseA = new List<CourseSection>();
        public static List<CourseSection> CourseB = new List<CourseSection>();
        public static List<CourseSection> CourseC = new List<CourseSection>();
        public static List<CourseSection> CourseD = new List<CourseSection>();
        public static List<CourseSection> CourseE = new List<CourseSection>();

        public static string[,] l = new string[2, 2] {
            { "x", "X"},
            { "X", "x" }
        };

        //Logic Table - filled by comparison method (both one-time things)
        //"." is null. "Y" is compatible, "N" is non-compatible. each 
        public static string[,] compat = new string[18,18] {
            {".", ".",".",".",".",".",".",".",".",".", ".",".",".",".",".", ".",".",".",},
            {".", ".",".",".",".",".",".",".",".",".", ".",".",".",".",".", ".",".",".",},
            {".", ".",".",".",".",".",".",".",".",".", ".",".",".",".",".", ".",".",".",},
            {".", ".",".",".",".",".",".",".",".",".", ".",".",".",".",".", ".",".",".",},
            {".", ".",".",".",".",".",".",".",".",".", ".",".",".",".",".", ".",".",".",},
            {".", ".",".",".",".",".",".",".",".",".", ".",".",".",".",".", ".",".",".",},
            {".", ".",".",".",".",".",".",".",".",".", ".",".",".",".",".", ".",".",".",},
            {".", ".",".",".",".",".",".",".",".",".", ".",".",".",".",".", ".",".",".",},
            {".", ".",".",".",".",".",".",".",".",".", ".",".",".",".",".", ".",".",".",},
            {".", ".",".",".",".",".",".",".",".",".", ".",".",".",".",".", ".",".",".",},
            {".", ".",".",".",".",".",".",".",".",".", ".",".",".",".",".", ".",".",".",},
            {".", ".",".",".",".",".",".",".",".",".", ".",".",".",".",".", ".",".",".",},
            {".", ".",".",".",".",".",".",".",".",".", ".",".",".",".",".", ".",".",".",},
            {".", ".",".",".",".",".",".",".",".",".", ".",".",".",".",".", ".",".",".",},
            {".", ".",".",".",".",".",".",".",".",".", ".",".",".",".",".", ".",".",".",},
            {".", ".",".",".",".",".",".",".",".",".", ".",".",".",".",".", ".",".",".",},
            {".", ".",".",".",".",".",".",".",".",".", ".",".",".",".",".", ".",".",".",},
            {".", ".",".",".",".",".",".",".",".",".", ".",".",".",".",".", ".",".",".",},
        } ;
            //dont define size here... so can grow when created

        private static string search = ""; //user input (iterate thru 5-6 classes input) CS-217 format
        private static int nummatches = 0;
        private static List<int> matchrows = new List<int>();
        private static string currentCB = "";


        public static string[,] c = new string[10, 10] {  //[down, over]
            {"FULLCODE", "CODE","NUM","SECTION", "NAME",
             "XT", "T1", "T2", "T3", "T4"},
            {"CS-203-09803", "CS","203","09803", "Soph Software Engineering",
             "2", "M-2", "H-2", ".", "."},
            {"CS-203-10814", "CS","203","10814", "Soph Software Engineering",
             "2", "T-2", "F-2", ".", "."},
            {"CS-217-05812", "CS","217","05812", "Object Oriented Programming",
             "2", "M-11", "H-11", ".", "."},
            {"CS-217-06800", "CS","217","06800", "Object Oriented Programming",
             "2", "W-11", "F-11", ".", "."},
            {"CS-231-11811", "CS","213","11811", "Database Systems",
             "2", "M-330", "H-330", ".", "."},
            {"CS-231-21809", "CS","213","21809", "Database Systems",
             "2", "T-5", "H-5", ".", "."},
            {"GAD-300-04702", "GAD","300","04702", "3D Character Rigging/Animation",
             "2", "F-8", "F-930", ".", "."},
            {"GAD-300-10702", "GAD","300","10702", "3D Character Rigging/Animation",
             "2", "T-2", "F-8", ".", "."}, //altered data for comparison //
            {"GAD-400-13703", "GAD","400","13703", "Creature Design",
             "2", "T-11", "T-1230", ".", "."}

        };


        public static string initRelevantTable()  //need to run 5-6 times (for each course search) so diff reset + other changes
        {
            nummatches = 0; //?reset where
            matchrows = new List<int>();

            for (int i = 1; i < 10; i++)  //sections, max should be full catalog size //todo size? 18?
            {

                string course = c[i, 0];  //?change to use CourseSection class for info in 1st col of array for .getName ease. UGH
                Console.WriteLine(course);
                course = course.Remove(course.LastIndexOf("-"));
                Console.WriteLine(course);


                if (course == search)
                {
                    nummatches += 1;
                    matchrows.Add(i);
                    Console.WriteLine("i=" + i + ". match! search was: " + getSearch());
                }

            }

            //Findings
            for (int w = 0; w < (matchrows.Count()); w++)
            {
                Console.WriteLine("c row/ID: " + matchrows.ElementAt(w) + ", value: " + c[matchrows.ElementAt(w), 0]);
            }

            return ("Initialize RelevantCourses Table complete.");
        }


        //Fills compatibility table
        //ID of matchrows holds ID in c 
        //ID of section in matchrows, plus 1, is ID in compat
        public static string courseCompare()
        {
            //compat = new string[15,15] { }; //reseting to size of nummatches (but cant bc not constant)

            //can start at . in each row, check compat only after, and then flip digits to fill in other half without having to calculate 2x
            
            for (int i = 0; i < matchrows.Count(); i++)
            {
                for (int j = 0; j<matchrows.Count(); j++)
                {
                    if (i == j)
                    {
                        compat[i, j] = "I";
                    } 
                    if (compat[i, j] == ".")
                    {
                        //skip all rest, its null....
                        return ("null reached");
                    }
                    else
                    {
                        string s_cXT = c[matchrows[j], 5];
                        int cXT = 0; //current number of times  //default = 2
                        int sXT = 0; //number of times of the subs
                        if(!Int32.TryParse(s_cXT, out cXT))
                        {
                            Console.WriteLine("Error Try Again in parsing. s: " + s_cXT + ", int: " + cXT);
                        } else
                        {
                            Console.WriteLine("int parsed: " + cXT);
                        }

                        for(t=6; t< (6+cXT); t++)  //col 6 to LESS THAN (6+2)=8 so 7.
                        {
                            //*//setting the current constant time block (t) (in course [i,j]) to compare all k's to 
                            Console.WriteLine("entered t loop: t = " + t);

                            for (int k = 1; k <= (matchrows.Count()); k++)  //-1?//matchrows - i (or j or invert?) will make it only do half?
                            {
                                Console.WriteLine("entered k loop, k = " + k);
                                if (!Int32.TryParse((c[matchrows[j + k], 5]),out sXT )){
                                    Console.WriteLine("Parse Error in loop k.");
                                }else
                                {
                                    Console.WriteLine("in parsing in k loop: sXT =" + sXT);
                                }


                                for (int b = 6; b < (6 + sXT); b++) //same as t, iterates thru time blocks (col 6-7-8-9)
                                {  //b should start at the col over (j?) so that it only compares half?

                                    Console.WriteLine("Entered b loop, b = " + b);
                                    //*//
                                    if (c[matchrows[j], t] == c[matchrows[j + k], b])
                                    {
                                        compat[i, j] = "N";
                                    }



                                }//end of b

                            }//end of k







                        }//end of t



                    }//end of else not i==j




                }//end of j loop
            }//end of i loop


            //PRINTING ARRAY

            for (int i = 0; i < matchrows.Count(); i++)
            {
                for (int j = 0; j <matchrows.Count(); j++)
                {
                    Console.Write(compat[i, j] + ", ");
                }
                Console.WriteLine();
            }



            //num of time blocks
            ////int XT = Int32.Parse(c[i,5]);
            //need to set a constant to compare to out here, like each blcok will need to be the "k" to compare to all else (?)
            //^^thats this vv i think
            ////for(int t = 6; t<(6+XT); t++)
            ////{
            //c[i, t];
            //compare to all other i's, j6-7-8-9 depending on how many XT

            ////}
            /*
            if(!(c[i,5].Contains(".")))
            {
                //
            }

            for (int j = 6; j < (Int32.Parse(c[i, 5]) + 6); j++)  //time blocks, across
            {
                if(c[i,j] == c[i + 1, j + 1])
                {

                }
            }
            */

        

            //if (CourseA.ElementAt(i).cbOne == CourseA.ElementAt(i + 1).cbOne)


            return "k";
        }



        public static void setSearch(string s)
        {
            search = s;
        }

        public static string getSearch()
        {
            return search;
        }


    }
}
