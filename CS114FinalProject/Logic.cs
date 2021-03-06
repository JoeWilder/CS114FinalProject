/* Name: Logic.cs
 * Purpose: static class to hold all funcationality related to creating course comparison tables
 * Author: Jade Kosa 
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
        
        /**** Compat(ability) Table holds letters to indicate whether 2 course sections are compatible
        *  Table is populated by CourseCompare() method
        *  "." is null. "Y" is compatible, "N" is not, "I" is Invalid (self comparison), "U" is invalid (unknown time)
        */
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
       

        //user inputs searches in "CS-217" format
        public static List<string> search = new List<string> ();

        //keeps track of how many course sections are relevant to the search
        public static int nummatches = 0;
        public static List<int> matchrows = new List<int>();

        // course catalog data
        public static string[] filedata;
        public static string[,] c = new string[60, 10];  //todo increase max

        //sample/altered data for testing
        //Format: {"FULLCODE", "CODE","NUM","SECTION", "NAME", "XT", "T1", "T2", "T3", "T4"},
        public static string[,] ctest = new string[4, 10] {  //[down, over]
            {"CS-217-09803", "CS","203","09803", "Soph Software Engineering",
             "2", "M-2", "H-2", ".", "."},
            {"CS-217-10814", "CS","203","10814", "Soph Software Engineering",
             "2", "T-2", "F-2", ".", "."},
            {"CS-217-05812", "CS","217","05812", "Object Oriented Programming",
             "2", "M-2", "F-2", ".", "."}, 
            {"GAD-300-13703", "GAD","300","13703", "Creature Design",
             "2", "T-11", "H-11", ".", "."}
        };


        /* 
         * This Method creates List<int> matchrows based off of users searches.
         * This List holds row numbers (rows in c/catalog) of relevant course sections
         */
        public static string initRelevantTable()  
        {
            nummatches = 0; 
            matchrows = new List<int>();

            for (int i = 1; i < c.GetUpperBound(0); i++) 
            {
                string course = c[i, 0];  
                Console.WriteLine(course);  //wr
                if(course != null)
                {
                    //removes section id from course to compare to user searches
                    course = course.Remove(course.LastIndexOf("-")); 
                    course = course.Trim(' ');
                    Console.WriteLine(course);  //wr
                    bool found = false;  


                    for (int s = 0; s < search.Count(); s++)
                    {

                        if (!found && (course == search.ElementAt(s)))
                        {
                            nummatches += 1;
                            matchrows.Add(i);
                            found = true;
                            Console.WriteLine("i=" + i + ". match! search was: " + course);  //wr
                        }
                    }
                }

            }

            //Findings  //wr
            for (int w = 0; w < (matchrows.Count()); w++)
            {
                Console.WriteLine("c row/ID: " + matchrows.ElementAt(w) + ", value: " + c[matchrows.ElementAt(w), 0]);
            }

            return ("Initialize RelevantCourses Table complete.");
        }


        /* courseCompare() method populates the course-section compatibility table (compat[,])  */
        public static string courseCompare()
        {
            /* (i) controls rows/down in the compat table */
            for (int i = 0; i < matchrows.Count(); i++) 
            {
                /* (j) controls cols/over in compat table */
                for (int j = 0; j<matchrows.Count(); j++)  
                {
                    /* skip unneeded logic if attempting self comparision */
                    if (i == j)
                    {
                        compat[i, j] = "I";  //invalid comparison
                    } else if (c[matchrows[i], 6] == "TBD" || c[matchrows[j],6] == "TBD")
                    {
                        compat[i, j] = "U"; //unknown time
                        compat[j, i] = "U";
                    } else if (c[matchrows[i], 0] == null)
                    {
                        //skip row if blank?
                    }
                    else 
                    {
                        /* current number of meeting times of the Constant course section (i), and (t) */
                        string s_cXT = c[matchrows[i], 5];
                        int cXT = 2; 

                        if (!Int32.TryParse(s_cXT, out cXT)) {
                            Console.WriteLine("Error Try Again in parsing. s: " + s_cXT + ", int: " + cXT);  //wr
                        } else {
                            Console.WriteLine("int parsed: " + cXT);
                        }

                        /* current number of meeting times of the compariSon coursesection (j), and (b) */
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
                        for (int t = 6; t < (6 + cXT); t++)  
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


        /* setSearch method overloads: input a List<sting> (any size), or 4, 5 or 6 course strings */
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


        /* formatData method takes the course data (saved local by WebbrowserForm) and puts it into 
         * processable format of string[,] c */
        public static void formatData()
        {
            int eos; //index of current end of section

            filedata = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "coursedata.txt");

            foreach (string line in filedata)
            {
                Console.WriteLine(line);  //wr
            }

            for (int l = 0; l < filedata.Count(); l++)
            {
                string currentline = filedata[l];

                if (currentline == "" || currentline == " ")
                {
                    break;
                }
                else
                {
                    eos = currentline.IndexOf("(");
                    c[l, 4] = currentline.Substring(0, eos );  //Name of Course saved

                    eos = currentline.IndexOf("@"); //returns 1st occurance (@ after full name)
                    currentline = currentline.Remove(0, (eos+1));  
    
                    eos = currentline.IndexOf("@"); //returns end of second section
                    c[l, 0] = currentline.Substring(0, eos); //Course number (CS-114-08608) saved

                    currentline = currentline.Remove(0, eos + 1); //remove up to (inlcuding) that @
                    eos = currentline.IndexOf("@"); //returns end of section 3 (term)
                    currentline = currentline.Remove(0, eos + 1);
                    eos = currentline.IndexOf("@"); //returns end of section 4 (prof)
                    currentline = currentline.Remove(0, eos + 1);
                    eos = currentline.IndexOf("@"); //returns end of section 5 (location)
                    currentline = currentline.Remove(0, eos + 1);

                    eos = currentline.IndexOf("@"); //returns end of section 6  (TIMES)

                    currentline = currentline.Substring(0, eos); //cuts off end section, incl last @             

                    Console.WriteLine(currentline); //wr

                     if ((currentline.Contains("Date TBD")) || (!currentline.Contains(":")))  
                     {
                         //Setting defaults
                        c[l, 5] = "2";
                        c[l, 6] = "TBD";
                        c[l, 7] = "TBD";
                        c[l, 8] = ".";
                        c[l, 9] = ".";

                     }
                     else
                     {
                        string first;
                        string second;

                        string days;
                        string times;
                        char[] nums = new char[10] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };

                        int xt = 0;
                        bool twoday = false;
                        bool doubleblock = false;
                        bool difflines = false;

                        //if before/after semicolon are same/contain each other, delete duplicate
                        if (currentline.Contains(";")) 
                        {
                            eos = currentline.IndexOf(";");

                            //storing the part before/after in identical formatting
                            first = currentline.Substring(0, eos + 1);
                            second = currentline.Substring(eos + 1, (currentline.Length - (eos + 1)));
                            first = first.Trim(' ');
                            second = second.Trim(' ');
                            first = first.Trim(';');
                            second = second.Trim(';');

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
                            //first & second are times, days1 & days2 are days letters

                            if (first.Contains(second) && days1.Contains(days2))
                            {
                                currentline = days1 + " " + first;
                            } else { //if they dont match  //todo
                                difflines = true; 
                            }

                            //sync with main variables
                            days = days1;
                            times = first;

                        } else  
                        {
                            //determine when day letters end
                            eos = currentline.IndexOfAny(nums);  //returns index of first number 

                            days = currentline.Substring(0, eos);
                            times = currentline.Remove(0, eos);

                            days = days.TrimStart(' ');  //leave trailing spaces for T uesdays
                            times = times.Trim(' ');
                        }

                        if (days.Contains("M"))
                        {
                            xt++;
                        }
                        if (days.Contains("W"))
                        {
                            xt++;
                        }
                        if (days.Contains("F"))
                        {
                            xt++;
                        }
                        if (days.Contains("TH"))
                        {
                            xt++;
                            //re-writing TH into just H
                            int thurs = days.IndexOf('H');
                            days = days.Remove(thurs - 1, 1);
                        }
                        if (days.Contains("T "))  //T<SPACE> so TH (thursday) doesn't get grabbed here 
                        {
                            xt++;
                        }

                        if (xt == 2) {
                            twoday = true;
                        }

                        Console.WriteLine(days + "_" + times); //wr

                        //Determining how many blocks of time course meets for
                        eos = times.IndexOf("-");

                        string starttime = times.Substring(0, eos);
                        string endtime = times.Remove(0, eos + 1);

                        starttime = starttime.Trim(' ');
                        endtime = endtime.Trim(' ');

                        DateTime startDT = DateTime.Parse(starttime);
                        DateTime endDT = DateTime.Parse(endtime);

                        int marker = 0;
                        marker = starttime.IndexOf((":"));
                        if (marker == 2) {
                            starttime = starttime.Substring(marker - 2, 5);
                        } else {
                            starttime = ('0' + starttime.Substring(marker - 1, 4));
                        }

                        Console.WriteLine($"startime: _{starttime}_ and end: _{endtime}");  //wr
                        Console.WriteLine($"startDT: _{startDT}_ and endDT: _{endDT}");

                        TimeSpan span = endDT.Subtract(startDT);

                        ////IF timeblock is longer than 1hr15min, class is double block
                        if(span.TotalMinutes > 76)
                        {
                            xt++;
                            doubleblock = true;

                            marker = starttime.IndexOf(":");
                            if (marker == 1){
                                starttime = ('0' +  starttime.Substring(marker-1, 4));  //"02:00" PM 
                            } else
                            {
                                starttime = starttime.Substring(marker - 2, 5);  //"11:00" AM  
                            }
                            starttime = starttime.Trim(' ');


                            //*Save starttime 1 to Catalog here
                            if (!twoday) //1 day dbl block 
                            {
                                c[l, 6] = (days.Substring(0, 1) + "-" + starttime);
                            }

                            //starttime now holds second block:
                            startDT = startDT.AddMinutes(90.0);
                            starttime = startDT.ToString(); 

                            //saving just the time
                            marker = starttime.IndexOf(":");
                            marker -= 2;
                            starttime = starttime.Substring(marker, 5);
                            starttime = starttime.Trim(' ');

                            //add leading 0 if 1 digit hour
                            marker = starttime.IndexOf(":");
                            if (marker == 1)
                                starttime = ('0' + starttime);


                            //* Saving time block 2 to Catalog here 
                            if (!twoday) //1 day dbl block
                            {
                                c[l, 7] = (days.Substring(0, 1) + "-" + starttime);
                                c[l,8]=".";
                                c[l,9]=".";
                            }


                            Console.WriteLine("starttime of second block: _" + starttime);  //wr
                        }
                        c[l, 5] = xt.ToString();  //* saves XT(number of timeblocks) in catalog 


                        //*Saving to Catalog 
                        if(twoday && !doubleblock)  //xt=2
                        {
                            c[l, 6] = (days.Substring(0, 1) + "-" + starttime);
                            c[l, 7] = (days.Substring(2, 1) + "-" + starttime);
                            c[l,8] = ".";
                            c[l,9] = ".";
                        }
                        else if( xt == 1 && !doubleblock) //1 day 1 block
                        {
                            c[l,6] = (days.Substring(0,1) + "-" + starttime);
                            c[l, 7] = ".";
                            c[l, 8] = ".";
                            c[l, 9] = ".";
                        } //Future implementation:
                        else if (xt ==3 && doubleblock && twoday) //2 days, 1 block 1 doubleblock
                        {

                        } else if(twoday && difflines){ //2 days, 1 block at different times
                            //see semicolon elseif above
                        }
                    
                     }//if not blank or tbd
                }
                
            } //end of l(ine) loop


            //Print at end //wr
            for (int li = 0; li < (c.GetUpperBound(0)+1); li++)
            {
                for (int m = 0; m < (c.GetUpperBound(1) +1); m++)
                {
                    Console.Write(c[li, m] + "_");
                }
                Console.WriteLine("");
            }


        }



    }
}
