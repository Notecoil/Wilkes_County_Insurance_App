using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wilkes_County_Insurance_App
{
    public partial class OptionsForm : Form
    {
        public string fileName = "databaseInit.txt";
        public string defaultUserFileName = "defaultuser";
        
        public string server;
        public string userid;
        public string password;
        public string database;

        ParentForm parentForm = new ParentForm();

        public OptionsForm()
        {
            InitializeComponent();
            fillTextBoxes();
            initUI();
        }

        private void initUI()
        {
            databasePanel.Visible = false;
            generalPanel.Visible = false;
            populateUsers();
            string defaultUser = Encoding.ASCII.GetString(File.ReadAllBytes(defaultUserFileName));
            userComboBox.SelectedItem = defaultUser;
            optionsSelectionListBox.SelectedItem = "General";
        }

        private void fillTextBoxes()
        {
            serverTextBox.Enabled = false;
            userTextBox.Enabled = false;
            passwordTextBox.Enabled = false;
            databaseTextBox.Enabled = false;

            /*databaseLines = File.ReadAllLines(fileName);
            server = databaseLines[0];
            userid = databaseLines[1];
            password = databaseLines[2];
            database = databaseLines[3];*/

            string[] databaseLines = File.ReadAllLines(fileName);

            serverTextBox.Text = databaseLines[0];
            userTextBox.Text = databaseLines[1];
            passwordTextBox.Text = databaseLines[2];
            databaseTextBox.Text = databaseLines[3];
        }

        private void populateUsers()
        {
            try
            {
                MySqlCommand cmd = parentForm.connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM employees;";
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    userComboBox.Items.Add(reader["first_name"].ToString() + " " + reader["last_name"].ToString());
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                //File.WriteAllText("errorlog.log", $"{DateTime.Now} {ex.ToString()}\n");
                File.AppendAllText("errorlog.log", $"{DateTime.Now} {ex.Message}\n");
            }
        }

        private void editDatabaseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            string[] databaseLines = File.ReadAllLines(fileName);

            if (editDatabaseCheckBox.Checked)
            {
                serverTextBox.Enabled = true;
                userTextBox.Enabled = true;
                passwordTextBox.Enabled = true;
                databaseTextBox.Enabled = true;
                connectToDatabaseButton.Enabled = false;
                /*ValidationForm validationForm = new ValidationForm();
                if (validationForm.ShowDialog() == DialogResult.OK)
                {
                    serverTextBox.Enabled = true;
                    userTextBox.Enabled = true;
                    passwordTextBox.Enabled = true;
                    databaseTextBox.Enabled = true;
                    connectToDatabaseButton.Enabled = false;
                }
                else
                {
                    editDatabaseCheckBox.Checked = false;
                }*/

            }
            else
            {
                if (MessageBox.Show("Are you sure you want to save these changes?", "Save Changes", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    File.WriteAllLines(fileName, new string[] { serverTextBox.Text, userTextBox.Text, passwordTextBox.Text, databaseTextBox.Text });

                    serverTextBox.Enabled = false;
                    userTextBox.Enabled = false;
                    passwordTextBox.Enabled = false;
                    databaseTextBox.Enabled = false;
                    connectToDatabaseButton.Enabled = true;
                }
                else // If user selects no, revert back to original values
                {
                    //editDatabaseCheckBox.Checked = true;
                    serverTextBox.Text = databaseLines[0];
                    userTextBox.Text = databaseLines[1];
                    passwordTextBox.Text = databaseLines[2];
                    databaseTextBox.Text = databaseLines[3];
                }


                serverTextBox.Enabled = false;
                userTextBox.Enabled = false;
                passwordTextBox.Enabled = false;
                databaseTextBox.Enabled = false;
                connectToDatabaseButton.Enabled = true;

            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void connectToDatabaseButton_Click(object sender, EventArgs e)
        {
            //parentForm = new ParentForm();
            if (parentForm.connection.State == ConnectionState.Open)
            {
                if (MessageBox.Show("Connection is already open. Do you want to close and reopen?", "Connection Status", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    parentForm.connection.Close();
                    parentForm.connectToDatabase();
                    if (parentForm.connection.State == ConnectionState.Open)
                    {
                        MessageBox.Show("Connection closed and reopened");
                    }
                    else
                    {
                        MessageBox.Show($"Connection not reopened: {parentForm.connectionError}");
                    }
                }
                else
                {
                    MessageBox.Show("Connection not closed");
                }
            }
            else
            {
                parentForm.connectToDatabase();
                if (parentForm.connection.State == ConnectionState.Open)
                {
                    MessageBox.Show("Connection opened");
                }
                else
                {
                    MessageBox.Show($"Connection not opened: {parentForm.connectionError}");
                }
            }
            //parentForm.connectToDatabase();
        }

        private void databaseStatusButton_Click(object sender, EventArgs e)
        {
            //ParentForm parentForm1 = new ParentForm();
            MessageBox.Show($"Database Status: {parentForm.connection.State}");
        }

        private void optionsSelectionListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedOption = optionsSelectionListBox.SelectedItem.ToString();

            switch (selectedOption)
            {
                case "Database":
                    clearPanels();
                    databasePanel.Visible = true;
                    break;
                case "General":
                    clearPanels();
                    generalPanel.Visible = true;
                    break;
            }
        }

        private void clearPanels()
        {
            for (int i = 0; i < this.Controls.Count; i++)
            {
                if (this.Controls[i] is Panel)
                {
                    this.Controls[i].Visible = false;
                }
            }
        }

        private void userComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            File.WriteAllBytes(defaultUserFileName, Encoding.ASCII.GetBytes(userComboBox.SelectedItem.ToString()));
        }
    }
}
