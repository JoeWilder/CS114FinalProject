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
            int ycoord = 80;
            int count = 1;
            foreach (Schedule sched in LogicPR.possibleSchedules)
            {

                Label lbl = new Label();
                lbl.Text = ("Option " + count + '\n' + sched.getNamesinOrder_string() + '\n'
                    + sched.getWhen_FullSched_string() + ".");

                lbl.Location = new Point(30, ycoord);
                ycoord += 60;
                lbl.AutoSize = true;
                lbl.Font = new Font("Arial", 9, FontStyle.Bold);
                lbl.ForeColor = Color.DarkSlateBlue;
                lbl.Padding = new Padding(1);
                if (count % 2 == 0)
                {
                    lbl.BackColor = Color.WhiteSmoke;
                }
                else
                {
                    lbl.BackColor = Color.LightGray;
                }

                //Add new control ^ to Form
                this.Controls.Add(lbl);
                count++;
            }


            
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
            //
            
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
