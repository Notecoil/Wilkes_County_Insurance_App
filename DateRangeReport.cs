using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using QuestPDF.Infrastructure;
using QuestPDF.Fluent;
using QuestPDF.Helpers;

namespace Wilkes_County_Insurance_App
{
    public partial class DateRangeReport : Form
    {
        ParentForm parentForm = new ParentForm();

        public string mode;

        private string startDate;
        private string endDate;

        public DateRangeReport(string mode)
        {
            InitializeComponent();

            this.mode = mode;

            initUI();
        }

        private void initUI()
        {
            companyNameLabel.Visible = false;
            companyComboBox.Visible = false;
            selectWarningLabel.Visible = false;

            fillInsuranceCompanies();

            switch (mode)
            {
                case "totalReceipts": // total receipts
                    this.Text = "Total Receipts Report";
                    break;
                case "totalPayments": // receipts by company
                    this.Text = "Total Payments Report";
                    companyNameLabel.Visible = true;
                    companyComboBox.Visible = true;
                    selectWarningLabel.Visible = true;
                    break;
                case "cashDrawerTotals": // cash drawer totals
                    this.Text = "Cash Drawer Totals Report";
                    break;
            }

            if (parentForm.connectionError != null)
            {
                MessageBox.Show($"Error: Couldn't connect to the database.\nTry restarting the program or your computer.\nIf the issue still persists contact support.");
                File.AppendAllLines("errorlog.log", new string[] { $"{DateTime.Now} {parentForm.connectionError}" });
                printReportButton.Enabled = false;
            }
        }

        private void fillInsuranceCompanies()
        {
            try
            {
                MySqlCommand cmd = parentForm.connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM insurance_companies";
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    companyComboBox.Items.Add(reader["company_name"].ToString());
                }

                reader.Close();
                companyComboBox.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                //MessageBox.Show($"Error: Failed to connect to database: {ex.Message}");
                File.AppendAllText("errorlog.log", $"{DateTime.Now} {ex.Message}\n");
                printReportButton.Enabled = false;
                this.Close();
            }
        }

        private void DateRangeReport_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            startDate = startDatePicker.Value.ToString("yyyy-MM-dd");
            endDate = endDatePicker.Value.ToString("yyyy-MM-dd");
            switch (mode)
            {
                case "totalReceipts": // total receipts
                    printTotalReceipts();
                    break;
                case "totalPayments": // receipts by company
                    /*if (companyComboBox.Text == "")
                    {
                        MessageBox.Show("Please select an insurance company");
                        printReportButton.Enabled = false;
                        return;
                    }
                    else
                    {
                        printTotalPayments();
                    }*/
                    printTotalPayments();
                    break;
                case "cashDrawerTotals": // cash drawer totals
                    printCashDrawerTotals();
                    break;
            }
        }

        private void printTotalReceipts()
        {
            try
            {
                MySqlCommand cmd = parentForm.connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM receipts WHERE receipt_date BETWEEN '" + startDate + "' AND '" + endDate + "';";
                MySqlDataReader reader = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                //MessageBox.Show($"Error: {parentForm.connectionError}");
                File.AppendAllLines("errorlog.log", new string[] { $"{DateTime.Now} {parentForm.connectionError}" });
            }
        }

        private void printTotalPayments()
        {
            try
            {
                MySqlCommand cmd = parentForm.connection.CreateCommand();  
                cmd.CommandText = "SELECT * FROM receipts WHERE receipt_date BETWEEN '" + startDate + "' AND '" + endDate + "' AND remit_to = '" + companyComboBox.Text + "';";
                MySqlDataReader reader = cmd.ExecuteReader();


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {parentForm.connectionError}");
                File.AppendAllLines("errorlog.log", new string[] { $"{DateTime.Now} {parentForm.connectionError}" });
            }
        }

        private void printCashDrawerTotals()
        {
            MessageBox.Show("Printing cash drawer totals report");
        }

        private void companyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mode == "totalPayments")
            {
                if (companyComboBox.Text == "")
                {
                    printReportButton.Enabled = false;
                    selectWarningLabel.Visible = true;
                }
                else
                {
                    printReportButton.Enabled = true;
                    selectWarningLabel.Visible = false;
                }
            }
            
        }
    }
}
