﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS114FinalProject
{
    class SNHUcourse
    {
        private string courseData; // Raw data about this course
        string[] splitData; // Raw split data about this course
        private string courseName;
        private string courseNum;
        private string courseSemester;
        private string courseProfessor;
        private string courseLocation;
        private string courseDate;
        private string courseMajor;


        public SNHUcourse(string courseData)
        {
            this.courseData = courseData;
            splitCourseData();
            parseCourseData();
            printCourseInformation();
        }


        /* Split raw data into something more readable */
        public void splitCourseData()
        {
            //Console.WriteLine(courseData);
            splitData = courseData.Split('\n');

        }


        /* Read the split data and store it with the correct variable */
        public void parseCourseData()
        {
            //Console.WriteLine(splitData.Length);
            if (splitData.Length < 10)
            {
                return;
            }

            if (splitData.Length == 11)
            {

                courseName = splitData[0];
                courseNum = splitData[2];
                courseSemester = splitData[3];
                courseProfessor = splitData[4];
                courseLocation = splitData[5];
                courseDate = "Date TBD";
                courseMajor = splitData[8];
            }

            else if (splitData.Length == 12)
            {
                courseName = splitData[0];
                courseNum = splitData[2];
                courseSemester = splitData[3];
                courseProfessor = "Professor TBD";
                courseLocation = splitData[4];
                courseDate = splitData[6];
                courseMajor = splitData[9];
            }
            else if (splitData.Length == 13)
            {
                courseName = splitData[0];
                courseNum = splitData[2];
                courseSemester = splitData[3];
                courseProfessor = splitData[4];
                courseLocation = splitData[5];
                courseDate = splitData[7];
                courseMajor = splitData[10];
            }
            else if (splitData.Length == 14)
            {
                courseName = splitData[0];
                courseNum = splitData[2];
                courseSemester = splitData[3];
                courseProfessor = splitData[4];
                courseLocation = splitData[5];
                courseDate = splitData[7];
                courseMajor = splitData[11];
            }
        }


        /* Print all course information */
        public void printCourseInformation()
        {
            Console.WriteLine(courseName);
            Console.WriteLine(courseNum);
            Console.WriteLine(courseSemester);
            Console.WriteLine(courseProfessor);
            Console.WriteLine(courseLocation);
            Console.WriteLine(courseDate);
            Console.WriteLine(courseMajor);
        }


        public string getCourseName()
        {
            return courseName;
        }


        public string getCourseNumber()
        {
            return courseNum;
        }


        public string getCourseSemester()
        {
            return courseSemester;
        }


        public string getCourseProfessor()
        {
            return courseProfessor;
        }


        public string getCourseLocation()
        {
            return courseLocation;
        }


        public string getCourseDate()
        {
            return courseDate;
        }


        public string getCourseMajor()
        {
            return courseMajor;
        }
    }
}