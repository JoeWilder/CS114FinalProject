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
    public partial class subject : Form
    {

        WebbrowserForm webForm = new WebbrowserForm();

        public subject()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (comboBox1.Text == "")
            {
                MessageBox.Show("Please select a subject");
                return;
            }

            webForm.setCourseSearchName(comboBox1.Text);
            webForm.Show();

            if (webForm.getPageNumber() == 7)
            {
                webForm.findMajorGivenString(webForm.getCourseSearchName());
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void subject_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
