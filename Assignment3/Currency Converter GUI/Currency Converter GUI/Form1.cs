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

        }//end Form1()

        private void cboCurrencyHave_SelectedIndexChanged(object sender, EventArgs e) {
            if (cboCurrencyHave.Text != "") {
                cboCurrencyWant.Enabled = true;
                cboCurrencyHave.Enabled = false;

                // Set currency code label based off selected value
                lblCurrencyCode1.Text = Currency_Exchange_Class.GetCurrencyCode(cboCurrencyHave.SelectedIndex);
            }
        } // end cboCurrencyHave_SelectedIndexChanged()

        private void cboCurrencyWant_SelectedIndexChanged(object sender, EventArgs e) {
            if (cboCurrencyWant.Text != "") {
                txtAmountHave.Enabled = true;
                cboCurrencyWant.Enabled = false;

                // Set currency code label based off selected value
                lblCurrencyCode2.Text = Currency_Exchange_Class.GetCurrencyCode(cboCurrencyWant.SelectedIndex);

                // Make have currency code visible
                lblCurrencyCode1.Visible = true;
            }
        } // end cboCurrencyWant_SelectedIndexChanged()

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
        } // end txtAmountHave_TextChanged()

        private void cmdEquals_Click(object sender, EventArgs e) {

            txtAmountHave.Enabled = false;

            // Make equals button clickable
            cmdEquals.Enabled = false;

            // Make wanted currency code visible
            lblCurrencyCode2.Visible = true;

            // Show converted amount
            txtAmountWant.Text = Currency_Exchange_Class.PerformCurrencyConversion(cboCurrencyHave.SelectedIndex,
                cboCurrencyWant.SelectedIndex, txtAmountHave.Text).ToString();

            // Make Another Conversion options visible
            grpConversion.Visible = true;

        } // end cmdEquals_Click()

        private void optConversion_CheckedChanged(object sender, EventArgs e) {
            if (optConversionYes.Checked) {
                // Clear form of entered values
                ResetConversionForm();

                // Reset another conversion to unchecked state
                ClearConversionRadio();
            } else if (optConversionNo.Checked) {
                ExitProgram();
            }
        } // end optConversion_CheckedChanged()

        private void ClearConversionRadio() {
            optConversionYes.Checked = false;
        } // end ClearConversionRadio

        private void ResetConversionForm() {
            // Reset dropdowns to default value;
            cboCurrencyHave.Text = "";
            cboCurrencyWant.Text = "";

            // Reset amounts to empty input
            txtAmountHave.Text = "";
            txtAmountWant.Text = "";

            // Reset currency code labels to placegholder value
            lblCurrencyCode1.Text = "XXX";
            lblCurrencyCode2.Text = "XXX";

            // Hide currency code labels
            lblCurrencyCode1.Visible = false;
            lblCurrencyCode2.Visible = false;

            // Enable CurrencyHave dropdown again for next conversion
            cboCurrencyHave.Enabled = true;
        } // end ResetConversionForm()

        private void ExitProgram() {
            MessageBox.Show("Thank you for using the Currency Convertor");
            Close();
        } // end ExitProgram()
    }//end class
}
