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
    public partial class ReportsForm : Form
    {
        ParentForm parentForm = new ParentForm();

        public ReportsForm()
        {
            InitializeComponent();

            initUI();
        }

        private void initUI()
        {
            if (parentForm.connectionError != null)
            {
                MessageBox.Show($"Error: Couldn't connect to the database.\nTry restarting the program or your computer.\nIf the issue still persists contact support.");
                File.AppendAllLines("errorlog.log", new string[] { $"{DateTime.Now} {parentForm.connectionError}" });
                foreach (Control control in Controls)
                {
                    control.Enabled = false;
                }   
            }
        }

        private void printTotalReceiptsButton_Click(object sender, EventArgs e)
        {
            DateRangeReport dateRangeReport = new DateRangeReport("totalReceipts");
            dateRangeReport.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateRangeReport dateRangeReport = new DateRangeReport("totalPayments");
            dateRangeReport.Show();
        }

        private void printCashDrawerTotalsButton_Click(object sender, EventArgs e)
        {
            DateRangeReport dateRangeReport = new DateRangeReport("cashDrawerTotals");
            dateRangeReport.Show();
        }
    }
}
