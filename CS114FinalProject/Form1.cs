using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

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
          
       }

        //JW start
        /* Start new web browser window */
        private void classDataButton_Click(object sender, EventArgs e)
        {
           // WebbrowserForm webForm = new WebbrowserForm();
            //webForm.ShowDialog();

        }
        //JW end
        //PR start
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
            

        }

        private void refreshCourseDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            subject settingsForm = new subject(); //create pop up
            settingsForm.Show();
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
        //PR end
        //JK start
        private void btn_schedule_Click(object sender, EventArgs e)
        {
            string[] raw = textBox1.Text.Split('\r', '\n');
            List<string> rawsearches = new List<string>(raw);
            if(rawsearches!= null && rawsearches[0] != "")
            {

                for (int h = 0; h < rawsearches.Count; h++)
                {
                    if (rawsearches[h] == "" || rawsearches[h] == " " || rawsearches[h] == "  ")
                    {
                        rawsearches.RemoveAt(h);
                    }
                }
                //will catch and delete blank last lines of null, 1, or 2 spaces
                if (rawsearches[(rawsearches.Count - 1)] == " " || rawsearches[(rawsearches.Count - 1)] == "" || rawsearches[(rawsearches.Count - 1)] == "  ")
                {
                    rawsearches.RemoveAt(rawsearches.Count - 1);
                }

                for (int b = 0; b < rawsearches.Count; b++)
                {
                    rawsearches[b] = rawsearches[b].Trim(' ');
                }

                Logic.setSearch(rawsearches);

                Logic.formatData();
                Logic.initRelevantTable();
                Logic.courseCompare();
                Logic.PrintCompatTable();

                LogicPR.FindSchedules();
                LogicPR.findDuplicateSchedules();

                foreach (Schedule sch in LogicPR.possibleSchedules)
                {
                    MessageBox.Show(sch.stringcourses);
                }

                ScheduleResultsForm resultsForm = new ScheduleResultsForm();
                resultsForm.Show();
            }else
            {
                MessageBox.Show("ERROR: Please enter courses");
            }
        }

        private void clearLocalDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //button resets coursedata.txt for if it gets too full
            string file = AppDomain.CurrentDomain.BaseDirectory + "coursedata.txt";
            File.Delete(file);
            File.Create(file);
        }
        //JK end
    }
}
