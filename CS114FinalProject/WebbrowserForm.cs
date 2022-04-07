/*******************************************
Program: WebbrowserForm.cs
Purpose: Winform for scraping SNHU course data from the web
Author: Joseph Wilder
Date: April 4, 2022
********************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace CS114FinalProject
{
    public partial class WebbrowserForm : Form
    {
        private string courseSearchName = "";
        private string courseData; // Raw data about a course
        private List<SNHUcourse> courseList = new List<SNHUcourse>(); // List of SNHU courses
        private int pageNumber = 0;
        private List<string> listOfMajors = new List<string>();


        /* Create the form */
        public WebbrowserForm()
        {
            InitializeComponent();
        }


        /* Start navigating to the course offerings page on SNHU website */
        private void WebbrowserForm_Load(object sender, EventArgs e)
        {
            mySNHULogin();
            webBrowser1.Show();
        }


        /* Keep checking where we are on the SNHU website */
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            pageNumber++;
            if (pageNumber == 5)
            {
                navigateToCourses();
            }

            else if (pageNumber == 7)
            {
                findMajorGivenString(courseSearchName);
            }
        }


        /* Navigate to mysnhu website and attempt to login using the given credentials */
        private void mySNHULogin()
        {
            webBrowser1.Show();
            webBrowser1.Navigate("https://my.snhu.edu/");
            while (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }

            webBrowser1.Document.GetElementById("input_1").InnerText = Environment.GetEnvironmentVariable("SNHU_EMAIL"); // Set this equal to your email (string)
            webBrowser1.Document.GetElementById("input_2").InnerText = Environment.GetEnvironmentVariable("SNHU_PASS"); // Set this equal to your password (string)
            webBrowser1.Document.GetElementById("SubmitCreds").InvokeMember("click");

            foreach (HtmlElement tag in webBrowser1.Document.GetElementsByTagName("a"))
            {
                if (tag.GetAttribute("span") == "Campus Students")
                {
                    tag.InvokeMember("click");
                }
            }
        }


        /* After logging in to mysnhu, navigate to course offerings */
        private void navigateToCourses()
        {
            webBrowser1.Navigate("https://my.snhu.edu/coursecatalog/Lists/Sections/SectionsBySubject.aspx?View={215C6024-AB45-46EF-B9CC-ADF871654DC5}&FilterField1=SectionLocation&FilterValue1=Manchester%20New%20Hampshire");
        }


        /* Validate the input of a major */
        public void findMajorGivenString(String majorNameInput)
        {
            foreach (HtmlElement tag in webBrowser1.Document.GetElementsByTagName("tbody"))
            {
                if (tag == null) continue;
                if (tag.Id == null) continue;
                if (tag.Id.StartsWith("titl"))
                {
                    string id = "";
                    foreach (char c in tag.Id)
                    {
                        if (Char.IsDigit(c))
                        {
                            id = id + c;
                        }
                    }
                    id = id.Insert(1, "-");
                    id = id + "__";
                    id = id.Insert(0, "tbod");
                    string majorString = Regex.Replace(tag.GetAttribute("groupstring"), @"[\d%-]", string.Empty);
                    majorString = majorString.TrimStart('b');
                    majorString = majorString.TrimEnd('b');

                    if (majorNameInput.Replace(" ", string.Empty).ToLower().Equals(majorString.ToLower()))
                    {
                        foreach (HtmlElement childTag in tag.Children)
                        {
                            childTag.GetElementsByTagName("img")[1].InvokeMember("click");
                            waitForCoursesToLoad(id);
                            return;
                        }
                    }
                }
            }
            MessageBox.Show("Could not find the given major: " + courseSearchName);
            Hide();
        }


        /* Wait until classes are loaded, then save the data */
        private async void waitForCoursesToLoad(string paramTag)
        {
            await Task.Delay(3000);
            foreach (HtmlElement tag in webBrowser1.Document.GetElementById(paramTag).Children)
            {
                if (tag.CanHaveChildren)
                {
                    foreach (HtmlElement childtag in tag.Children)
                    {
                        if (childtag.InnerText == null)
                        {
                            continue;
                        }
                        courseData += childtag.InnerText;
                        courseData += "\n";
                    }
                    if (String.IsNullOrEmpty(courseData)) continue;
                    SNHUcourse course = new SNHUcourse(courseData);
                    courseList.Add(course);
                }

                courseData = "";
            }
            Hide();
            saveCourseDataToFile();
        }


        /* Overwrite data to coursedata.txt */
        public void saveCourseDataToFile()
        {
            List<string> linesOfData = new List<string>(); // List of all lines
            String filePath = AppDomain.CurrentDomain.BaseDirectory + "coursedata.txt"; // Path of txt file

            foreach (SNHUcourse course in courseList)
            {
                if (!course.isCurrentlyOffered()) continue;
                linesOfData.Add(course.getFormattedCourseData());
            }
            File.WriteAllLines(filePath, linesOfData);
        }



        /* Overwrite data to SNHUmajors.txt */
        public void saveMajorDataToFile()
        {
            List<string> linesOfData = new List<string>(); // List of all lines
            String filePath = AppDomain.CurrentDomain.BaseDirectory + "SNHUmajors.txt"; // Path of txt file

            foreach (string major in listOfMajors)
            {
                linesOfData.Add(major);
            }
            File.WriteAllLines(filePath, linesOfData);
        }


        /* Get all majors and put them in a list */
        public void populateListOfMajors()
        {
            foreach (HtmlElement tag in webBrowser1.Document.GetElementsByTagName("tbody"))
            {
                if (tag == null) continue;
                if (tag.Id == null) continue;
                if (tag.Id.StartsWith("titl"))
                {
                    string id = "";
                    foreach (char c in tag.Id)
                    {
                        if (Char.IsDigit(c))
                        {
                            id = id + c;
                        }
                    }
                    id = id.Insert(1, "-");
                    id = id + "__";
                    id = id.Insert(0, "tbod");
                    string majorString = Regex.Replace(tag.GetAttribute("groupstring"), @"[\d%-]", string.Empty);
                    majorString = majorString.TrimStart('b');
                    majorString = majorString.TrimEnd('b');
                    listOfMajors.Add(majorString);
                }
            }
        }


        /* Print all majors */
        public void printAllMajors()
        {
            foreach (string major in listOfMajors)
            {
                Console.WriteLine(major);
            }
        }


        public void setCourseSearchName(string courseName)
        {
            courseSearchName = courseName;
        }


        public string getCourseSearchName()
        {
            return courseSearchName;
        }


        public int getPageNumber()
        {
            return pageNumber;
        }

    }
}
