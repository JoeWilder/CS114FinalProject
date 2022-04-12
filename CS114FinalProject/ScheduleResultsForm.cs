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
    public partial class ScheduleResultsForm : Form
    {
        public ScheduleResultsForm()
        {
            InitializeComponent();
        }


        private void ScheduleResultsForm_Load(object sender, EventArgs e)
        {

            
            
            
            //JK testing
            /*
            Label lbl = new Label();

            lbl.Text = "Hello World!";
            lbl.Location = new Point(20, 20);
            lbl.AutoSize = true;
            lbl.Font = new Font("Arial", 12);
             lbl.ForeColor = Color.Green;
            lbl.Padding = new Padding(6);

            //Add new control ^ to Form
            this.Controls.Add(lbl);
            */
        }

        private void lbl_title_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            RadioButton rad = new RadioButton();
            rad.Location = new Point(30, 40);
            rad.Text = "Option";
            this.Controls.Add(rad);

        }

        private void groupBox_selectA_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

            //JK testing
            int ycoord = 80;
            int count = 1;
            foreach (Schedule sched in LogicPR.possibleSchedules)
            {
                //string when = 


                Label lbl = new Label();
                lbl.Text = ("Option "+ count + '\n'+sched.stringcourses);

                lbl.Location = new Point(30, ycoord);
                ycoord += 60;
                lbl.AutoSize = true;
                lbl.Font = new Font("Arial", 10, FontStyle.Bold);
                lbl.ForeColor = Color.DarkSlateBlue;
                lbl.Padding = new Padding(1);

                //Add new control ^ to Form
                this.Controls.Add(lbl);
                count++;
            }
        }

        private void btn_devdata_Click(object sender, EventArgs e)
        {
            //future implementation
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            ////
        }
    }
}
