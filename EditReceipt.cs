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
    public partial class EditReceipt : Form
    {
        ParentForm parentForm = new ParentForm();

        public int selectedReceiptID;

        public EditReceipt()
        {
            InitializeComponent();

            initUI();
        }

        private void initUI()
        {
            receiptDataView.AutoSize = true;
            receiptDataView.MultiSelect = false;
            receiptDataView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            receiptDataView.CurrentCell = null;
            dataInit();
        }

        private void dataInit()
        {
            try
            {
                MySqlCommand cmd = parentForm.connection.CreateCommand();
                cmd.CommandText = $"SELECT receipt_id, CONCAT(received_from_first, ' ', received_from_last) AS name, DATE_FORMAT(receipt_date, '%m/%d/%Y'), remit_to, reference, transaction_description, payment_amount, employee_name FROM receipts;";
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataTable table = new DataTable();
                adapter.Fill(table);
                BindingSource source = new BindingSource();
                source.DataSource = table;
                receiptDataView.DataSource = source;

                receiptDataView.Columns[0].HeaderText = "Receipt ID";
                receiptDataView.Columns[1].HeaderText = "Received From";
                receiptDataView.Columns[2].HeaderText = "Receipt Date";
                receiptDataView.Columns[3].HeaderText = "Remit To";
                receiptDataView.Columns[4].HeaderText = "Reference";
                receiptDataView.Columns[5].HeaderText = "Transaction Description";
                receiptDataView.Columns[6].HeaderText = "Payment Amount";
                receiptDataView.Columns[7].HeaderText = "Employee Name";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {parentForm.connectionError}");
                File.AppendAllLines("errorlog.log", new string[] { $"{DateTime.Now} {parentForm.connectionError}" });
            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                MySqlCommand cmd = parentForm.connection.CreateCommand();
                cmd.CommandText = "SELECT receipt_id, CONCAT(received_from_first, ' ', received_from_last) AS name, receipt_date, remit_to, reference, transaction_description, payment_amount, employee_name FROM receipts WHERE CONCAT(received_from_first, ' ', received_from_last) LIKE '%" + textBox1.Text + "%';";
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataTable table = new DataTable();
                adapter.Fill(table);
                BindingSource source = new BindingSource();
                source.DataSource = table;
                receiptDataView.DataSource = source;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {parentForm.connectionError}");
                File.AppendAllLines("errorlog.log", new string[] { $"{DateTime.Now} {parentForm.connectionError}" });
            }


        }

        private void selectReceiptButton_Click(object sender, EventArgs e)
        {
            selectedReceiptID = Convert.ToInt32(receiptDataView.SelectedRows[0].Cells[0].Value);
            this.Close();

        }

        /*void EditReceipt_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                selectedReceiptID = Convert.ToInt32(receiptDataView.SelectedRows[0].Cells[0].Value);
                this.Close();
            }
        }*/
        private void receiptDataView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                selectedReceiptID = Convert.ToInt32(receiptDataView.SelectedRows[0].Cells[0].Value);
                this.Close();
            }
        }

        void EditReceipt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void exitWindowButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
