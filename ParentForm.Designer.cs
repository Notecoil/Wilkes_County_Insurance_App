namespace Wilkes_County_Insurance_App
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
            panel1 = new Panel();
            optionsButton = new Button();
            homeButton = new Button();
            printReceiptButton = new Button();
            cashDrawerButton = new Button();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.AutoSize = true;
            panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(0, 0);
            panel1.TabIndex = 0;
            // 
            // optionsButton
            // 
            optionsButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            optionsButton.Image = Properties.Resources.Options_icon;
            optionsButton.Location = new Point(1110, 66);
            optionsButton.Name = "optionsButton";
            optionsButton.Size = new Size(62, 48);
            optionsButton.TabIndex = 1;
            optionsButton.UseVisualStyleBackColor = true;
            optionsButton.Click += optionsButton_Click;
            // 
            // homeButton
            // 
            homeButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            homeButton.Image = Properties.Resources.Home_icon;
            homeButton.Location = new Point(1110, 12);
            homeButton.Name = "homeButton";
            homeButton.Size = new Size(62, 48);
            homeButton.TabIndex = 2;
            homeButton.UseVisualStyleBackColor = true;
            homeButton.Click += homeButton_Click;
            // 
            // printReceiptButton
            // 
            printReceiptButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            printReceiptButton.Location = new Point(1110, 120);
            printReceiptButton.Name = "printReceiptButton";
            printReceiptButton.Size = new Size(62, 48);
            printReceiptButton.TabIndex = 3;
            printReceiptButton.Text = "Print Receipt";
            printReceiptButton.UseVisualStyleBackColor = true;
            printReceiptButton.Click += printReceiptButton_Click;
            // 
            // cashDrawerButton
            // 
            cashDrawerButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cashDrawerButton.Location = new Point(1110, 174);
            cashDrawerButton.Name = "cashDrawerButton";
            cashDrawerButton.Size = new Size(62, 48);
            cashDrawerButton.TabIndex = 4;
            cashDrawerButton.Text = "Cash Drawer";
            cashDrawerButton.UseVisualStyleBackColor = true;
            cashDrawerButton.Click += cashDrawerButton_Click;
            // 
            // ParentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 691);
            Controls.Add(cashDrawerButton);
            Controls.Add(printReceiptButton);
            Controls.Add(homeButton);
            Controls.Add(optionsButton);
            Controls.Add(panel1);
            MinimumSize = new Size(640, 500);
            Name = "ParentForm";
            Text = "Wilkes County Insurance Agency";
            Load += ParentForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button optionsButton;
        private Button homeButton;
        private Button printReceiptButton;
        private Button cashDrawerButton;
    }
}