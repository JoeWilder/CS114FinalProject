﻿
namespace CS114FinalProject
{
    partial class Form1
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
            this.classDataButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // classDataButton
            // 
            this.classDataButton.Location = new System.Drawing.Point(38, 429);
            this.classDataButton.Name = "classDataButton";
            this.classDataButton.Size = new System.Drawing.Size(188, 76);
            this.classDataButton.TabIndex = 0;
            this.classDataButton.Text = "Get Computer Science Class Data";
            this.classDataButton.UseVisualStyleBackColor = true;
            this.classDataButton.Click += new System.EventHandler(this.classDataButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.classDataButton);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button classDataButton;
    }
}

