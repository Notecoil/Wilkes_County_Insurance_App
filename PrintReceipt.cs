using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using QuestPDF.Infrastructure;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using System.Drawing.Text;
using System.Globalization;

namespace Wilkes_County_Insurance_App
{
    public partial class PrintReceipt : Form
    {
        ParentForm parentForm = new ParentForm();

        private int receiptID;
        private string receivedFromFirstName;
        private string receivedFromLastName;
        private DateTime receiptDate;
        private string receiptTime;
        private string remit_to;
        private string reference;
        private string transactionDescription;
        private string paymentMethod;
        private decimal paymentAmount;
        private string employeeName;
        private decimal amountTendered;
        private decimal changeDue;

        private int selectedReceiptID;

        string defaultEmployee;

        private System.Windows.Forms.Control[] entryFields;
        private string[] inputStrings;

        private bool editMode = false;


        public PrintReceipt()
        {
            // initializes the form
            InitializeComponent();

            // initializes the UI
            initUI();

            // initializes the entry fields and their corresponding strings
            entryFields = new System.Windows.Forms.Control[] { firstNameTextBox, lastNameTextBox, employeeComboBox, remitToComboBox, referenceTextBox, transactionDescriptionTextBox, paymentAmountTextBox };
            inputStrings = new string[] { "First Name", "Last Name", "User ID", "Remit To", "Reference", "Transaction Description", "Payment Amount" };
        }

        private void employeeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void initUI()
        {
            // initializes the UI
            fillEmployees();
            getDefaultEmployee();
            fillInsuranceCompanies();
            paymentMethodComboBox.SelectedIndex = 0;
            editingReceiptLabel.Visible = false;
            receiptDatePicker.Value = DateTime.Now;

            defaultEmployee = File.ReadAllText(parentForm.defaultUserFileName);
            employeeComboBox.SelectedItem = defaultEmployee;

            amountTenderedLabel.Visible = false;
            amountTenderedTextBox.Visible = false;
            changeDueLabel.Visible = false;
            changeDueTextBox.Visible = false;
            numbersOnlyLabel.Visible = false;
            billPaymentWarningLabel.Visible = false;
            changeDueTextBox.Text = "0.00";

            if (parentForm.connectionError != null)
            {
                MessageBox.Show($"Error: Couldn't connect to the database.\nTry restarting the program or your computer.\nIf the issue still persists contact support.");
                File.AppendAllLines("errorlog.log", new string[] { $"{DateTime.Now} {parentForm.connectionError}" });
                printReceiptButton.Enabled = false;
                editExistingReceiptButton.Enabled = false;
            }
        }

        private void fillEmployees()
        {
            // fills the employeeComboBox with the employees from the database
            try
            {
                MySqlCommand cmd = parentForm.connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM employees";
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    employeeComboBox.Items.Add(reader["first_name"].ToString() + " " + reader["last_name"].ToString());
                }

                reader.Close();

                employeeComboBox.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                //MessageBox.Show($"Error: Failed to connect to database: {ex.Message}");
                File.AppendAllText("errorlog.log", $"{DateTime.Now} {ex.Message}\n");
                printReceiptButton.Enabled = false;
            }
        }

        private void getDefaultEmployee()
        {
            // gets the default employee from the defaultuser file
            string[] defaultEmployee = File.ReadAllLines("defaultuser");

        }

        private void fillInsuranceCompanies()
        {
            // fills the remitToComboBox with the insurance companies from the database
            try
            {
                MySqlCommand cmd = parentForm.connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM insurance_companies";
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    remitToComboBox.Items.Add(reader["company_name"].ToString());
                }

                reader.Close();
                remitToComboBox.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                //MessageBox.Show($"Error: Failed to connect to database: {ex.Message}");
                File.AppendAllText("errorlog.log", $"{DateTime.Now} {ex.Message}\n");
                printReceiptButton.Enabled = false;
            }
        }

        private void printReceiptButton_Click(object sender, EventArgs e)
        {
            // checks if any entry fields are empty

            List<string> emptyFields = new List<string>();
            for (int i = 0; i < entryFields.Length; i++)
            {
                if (entryFields[i].Text == "")
                {
                    emptyFields.Add(inputStrings[i]);
                }
            }

            /// DEPRECATED
            if (billPaymentWarningLabel.Visible == true || numbersOnlyLabel.Visible == true)
            {
                MessageBox.Show("Please provide valid payment amount.");
                return;
            }
            else
            {
                if (paymentMethodComboBox.SelectedItem.ToString() == "Cash" && amountTenderedTextBox.Text == "")
                {

                    emptyFields.Add("Amount Tendered");
                }
                if (emptyFields.Count > 0)
                {
                    // if any entry fields are empty, displays a message box with the empty fields
                    string message = "Please fill out the following fields: ";
                    foreach (string field in emptyFields)
                    {
                        message += field + ", ";
                    }
                    message = message.Remove(message.Length - 2);
                    MessageBox.Show(message);
                    return;
                }
                else
                {
                    getProvidedData();
                }
                QuestPDF.Settings.License = LicenseType.Community;

                /// Allowed the user to provide a path to save the PDF file
                /// DEPRECATED
                /// 

                /*SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                saveFileDialog.FilterIndex = 2;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string path = saveFileDialog.FileName;
                    Debug.WriteLine(path);
                    createPDF(path);
                    try
                    {
                        if (editMode)
                        {
                            editExistingReceipt();
                        }
                        else
                        {
                            saveReceiptToDatabase();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}");
                    }

                    clearFields();
                }*/

                
                try
                {
                    if (editMode)
                    {
                        editExistingReceipt();
                    }
                    else
                    {
                        saveReceiptToDatabase();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
                

                clearFields();
                createPDF();
            }

       

        }

        private void editExistingReceipt()
        {
            // edits an existing receipt in the database
            try
            {
                MySqlCommand cmd = parentForm.connection.CreateCommand();
                if (cmd.Connection.State == ConnectionState.Closed)
                {
                    cmd.Connection.Open();
                }
                cmd.CommandText = $"UPDATE insurancedb.receipts SET received_from_first = '{receivedFromFirstName}', received_from_last = '{receivedFromLastName}', receipt_date = '{receiptDate.ToString("yyyy-MM-dd HH:mm:ss")}', receipt_time = '{receiptTime}', remit_to = '{remit_to}', reference = '{reference}', transaction_description = '{transactionDescription}', payment_method = '{paymentMethod}', payment_amount = {paymentAmount}, cash_paid = {amountTendered}, change_due = {changeDue}, employee_name = '{employeeName}' WHERE receipt_id = {receiptID};";
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //MessageBox.Show($"Error: Failed to connect to database: {ex.Message}");
                File.AppendAllText("errorlog.log", $"{DateTime.Now} {ex.Message}\n");
            }
        }

        private void clearFields()
        {
            // clears all entry fields
            foreach (System.Windows.Forms.Control control in entryFields)
            {
                control.Text = "";
            }
            editMode = false;
            receiptDatePicker.Value = DateTime.Now;
            editingReceiptLabel.Visible = false;
            employeeComboBox.SelectedItem = defaultEmployee;
        }

        private void saveReceiptToDatabase()
        {
            // saves the receipt data to the database
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
                /*cmd.CommandText = $"INSERT INTO insurancedb.receipts(received_from_first, received_from_last, receipt_date, receipt_time, remit_to, reference, transaction_description, payment_method, payment_amount, cash_paid, change_due, employee_name) VALUES ('{receivedFromFirstName}', '{receivedFromLastName}', '{receiptDate.ToString("yyyy-MM-dd HH:mm:ss")}', '{receiptTime}', '{remit_to}', '{reference}', '{transactionDescription}', '{paymentMethod}', {paymentAmount}, {amountTendered}, {changeDue}, '{employeeName}');";*/
                cmd.CommandText = $"INSERT INTO insurancedb.receipts(received_from_first, received_from_last, receipt_date, receipt_time, remit_to, reference, transaction_description, payment_method, payment_amount, cash_paid, change_due, employee_name) VALUES (@receivedFromFirstName, @receivedFromLastName, @receiptDate, @receiptTime, @remit_to, @reference, @transactionDescription, @paymentMethod, {paymentAmount}, {amountTendered}, {changeDue}, '{employeeName}');";
                cmd.Parameters.AddWithValue("@receivedFromFirstName", receivedFromFirstName);
                cmd.Parameters.AddWithValue("@receivedFromLastName", receivedFromLastName);
                cmd.Parameters.AddWithValue("@receiptDate", receiptDate.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@receiptTime", receiptTime);
                cmd.Parameters.AddWithValue("@remit_to", remit_to);
                cmd.Parameters.AddWithValue("@reference", reference);
                cmd.Parameters.AddWithValue("@transactionDescription", transactionDescription);
                cmd.Parameters.AddWithValue("@paymentMethod", paymentMethod);
                cmd.ExecuteNonQuery();

                /// DEPRECATED
                /// Previously updated the cash drawer with the payment amount
                /// But since the cash drawer is no longer in use, this is no longer needed
                /// DEPRECATED
                /*string cashDrawerScript = $"UPDATE cash_drawer SET receipt_item_total = receipt_item_total + 1, receipt_cash_amount = receipt_cash_amount + {paymentAmount} WHERE employee_name = '{employeeName}';";
                cmd.CommandText = cashDrawerScript;
                cmd.ExecuteNonQuery();*/
            }
            catch (Exception ex)
            {
                //MessageBox.Show($"Error: Failed to connect to database: {ex.Message}");
                File.AppendAllText("errorlog.log", $"{DateTime.Now} {ex.Message}\n");
            }
        }

        private void getProvidedData()
        {
            // gets the data provided by the user
            if (editMode)
            {
                receiptID = selectedReceiptID;
            }
            else
            {
                receiptID = getReceiptID();
            }

            // gets the data from the entry fields
            receivedFromFirstName = firstNameTextBox.Text;
            receivedFromLastName = lastNameTextBox.Text;
            
            receiptDate = receiptDatePicker.Value;
            
            receiptTime = receiptDatePicker.Value.ToString("hh:mm:ss tt");

            remit_to = remitToComboBox.SelectedItem.ToString();
            reference = referenceTextBox.Text;
            transactionDescription = transactionDescriptionTextBox.Text;

            paymentMethod = "Cash";

            if (billPaymentWarningLabel.Visible != true)
            {
                try
                {
                    paymentAmount = Convert.ToDecimal(paymentAmountTextBox.Text);
                }
                catch (Exception ex)
                {

                }
            }

            if (paymentMethodComboBox.SelectedItem.ToString() == "Cash")
            {
                try
                {
                    amountTendered = Convert.ToDecimal(amountTenderedTextBox.Text);
                }
                catch (Exception ex)
                {

                }
            }

            if (employeeComboBox.SelectedItem.ToString() != "")
            {
                employeeName = employeeComboBox.SelectedItem.ToString();
            }
            
        }

        /// <summary>
        /// gets and returns the next available receipt_id 
        ///
        /// </summary>
        /// <returns></returns>
        private int getReceiptID()
        {
            // gets the next available receipt ID
            int origionalReceiptID = 0;
            try
            {
                MySqlCommand cmd = parentForm.connection.CreateCommand();
                cmd.CommandText = "SELECT MAX(receipt_id) FROM receipts";
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    origionalReceiptID = Convert.ToInt32(reader["MAX(receipt_id)"]);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                File.AppendAllText("errorlog.log", $"{DateTime.Now} {ex.Message}\n");
            }
            return origionalReceiptID += 1;
        }

        /// <summary>
        /// Creates a PDF receipt using a set of data provided by the user
        /// </summary>
        /// <param name="path"></param>
        private void createPDF(string path="")
        {
            // Create a new PDF document for a receipt
            var document = Document.Create(container =>
            {
                container
                    .Page(page =>
                    {
                        page.Size(PageSizes.A4);
                        page.Margin(2, Unit.Centimetre);
                        page.PageColor(Colors.White);

                        page.Header()
                            .Text("WILKES COUNTY INSURANCE AGENCY\nPO BOX 1386\nNORTH WILKESBORO, NC 28659\nPhone: (336) 838-2600")
                            .AlignCenter()
                            .FontSize(8)
                            .FontFamily(Fonts.Consolas);
                        page.Content().Column(c =>
                        {
                            // 1st table
                            c.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn(1);
                                    columns.RelativeColumn(2);
                                    columns.RelativeColumn(2);
                                    columns.RelativeColumn(1);
                                });

                                // Add left sections
                                table.Cell().Row(1).Column(1).Element(BlockLeft).Text("Received From:").FontFamily(Fonts.Consolas).FontSize(8);
                                table.Cell().Row(1).Column(2).Element(BlockLeft).Text(receivedFromFirstName + " " + receivedFromLastName).FontFamily(Fonts.Consolas).FontSize(8);

                                table.Cell().Row(2).Column(1).Element(BlockLeft).Text("Date:").FontFamily(Fonts.Consolas).FontSize(8);
                                table.Cell().Row(2).Column(2).Element(BlockLeft).Text(receiptDate.ToString("MM/dd/yyyy")).FontFamily(Fonts.Consolas).FontSize(8);

                                table.Cell().Row(3).Column(1).Element(BlockLeft).Text("Time:").FontFamily(Fonts.Consolas).FontSize(8);
                                table.Cell().Row(3).Column(2).Element(BlockLeft).Text(receiptDate.ToString("hh:mm:ss tt")).FontFamily(Fonts.Consolas).FontSize(8);

                                // Add right sections
                                table.Cell().Row(1).Column(3).Element(BlockRight).Text("Receipt #:").FontFamily(Fonts.Consolas).FontSize(8);
                                table.Cell().Row(1).Column(4).Element(BlockRight).Text(receiptID.ToString()).FontFamily(Fonts.Consolas).FontSize(8);

                                table.Cell().Row(2).Column(3).Element(BlockRight).Text("User ID:").FontFamily(Fonts.Consolas).FontSize(8);
                                table.Cell().Row(2).Column(4).Element(BlockRight).Text(employeeName).FontFamily(Fonts.Consolas).FontSize(8);

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
                            });

                            c.Spacing(1, Unit.Centimetre);

                            // 2nd table
                            c.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn(2);
                                    columns.RelativeColumn(1);
                                    columns.RelativeColumn(1);
                                    columns.RelativeColumn(1);
                                    columns.RelativeColumn(1);
                                });

                                // top row
                                table.Cell().Row(1).Column(1).Element(BlockLeft).Text("Remit To").FontFamily(Fonts.Consolas).FontSize(8);
                                table.Cell().Row(1).Column(2).Element(BlockLeft).Text("Reference").FontFamily(Fonts.Consolas).FontSize(8);
                                table.Cell().Row(1).Column(3).Element(BlockLeft).Text("Transaction").FontFamily(Fonts.Consolas).FontSize(8);
                                table.Cell().Row(1).Column(4).Element(BlockLeft).Text("Type").FontFamily(Fonts.Consolas).FontSize(8);
                                table.Cell().Row(1).Column(5).Element(BlockRight).Text("Amount").FontFamily(Fonts.Consolas).FontSize(8);

                                // seperator
                                //table.Cell().ColumnSpan(5).Text("_________________________________________________________________________________________").FontFamily(Fonts.Consolas).FontSize(8);
                                table.Cell().ColumnSpan(5).BorderTop(0.5f);

                                // bottom row
                                table.Cell().Row(2).Column(1).Element(BlockLeft).Text(remit_to).FontFamily(Fonts.Consolas).FontSize(8);
                                table.Cell().Row(2).Column(2).Element(BlockLeft).Text(reference).FontFamily(Fonts.Consolas).FontSize(8);
                                table.Cell().Row(2).Column(3).Element(BlockLeft).Text(transactionDescription).FontFamily(Fonts.Consolas).FontSize(8);
                                table.Cell().Row(2).Column(4).Element(BlockLeft).Text(paymentMethod).FontFamily(Fonts.Consolas).FontSize(8);
                                table.Cell().Row(2).Column(5).Element(BlockRight).Text(paymentAmount.ToString("0.00")).FontFamily(Fonts.Consolas).FontSize(8);

                                table.Cell().Row(3).Column(5).Element(BlockRight).Text(".00").FontFamily(Fonts.Consolas).FontSize(8);
                                table.Cell().Row(4).Column(5).Element(BlockRight).Text(".00").FontFamily(Fonts.Consolas).FontSize(8);
                                table.Cell().Row(5).Column(5).Element(BlockRight).Text(".00").FontFamily(Fonts.Consolas).FontSize(8);
                                table.Cell().Row(6).Column(5).Border(0.5f);

                                // total section
                                table.Cell().Row(7).Column(4).Element(BlockLeft).Text("Total:").FontFamily(Fonts.Consolas).FontSize(8);
                                table.Cell().Row(7).Column(5).Element(BlockRight).Text(paymentAmount.ToString("0.00")).FontFamily(Fonts.Consolas).FontSize(8);
                                table.Cell().Row(8).Column(4).Element(BlockLeft).Text("Amount Tendered:").FontFamily(Fonts.Consolas).FontSize(8);
                                table.Cell().Row(8).Column(5).Element(BlockRight).Text(amountTendered.ToString()).FontFamily(Fonts.Consolas).FontSize(8);
                                table.Cell().Row(9).Column(4).Element(BlockLeft).Text("Change Due:").FontFamily(Fonts.Consolas).FontSize(8);
                                table.Cell().Row(9).Column(5).Element(BlockRight).Text(changeDue.ToString()).FontFamily(Fonts.Consolas).FontSize(8);




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
                            });
                        });
                        // Footer space
                    });
            });
            document.GeneratePdfAndShow();
            //document.GeneratePdf(path);
        }


        /*private void amountTenderedTextBox_TextChanged(object sender, EventArgs e) // DEPRECATED
        {
            changeDueCalc();
            if (numbersOnlyLabel.Visible == true)
            {
                printReceiptButton.Enabled = false;
            }
            else
            {
                printReceiptButton.Enabled = true;
            }
        }*/

        /*private void changeDueCalc() // DEPRECATED
        {
            try
            {
                paymentAmount = Convert.ToDecimal(paymentAmountTextBox.Text);
            }
            catch (Exception ex)
            {
                //MessageBox.Show($"Error: {ex.Message}");
                if (paymentAmountTextBox.Text != "")
                {
                    billPaymentWarningLabel.Visible = true;
                    changeDueTextBox.Text = "0.00";
                }
                else
                {
                    billPaymentWarningLabel.Visible = false;
                    changeDueTextBox.Text = "0.00";
                }
            }
            try
            {
                decimal tendered = Convert.ToDecimal(amountTenderedTextBox.Text);
                numbersOnlyLabel.Visible = false;
                decimal change = tendered - paymentAmount;
                if (change < 0)
                {
                    change = 0;
                }
                changeDue = change;
                changeDueTextBox.Text = change.ToString("C");
            }
            catch (Exception ex)
            {
                //MessageBox.Show($"Error: {ex.Message}");
                if (amountTenderedTextBox.Text != "")
                {
                    numbersOnlyLabel.Visible = true;
                    changeDueTextBox.Text = "0.00";
                }
                else
                {
                    numbersOnlyLabel.Visible = false;
                    changeDueTextBox.Text = "0.00";
                }
            }
        }*/

        private void calcNumber() // checks if the payment amount is a valid number
        {
            try
            {
                paymentAmount = Convert.ToDecimal(paymentAmountTextBox.Text);
                billPaymentWarningLabel.Visible = false;
            }
            catch (Exception ex)
            {
                if (paymentAmountTextBox.Text == "")
                {
                    billPaymentWarningLabel.Visible = false;
                }
                else
                {
                    billPaymentWarningLabel.Visible = true;
                }
            }
        }

        private void paymentAmountTextBox_TextChanged(object sender, EventArgs e)
        {
            // check if the payment amount is a valid number, if not disables the number and prints a warning
            calcNumber();
            if (billPaymentWarningLabel.Visible == true)
            {
                printReceiptButton.Enabled = false;
            }
            else
            {
                printReceiptButton.Enabled = true;
            }
        }

        private void clearFieldsButton_Click(object sender, EventArgs e)
        {
            // clears all entry fields
            clearFields();
        }

        private void editExistingReceiptButton_Click(object sender, EventArgs e)
        {
            // opens the EditReceipt form to select a receipt to edit
            EditReceipt editReceipt = new EditReceipt();
            editReceipt.ShowDialog();

            // if a receipt is selected, fills the entry fields with the selected receipt's data
            selectedReceiptID = editReceipt.selectedReceiptID;
            if (selectedReceiptID != 0)
            {
                MySqlCommand cmd = parentForm.connection.CreateCommand();
                cmd.CommandText = $"SELECT * FROM receipts WHERE receipt_id = {selectedReceiptID};";
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    // fills the entry fields with the selected receipt's data
                    receiptID = selectedReceiptID;
                    firstNameTextBox.Text = reader["received_from_first"].ToString();
                    lastNameTextBox.Text = reader["received_from_last"].ToString();
                    DateTime date = DateTime.Parse(reader["receipt_date"].ToString()); // converts the string from the database to a DateTime object
                    receiptDatePicker.Value = date;
                    remitToComboBox.SelectedItem = reader["remit_to"].ToString();
                    referenceTextBox.Text = reader["reference"].ToString();
                    transactionDescriptionTextBox.Text = reader["transaction_description"].ToString();
                    paymentAmountTextBox.Text = reader["payment_amount"].ToString();
                    employeeComboBox.SelectedItem = reader["employee_name"].ToString();
                }
                // closes the reader
                reader.Close();

                // sets the editMode to true and displays the editingReceiptLabel
                editMode = true;
                editingReceiptLabel.Visible = true;
            }
        }
    }
}
