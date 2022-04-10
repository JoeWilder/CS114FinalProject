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

            Label lbl = new Label();

            lbl.Text = "Hello World!";
            lbl.Location = new Point(20, 20);
            lbl.AutoSize = true;
            lbl.Font = new Font("Arial", 12);
             lbl.ForeColor = Color.Green;
            lbl.Padding = new Padding(6);

            //Add new control ^ to Form
            this.Controls.Add(lbl);
            
        }

        private void lbl_title_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

            
        }

        private void groupBox_selectA_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {
            int ycoord = 40;
            foreach (Schedule sched in LogicPR.possibleSchedules)
            {
                Label lbl = new Label();

                lbl.Text = (sched.thecourses[2]);

                lbl.Location = new Point(127, ycoord);
                ycoord += 50;
                lbl.AutoSize = true;
                lbl.Font = new Font("Arial", 12);
                lbl.ForeColor = Color.DarkSlateBlue;
                lbl.Padding = new Padding(4);

                //Add new control ^ to Form
                this.Controls.Add(lbl);
            }
        }
    }
}
