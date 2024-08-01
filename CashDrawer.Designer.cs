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
            drawerAmountDataView = new DataGridView();
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
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            drawerAmountDataView.DefaultCellStyle = dataGridViewCellStyle1;
            drawerAmountDataView.Location = new Point(179, 81);
            drawerAmountDataView.Name = "drawerAmountDataView";
            drawerAmountDataView.ReadOnly = true;
            drawerAmountDataView.Size = new Size(675, 423);
            drawerAmountDataView.TabIndex = 0;
            // 
            // CashDrawer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1076, 628);
            Controls.Add(drawerAmountDataView);
            Name = "CashDrawer";
            Text = "CashDrawer";
            ((System.ComponentModel.ISupportInitialize)drawerAmountDataView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView drawerAmountDataView;
    }
}