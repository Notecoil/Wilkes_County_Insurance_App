﻿namespace Wilkes_County_Insurance_App
{
    partial class ParentForm
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
            components = new System.ComponentModel.Container();
            panel1 = new Panel();
            optionsButton = new Button();
            homeButton = new Button();
            printReceiptButton = new Button();
            cashDrawerButton = new Button();
            pictureBox1 = new PictureBox();
            reportsButton = new Button();
            toolTip1 = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.AutoSize = true;
            panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel1.Location = new Point(223, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(0, 0);
            panel1.TabIndex = 0;
            // 
            // optionsButton
            // 
            optionsButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            optionsButton.Image = Properties.Resources.Options_icon;
            optionsButton.Location = new Point(12, 631);
            optionsButton.Name = "optionsButton";
            optionsButton.Size = new Size(62, 48);
            optionsButton.TabIndex = 4;
            toolTip1.SetToolTip(optionsButton, "Program settings");
            optionsButton.UseVisualStyleBackColor = true;
            optionsButton.Click += optionsButton_Click;
            // 
            // homeButton
            // 
            homeButton.Image = Properties.Resources.Home_icon;
            homeButton.Location = new Point(12, 189);
            homeButton.Name = "homeButton";
            homeButton.Size = new Size(62, 48);
            homeButton.TabIndex = 0;
            toolTip1.SetToolTip(homeButton, "Home menu");
            homeButton.UseVisualStyleBackColor = true;
            homeButton.Click += homeButton_Click;
            // 
            // printReceiptButton
            // 
            printReceiptButton.Location = new Point(12, 243);
            printReceiptButton.Name = "printReceiptButton";
            printReceiptButton.Size = new Size(62, 48);
            printReceiptButton.TabIndex = 1;
            printReceiptButton.Text = "Print Receipt";
            toolTip1.SetToolTip(printReceiptButton, "Enter information to print receipts.");
            printReceiptButton.UseVisualStyleBackColor = true;
            printReceiptButton.Click += printReceiptButton_Click;
            // 
            // cashDrawerButton
            // 
            cashDrawerButton.Enabled = false;
            cashDrawerButton.Location = new Point(12, 351);
            cashDrawerButton.Name = "cashDrawerButton";
            cashDrawerButton.Size = new Size(62, 48);
            cashDrawerButton.TabIndex = 2;
            cashDrawerButton.Text = "UNUSED";
            cashDrawerButton.UseVisualStyleBackColor = true;
            cashDrawerButton.Click += cashDrawerButton_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logo_resized;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(205, 171);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // reportsButton
            // 
            reportsButton.Location = new Point(12, 297);
            reportsButton.Name = "reportsButton";
            reportsButton.Size = new Size(62, 48);
            reportsButton.TabIndex = 3;
            reportsButton.Text = "Reports";
            toolTip1.SetToolTip(reportsButton, "Page to printout receipt reports.");
            reportsButton.UseVisualStyleBackColor = true;
            reportsButton.Click += reportsButton_Click;
            // 
            // ParentForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1184, 691);
            Controls.Add(reportsButton);
            Controls.Add(pictureBox1);
            Controls.Add(cashDrawerButton);
            Controls.Add(printReceiptButton);
            Controls.Add(homeButton);
            Controls.Add(optionsButton);
            Controls.Add(panel1);
            MinimumSize = new Size(700, 560);
            Name = "ParentForm";
            Text = "Wilkes County Insurance Agency";
            Load += ParentForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button optionsButton;
        private Button homeButton;
        private Button printReceiptButton;
        private Button cashDrawerButton;
        private PictureBox pictureBox1;
        private Button reportsButton;
        private ToolTip toolTip1;
    }
}