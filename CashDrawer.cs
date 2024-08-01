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
using QuestPDF.Infrastructure;
using QuestPDF.Fluent;
using QuestPDF.Helpers;

namespace Wilkes_County_Insurance_App
{
    public partial class CashDrawer : Form
    {
        ParentForm parentForm = new ParentForm();

        public CashDrawer()
        {
            InitializeComponent();

            initUI();
        }

        private void initUI()
        {
            dataInit();
        }

        private void dataInit()
        {
            /*string employeeNames = "SELECT DISTINCT employee_name FROM receipts";
            MySqlCommand cmd = parentForm.connection.CreateCommand();
            cmd.CommandText = employeeNames;
            MySqlDataReader reader = cmd.ExecuteReader();
            List<string> employeeList = new List<string>();
            while (reader.Read())
            {
                employeeList.Add(reader.GetString(0));
            }*/

            MySqlCommand cmd = parentForm.connection.CreateCommand();
            cmd.CommandText = "SELECT employee_name, payment_method, COUNT(*), CONCAT('$', FORMAT(SUM(payment_amount), 2, 'en_US')) FROM receipts WHERE payment_method='Cash' GROUP BY employee_name;";
            //MySqlDataReader reader = cmd.ExecuteReader();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataTable table = new DataTable();
            adapter.Fill(table);
            BindingSource source = new BindingSource();
            source.DataSource = table;
            drawerAmountDataView.DataSource = source;

            

            drawerAmountDataView.Columns[0].HeaderText = "Employee ID";
            drawerAmountDataView.Columns[1].HeaderText = "Payment Method";
            drawerAmountDataView.Columns[2].HeaderText = "Number of Transactions";
            drawerAmountDataView.Columns[3].HeaderText = "Total Amount";

            //drawerAmountDataView.RowTemplate.Height = 25;

            /*var height = drawerAmountDataView.ColumnHeadersHeight;

            foreach (DataGridViewRow row in drawerAmountDataView.Rows)
            {
                height += row.Height;
            }

            drawerAmountDataView.Height = height;*/
        }
    }
}
