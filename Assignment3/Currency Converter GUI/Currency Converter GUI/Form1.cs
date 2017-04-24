using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Currency_Converter_GUI {
    public partial class Form1 : Form {

        public Form1() {
            InitializeComponent();

            cboCurrencyHave.DataSource = Currency_Exchange_Class.InitialiseComboBox();

            cboCurrencyWant.DataSource = Currency_Exchange_Class.InitialiseComboBox();

            cboCurrencyHave.SelectedIndexChanged += new EventHandler(cboCurrencyHave_SelectedIndexChanged);

            cboCurrencyWant.SelectedIndexChanged += new EventHandler(cboCurrencyWant_SelectedIndexChanged);

        }//end Form1

        private void cboCurrencyHave_SelectedIndexChanged(object sender, EventArgs e) {
            if (cboCurrencyHave.Text != "") {
                cboCurrencyWant.Enabled = true;
                cboCurrencyHave.Enabled = false;

                // Set currency code label based off selected value
                lblCurrencyCode1.Text = Currency_Exchange_Class.GetCurrencyCode(cboCurrencyHave.SelectedIndex);
            }
        }

        private void cboCurrencyWant_SelectedIndexChanged(object sender, EventArgs e) {
            if (cboCurrencyWant.Text != "") {
                txtAmountHave.Enabled = true;
                cboCurrencyWant.Enabled = false;

                // Set currency code label based off selected value
                lblCurrencyCode2.Text = Currency_Exchange_Class.GetCurrencyCode(cboCurrencyWant.SelectedIndex);

                // Make have currency code visible
                lblCurrencyCode1.Visible = true;
            }        
        }

        private void txtAmountHave_TextChanged(object sender, EventArgs e) {
            double amountHave;

            bool okay = double.TryParse(txtAmountHave.Text, out amountHave);

            if (txtAmountHave.Text != "") {
                if (!okay) {
                    cmdEquals.Enabled = false;
                    MessageBox.Show("\"Amount I have\" must be a number.");
                } else if (amountHave < 0) {
                    cmdEquals.Enabled = false;
                    MessageBox.Show("Amount entered cannot be less than $0.");
                } else {
                    cmdEquals.Enabled = true;
                }
            }         
        }

        private void cmdEquals_Click(object sender, EventArgs e) {

            txtAmountHave.Enabled = false;

            // Make equals button clickable
            cmdEquals.Enabled = false;

            // Make wanted currency code visible
            lblCurrencyCode2.Visible = true;

            // Make Another Conversion options visible
            grpConversion.Visible = true;       
        }

        private void optConversionYes_CheckedChanged(object sender, EventArgs e) {
            // Reset dropdowns to default value;
            cboCurrencyHave.Text = "";
            cboCurrencyWant.Text = "";

            // Reset amounts to empty input
            txtAmountHave.Text = ""; 
            txtAmountWant.Text = "";

            // Enable CurrencyHave dropdown again for next conversion
            cboCurrencyHave.Enabled = true; 
        }

        private void optConversionNo_CheckedChanged(object sender, EventArgs e) {
            MessageBox.Show("Thank you for using the Currency Convertor");
            Close();
        }
    }//end class
}
