using System.Runtime.CompilerServices;

namespace Wilkes_County_Insurance_App
{
    partial class EditReceipt
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
            label1 = new Label();
            textBox1 = new TextBox();
            receiptDataView = new DataGridView();
            selectReceiptButton = new Button();
            exitWindowButton = new Button();
            ((System.ComponentModel.ISupportInitialize)receiptDataView).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 57);
            label1.Name = "label1";
            label1.Size = new Size(93, 15);
            label1.TabIndex = 0;
            label1.Text = "Search by Name";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(108, 54);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(159, 23);
            textBox1.TabIndex = 1;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // receiptDataView
            // 
            receiptDataView.AllowUserToAddRows = false;
            receiptDataView.AllowUserToDeleteRows = false;
            receiptDataView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllHeaders;
            receiptDataView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            receiptDataView.Location = new Point(108, 83);
            receiptDataView.Name = "receiptDataView";
            receiptDataView.ReadOnly = true;
            receiptDataView.Size = new Size(240, 150);
            receiptDataView.TabIndex = 2;
            receiptDataView.KeyDown += receiptDataView_KeyDown;
            // 
            // selectReceiptButton
            // 
            selectReceiptButton.Location = new Point(273, 54);
            selectReceiptButton.Name = "selectReceiptButton";
            selectReceiptButton.Size = new Size(75, 23);
            selectReceiptButton.TabIndex = 3;
            selectReceiptButton.Text = "Select Receipt";
            selectReceiptButton.UseVisualStyleBackColor = true;
            selectReceiptButton.Click += selectReceiptButton_Click;
            // 
            // exitWindowButton
            // 
            exitWindowButton.Location = new Point(12, 12);
            exitWindowButton.Name = "exitWindowButton";
            exitWindowButton.Size = new Size(82, 23);
            exitWindowButton.TabIndex = 4;
            exitWindowButton.Text = "Exit Window";
            exitWindowButton.UseVisualStyleBackColor = true;
            exitWindowButton.Click += exitWindowButton_Click;
            // 
            // EditReceipt
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1076, 628);
            Controls.Add(exitWindowButton);
            Controls.Add(selectReceiptButton);
            Controls.Add(receiptDataView);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "EditReceipt";
            Text = "EditReceipt";
            ((System.ComponentModel.ISupportInitialize)receiptDataView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private DataGridView receiptDataView;
        private Button selectReceiptButton;
        private Button exitWindowButton;
    }
}