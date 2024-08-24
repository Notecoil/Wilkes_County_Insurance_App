using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Wilkes_County_Insurance_App
{
    public partial class ParentForm : Form
    {
        public string databaseInitFileName = "databaseInit.txt";
        public string defaultUserFileName = "defaultuser";
        public string errorFileName = "errorlog.log";
        //public string[] databaseConfig;
        public MySqlConnection connection;
        public string connectionError;

        Form1 form1 = new Form1();

        Button[] parentButtons;
        public ParentForm()
        {
            InitializeComponent();

            parentButtons = new Button[] { homeButton, optionsButton, printReceiptButton, cashDrawerButton, reportsButton};
            homeInit();
            databaseInit();
            defaultUser();
            errorFile();

            connectToDatabase();
        }

        private void errorFile()
        {
            if (!File.Exists(errorFileName))
            {
                File.WriteAllText(errorFileName, "");
            }
        }

        /*private void panel1_Paint(object sender, PaintEventArgs e)
        {
            homeButton.Enabled = false;

            form1.TopLevel = false;
            form1.AutoScroll = true;
            form1.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(form1);
            form1.Show();
        }*/

        private void ParentForm_Load(object sender, EventArgs e)
        {
            //connectToDatabase();
        }

        public void connectToDatabase()
        {
            string[] databaseConfig = File.ReadAllLines(databaseInitFileName);
            string connectionStr = $"server={databaseConfig[0]};userid={databaseConfig[1]};password={databaseConfig[2]};database={databaseConfig[3]};";
            if (connection != null)
            {
                connection.Close();
            }

            connection = new MySqlConnection(connectionStr);
            try
            {
                connection.Open();
                //connection.Close();
                //MessageBox.Show("Connected to database");
            }
            catch (Exception e)
            {
                //MessageBox.Show($"Error connecting to database: {e.Message}");
                connectionError = e.Message;
            }
        }

        private void databaseInit()
        {
            if (File.Exists(databaseInitFileName))
            {
                //databaseConfig = File.ReadAllLines(databaseInitFileName);
            }
            else
            {
                File.WriteAllText(databaseInitFileName, "\n\n\n\n");
            }
        }

        private void defaultUser()
        {
            if (File.Exists(defaultUserFileName))
            {

            }
            else
            {
                File.WriteAllText(defaultUserFileName, "\n");
            }
        }

        private void optionsButton_Click(object sender, EventArgs e)
        {
            /*ValidationForm validationForm = new ValidationForm();
            if (validationForm.ShowDialog() == DialogResult.OK)
            {
                OptionsForm optionsForm = new OptionsForm();
                buttonInit();
                optionsButton.Enabled = false;
                clearPanel();

                optionsForm.TopLevel = false;
                optionsForm.AutoScroll = true;
                optionsForm.FormBorderStyle = FormBorderStyle.None;
                panel1.Controls.Add(optionsForm);
                optionsForm.Show();
            }*/
            OptionsForm optionsForm = new OptionsForm();
            buttonInit();
            optionsButton.Enabled = false;
            clearPanel();

            optionsForm.TopLevel = false;
            optionsForm.AutoScroll = true;
            optionsForm.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(optionsForm);
            optionsForm.Show();
        }

        private void homeButton_Click(object sender, EventArgs e)
        {
            buttonInit();
            homeButton.Enabled = false;
            clearPanel();

            form1.TopLevel = false;
            form1.AutoScroll = true;
            form1.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(form1);
            form1.Show();
        }

        public void returnHome()
        {
            buttonInit();
            homeButton.Enabled = false;
            clearPanel();

            form1.TopLevel = false;
            form1.AutoScroll = true;
            form1.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(form1);
            form1.Show();
        }

        private void clearPanel()
        {
            foreach (Control control in panel1.Controls)
            {
                panel1.Controls.Remove(control);
            }
        }

        private void buttonInit()
        {
            foreach (Button button in parentButtons)
            {
                button.Enabled = true;
                this.ActiveControl = null;
            }
        }

        private void homeInit()
        {
            homeButton.Enabled = false;
            clearPanel();

            form1.TopLevel = false;
            form1.AutoScroll = true;
            form1.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(form1);
            form1.Show();
        }

        private void printReceiptButton_Click(object sender, EventArgs e)
        {
            PrintReceipt printReceipt = new PrintReceipt();
            buttonInit();
            printReceiptButton.Enabled = false;
            clearPanel();

            printReceipt.TopLevel = false;
            printReceipt.AutoScroll = true;
            printReceipt.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(printReceipt);
            printReceipt.Show();
        }

        private void cashDrawerButton_Click(object sender, EventArgs e)
        {
            CashDrawer cashDrawer = new CashDrawer();
            buttonInit();
            cashDrawerButton.Enabled = false;
            clearPanel();

            cashDrawer.TopLevel = false;
            cashDrawer.AutoScroll = true;
            cashDrawer.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(cashDrawer);
            cashDrawer.Show();
        }

        private void reportsButton_Click(object sender, EventArgs e)
        {
            ReportsForm reportsForm = new ReportsForm();
            buttonInit();
            reportsButton.Enabled = false;
            clearPanel();

            reportsForm.TopLevel = false;
            reportsForm.AutoScroll = true;
            reportsForm.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(reportsForm);
            reportsForm.Show();
        }
    }
}
