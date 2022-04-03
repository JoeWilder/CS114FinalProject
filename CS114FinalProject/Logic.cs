﻿/* Name: Logic.cs
 * Purpose: static class to hold all funcationality related to creating course comparison tables
 * Notes: created by Jade 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CS114FinalProject
{
    public static class Logic
    {
        // outdated
        public static DayOfWeek d = DayOfWeek.Monday;
        public static int t = 1230;

        public static string[,] l = new string[2, 2] {
            { "x", "X"},
            { "X", "x" }
        };
        //outdated ^^

        //Logic Table - filled by comparison method (both one-time things)
        //"." is null. "Y" is compatible, "N" is non-compatible, "I" is Invalid (self comparison)
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
       

        //user input (iterate thru 5-6 classes input) "CS-217" format
        private static List<string> search = new List<string> ();

        private static int nummatches = 0;
        private static List<int> matchrows = new List<int>();


        private static string currentCB = ""; // outdated

        //sample/altered data for comparison//

        public static string[,] c = new string[10, 10] {  //[down, over]
            {"FULLCODE", "CODE","NUM","SECTION", "NAME",
             "XT", "T1", "T2", "T3", "T4"},
            {"CS-217-09803", "CS","203","09803", "Soph Software Engineering",
             "2", "M-2", "H-2", ".", "."},
            {"CS-217-10814", "CS","203","10814", "Soph Software Engineering",
             "2", "T-2", "F-2", ".", "."},
            {"CS-217-05812", "CS","217","05812", "Object Oriented Programming",
             "2", "M-11", "H-11", ".", "."},
            {"GAD-300-06800", "GAD","300","06800", "Object Oriented Programming",  
             "2", "W-8", "M-8", ".", "."},
            {"GAD-300-11811", "GAD","300","11811", "Database Systems", 
             "3", "W-8", "T1230", "F8", "."},
            {"GAD-300-21809", "GAD","300","21809", "Database Systems", 
             "2", "W-8", "F-8", ".", "."},
            {"GAD-30-04702", "GAD","300","04702", "3D Character Rigging/Animation", 
             "3", "W-330", "W-5", "H-5", "."},
            {"GAD-330-10702", "GAD","400","10702", "3D Character Rigging/Animation",
             "2", "M-11", "H-11", ".", "."}, 
            {"GAD-300-13703", "GAD","300","13703", "Creature Design",
             "2", "T-11", "H-11", ".", "."}

        };


        //trigger this once all 5-6 searches are filled (with user's courses)  //todo
        public static string initRelevantTable()  
        {
            nummatches = 0; 
            matchrows = new List<int>();

            for (int i = 1; i < c.GetUpperBound(0); i++)  
            {
                string course = c[i, 0];  
                Console.WriteLine(course);
                course = course.Remove(course.LastIndexOf("-"));
                Console.WriteLine(course);
                bool found = false;  //to prevent duplicate searches and prevent wasted time


                for (int s = 0; s<search.Count(); s++)
                {

                    if ( !found && (course == search.ElementAt(s)) )
                    {
                        nummatches += 1;
                        matchrows.Add(i);
                        found = true;
                        Console.WriteLine("i=" + i + ". match! search was: " + getSearch());
                        //break;  //use instead of bool? to break entire s loop if term found.
                    }

                }


                //add an "if reached alphabetical AFTER last search term found, break? so doesnt search thru the ENTIRE thousands course catalog? 
                //basically, work on optimization if at all possible. //todo
            }

            //Findings
            for (int w = 0; w < (matchrows.Count()); w++)
            {
                Console.WriteLine("c row/ID: " + matchrows.ElementAt(w) + ", value: " + c[matchrows.ElementAt(w), 0]);
            }

            return ("Initialize RelevantCourses Table complete.");
        }


        /* Fills course section compatibility table (compat[,])
         *  Example of how the 3 arrays relate:
         *      ID 0 in compat (either dimension): holds "Y"/"N" compatibity for
         *      ID 0 in matchrows (single Dim List<>): holds ID of course from c (catalog)
         *      ID 23 down in c (catalog) row holds info about certain course section.
         *  matchrows is the key that connects course section info (c) to its intercompatibilty (compat)
         */
        //ID of matchrows holds ID in c 
        //ID of section in matchrows, plus 1, is ID in compat
        public static string courseCompare()
        {
            //compat = new string[15,15] { }; //tried to set to size of nummatches (but cant bc not constant)

            //can start at . in each row, check compat only after, and then flip digits to fill in other half without having to calculate 2x

            /* (i) controls rows/down in the compat table */
            for (int i = 0; i < matchrows.Count(); i++) 
            {
                /* (j) controls cols/over in compat table */
                for (int j = 0; j<matchrows.Count(); j++)  
                {
                    /* skip unneeded logic if attempting self comparision */
                    if (i == j)
                    {
                        compat[i, j] = "I";
                    } 
                    else 
                    {
                        /* current number of meeting times of the Constant course section (i), and (t) */
                        string s_cXT = c[matchrows[i], 5];
                        int cXT = 0; //current number of times  //default = 2

                        if (!Int32.TryParse(s_cXT, out cXT)) {
                            Console.WriteLine("Error Try Again in parsing. s: " + s_cXT + ", int: " + cXT);
                        } else {
                            Console.WriteLine("int parsed: " + cXT);
                        }

                        /* current number of meeting times of the comparison coursesection (j), and (b) */
                        string s_sXT = c[matchrows[j], 5];
                        int sXT = 0;

                        if (!Int32.TryParse(s_sXT, out sXT)){
                            Console.WriteLine("Parse Error in loop j sXT parse.");
                        } else {
                            Console.WriteLine("int parsing in sXT =" + sXT);
                        }

                        /* will reset for each new Comparison (j) */
                        int sumcheck = 0;

                        /* (t) sets the time block of the current Constant coursesection (i) */
                        for (t = 6; t < (6 + cXT); t++)  
                        {
                            Console.WriteLine($"Constants- Course section: {c[matchrows[i],0]} ,Current timeblock is i(t):" + c[matchrows[i], t]);

                            /* (b) sets the time block of the current Comparison coursesection (j) */
                            for (int b = 6; b < (6 + sXT); b++) 
                            {
                                Console.WriteLine($"Compares- Course section: {c[matchrows[j], 0]} ,Current timeblock is j(b):" + c[matchrows[j], b]);

                                if (c[matchrows[i], t] != c[matchrows[j], b])
                                {
                                    sumcheck += 1;
                                    Console.WriteLine($"In b loop: compatible section, add to sumcheck = {sumcheck}");
                                }
                                else
                                {
                                    Console.WriteLine("In b loop: times incompatible");  
                                }

                            }//end of b

                        }//end of t

                        Console.WriteLine("after t loop ends, before j loop ends, sum = " + sumcheck);

                        if (sumcheck == (cXT * sXT))  //number of cycles of t * b essentially
                        {
                            compat[i, j] = "Y";
                            Console.WriteLine($"Set compat[{i}, {j}] to Yes");
                        }
                        else
                        {
                            compat[i, j] = "N";
                        }

                    }//end of else
                }//end of j loop
            }//end of i loop

            return "k";
        }



        //PRINTING Compatibility Table/2D ARRAY
        public static void PrintCompatTable()
        {
            //Header row
            Console.Write("   ");
            for(int d = 0; d<matchrows.Count(); d++)
            {
                Console.Write( d + "  " );

            }
            Console.WriteLine();

            //Table Data
            for (int i = 0; i < matchrows.Count(); i++)
            {
                Console.Write(i + ": ");
                for (int j = 0; j < matchrows.Count(); j++)
                {
                    Console.Write(compat[i, j] + ", ");
                }
                Console.WriteLine();
            }

        }

        /* SetSearch overloads: input a List<sting> (any size), or 4, 5  or 6 strings*/
        public static void setSearch(List<string> s)
        {
            search = s;
        }

        public static List<string> setSearch(string a, string b, string c, string d){
            search = new List<string> { a, b, c, d};
            return search;
        }

        public static List<string> setSearch(string a, string b, string c, string d, string e){
            search = new List<string> { a, b, c, d , e};
            return search;
        }
        public static List<string> setSearch(string a, string b, string c, string d, string e, string f)
        {
            search = new List<string> { a, b, c, d, e, f};
            return search;
        }
        public static List<string> getSearch()
        {
            return search;
        }


        private static string[] filedata;
        private static string[,] c2 = new string[50,10];

        public static void formatData()
        {
            int eos; //index of current  end of section

            //             File.WriteAllText("Test.txt", "Hellow World!");
            //File.OpenRead();

            //noT going to store any info abt professor or term year?  //also consider the jagged array??
            //Columns of c catalog 2d array are:
            //{"FULLCODE", "CODE","NUM","SECTION", "NAME", "XT", "T1", "T2", "T3", "T4"}
            //{CS-413-10801, CS, 413, 10801, Senior Software Engineering, 2, T2, F2, ., .

            //default directory is FinalProject/bin/debug, may change when project BUILT tho?
            //cannot have any blank lines. deleting any blank entries


            filedata = File.ReadAllLines("SampleData.txt");  

            foreach (string line in filedata)
            {
                Console.WriteLine(line);
            }

            for (int l = 0; l < filedata.Count(); l++)
            {
                string currentline = filedata[l];

                eos = currentline.IndexOf("(");
                c2[l, 4] = currentline.Substring(0, eos + 1);  //Name of Course saved

                eos = currentline.IndexOf("@"); //returns 1st occurance
                currentline = currentline.Remove(0, (eos+1));  //starting pos, NUMBER of chars to delete, returns new string

                eos = currentline.IndexOf("@"); //returns end of second section
                c2[l, 0] = currentline.Substring(0, eos+1); //Course number (CS-114-08608) saved
                currentline = currentline.Remove(0, eos + 1); //remove up to (inlcuding) that @

                eos = currentline.IndexOf("@"); //returns end of section 3 (term)
                currentline = currentline.Remove(0, eos + 1);
                eos = currentline.IndexOf("@"); //returns end of section 4 (prof)
                currentline = currentline.Remove(0, eos + 1);
                eos = currentline.IndexOf("@"); //returns end of section 5 (location)
                currentline = currentline.Remove(0, eos + 1);

                eos = currentline.IndexOf("@"); //returns end of section 6  TIMES

                currentline = currentline.Substring(0, eos); //cuts off end, incl last @             

                Console.WriteLine(currentline); //todo temp

                //if datetime has a semicolon, check if after; contains substr of the befor;, if same, delete 1 =theyre dupes

                if (currentline == "" || currentline == " ")
                {
                    break;
                }
                else if (currentline.Contains("Date TBD"))
                {
                    //Setting defaults
                    c2[l, 5] = "2";
                    c2[l, 6] = "TBD";
                    c2[l, 7] = "TBD";
                    c2[l, 8] = ".";
                    c2[l, 9] = ".";

                } 
                else 
                {
                    string first; 
                    string second;

                    string days;
                    string times;
                    char[] nums = new char[10] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };


                    if (currentline.Contains(";"))  //Remove duplicate time entries
                    {
                        
                        eos = currentline.IndexOf(";");  //id 1 of length 5/max id 4

                        first = currentline.Substring(0, eos + 1);
                        second = currentline.Substring(eos + 1, (currentline.Length - (eos + 1)));


                        first = first.Trim(' ');
                        second = second.Trim(' ');
                        first = first.Trim(';');
                        second = second.Trim(';');

                        //currentline = first + "@" + second;

                        //int start2 = currentline.IndexOf("@") + 1;


                        //determine when day letters end
                        
                        eos = first.IndexOfAny(nums);  //days1/2 end at first number 
                        string days1 = first.Substring(0, eos);
                        first = first.Remove(0, eos);
                        
                        int eos2 = second.IndexOfAny(nums);
                        string days2 = second.Substring(0, eos);
                        second = second.Remove(0, eos2);

                        days1 = days1.TrimStart(' ');
                        days2 = days2.TrimStart(' ');
                        first = first.Trim(' ');
                        second = second.Trim(' ');
                        //now first/second are times, days1/2 are days

                        //Console.WriteLine($"first: _{first}_ adn second: _{second}_");
                        if (first.Contains(second) && days1.Contains(days2))
                        {
                            currentline = days1 + " " + first;  
                        }
                        days = days1;
                        times = first;
                    } else
                    {
                        //determine when day letters end
                  
                         eos = currentline.IndexOfAny(nums);  //returns index of first number 

                        days = currentline.Substring(0, eos);
                        times = currentline.Remove(0, eos);

                        days = days.TrimStart(' ');
                        times = times.Trim(' ');

                    }

                    if (days.Contains("M"))
                    {

                    }
                    if (days.Contains("W"))
                    {

                    }
                    if (days.Contains("F"))
                    {

                    }
                    if (days.Contains("TH"))
                    {
                        //catalog gets thurs
                        int thurs = days.IndexOf('H');
                        days = days.Remove(thurs - 1, 1);
                    } 
                    if (days.Contains("T "))  //T <SPACE> so TH (thursday) doesn't get grabbed here 
                    {
                        Console.WriteLine("Tuesday recognized)");
                    }

                    Console.WriteLine(days + "_" + times);//

                    //Determining how many blocks of time course meets for
                    eos = times.IndexOf("-");

                    //todo; either if tree, or convert to datetime substraction, or number/placeval diffs





                }// ^ if not blank or tbd


            } //end of l loop (each line)


            //Heading with name@full code num@term@prof@Location@times@catergory@

            //Print at end//temporary
            for (int li = 0; li < (c2.GetUpperBound(0)+1); li++)
            {
                for (int m = 0; m < (c2.GetUpperBound(1) +1); m++)
                {
                    Console.Write(c2[li, m]);
                }
                Console.WriteLine("");
            }


        }



    }
}
