namespace Wilkes_County_Insurance_App
{
    partial class DateRangeReport
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
            startDatePicker = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            endDatePicker = new DateTimePicker();
            printReportButton = new Button();
            backButton = new Button();
            SuspendLayout();
            // 
            // startDatePicker
            // 
            startDatePicker.Location = new Point(215, 52);
            startDatePicker.Name = "startDatePicker";
            startDatePicker.Size = new Size(200, 23);
            startDatePicker.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(65, 50);
            label1.Name = "label1";
            label1.Size = new Size(94, 25);
            label1.TabIndex = 1;
            label1.Text = "Start Date";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(71, 100);
            label2.Name = "label2";
            label2.Size = new Size(88, 25);
            label2.TabIndex = 2;
            label2.Text = "End Date";
            // 
            // endDatePicker
            // 
            endDatePicker.Location = new Point(215, 102);
            endDatePicker.Name = "endDatePicker";
            endDatePicker.Size = new Size(200, 23);
            endDatePicker.TabIndex = 3;
            // 
            // printReportButton
            // 
            printReportButton.Location = new Point(340, 152);
            printReportButton.Name = "printReportButton";
            printReportButton.Size = new Size(75, 38);
            printReportButton.TabIndex = 4;
            printReportButton.Text = "Print Report";
            printReportButton.UseVisualStyleBackColor = true;
            printReportButton.Click += button1_Click;
            // 
            // backButton
            // 
            backButton.Location = new Point(12, 12);
            backButton.Name = "backButton";
            backButton.Size = new Size(75, 23);
            backButton.TabIndex = 8;
            backButton.Text = "Back";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // DateRangeReport
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(backButton);
            Controls.Add(printReportButton);
            Controls.Add(endDatePicker);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(startDatePicker);
            Name = "DateRangeReport";
            Text = "DateRangeReport";
            Load += DateRangeReport_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker startDatePicker;
        private Label label1;
        private Label label2;
        private DateTimePicker endDatePicker;
        private Button printReportButton;
        private Button backButton;
    }
}