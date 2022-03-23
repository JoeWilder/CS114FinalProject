using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS114FinalProject
{
    public partial class Form1 : Form
    {


        int pageNumber = 0;

        public Form1()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            Logic.setSearch( "GAD-300", "GAD-330", "GAD-400", "CS-217");
            Logic.initRelevantTable();
            Logic.courseCompare();
            Logic.PrintCompatTable();


            webBrowser1.Navigate("https://my.snhu.edu/");
            while (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
            page1();


            
            webBrowser1.Show();
        }

        private void webBrowser1_DocumentCompleted_1(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            Console.WriteLine("LOADED");
            pageNumber++;

            if (pageNumber == 5)
            {
                Thread.Sleep(1000);
                page2();
            }

            else if (pageNumber == 7)
            {
                Thread.Sleep(5000);
                page3();
            }

        }



        private void page1()
        {
            webBrowser1.Navigate("https://my.snhu.edu/");
            while (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }

            // Account credentials go down here

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

        private void page2()
        {
            webBrowser1.Navigate("https://my.snhu.edu/coursecatalog/Lists/Sections/SectionsBySubject.aspx?View={215C6024-AB45-46EF-B9CC-ADF871654DC5}&FilterField1=SectionLocation&FilterValue1=Manchester%20New%20Hampshire");
        }

        private void page3()
        {
            Thread.Sleep(1000);

            
            // Stuck here

            Console.WriteLine(webBrowser1.DocumentText);
            webBrowser1.Show(); 

        }


    }
}
