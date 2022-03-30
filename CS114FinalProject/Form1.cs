using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS114FinalProject
{
    public partial class Form1 : Form
    {
        string courseData; // Raw data about a course
        List<SNHUcourse> courseList = new List<SNHUcourse>(); // List of SNHU courses
        int pageNumber = 0; // What page of the SNHU website we are on


        public Form1()
        {
            InitializeComponent();
        }


        /* Listen for form load event */
        private void Form1_Load(object sender, EventArgs e)
        {
            Logic.setSearch("GAD-300", "GAD-330", "GAD-400", "CS-217");
            Logic.initRelevantTable();
            Logic.courseCompare();
            Logic.PrintCompatTable();

            mySNHULogin();
            webBrowser1.Show();
        }


        /* Listen for page load event and check if we are on the correct page */
        private void webBrowser1_DocumentCompleted_1(object sender, WebBrowserDocumentCompletedEventArgs e)
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
            await Task.Delay(5000);
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
                    if (courseData == null) continue;
                    SNHUcourse course = new SNHUcourse(courseData);
                    courseList.Add(course);
                }

                courseData = "";
                Console.WriteLine("\n\n\n");
            }
            webBrowser1.Dispose();
        }
    }
}
