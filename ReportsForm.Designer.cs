namespace Wilkes_County_Insurance_App
{
    partial class ReportsForm
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
            printTotalReceiptsButton = new Button();
            button2 = new Button();
            printCashDrawerTotalsButton = new Button();
            SuspendLayout();
            // 
            // printTotalReceiptsButton
            // 
            printTotalReceiptsButton.Location = new Point(12, 12);
            printTotalReceiptsButton.Name = "printTotalReceiptsButton";
            printTotalReceiptsButton.Size = new Size(122, 53);
            printTotalReceiptsButton.TabIndex = 1;
            printTotalReceiptsButton.Text = "Print Daily Receipts Report";
            printTotalReceiptsButton.UseVisualStyleBackColor = true;
            printTotalReceiptsButton.Click += printTotalReceiptsButton_Click;
            // 
            // button2
            // 
            button2.Location = new Point(12, 71);
            button2.Name = "button2";
            button2.Size = new Size(122, 53);
            button2.TabIndex = 2;
            button2.Text = "Print Company Receipt Reports";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // printCashDrawerTotalsButton
            // 
            printCashDrawerTotalsButton.Location = new Point(12, 130);
            printCashDrawerTotalsButton.Name = "printCashDrawerTotalsButton";
            printCashDrawerTotalsButton.Size = new Size(122, 53);
            printCashDrawerTotalsButton.TabIndex = 3;
            printCashDrawerTotalsButton.Text = "Print Cash Drawer Totals / Receipts per User Report";
            printCashDrawerTotalsButton.UseVisualStyleBackColor = true;
            printCashDrawerTotalsButton.Click += printCashDrawerTotalsButton_Click;
            // 
            // ReportsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1076, 628);
            Controls.Add(printCashDrawerTotalsButton);
            Controls.Add(button2);
            Controls.Add(printTotalReceiptsButton);
            Name = "ReportsForm";
            Text = "ReportsForm";
            ResumeLayout(false);
        }

        #endregion

        private Button printTotalReceiptsButton;
        private Button button2;
        private Button printCashDrawerTotalsButton;
    }
}