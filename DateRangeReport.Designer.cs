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
            companyNameLabel = new Label();
            companyComboBox = new ComboBox();
            selectWarningLabel = new Label();
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
            printReportButton.Location = new Point(340, 198);
            printReportButton.Name = "printReportButton";
            printReportButton.Size = new Size(75, 38);
            printReportButton.TabIndex = 4;
            printReportButton.Text = "Print Report";
            printReportButton.UseVisualStyleBackColor = true;
            printReportButton.Click += button1_Click;
            // 
            // companyNameLabel
            // 
            companyNameLabel.AutoSize = true;
            companyNameLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            companyNameLabel.Location = new Point(12, 150);
            companyNameLabel.Name = "companyNameLabel";
            companyNameLabel.Size = new Size(147, 25);
            companyNameLabel.TabIndex = 5;
            companyNameLabel.Text = "Company Name";
            // 
            // companyComboBox
            // 
            companyComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            companyComboBox.FormattingEnabled = true;
            companyComboBox.Items.AddRange(new object[] { "" });
            companyComboBox.Location = new Point(215, 155);
            companyComboBox.Name = "companyComboBox";
            companyComboBox.Size = new Size(200, 23);
            companyComboBox.TabIndex = 6;
            companyComboBox.SelectedIndexChanged += companyComboBox_SelectedIndexChanged;
            // 
            // selectWarningLabel
            // 
            selectWarningLabel.AutoSize = true;
            selectWarningLabel.ForeColor = Color.Red;
            selectWarningLabel.Location = new Point(421, 158);
            selectWarningLabel.Name = "selectWarningLabel";
            selectWarningLabel.Size = new Size(163, 15);
            selectWarningLabel.TabIndex = 7;
            selectWarningLabel.Text = "Select an Insurancy Company";
            // 
            // DateRangeReport
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(selectWarningLabel);
            Controls.Add(companyComboBox);
            Controls.Add(companyNameLabel);
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
        private Label companyNameLabel;
        private ComboBox companyComboBox;
        private Label selectWarningLabel;
    }
}