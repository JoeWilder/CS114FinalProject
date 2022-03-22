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
            {"GAD-300-06800", "GAD","300","06800", "Object Oriented Programming",  //21//0
             "2", "W-8", "M-8", ".", "."},
            {"GAD-300-11811", "GAD","300","11811", "Database Systems", //22//1
             "3", "W-8", "T1230", "F8", "."},
            {"GAD-300-21809", "GAD","300","21809", "Database Systems", //23//2
             "2", "W-8", "F-8", ".", "."},
            {"GAD-300-04702", "GAD","300","04702", "3D Character Rigging/Animation", //24//3
             "3", "W-330", "W-5", "H-5", "."},
            {"GAD-400-10702", "GAD","400","10702", "3D Character Rigging/Animation", //25//
             "2", "M-11", "H-11", ".", "."}, //altered data for comparison
            {"GAD-300-13703", "GAD","300","13703", "Creature Design",//26//4
             "2", "T-11", "H-11", ".", "."}

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
            
            for (int i = 0; i < matchrows.Count(); i++)  //down rows of compat table
            {
                for (int j = 0; j<matchrows.Count(); j++)  //over cols of compat table.
                {
                    // preface to rest of logic: if i = j, thats the same section compared to itself, so "I"nvalide
                    if (i == j)
                    {
                        compat[i, j] = "I";
                    } 
                    else 
                    {
                        /* current number of meeting times of the constant coursesection (i), and (t) */
                        string s_cXT = c[matchrows[i], 5];
                        int cXT = 0; //current number of times  //default = 2

                        if (!Int32.TryParse(s_cXT, out cXT))
                        {
                            Console.WriteLine("Error Try Again in parsing. s: " + s_cXT + ", int: " + cXT);
                        }
                        else
                        {
                            Console.WriteLine("int parsed: " + cXT);
                        }

                        /* current number of meeting times of the comparison coursesection (j), and (b) */
                        string s_sXT = c[matchrows[j], 5];
                        int sXT = 0;

                        if (!Int32.TryParse(s_sXT, out sXT))
                        {
                            Console.WriteLine("Parse Error in loop j sXT parse.");
                        }
                        else  //finding number of times comparisoncoursesection meets
                        {
                            Console.WriteLine("int parsing in sXT =" + sXT);
                        }

                        /* will reset for each new comparison (j) */
                        int sumcheck = 0;

                        /*t: sets the current constant time block in the constantcoursesection (i) */
                        for (t = 6; t < (6 + cXT); t++)  //col 6 to LESS THAN (6+2)=8 so 7.
                        {
                            //*//setting the current constant time block (t) (in course [i,j]) to compare all k's to 
                            Console.WriteLine("entered t loop: t = " + t + $" in i {i}, j{j}; current time block is i(t):" + c[matchrows[i], t]);


                            /*"same as t", iterates thru time blocks (col 6-7-8-9) OF current Comparison coursesection (j)(b) */
                            for (int b = 6; b < (6 + sXT); b++) 
                            {
                                Console.WriteLine($"Entered b loop. b {b}, j {j}. i={i}, t={t}");
                                
                                if (c[matchrows[i], t] != c[matchrows[j], b])
                                {
                                    sumcheck += 1;
                                    Console.WriteLine($"In b loop: compat section, add to sumcheck = {sumcheck}");
                                }
                                else
                                {
                                    //timeblock same/incompatible: dont add    
                                    Console.WriteLine("In b loop: times incompat");  //oH its comparing the same one, k isnt incremented..
                                }


                            }//end of b


                        }//end of t

                        Console.WriteLine("after t loop ends, before j loop ends, sum = " + sumcheck);
                        if (sumcheck == (cXT * sXT))  //number of cycles of t * b essentially(?)
                        {
                            compat[i, j] = "Y";  //or [i,r] ????!!!!
                        }
                        else
                        {
                            compat[i, j] = "N";  //should this be [i, r] not j ....????.. no? bc r is the controller of the comparison course nott he OH. wait so yea??  is this still inide the r loop!? YES so...
                        }






                    }//end of else


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
