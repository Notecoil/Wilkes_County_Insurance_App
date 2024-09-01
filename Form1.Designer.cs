namespace Wilkes_County_Insurance_App
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            welcomeLabel = new Label();
            receiptsTodayLabel = new Label();
            SuspendLayout();
            // 
            // welcomeLabel
            // 
            welcomeLabel.AutoSize = true;
            welcomeLabel.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            welcomeLabel.Location = new Point(12, 9);
            welcomeLabel.Name = "welcomeLabel";
            welcomeLabel.Size = new Size(125, 32);
            welcomeLabel.TabIndex = 0;
            welcomeLabel.Text = "Welcome, ";
            // 
            // receiptsTodayLabel
            // 
            receiptsTodayLabel.AutoSize = true;
            receiptsTodayLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            receiptsTodayLabel.Location = new Point(12, 130);
            receiptsTodayLabel.Name = "receiptsTodayLabel";
            receiptsTodayLabel.Size = new Size(142, 25);
            receiptsTodayLabel.TabIndex = 1;
            receiptsTodayLabel.Text = "Receipts today: ";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1076, 628);
            Controls.Add(receiptsTodayLabel);
            Controls.Add(welcomeLabel);
            Name = "Form1";
            Text = "Wilkes County Insurance";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label welcomeLabel;
        private Label receiptsTodayLabel;
    }
}
