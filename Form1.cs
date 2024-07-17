using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.IO;
using MySql.Data.MySqlClient;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace Wilkes_County_Insurance_App
{
    public partial class Form1 : Form
    {
        //public string fileName = "database.txt";

        /*public string server;
        public string database;
        public string userid;
        public string password;
        public string port;*/
        string[] databaseLines;
        private string TAG = "";

        private Font printFont;
        List<string> firstNames = new List<string>();


        public Form1()
        {
            InitializeComponent();

            /*if (File.Exists(fileName))
            {
                databaseLines = File.ReadAllLines(fileName);
                server = databaseLines[0];
                userid = databaseLines[1];
                password = databaseLines[2];
                database = databaseLines[3];
                port = "3306";
            }
            else
            {
                string[] lines = { "localhost", "root", "admin", "insurancedb" };
                File.WriteAllLines(fileName, lines);
            }*/

            //connectToDatabase();
        }

        /*private void printButton_Click(object sender, EventArgs e)
        {
            Debug.WriteLine($"server: {server}, userid: {userid}, password: {password}, database: {database}");


        }*/

        /*private void connectToDatabase()
        {
            string connectionStr = $"server={server};userid={userid};password={password};database={database};";
            MySqlConnection connection = new MySqlConnection(connectionStr);
            try
            {
                connection.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }*/



        private void optionsButton_Click(object sender, EventArgs e)
        {
            OptionsForm optionsForm = new OptionsForm();
            optionsForm.Show();

        }

        /*private void button1_Click(object sender, EventArgs e)
        {
            databaseLines = File.ReadAllLines(fileName);
            server = databaseLines[0];
            userid = databaseLines[1];
            password = databaseLines[2];
            database = databaseLines[3];

            Debug.WriteLine("Server: " + server + "UserID" + userid + "Database" + database);
        }*/

        private void button2_Click(object sender, EventArgs e)
        {
            /*QuestPDF.Settings.License = LicenseType.Community;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = saveFileDialog.FileName;
                Debug.WriteLine(path);
                createPDF(path);
            }*/

        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*QuestPDF.Settings.License = LicenseType.Community;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = saveFileDialog.FileName;
                Debug.WriteLine(path);
                createPDF(path);
            }*/
        }

        /*private void createPDF(string path)
        {
            var document = Document.Create(container =>
            {
                container
                    .Page(page =>
                    {
                        page.Size(PageSizes.A4);
                        page.Margin(2, Unit.Centimetre);
                        page.PageColor(Colors.White);

                        page.Header()
                            .Text("Wilkes County Insurance Agency")
                            .AlignCenter();

                        page.Content()
                            .PaddingVertical(1, Unit.Centimetre)
                            .AlignCenter()
                            .Text($"{TAG}")
                            .FontSize(8)
                            .FontFamily(Fonts.Consolas);

                        page.Footer()
                            .AlignCenter()
                            .Text("This is the footer");
                    });
            });
            document.GeneratePdfAndShow();
            document.GeneratePdf(path);
        }*/
    }
}
