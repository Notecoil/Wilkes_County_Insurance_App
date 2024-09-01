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
            components = new System.ComponentModel.Container();
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
            optionsSelectionListBox = new ListBox();
            databasePanel = new Panel();
            generalPanel = new Panel();
            userComboBox = new ComboBox();
            label5 = new Label();
            pictureBox2 = new PictureBox();
            toolTip1 = new ToolTip(components);
            databasePanel.SuspendLayout();
            generalPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 80);
            label1.Name = "label1";
            label1.Size = new Size(90, 15);
            label1.TabIndex = 0;
            label1.Text = "Database Server";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 120);
            label2.Name = "label2";
            label2.Size = new Size(81, 15);
            label2.TabIndex = 1;
            label2.Text = "Database User";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(9, 160);
            label3.Name = "label3";
            label3.Size = new Size(108, 15);
            label3.TabIndex = 2;
            label3.Text = "Database Password";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(9, 200);
            label4.Name = "label4";
            label4.Size = new Size(55, 15);
            label4.TabIndex = 3;
            label4.Text = "Database";
            // 
            // serverTextBox
            // 
            serverTextBox.Location = new Point(123, 77);
            serverTextBox.Name = "serverTextBox";
            serverTextBox.Size = new Size(125, 23);
            serverTextBox.TabIndex = 4;
            // 
            // userTextBox
            // 
            userTextBox.Location = new Point(123, 117);
            userTextBox.Name = "userTextBox";
            userTextBox.Size = new Size(125, 23);
            userTextBox.TabIndex = 5;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(123, 157);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.PasswordChar = '●';
            passwordTextBox.Size = new Size(125, 23);
            passwordTextBox.TabIndex = 6;
            // 
            // databaseTextBox
            // 
            databaseTextBox.Location = new Point(123, 197);
            databaseTextBox.Name = "databaseTextBox";
            databaseTextBox.Size = new Size(125, 23);
            databaseTextBox.TabIndex = 7;
            // 
            // editDatabaseCheckBox
            // 
            editDatabaseCheckBox.AutoSize = true;
            editDatabaseCheckBox.Location = new Point(85, 40);
            editDatabaseCheckBox.Name = "editDatabaseCheckBox";
            editDatabaseCheckBox.Size = new Size(163, 19);
            editDatabaseCheckBox.TabIndex = 8;
            editDatabaseCheckBox.Text = "Edit Database Information";
            editDatabaseCheckBox.UseVisualStyleBackColor = true;
            editDatabaseCheckBox.CheckedChanged += editDatabaseCheckBox_CheckedChanged;
            // 
            // connectToDatabaseButton
            // 
            connectToDatabaseButton.Location = new Point(118, 230);
            connectToDatabaseButton.Name = "connectToDatabaseButton";
            connectToDatabaseButton.Size = new Size(130, 23);
            connectToDatabaseButton.TabIndex = 9;
            connectToDatabaseButton.Text = "Connect to Database";
            connectToDatabaseButton.UseVisualStyleBackColor = true;
            connectToDatabaseButton.Click += connectToDatabaseButton_Click;
            // 
            // databaseStatusButton
            // 
            databaseStatusButton.Location = new Point(9, 230);
            databaseStatusButton.Name = "databaseStatusButton";
            databaseStatusButton.Size = new Size(103, 23);
            databaseStatusButton.TabIndex = 10;
            databaseStatusButton.Text = "Database Status";
            databaseStatusButton.UseVisualStyleBackColor = true;
            databaseStatusButton.Click += databaseStatusButton_Click;
            // 
            // optionsSelectionListBox
            // 
            optionsSelectionListBox.FormattingEnabled = true;
            optionsSelectionListBox.ItemHeight = 15;
            optionsSelectionListBox.Items.AddRange(new object[] { "General", "Database" });
            optionsSelectionListBox.Location = new Point(12, 12);
            optionsSelectionListBox.Name = "optionsSelectionListBox";
            optionsSelectionListBox.Size = new Size(120, 604);
            optionsSelectionListBox.TabIndex = 11;
            optionsSelectionListBox.SelectedIndexChanged += optionsSelectionListBox_SelectedIndexChanged;
            // 
            // databasePanel
            // 
            databasePanel.Controls.Add(editDatabaseCheckBox);
            databasePanel.Controls.Add(label1);
            databasePanel.Controls.Add(databaseStatusButton);
            databasePanel.Controls.Add(label2);
            databasePanel.Controls.Add(connectToDatabaseButton);
            databasePanel.Controls.Add(label3);
            databasePanel.Controls.Add(label4);
            databasePanel.Controls.Add(databaseTextBox);
            databasePanel.Controls.Add(serverTextBox);
            databasePanel.Controls.Add(passwordTextBox);
            databasePanel.Controls.Add(userTextBox);
            databasePanel.Location = new Point(138, 12);
            databasePanel.Name = "databasePanel";
            databasePanel.Size = new Size(571, 286);
            databasePanel.TabIndex = 12;
            // 
            // generalPanel
            // 
            generalPanel.Controls.Add(pictureBox2);
            generalPanel.Controls.Add(userComboBox);
            generalPanel.Controls.Add(label5);
            generalPanel.Location = new Point(138, 12);
            generalPanel.Name = "generalPanel";
            generalPanel.Size = new Size(589, 224);
            generalPanel.TabIndex = 13;
            // 
            // userComboBox
            // 
            userComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            userComboBox.FormattingEnabled = true;
            userComboBox.Items.AddRange(new object[] { "" });
            userComboBox.Location = new Point(100, 20);
            userComboBox.Name = "userComboBox";
            userComboBox.Size = new Size(121, 23);
            userComboBox.TabIndex = 14;
            userComboBox.SelectedIndexChanged += userComboBox_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(24, 23);
            label5.Name = "label5";
            label5.Size = new Size(71, 15);
            label5.TabIndex = 13;
            label5.Text = "Default User";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.Information16;
            pictureBox2.Location = new Point(7, 23);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(18, 15);
            pictureBox2.TabIndex = 33;
            pictureBox2.TabStop = false;
            toolTip1.SetToolTip(pictureBox2, "Default user on this machine.\r\nWhen printing receipts, the selection here\r\nis auto provided.");
            // 
            // OptionsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1076, 628);
            Controls.Add(generalPanel);
            Controls.Add(optionsSelectionListBox);
            Controls.Add(databasePanel);
            Name = "OptionsForm";
            Text = "OptionsForm";
            databasePanel.ResumeLayout(false);
            databasePanel.PerformLayout();
            generalPanel.ResumeLayout(false);
            generalPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
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
        private ListBox optionsSelectionListBox;
        private Panel databasePanel;
        private Panel generalPanel;
        private ComboBox userComboBox;
        private Label label5;
        private PictureBox pictureBox2;
        private ToolTip toolTip1;
    }
}