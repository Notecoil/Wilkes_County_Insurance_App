using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.IO;
using System.Text;
using MySql.Data.MySqlClient;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace Wilkes_County_Insurance_App
{
    public partial class Form1 : Form
    {
        
        string[] databaseLines;
        private string TAG = "";

        private Font printFont;
        List<string> firstNames = new List<string>();

        string defaultUserFileName = "defaultuser";
        string defaultUser = "";

        MySqlConnection connection;

        //ParentForm parentForm = new ParentForm();


        public Form1(MySqlConnection connection = null)
        {
            InitializeComponent();

            this.connection = connection;

            initUI();
        }

        private void initUI()
        {
            defaultUser = Encoding.ASCII.GetString(File.ReadAllBytes(defaultUserFileName));

            welcomeLabel.Text = $"Welcome, {defaultUser}!";

            initAnalytics();
        }

        private void initAnalytics()
        {
            string startDateTime = DateTime.Now.ToString("yyyy-MM-dd 00:00:00");
            string endDateTime = DateTime.Now.ToString("yyyy-MM-dd 23:59:59");

            
            try
            {
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT COUNT(*) FROM receipts WHERE receipt_date BETWEEN @startDateTime AND @endDateTime;";
                cmd.Parameters.AddWithValue("@startDateTime", startDateTime);
                cmd.Parameters.AddWithValue("@endDateTime", endDateTime);

                int totalReceipts = Convert.ToInt32(cmd.ExecuteScalar());

                receiptsTodayLabel.Text = $"Receipts Today: {totalReceipts}";
            }
            catch (Exception ex)
            {
                File.AppendAllLines("errorlog.log", new string[] { $"{DateTime.Now} {ex.Message}" });
                //MessageBox.Show($"Error: Couldn't connect to the database.\nTry restarting the program or your computer.\nIf the issue still persists contact support.");
            }
        }

        
        private void optionsButton_Click(object sender, EventArgs e)
        {
            OptionsForm optionsForm = new OptionsForm();
            optionsForm.Show();

        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        
    }
}
