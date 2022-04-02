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
            Logic.setSearch("GAD-300", "GAD-330", "GAD-400", "CS-217");
            Logic.initRelevantTable();
            Logic.courseCompare();
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
