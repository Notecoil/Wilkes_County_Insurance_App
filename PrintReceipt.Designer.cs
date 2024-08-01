namespace Wilkes_County_Insurance_App
{
    partial class PrintReceipt
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
            firstNameTextBox = new TextBox();
            lastNameTextBox = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            receiptDatePicker = new DateTimePicker();
            label5 = new Label();
            employeeComboBox = new ComboBox();
            label6 = new Label();
            remitTextBox = new TextBox();
            label7 = new Label();
            referenceTextBox = new TextBox();
            transactionDescriptionTextBox = new TextBox();
            label8 = new Label();
            label9 = new Label();
            paymentAmountTextBox = new TextBox();
            label10 = new Label();
            printReceiptButton = new Button();
            paymentMethodComboBox = new ComboBox();
            amountTenderedLabel = new Label();
            amountTenderedTextBox = new TextBox();
            changeDueLabel = new Label();
            changeDueTextBox = new TextBox();
            numbersOnlyLabel = new Label();
            billPaymentWarningLabel = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(73, 63);
            label1.Name = "label1";
            label1.Size = new Size(88, 15);
            label1.TabIndex = 0;
            label1.Text = "Received From:";
            // 
            // firstNameTextBox
            // 
            firstNameTextBox.Location = new Point(164, 60);
            firstNameTextBox.Name = "firstNameTextBox";
            firstNameTextBox.Size = new Size(116, 23);
            firstNameTextBox.TabIndex = 1;
            // 
            // lastNameTextBox
            // 
            lastNameTextBox.Location = new Point(286, 60);
            lastNameTextBox.Name = "lastNameTextBox";
            lastNameTextBox.Size = new Size(116, 23);
            lastNameTextBox.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(164, 42);
            label2.Name = "label2";
            label2.Size = new Size(64, 15);
            label2.TabIndex = 3;
            label2.Text = "First Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(286, 42);
            label3.Name = "label3";
            label3.Size = new Size(63, 15);
            label3.TabIndex = 4;
            label3.Text = "Last Name";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(124, 103);
            label4.Name = "label4";
            label4.Size = new Size(34, 15);
            label4.TabIndex = 5;
            label4.Text = "Date:";
            // 
            // receiptDatePicker
            // 
            receiptDatePicker.Location = new Point(164, 97);
            receiptDatePicker.Name = "receiptDatePicker";
            receiptDatePicker.Size = new Size(200, 23);
            receiptDatePicker.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(111, 146);
            label5.Name = "label5";
            label5.Size = new Size(47, 15);
            label5.TabIndex = 7;
            label5.Text = "User ID:";
            // 
            // employeeComboBox
            // 
            employeeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            employeeComboBox.FormattingEnabled = true;
            employeeComboBox.Items.AddRange(new object[] { "" });
            employeeComboBox.Location = new Point(164, 143);
            employeeComboBox.Name = "employeeComboBox";
            employeeComboBox.Size = new Size(121, 23);
            employeeComboBox.TabIndex = 8;
            employeeComboBox.SelectedIndexChanged += employeeComboBox_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(103, 194);
            label6.Name = "label6";
            label6.Size = new Size(55, 15);
            label6.TabIndex = 9;
            label6.Text = "Remit to:";
            // 
            // remitTextBox
            // 
            remitTextBox.Location = new Point(164, 191);
            remitTextBox.Name = "remitTextBox";
            remitTextBox.Size = new Size(200, 23);
            remitTextBox.TabIndex = 10;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(95, 242);
            label7.Name = "label7";
            label7.Size = new Size(62, 15);
            label7.TabIndex = 11;
            label7.Text = "Reference:";
            // 
            // referenceTextBox
            // 
            referenceTextBox.Location = new Point(164, 239);
            referenceTextBox.Name = "referenceTextBox";
            referenceTextBox.Size = new Size(200, 23);
            referenceTextBox.TabIndex = 12;
            // 
            // transactionDescriptionTextBox
            // 
            transactionDescriptionTextBox.Location = new Point(164, 281);
            transactionDescriptionTextBox.Name = "transactionDescriptionTextBox";
            transactionDescriptionTextBox.Size = new Size(200, 23);
            transactionDescriptionTextBox.TabIndex = 14;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(25, 284);
            label8.Name = "label8";
            label8.Size = new Size(133, 15);
            label8.TabIndex = 13;
            label8.Text = "Transaction Description:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(56, 446);
            label9.Name = "label9";
            label9.Size = new Size(102, 15);
            label9.TabIndex = 15;
            label9.Text = "Payment Method:";
            label9.Visible = false;
            // 
            // paymentAmountTextBox
            // 
            paymentAmountTextBox.Location = new Point(164, 319);
            paymentAmountTextBox.Name = "paymentAmountTextBox";
            paymentAmountTextBox.Size = new Size(200, 23);
            paymentAmountTextBox.TabIndex = 18;
            paymentAmountTextBox.TextChanged += paymentAmountTextBox_TextChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(25, 322);
            label10.Name = "label10";
            label10.Size = new Size(132, 15);
            label10.TabIndex = 17;
            label10.Text = "Bill Payment Amount: $";
            // 
            // printReceiptButton
            // 
            printReceiptButton.Location = new Point(208, 360);
            printReceiptButton.Name = "printReceiptButton";
            printReceiptButton.Size = new Size(99, 23);
            printReceiptButton.TabIndex = 19;
            printReceiptButton.Text = "Print Receipt";
            printReceiptButton.UseVisualStyleBackColor = true;
            printReceiptButton.Click += printReceiptButton_Click;
            // 
            // paymentMethodComboBox
            // 
            paymentMethodComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            paymentMethodComboBox.FormattingEnabled = true;
            paymentMethodComboBox.Items.AddRange(new object[] { "", "Cash", "Credit" });
            paymentMethodComboBox.Location = new Point(164, 443);
            paymentMethodComboBox.Name = "paymentMethodComboBox";
            paymentMethodComboBox.Size = new Size(200, 23);
            paymentMethodComboBox.TabIndex = 20;
            paymentMethodComboBox.Visible = false;
            paymentMethodComboBox.SelectedIndexChanged += paymentMethodComboBox_SelectedIndexChanged;
            // 
            // amountTenderedLabel
            // 
            amountTenderedLabel.AutoSize = true;
            amountTenderedLabel.Location = new Point(387, 446);
            amountTenderedLabel.Name = "amountTenderedLabel";
            amountTenderedLabel.Size = new Size(114, 15);
            amountTenderedLabel.TabIndex = 21;
            amountTenderedLabel.Text = "Amount Tendered: $";
            amountTenderedLabel.Visible = false;
            // 
            // amountTenderedTextBox
            // 
            amountTenderedTextBox.Location = new Point(507, 443);
            amountTenderedTextBox.Name = "amountTenderedTextBox";
            amountTenderedTextBox.Size = new Size(100, 23);
            amountTenderedTextBox.TabIndex = 22;
            amountTenderedTextBox.Visible = false;
            amountTenderedTextBox.TextChanged += amountTenderedTextBox_TextChanged;
            // 
            // changeDueLabel
            // 
            changeDueLabel.AutoSize = true;
            changeDueLabel.Location = new Point(417, 484);
            changeDueLabel.Name = "changeDueLabel";
            changeDueLabel.Size = new Size(84, 15);
            changeDueLabel.TabIndex = 23;
            changeDueLabel.Text = "Change Due: $";
            changeDueLabel.Visible = false;
            // 
            // changeDueTextBox
            // 
            changeDueTextBox.Location = new Point(507, 481);
            changeDueTextBox.Name = "changeDueTextBox";
            changeDueTextBox.ReadOnly = true;
            changeDueTextBox.Size = new Size(100, 23);
            changeDueTextBox.TabIndex = 24;
            changeDueTextBox.Visible = false;
            // 
            // numbersOnlyLabel
            // 
            numbersOnlyLabel.AutoSize = true;
            numbersOnlyLabel.ForeColor = Color.Red;
            numbersOnlyLabel.Location = new Point(613, 446);
            numbersOnlyLabel.Name = "numbersOnlyLabel";
            numbersOnlyLabel.Size = new Size(84, 15);
            numbersOnlyLabel.TabIndex = 25;
            numbersOnlyLabel.Text = "Numbers Only";
            numbersOnlyLabel.Visible = false;
            // 
            // billPaymentWarningLabel
            // 
            billPaymentWarningLabel.AutoSize = true;
            billPaymentWarningLabel.ForeColor = Color.Red;
            billPaymentWarningLabel.Location = new Point(370, 322);
            billPaymentWarningLabel.Name = "billPaymentWarningLabel";
            billPaymentWarningLabel.Size = new Size(84, 15);
            billPaymentWarningLabel.TabIndex = 26;
            billPaymentWarningLabel.Text = "Numbers Only";
            // 
            // PrintReceipt
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1076, 628);
            Controls.Add(billPaymentWarningLabel);
            Controls.Add(numbersOnlyLabel);
            Controls.Add(changeDueTextBox);
            Controls.Add(changeDueLabel);
            Controls.Add(amountTenderedTextBox);
            Controls.Add(amountTenderedLabel);
            Controls.Add(paymentMethodComboBox);
            Controls.Add(printReceiptButton);
            Controls.Add(paymentAmountTextBox);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(transactionDescriptionTextBox);
            Controls.Add(label8);
            Controls.Add(referenceTextBox);
            Controls.Add(label7);
            Controls.Add(remitTextBox);
            Controls.Add(label6);
            Controls.Add(employeeComboBox);
            Controls.Add(label5);
            Controls.Add(receiptDatePicker);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(lastNameTextBox);
            Controls.Add(firstNameTextBox);
            Controls.Add(label1);
            Name = "PrintReceipt";
            Text = "PrintReceipt";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox firstNameTextBox;
        private TextBox lastNameTextBox;
        private Label label2;
        private Label label3;
        private Label label4;
        private DateTimePicker receiptDatePicker;
        private Label label5;
        private ComboBox employeeComboBox;
        private Label label6;
        private TextBox remitTextBox;
        private Label label7;
        private TextBox referenceTextBox;
        private TextBox transactionDescriptionTextBox;
        private Label label8;
        private Label label9;
        private TextBox paymentAmountTextBox;
        private Label label10;
        private Button printReceiptButton;
        private ComboBox paymentMethodComboBox;
        private Label amountTenderedLabel;
        private TextBox amountTenderedTextBox;
        private Label changeDueLabel;
        private TextBox changeDueTextBox;
        private Label numbersOnlyLabel;
        private Label billPaymentWarningLabel;
    }
}