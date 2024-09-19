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
        // Variables
        ParentForm parentForm = new ParentForm();

        public string mode;
        private int pageNumber = 1;
        private DateTime startDate;
        private DateTime endDate;

        private decimal cashAmount;

        private List<string> companies = new List<string>();
        // Variables end

        public DateRangeReport(string mode)
        {
            InitializeComponent();

            this.mode = mode;

            initUI();
        }

        /// <summary>
        /// Initializes the UI based on the mode
        /// </summary>
        private void initUI()
        {

            switch (mode)
            {
                case "totalReceipts": // total receipts
                    this.Text = "Total Receipts Report";
                    break;
                case "totalPayments": // receipts by company
                    this.Text = "Receipts by Company Report";
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


        /// <summary>
        /// Called when the form is loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DateRangeReport_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Determines which report to generate based on the mode and generates the report
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //startDate = startDatePicker.Value.ToString("yyyy-MM-dd");
            //endDate = endDatePicker.Value.ToString("yyyy-MM-dd");
            startDate = startDatePicker.Value;
            endDate = endDatePicker.Value;
            QuestPDF.Settings.License = LicenseType.Community;
            switch (mode)
            {
                case "totalReceipts": // total receipts
                    printTotalReceipts();
                    break;
                case "totalPayments": // receipts by company

                    printTotalPayments();
                    break;
                case "cashDrawerTotals": // cash drawer totals
                    printCashDrawerTotals();
                    break;
            }
        }

        /// <summary>
        /// Creates a PDF report for all of the receipts for the selected date range
        /// </summary>
        private void printTotalReceipts() // TOTAL RECEIPTS FOR DATE RANGE
        {
            try
            {
                MySqlCommand cmd = parentForm.connection.CreateCommand();
                if (cmd.Connection.State == ConnectionState.Open)
                {
                    /// 2024-9-09: Added this line to close the connection before opening it again
                    /// Since for some reason it was thinking a datareader was open.
                    /// I LOVE PROGRAMMING HOLY SHIT THIS IS ANNOYING
                    //cmd.Connection.Open();
                    cmd.Connection.Close();
                    cmd.Connection.Open();
                }
                else if (cmd.Connection.State == ConnectionState.Closed)
                {
                    cmd.Connection.Open();
                }
                cmd.CommandText = "SELECT * FROM receipts WHERE receipt_date BETWEEN '" + startDate.ToString("yyyy-MM-dd 00:00:00") + "' AND '" + endDate.ToString("yyyy-MM-dd 23:59:59") + "';";
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    // create PDF for total reports
                    var document = Document.Create(container =>
                    {
                        container
                            .Page(page =>
                            {
                                page.Size(PageSizes.A4);
                                page.Margin(2, Unit.Centimetre);
                                page.PageColor(Colors.White);

                                // PAGE HEADER
                                page.Header()
                                    .Text("Total Receipts Report")
                                    .AlignCenter()
                                    .FontSize(10)
                                    .FontFamily(Fonts.Consolas);

                                // PAGE CONTENT
                                page.Content().Column(c =>
                                {
                                    c.Spacing(5);
                                    c.Item().Text("Receipts from " + startDate.ToString("MM/dd/yyyy") + " - " + endDate.ToString("MM/dd/yyyy"))
                                        .FontSize(8)
                                        .FontFamily(Fonts.Consolas);

                                    // 1st table
                                    c.Item().Table(table =>
                                    {
                                        table.ColumnsDefinition(columns =>
                                        {
                                            // receipt#
                                            columns.RelativeColumn(1);
                                            // date
                                            columns.RelativeColumn(1);
                                            // received from
                                            columns.RelativeColumn(2);
                                            // reference
                                            columns.RelativeColumn(1);
                                            // description
                                            columns.RelativeColumn(1);
                                            // remit to
                                            columns.RelativeColumn(2);
                                            // amount
                                            columns.RelativeColumn(1);
                                        });

                                        // top row
                                        table.Cell().Row(1).Column(1).Element(BlockLeft).Text("Receipt #").FontFamily(Fonts.Consolas).FontSize(8);
                                        table.Cell().Row(1).Column(2).Element(BlockLeft).Text("Date").FontFamily(Fonts.Consolas).FontSize(8);
                                        table.Cell().Row(1).Column(3).Element(BlockLeft).Text("Received From").FontFamily(Fonts.Consolas).FontSize(8);
                                        table.Cell().Row(1).Column(4).Element(BlockLeft).Text("Reference").FontFamily(Fonts.Consolas).FontSize(8);
                                        table.Cell().Row(1).Column(5).Element(BlockLeft).Text("Description").FontFamily(Fonts.Consolas).FontSize(8);
                                        table.Cell().Row(1).Column(6).Element(BlockLeft).Text("Remit to").FontFamily(Fonts.Consolas).FontSize(8);
                                        table.Cell().Row(1).Column(7).Element(BlockRight).Text("Amount").FontFamily(Fonts.Consolas).FontSize(8);

                                        // top row border
                                        table.Cell().ColumnSpan(7).BorderTop(0.5f);

                                        int rowCount = 1;

                                        int receiptAmount = 0;

                                        //data rows
                                        for (int i = 1; reader.Read(); i++)
                                        {
                                            rowCount++;
                                            receiptAmount++;
                                            string receiptId = reader["receipt_id"].ToString();
                                            DateTime date = DateTime.Parse(reader["receipt_date"].ToString());
                                            string receivedFromFirst = reader["received_from_First"].ToString();
                                            string receivedFromLast = reader["received_from_Last"].ToString();
                                            string receivedFrom = receivedFromFirst + " " + receivedFromLast;
                                            string reference = reader["reference"].ToString();
                                            string description = reader["transaction_description"].ToString();
                                            string remitTo = reader["remit_to"].ToString();
                                            decimal amount = (Decimal)reader["payment_amount"];

                                            cashAmount += amount;

                                            table.Cell().Row((uint)(i + 1)).Column(1).Element(BlockLeft).Text(receiptId).FontFamily(Fonts.Consolas).FontSize(8);
                                            table.Cell().Row((uint)(i + 1)).Column(2).Element(BlockLeft).Text(date.ToString("MM/dd/yyyy")).FontFamily(Fonts.Consolas).FontSize(8);
                                            table.Cell().Row((uint)(i + 1)).Column(3).Element(BlockLeft).Text(receivedFrom).FontFamily(Fonts.Consolas).FontSize(8);
                                            table.Cell().Row((uint)(i + 1)).Column(4).Element(BlockLeft).Text(reference).FontFamily(Fonts.Consolas).FontSize(8);
                                            table.Cell().Row((uint)(i + 1)).Column(5).Element(BlockLeft).Text(description).FontFamily(Fonts.Consolas).FontSize(8);
                                            table.Cell().Row((uint)(i + 1)).Column(6).Element(BlockLeft).Text(remitTo).FontFamily(Fonts.Consolas).FontSize(8);
                                            table.Cell().Row((uint)(i + 1)).Column(7).Element(BlockRight).Text(amount.ToString("0.00")).FontFamily(Fonts.Consolas).FontSize(8);
                                        }

                                        // total row border
                                        table.Cell().ColumnSpan(7).BorderBottom(0.5f);

                                        // total row
                                        c.Spacing(5);
                                        table.Cell().Row((uint)rowCount + 2).Column(6).Element(BlockRight).Text("Total").FontFamily(Fonts.Consolas).FontSize(8);
                                        table.Cell().Row((uint)rowCount + 2).Column(7).Element(BlockRight).Text(cashAmount.ToString("0.00")).FontFamily(Fonts.Consolas).FontSize(8);

                                        // bottom row
                                        /*table.Cell().Row((uint)rowCount + 4).Column(1).Element(BlockLeft).Text("Payment Method").FontFamily(Fonts.Consolas).FontSize(8);
                                        table.Cell().Row((uint)rowCount + 4).Column(2).Element(BlockLeft).Text("Amount of Receipts").FontFamily(Fonts.Consolas).FontSize(8);
                                        table.Cell().Row((uint)rowCount + 4).Column(3).Element(BlockLeft).Text("Amount").FontFamily(Fonts.Consolas).FontSize(8);
                                        table.Cell().Row((uint)rowCount + 4).Column(1).Element(BlockLeft).Text("Cash").FontFamily(Fonts.Consolas).FontSize(8);
                                        table.Cell().Row((uint)rowCount + 4).Column(2).Element(BlockLeft).Text(receiptAmount.ToString()).FontFamily(Fonts.Consolas).FontSize(8);
                                        table.Cell().Row((uint)rowCount + 4).Column(3).Element(BlockRight).Text(cashAmount.ToString("0.00")).FontFamily(Fonts.Consolas).FontSize(8);*/




                                        static QuestPDF.Infrastructure.IContainer BlockLeft(QuestPDF.Infrastructure.IContainer container)
                                        {
                                            return container
                                                .ShowOnce()
                                                .MinWidth(25)
                                                .MinHeight(1)
                                                .AlignLeft();
                                        }

                                        static QuestPDF.Infrastructure.IContainer BlockRight(QuestPDF.Infrastructure.IContainer container)
                                        {
                                            return container
                                                .ShowOnce()
                                                .MinWidth(25)
                                                .MinHeight(1)
                                                .AlignRight();
                                        }
                                    }); // TABLE END


                                }); // PAGE CONTENT END

                            }); // PAGE END
                    }); // DOCUMENT END
                    this.Close();
                    document.GeneratePdfAndShow();
                    
                }
                else
                {
                    MessageBox.Show("No receipts found for the selected date range");
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                //MessageBox.Show($"Error: {parentForm.connectionError}");
                File.AppendAllLines("errorlog.log", new string[] { $"{DateTime.Now} {ex.Message}" });
            }
        }

        /// <summary>
        /// Merges all of the reports for each company in the companies list and generates a PDF
        /// </summary>
        private void printTotalPayments() // receipts by company
        {
            List<Document> reports = new List<Document>();
            try // gets companies
            {
                MySqlCommand mySqlCommand = parentForm.connection.CreateCommand();
                if (mySqlCommand.Connection.State == ConnectionState.Open)
                {
                    /// 2024-9-09: Added this line to close the connection before opening it again
                    /// Since for some reason it was thinking a datareader was open.
                    /// I LOVE PROGRAMMING HOLY SHIT THIS IS ANNOYING
                    //cmd.Connection.Open();
                    mySqlCommand.Connection.Close();
                    mySqlCommand.Connection.Open();
                }
                else if (mySqlCommand.Connection.State == ConnectionState.Closed)
                {
                    mySqlCommand.Connection.Open();
                }
                mySqlCommand.CommandText = $"SELECT DISTINCT remit_to FROM receipts WHERE receipt_date BETWEEN '{startDate.ToString("yyyy-MM-dd 00:00:00")}' AND '{endDate.ToString("yyyy-MM-dd 23:59:59")}'";
                MySqlDataReader reader = mySqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        companies.Add(reader["remit_to"].ToString());
                    }
                    reader.Close();

                    foreach (var company in companies)
                    {
                        try
                        {
                            reports.Add(generateReport(company));

                        }
                        catch (Exception ex)
                        {
                            File.AppendAllLines("errorlog.log", new string[] { $"{DateTime.Now} {ex.Message} companies loop" });
                        }
                    }
                    // merge all reports
                    var document = Document.Merge(reports);
                    this.Close();
                    document.GeneratePdfAndShow();
                    
                }
                else
                {
                    MessageBox.Show("No receipts found for the selected date range");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                File.AppendAllLines("errorlog.log", new string[] { $"{DateTime.Now} {ex.Message}" });
            }



        } // END OF FUNCTION

        /// <summary>
        /// Creates a PDF report for all of the companies 
        /// in the companies list with the receipts for the 
        /// selected date range and returns the document
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        Document generateReport(string company)
        {
            decimal cashAmount = 0;

            var document = Document.Create(container =>
            {
                /// creating the connection and reader here because the document isn't created when initially adding this document to a list of documents
                /// but it is created when generating the pdf and showing it
                /// FOR SOME FUCKING REASON I LOVE PROGRAMMING AND ITS
                /// BULLLSHIT
                MySqlCommand cmd = parentForm.connection.CreateCommand();
                if (cmd.Connection.State == ConnectionState.Open)
                {
                    /// 2024-9-09: Added this line to close the connection before opening it again
                    /// Since for some reason it was thinking a datareader was open.
                    /// I LOVE PROGRAMMING HOLY SHIT THIS IS ANNOYING
                    //cmd.Connection.Open();
                    cmd.Connection.Close();
                    cmd.Connection.Open();
                }
                else if (cmd.Connection.State == ConnectionState.Closed)
                {
                    cmd.Connection.Open();
                }
                cmd.CommandText = "SELECT * FROM receipts WHERE receipt_date BETWEEN '" + startDate.ToString("yyyy-MM-dd 00:00:00") + "' AND '" + endDate.ToString("yyyy-MM-dd 23:59:59") + "' AND remit_to = '" + company + "';";
                MySqlDataReader reader = cmd.ExecuteReader();
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);

                    // PAGE HEADER
                    page.Header()
                        .PaddingBottom(0.5f, Unit.Centimetre)
                        .Text($"Date: {startDate.ToString("MM/dd/yyyy")} - {endDate.ToString("MM/dd/yyyy")}\nAgent: WILKES COUNTY INSURANCE AGENCY\nRemit to: {company}")
                        .FontSize(8)
                        .FontFamily(Fonts.Consolas);

                    // PAGE CONTENT
                    page.Content().Column(c =>
                    {
                        c.Spacing(5);

                        // 1st table
                        c.Item().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                // receipt#
                                columns.RelativeColumn(1);
                                // date
                                columns.RelativeColumn(1);
                                // received from
                                columns.RelativeColumn(2);
                                // reference
                                columns.RelativeColumn(1);
                                // description
                                columns.RelativeColumn(1);
                                // payment method
                                columns.RelativeColumn(2);
                                // amount
                                columns.RelativeColumn(1);
                            }); // COLUMNS END 7 COLUMNS

                            // top row
                            table.Cell().Row(1).Column(1).Element(BlockLeft).Text("Receipt #").FontFamily(Fonts.Consolas).FontSize(8);
                            table.Cell().Row(1).Column(2).Element(BlockLeft).Text("Date").FontFamily(Fonts.Consolas).FontSize(8);
                            table.Cell().Row(1).Column(3).Element(BlockLeft).Text("Received From").FontFamily(Fonts.Consolas).FontSize(8);
                            table.Cell().Row(1).Column(4).Element(BlockLeft).Text("Reference").FontFamily(Fonts.Consolas).FontSize(8);
                            table.Cell().Row(1).Column(5).Element(BlockLeft).Text("Description").FontFamily(Fonts.Consolas).FontSize(8);
                            table.Cell().Row(1).Column(6).Element(BlockLeft).Text("Payment Method").FontFamily(Fonts.Consolas).FontSize(8);
                            table.Cell().Row(1).Column(7).Element(BlockRight).Text("Amount").FontFamily(Fonts.Consolas).FontSize(8);

                            // top row border
                            table.Cell().ColumnSpan(7).BorderTop(0.5f);


                            int rowCount = 1;

                            for (int i = 1; reader.Read(); i++)
                            {
                                rowCount++;
                                string receiptId = reader["receipt_id"].ToString();
                                DateTime date = DateTime.Parse(reader["receipt_date"].ToString());
                                string receivedFromFirst = reader["received_from_first"].ToString();
                                string receivedFromLast = reader["received_from_last"].ToString();
                                string receivedFrom = receivedFromFirst + " " + receivedFromLast;
                                string reference = reader["reference"].ToString();
                                string description = reader["transaction_description"].ToString();
                                decimal amount = (Decimal)reader["payment_amount"];

                                cashAmount += amount;

                                table.Cell().Row((uint)(i + 1)).Column(1).Element(BlockLeft).Text(receiptId).FontFamily(Fonts.Consolas).FontSize(8);
                                table.Cell().Row((uint)(i + 1)).Column(2).Element(BlockLeft).Text(date.ToString("MM/dd/yyyy")).FontFamily(Fonts.Consolas).FontSize(8);
                                table.Cell().Row((uint)(i + 1)).Column(3).Element(BlockLeft).Text(receivedFrom).FontFamily(Fonts.Consolas).FontSize(8);
                                table.Cell().Row((uint)(i + 1)).Column(4).Element(BlockLeft).Text(reference).FontFamily(Fonts.Consolas).FontSize(8);
                                table.Cell().Row((uint)(i + 1)).Column(5).Element(BlockLeft).Text(description).FontFamily(Fonts.Consolas).FontSize(8);
                                table.Cell().Row((uint)(i + 1)).Column(6).Element(BlockLeft).Text("Cash").FontFamily(Fonts.Consolas).FontSize(8);
                                table.Cell().Row((uint)(i + 1)).Column(7).Element(BlockRight).Text(amount.ToString("0.00")).FontFamily(Fonts.Consolas).FontSize(8);
                            } // END OF DATA FOR LOOP



                            // total row border
                            table.Cell().ColumnSpan(7).BorderBottom(0.5f);

                            // total row
                            c.Spacing(5);
                            table.Cell().Row((uint)rowCount + 2).Column(6).Element(BlockRight).Text("Total").FontFamily(Fonts.Consolas).FontSize(8);
                            table.Cell().Row((uint)rowCount + 2).Column(7).Element(BlockRight).Text(cashAmount.ToString("0.00")).FontFamily(Fonts.Consolas).FontSize(8);


                            static QuestPDF.Infrastructure.IContainer BlockLeft(QuestPDF.Infrastructure.IContainer container)
                            {
                                return container
                                    .ShowOnce()
                                    .MinWidth(25)
                                    .MinHeight(1)
                                    .AlignLeft();
                            }

                            static QuestPDF.Infrastructure.IContainer BlockRight(QuestPDF.Infrastructure.IContainer container)
                            {
                                return container
                                    .ShowOnce()
                                    .MinWidth(25)
                                    .MinHeight(1)
                                    .AlignRight();
                            }
                        }); //TABLE END

                    }); // PAGE CONTENT END

                    // PAGE FOOTER
                    /*page.Footer()
                        .AlignCenter()
                        .Text(text =>
                        {
                            text.DefaultTextStyle(TextStyle.Default.FontSize(6));
                            text.DefaultTextStyle(TextStyle.Default.FontFamily(Fonts.Consolas));
                            text.Span($"Page {pageNumber}");
                        });
                    pageNumber++;*/
                }); // PAGE END
                reader.Close();
            }); // DOCUMENT END
            //reader.Close();
            return document;
        }

        /// <summary>
        /// Creates a PDF report for the cash drawer totals for the selected date range
        /// </summary>
        private void printCashDrawerTotals() // CASH DRAWER / RECEIPTS PER USER
        {
            try
            {
                MySqlCommand cmd = parentForm.connection.CreateCommand();
                if (cmd.Connection.State == ConnectionState.Open)
                {
                    /// 2024-9-09: Added this line to close the connection before opening it again
                    /// Since for some reason it was thinking a datareader was open.
                    /// I LOVE PROGRAMMING HOLY SHIT THIS IS ANNOYING
                    //cmd.Connection.Open();
                    cmd.Connection.Close();
                    cmd.Connection.Open();
                }
                else if (cmd.Connection.State == ConnectionState.Closed)
                {
                    cmd.Connection.Open();
                }
                //cmd.CommandText = "SELECT * FROM receipts WHERE receipt_date BETWEEN '" + startDate.ToString("yyyy-MM-dd 00:00:00") + "' AND '" + endDate.ToString("yyyy-MM-dd 23:59:59") + "';";
                cmd.CommandText = $"SELECT employee_name, COUNT(*) AS items, SUM(payment_amount) AS amount FROM receipts WHERE receipt_date BETWEEN '{startDate.ToString("yyyy-MM-dd 00:00:00")}' AND '{endDate.ToString("yyyy-MM-dd 23:59:59")}' GROUP BY employee_name;";
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    // create PDF for total reports
                    var document = Document.Create(container =>
                    {
                        container
                            .Page(page =>
                            {
                                page.Size(PageSizes.A4);
                                page.Margin(2, Unit.Centimetre);
                                page.PageColor(Colors.White);

                                // PAGE HEADER
                                page.Header()
                                    .PaddingBottom(0.5f, Unit.Centimetre)
                                    .Text($"WILKES COUNTY INS AGENCY\nCash Drawer Totals per User\nDate: {startDate.ToString("MM/dd/yyyy")} - {endDate.ToString("MM/dd/yyyy")}")
                                    .FontSize(10)
                                    .FontFamily(Fonts.Consolas);

                                // PAGE CONTENT
                                page.Content().Column(c =>
                                {
                                    c.Spacing(5);
                                    

                                    // 1st table
                                    c.Item().Table(table =>
                                    {
                                        table.ColumnsDefinition(columns =>
                                        {
                                            // employee name
                                            columns.RelativeColumn(1);
                                            // payment method
                                            columns.RelativeColumn(2);
                                            // items
                                            columns.RelativeColumn(1);
                                            // amount total
                                            columns.RelativeColumn(1);
                                        });

                                        // top row
                                        table.Cell().Row(1).Column(1).Element(BlockLeft).Text("User ID").FontFamily(Fonts.Consolas).FontSize(10);
                                        table.Cell().Row(1).Column(2).Element(BlockLeft).Text("Payment Method").FontFamily(Fonts.Consolas).FontSize(10);
                                        table.Cell().Row(1).Column(3).Element(BlockLeft).Text("# Receipts").FontFamily(Fonts.Consolas).FontSize(10);
                                        table.Cell().Row(1).Column(4).Element(BlockRight).Text("Amount").FontFamily(Fonts.Consolas).FontSize(10);

                                        // top row border
                                        table.Cell().ColumnSpan(4).BorderTop(0.5f);

                                        int rowCount = 1;

                                        //data rows
                                        for (int i = 1; reader.Read(); i++)
                                        {
                                            rowCount++;
                                            string employeeName = reader["employee_name"].ToString();
                                            string items = reader["items"].ToString();
                                            decimal amount = (Decimal)reader["amount"];

                                            table.Cell().Row((uint)(i + 1)).Column(1).Element(BlockLeft).Text(employeeName).FontFamily(Fonts.Consolas).FontSize(10);
                                            table.Cell().Row((uint)(i + 1)).Column(2).Element(BlockLeft).Text("Cash").FontFamily(Fonts.Consolas).FontSize(10);
                                            table.Cell().Row((uint)(i + 1)).Column(3).Element(BlockLeft).Text(items.ToString()).FontFamily(Fonts.Consolas).FontSize(10);
                                            table.Cell().Row((uint)(i + 1)).Column(4).Element(BlockRight).Text(amount.ToString("0.00")).FontFamily(Fonts.Consolas).FontSize(10);
                                            table.Cell().Row((uint)(i + 1)).PaddingBottom(0.5f, Unit.Centimetre);
                                        }

                                        static QuestPDF.Infrastructure.IContainer BlockLeft(QuestPDF.Infrastructure.IContainer container)
                                        {
                                            return container
                                                .ShowOnce()
                                                .MinWidth(25)
                                                .MinHeight(1)
                                                .AlignLeft();
                                        }

                                        static QuestPDF.Infrastructure.IContainer BlockRight(QuestPDF.Infrastructure.IContainer container)
                                        {
                                            return container
                                                .ShowOnce()
                                                .MinWidth(25)
                                                .MinHeight(1)
                                                .AlignRight();
                                        }
                                    }); // TABLE END
                                }); // PAGE CONTENT END
                            }); // PAGE END
                    }); // DOCUMENT END
                    this.Close();
                    document.GeneratePdfAndShow();
                }
                else
                {
                    MessageBox.Show("No receipts found for the selected date range");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show($"Error: {parentForm.connectionError}");
                File.AppendAllLines("errorlog.log", new string[] { $"{DateTime.Now} {ex.Message}" });
            }
        }

      
        /// <summary>
        /// Closes the form when the back button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
