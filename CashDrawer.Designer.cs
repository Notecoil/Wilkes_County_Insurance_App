namespace Wilkes_County_Insurance_App
{
    partial class CashDrawer
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            drawerAmountDataView = new DataGridView();
            dateTimePicker1 = new DateTimePicker();
            button1 = new Button();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)drawerAmountDataView).BeginInit();
            SuspendLayout();
            // 
            // drawerAmountDataView
            // 
            drawerAmountDataView.AllowUserToAddRows = false;
            drawerAmountDataView.AllowUserToDeleteRows = false;
            drawerAmountDataView.AllowUserToResizeColumns = false;
            drawerAmountDataView.AllowUserToResizeRows = false;
            drawerAmountDataView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            drawerAmountDataView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllHeaders;
            drawerAmountDataView.BackgroundColor = SystemColors.Control;
            drawerAmountDataView.BorderStyle = BorderStyle.None;
            drawerAmountDataView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Menu;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Menu;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            drawerAmountDataView.DefaultCellStyle = dataGridViewCellStyle1;
            drawerAmountDataView.Location = new Point(179, 81);
            drawerAmountDataView.MultiSelect = false;
            drawerAmountDataView.Name = "drawerAmountDataView";
            drawerAmountDataView.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.Transparent;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            drawerAmountDataView.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            drawerAmountDataView.Size = new Size(675, 298);
            drawerAmountDataView.TabIndex = 0;
            drawerAmountDataView.CellContentClick += drawerAmountDataView_CellContentClick;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(179, 403);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(179, 447);
            button1.Name = "button1";
            button1.Size = new Size(141, 23);
            button1.TabIndex = 2;
            button1.Text = "Print from selected date";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(179, 485);
            button2.Name = "button2";
            button2.Size = new Size(141, 23);
            button2.TabIndex = 3;
            button2.Text = "Clear Cash Drawers";
            button2.UseVisualStyleBackColor = true;
            // 
            // CashDrawer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1076, 628);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dateTimePicker1);
            Controls.Add(drawerAmountDataView);
            Name = "CashDrawer";
            Text = "CashDrawer";
            ((System.ComponentModel.ISupportInitialize)drawerAmountDataView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView drawerAmountDataView;
        private DateTimePicker dateTimePicker1;
        private Button button1;
        private Button button2;
    }
}