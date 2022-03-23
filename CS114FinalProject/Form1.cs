using System;
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
            //jade commented out temporarily
            /*  webBrowser1.Navigate("https://my.snhu.edu/");
            while (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }

            webBrowser1.Document.GetElementById("input_1").InnerText = "email";
            webBrowser1.Document.GetElementById("input_2").InnerText = "password";

            System.Threading.Thread.Sleep(1000);

            webBrowser1.Document.GetElementById("SubmitCreds").InvokeMember("click");

            while (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }


            foreach (HtmlElement tag in webBrowser1.Document.GetElementsByTagName("a")) {
                if (tag.GetAttribute("span") == "Campus Students")
                {
                    tag.InvokeMember("click");
                }
            }

            


            Console.WriteLine(webBrowser1.DocumentText);
            webBrowser1.Show(); */
        }
    }
}
