
namespace CS114FinalProject
{
    partial class subject
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.comboBox1.BackColor = System.Drawing.Color.White;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Accounting",
            "AerospaceStudies",
            "AirTrafficManagement",
            "AmericanSignLanguage",
            "Anthropology",
            "Arabic",
            "Aviation",
            "Aviation Management",
            "Biology",
            "Business",
            "Chemistry",
            "Communication",
            "Computer Information Systems",
            "Computer Science",
            "Construction Management",
            "Construction Science Management",
            "Culinary",
            "Development",
            "Early Chilhood Education",
            "Economics",
            "Education",
            "Educational Entrepreneurship",
            "Educationd Field Based Ed",
            "Electrical Engineering",
            "Engineering",
            "English",
            "English Asa Second Language",
            "Environmental Studies",
            "Fashion Merchandising Manegment",
            "Finance",
            "Fine Arts",
            "First Year Seminar",
            "French",
            "Game Art",
            "Game Design",
            "Game Design and Development",
            "Gender Studies",
            "Geography",
            "Grad Business Administration",
            "Graphics",
            "History",
            "Honors",
            "Hospitality Administration",
            "Humanities",
            "InformationTechnology",
            "International Business",
            "Justice Studies",
            "Literature",
            "Mandarin Language Culture",
            "Marketing",
            "Mathematics",
            "Military NHCUC",
            "Music",
            "Music Education",
            "Organizational Leadership",
            "Personal and Professional Comm",
            "Philosophy",
            "Physics",
            "Pilot",
            "Political Science",
            "Psychology",
            "Quantitative Studies",
            "SchoolBusiness",
            "Science",
            "SocialScience",
            "Sociology",
            "Spanish",
            "Special Education",
            "Sport Management",
            "Sustainability Studies",
            "Taxation",
            "UAS Unmanned Aerial Systems",
            "Wellness"});
            this.comboBox1.Location = new System.Drawing.Point(303, 172);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(181, 24);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(247, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(294, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select your desired subject";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button1.Font = new System.Drawing.Font("Lucida Sans Unicode", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Navy;
            this.button1.Location = new System.Drawing.Point(345, 264);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 32);
            this.button1.TabIndex = 2;
            this.button1.Text = "Confirm";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // subject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Name = "subject";
            this.Text = "subject";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}