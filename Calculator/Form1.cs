using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void textBox1_Validating(object sender,
                        System.ComponentModel.CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidInput(textBox1.Text, out errorMsg))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                textBox1.Select(0, textBox1.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(textBox1, errorMsg);
            }
        }

        private void textBox1_Validated(object sender, System.EventArgs e)
        {
            // If all conditions have been met, clear the ErrorProvider of errors.
            errorProvider1.SetError(textBox1, "");
        }

        public bool ValidInput(string num1, out string errorMessage)
        {
            if (num1.Length == 0)
            {
                errorMessage = "Number is required.";
                return false;
            }

            if (num1.IndexOf(".") > -1)
            {
                errorMessage = "";
                return true;
            }

            errorMessage = "Number must be decimal (eg. 0.1, 5.23)";
            return false;
        }
        private void btnMultiply_Click(object sender, EventArgs e)
        {
            lblResults.Text = (Convert.ToDecimal(textBox1.Text) * Convert.ToDecimal(textBox2.Text)).ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
