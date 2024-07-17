namespace Wilkes_County_Insurance_App
{
    partial class OptionsForm
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
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            serverTextBox = new TextBox();
            userTextBox = new TextBox();
            passwordTextBox = new TextBox();
            databaseTextBox = new TextBox();
            editDatabaseCheckBox = new CheckBox();
            connectToDatabaseButton = new Button();
            databaseStatusButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(180, 119);
            label1.Name = "label1";
            label1.Size = new Size(90, 15);
            label1.TabIndex = 0;
            label1.Text = "Database Server";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(189, 159);
            label2.Name = "label2";
            label2.Size = new Size(81, 15);
            label2.TabIndex = 1;
            label2.Text = "Database User";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(162, 199);
            label3.Name = "label3";
            label3.Size = new Size(108, 15);
            label3.TabIndex = 2;
            label3.Text = "Database Password";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(215, 239);
            label4.Name = "label4";
            label4.Size = new Size(55, 15);
            label4.TabIndex = 3;
            label4.Text = "Database";
            // 
            // serverTextBox
            // 
            serverTextBox.Location = new Point(276, 120);
            serverTextBox.Name = "serverTextBox";
            serverTextBox.Size = new Size(100, 23);
            serverTextBox.TabIndex = 4;
            // 
            // userTextBox
            // 
            userTextBox.Location = new Point(276, 156);
            userTextBox.Name = "userTextBox";
            userTextBox.Size = new Size(100, 23);
            userTextBox.TabIndex = 5;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(276, 196);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.PasswordChar = '●';
            passwordTextBox.Size = new Size(100, 23);
            passwordTextBox.TabIndex = 6;
            // 
            // databaseTextBox
            // 
            databaseTextBox.Location = new Point(276, 236);
            databaseTextBox.Name = "databaseTextBox";
            databaseTextBox.Size = new Size(100, 23);
            databaseTextBox.TabIndex = 7;
            // 
            // editDatabaseCheckBox
            // 
            editDatabaseCheckBox.AutoSize = true;
            editDatabaseCheckBox.Location = new Point(213, 69);
            editDatabaseCheckBox.Name = "editDatabaseCheckBox";
            editDatabaseCheckBox.Size = new Size(163, 19);
            editDatabaseCheckBox.TabIndex = 8;
            editDatabaseCheckBox.Text = "Edit Database Information";
            editDatabaseCheckBox.UseVisualStyleBackColor = true;
            editDatabaseCheckBox.CheckedChanged += editDatabaseCheckBox_CheckedChanged;
            // 
            // connectToDatabaseButton
            // 
            connectToDatabaseButton.Location = new Point(246, 281);
            connectToDatabaseButton.Name = "connectToDatabaseButton";
            connectToDatabaseButton.Size = new Size(130, 23);
            connectToDatabaseButton.TabIndex = 9;
            connectToDatabaseButton.Text = "Connect to Database";
            connectToDatabaseButton.UseVisualStyleBackColor = true;
            connectToDatabaseButton.Click += connectToDatabaseButton_Click;
            // 
            // databaseStatusButton
            // 
            databaseStatusButton.Location = new Point(137, 281);
            databaseStatusButton.Name = "databaseStatusButton";
            databaseStatusButton.Size = new Size(103, 23);
            databaseStatusButton.TabIndex = 10;
            databaseStatusButton.Text = "Database Status";
            databaseStatusButton.UseVisualStyleBackColor = true;
            databaseStatusButton.Click += databaseStatusButton_Click;
            // 
            // OptionsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1076, 628);
            Controls.Add(databaseStatusButton);
            Controls.Add(connectToDatabaseButton);
            Controls.Add(editDatabaseCheckBox);
            Controls.Add(databaseTextBox);
            Controls.Add(passwordTextBox);
            Controls.Add(userTextBox);
            Controls.Add(serverTextBox);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "OptionsForm";
            Text = "OptionsForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox serverTextBox;
        private TextBox userTextBox;
        private TextBox passwordTextBox;
        private TextBox databaseTextBox;
        private CheckBox editDatabaseCheckBox;
        private Button connectToDatabaseButton;
        private Button databaseStatusButton;
    }
}