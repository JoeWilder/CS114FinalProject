using System;
using System.Collections.Generic;
using System.Threading;
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


        /* Listen for form load event */
        private void Form1_Load(object sender, EventArgs e)
        {
            Logic.formatData();  //run only after refreshing database/file/webscrape

            Logic.setSearch("CS-331", "CS-361", "CS-114","CS-114L", "CS-217");
            Logic.initRelevantTable();  //creates table link with only the searched-for courses
            Logic.courseCompare();  //creates compatibility table comparing all sections of the searched-for courses
            Logic.PrintCompatTable();
                
        }


        /* Start new web browser window */
        private void classDataButton_Click(object sender, EventArgs e)
        {
            WebbrowserForm webForm = new WebbrowserForm();
            webForm.ShowDialog();
        }
    }
}
