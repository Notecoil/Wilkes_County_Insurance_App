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
using System.Linq;

namespace Wilkes_County_Insurance_App
{
    public partial class ParentForm : Form
    {
        // Variables
        public string databaseInitFileName = "databaseInit.txt";
        public string defaultUserFileName = "defaultuser";
        public string errorFileName = "errorlog.log";
        public MySqlConnection connection;
        public string connectionError;
        Button[] parentButtons;

        public ParentForm()
        {
            InitializeComponent();

            parentButtons = new Button[] { homeButton, optionsButton, printReceiptButton, reportsButton};
            //homeInit();
            databaseInit();
            defaultUser();
            errorFile();

            connectToDatabase();

            initUI();
        }

        /// <summary>
        /// Creates an error log file 
        /// to store error information to if one does not exist
        /// </summary>
        private void errorFile()
        {
            if (!File.Exists(errorFileName))
            {
                File.WriteAllText(errorFileName, "");
            }
        }

        /// <summary>
        /// Initializes the UI of the parent form
        /// </summary>
        private void initUI()
        {
            // runs on startup of program, checks if any buttons have been selected, if not, defaults to home menu.
            bool exists = parentButtons.Any(button => button.Enabled == false);

            if (exists)
            {
                buttonInit();
            }
            else
            {
                homeButton_Click(this, null);
            }

            cashDrawerButton.Visible = false;
        }

        
        /// <summary>
        /// Executes when the parent form is loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ParentForm_Load(object sender, EventArgs e)
        {
            //connectToDatabase();
        }

        /// <summary>
        /// Connects to the database using the connection string stored in the databaseInit file
        /// </summary>
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

        /// <summary>
        /// Creates a default database file to store database connection information
        /// </summary>
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

        /// <summary>
        /// Creates a default user file to store user preference
        /// for a default user on the machine if one does not exist
        /// </summary>
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

        /// <summary>
        /// Moves to the options form when the button is clicked on the parent form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void optionsButton_Click(object sender, EventArgs e)
        {
            /// *** IMPORTANT ***
            /// Old method of validating if the user was allowed to access the options menu
            /// has been replaced with a standard options menu that is always accessible
            /// training will be done to ensure that users do not change settings that they are not supposed to
            /// *** IMPORTANT ***
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

        /// <summary>
        /// Moves to the home form when the button is clicked on the parent form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void homeButton_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1(connection);
            buttonInit();
            homeButton.Enabled = false;
            clearPanel();

            form1.TopLevel = false;
            form1.AutoScroll = true;
            form1.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(form1);
            form1.Show();
        }

        
        /// <summary>
        /// Clears the panel of all controls
        /// </summary>
        private void clearPanel()
        {
            foreach (Control control in panel1.Controls)
            {
                panel1.Controls.Remove(control);
            }
        }

        /// <summary>
        /// Sets all buttons to enabled and clears the active control
        /// </summary>
        private void buttonInit()
        {
            foreach (Button button in parentButtons)
            {
                button.Enabled = true;
                this.ActiveControl = null;
            }
        }

        /// <summary>
        /// Moves to the print receipt form when the button is clicked on the parent form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Moves to the cash drawer form when the button is clicked on the parent form DEPRECATED
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cashDrawerButton_Click(object sender, EventArgs e) // Cash Drawer Button
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

        /// <summary>
        /// Moves to the reports form when the button is clicked on the parent form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
