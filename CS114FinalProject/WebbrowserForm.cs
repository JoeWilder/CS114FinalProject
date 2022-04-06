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
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CS114FinalProject
{
    public partial class WebbrowserForm : Form
    {

        string courseData; // Raw data about a course
        List<SNHUcourse> courseList = new List<SNHUcourse>(); // List of SNHU courses
        int pageNumber = 0; // What page of the SNHU website we are on

        public WebbrowserForm()
        {
            InitializeComponent();
        }


        private void WebbrowserForm_Load(object sender, EventArgs e)
        {
            mySNHULogin();
            webBrowser1.Show();
        }


        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            pageNumber++;
            if (pageNumber == 5)
            {
                navigateToCourses();
            }

            else if (pageNumber == 7)
            {
                navigateToCompSciMajor();
            }
        }

        /* Navigate to mysnhu website and attempt to login using the given credentials */
        private void mySNHULogin()
        {
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


        /* Show all computer science classes */
        private void navigateToCompSciMajor()
        {
            webBrowser1.Document.GetElementById("img_1-15_").InvokeMember("click");
            waitForCoursesToLoad();
        }


        /* Wait until classes are loaded, then save the data */
        private async void waitForCoursesToLoad()
        {
            await Task.Delay(3000);
            foreach (HtmlElement tag in webBrowser1.Document.GetElementById("tbod1-15__").Children)
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
                Console.WriteLine("\n\n\n");
            }
            webBrowser1.Dispose();
            Close();
            saveDataToFile();
        }


        /* Overwrite data to coursedata.txt */
        public void saveDataToFile()
        {
            Console.WriteLine("Saving data to text file");
            List<string> linesOfData = new List<string>(); // List of all lines
            String filePath = AppDomain.CurrentDomain.BaseDirectory + "coursedata.txt"; // Path of txt file

            foreach (SNHUcourse course in courseList) {
                linesOfData.Add(course.getFormattedCourseData());
            }

            File.WriteAllLines(filePath, linesOfData);
        }

    }
}
