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
    /// <summary>
    /// Name: Chadwick Gay
    /// Student Number: 9410392
    /// </summary>
    public partial class Form1 : Form {

        public Form1() {
            InitializeComponent();

            // Inserted according to assignement specifications
            cboCurrencyHave.DataSource = Currency_Exchange_Class.InitialiseComboBox();
            cboCurrencyWant.DataSource = Currency_Exchange_Class.InitialiseComboBox();

            // Inserted according to assignement specifications
            cboCurrencyHave.SelectedIndexChanged += new EventHandler(cboCurrencyHave_SelectedIndexChanged);
            cboCurrencyWant.SelectedIndexChanged += new EventHandler(cboCurrencyWant_SelectedIndexChanged);

        }//end Form1()

        private void cboCurrencyHave_SelectedIndexChanged(object sender, EventArgs e) {
            
            if (cboCurrencyHave.Text != "") {
                //
                cboCurrencyWant.Enabled = true;
                cboCurrencyHave.Enabled = false;

                // Set currency code label based off selected currency
                lblCurrencyCodeHave.Text = Currency_Exchange_Class.GetCurrencyCode(cboCurrencyHave.SelectedIndex);
            }
        } // end cboCurrencyHave_SelectedIndexChanged()

        private void cboCurrencyWant_SelectedIndexChanged(object sender, EventArgs e) {
            if (cboCurrencyWant.Text != "") {
                //
                txtAmountHave.Enabled = true;
                cboCurrencyWant.Enabled = false;

                // Set currency code label based off selected currency 
                lblCurrencyCodeWant.Text = Currency_Exchange_Class.GetCurrencyCode(cboCurrencyWant.SelectedIndex);

                // Make have currency code visible
                lblCurrencyCodeHave.Visible = true;
            }
        } // end cboCurrencyWant_SelectedIndexChanged()

        private void txtAmountHave_TextChanged(object sender, EventArgs e) {
            ValidateAmountHave(txtAmountHave.Text);
        } // end txtAmountHave_TextChanged()

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputValue"></param>
        private void ValidateAmountHave(string inputValue) {
            double amountHave;

            // Test input is numeric
            bool okay = double.TryParse(inputValue, out amountHave);

            // Error handling for invalid input
            if (inputValue != "") {
                // Number entered not numeric
                if (!okay) {
                    cmdEquals.Enabled = false;
                    MessageBox.Show("\"Amount I have\" must be a number.");
                    // Negative number entered
                } else if (amountHave < 0) {
                    cmdEquals.Enabled = false;
                    MessageBox.Show("Amount entered cannot be less than 0.");
                } else {
                    cmdEquals.Enabled = true;
                }
            }
        }

        private void cmdEquals_Click(object sender, EventArgs e) {
            // Perform currency conversion
            txtAmountWant.Text = Currency_Exchange_Class.PerformCurrencyConversion(cboCurrencyHave.SelectedIndex,
                cboCurrencyWant.SelectedIndex, txtAmountHave.Text).ToString("0.####");

            // Disable ability to change AmountHave
            txtAmountHave.Enabled = false;

            // Make equals button clickable
            cmdEquals.Enabled = false;

            // Make wanted currency code visible
            lblCurrencyCodeWant.Visible = true;

            // Make Another Conversion options visible
            grpConversion.Visible = true;

        } // end cmdEquals_Click()

        private void optConversion_CheckedChanged(object sender, EventArgs e) {
            if (optConversionYes.Checked) {
                // Clear form of entered values
                ResetConversionForm();

                // Reset another conversion to unchecked state
                optConversionYes.Checked = false;
            } else if (optConversionNo.Checked) {
                ExitProgram();
            }
        } // end optConversion_CheckedChanged()


        /// <summary>
        /// 
        /// </summary>
        private void ResetConversionForm() {
            // Reset dropdowns to default value;
            cboCurrencyHave.Text = "";
            cboCurrencyWant.Text = "";

            // Reset amounts to empty input
            txtAmountHave.Text = "";
            txtAmountWant.Text = "";

            // Reset currency code labels to placegholder value
            lblCurrencyCodeHave.Text = "XXX";
            lblCurrencyCodeWant.Text = "XXX";

            // Hide currency code labels
            lblCurrencyCodeHave.Visible = false;
            lblCurrencyCodeWant.Visible = false;

            // Enable CurrencyHave dropdown again for next conversion
            cboCurrencyHave.Enabled = true;
        } // end ResetConversionForm()

        /// <summary>
        /// Prompts user to exit the program gracefully. 
        /// </summary>
        private void ExitProgram() {
            string message = "Thank you for using the Currency Convertor.\n\n Are you sure you want to exit?";
            string caption = "\n\n Currency Convertor.";

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult result = MessageBox.Show(message, caption, buttons);

            // Close program on user confirmation or abort program exit
            if (result == DialogResult.Yes) {
                Close();
            } else {
                optConversionNo.Checked = false;
            }
        } // end ExitProgram()
    }//end class
}
