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


            Logic.setSearch("CS-203", "CS-219", "CS-114","CS-114L", "CS-217");
            Logic.initRelevantTable();  //creates linker table with only the searched-for courses
            Logic.courseCompare();  //creates compatibility table comparing all sections of the searched-for courses
            Logic.PrintCompatTable();
                
       }


        /* Start new web browser window */
       private void classDataButton_Click(object sender, EventArgs e)
        {
           // WebbrowserForm webForm = new WebbrowserForm();
            //webForm.ShowDialog();


            Logic.formatData();  //run only after refreshing database/file/webscrape

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void creditsToolStripMenuItem_Click(object sender, EventArgs e) //PR
        {
           
            creators settingsForm = new creators(); //create pop up
            settingsForm.Show();

           
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            subject settingsForm = new subject(); //create pop up
            settingsForm.Show();
        }

        private void refreshCourseDataToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        
        private void btn_schedule_Click(object sender, EventArgs e)
        {

            Logic.setSearch(textBox1.Text);
        }
    }
}
