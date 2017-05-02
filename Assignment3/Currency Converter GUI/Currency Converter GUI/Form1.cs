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
    /// GUI driven program that allows user to convert from 
    /// one selected currency to another selected currency.
    /// 
    /// Upon completetion of conversion user can reset form 
    /// and perform multiple currency conversions.
    /// 
    /// Author Chadwick Gay May 2017 - Student Number: 9410392
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
            // If a selection has been made from the cbo
            if (cboCurrencyHave.Text != "") {
                cboCurrencyWant.Enabled = true;
                cboCurrencyHave.Enabled = false;

                // Set currency have code label based off selected currency
                lblCurrencyCodeHave.Text = Currency_Exchange_Class.GetCurrencyCode(cboCurrencyHave.SelectedIndex);
            }
        } // end cboCurrencyHave_SelectedIndexChanged()

        private void cboCurrencyWant_SelectedIndexChanged(object sender, EventArgs e) {
            // If a selection has been made from the cbo
            if (cboCurrencyWant.Text != "") {
                txtAmountHave.Enabled = true;
                cboCurrencyWant.Enabled = false;

                // Set currency wanted code label based off selected currency 
                lblCurrencyCodeWant.Text = Currency_Exchange_Class.GetCurrencyCode(cboCurrencyWant.SelectedIndex);

                lblCurrencyCodeHave.Visible = true;
            }
        } // end cboCurrencyWant_SelectedIndexChanged()

        private void txtAmountHave_TextChanged(object sender, EventArgs e) {
            ValidateAmountInput(txtAmountHave.Text);
        } // end txtAmountHave_TextChanged()

        private void btnEquals_Click(object sender, EventArgs e) {
            // Call PerformCurrencyConversion to convert amount according to currency provided
            txtAmountWant.Text = Currency_Exchange_Class.PerformCurrencyConversion(cboCurrencyHave.SelectedIndex,
                cboCurrencyWant.SelectedIndex, txtAmountHave.Text).ToString("0.####");

            // Lock input in amount have field from being changed
            txtAmountHave.Enabled = false;

            // Make equals button unclickable
            btnEquals.Enabled = false;

            // Show currency wanted currency code
            lblCurrencyCodeWant.Visible = true;

            // Show another conversion options
            grpConversion.Visible = true;
        } // end btnEquals_Click()

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
        /// Validates Amount input by the user. Shows relevant error message with MessageBox on invalid input.
        /// Only enables user to proceed if value entered is a non-negative  number.
        /// If amount entered is non-negative number, equals button is enabled for the user.
        /// </summary>
        /// <param name="inputValue">Value to to validated as non-negative number</param>
        private void ValidateAmountInput(string inputValue) {
            double amountHave;

            // Test input is numeric
            bool okay = double.TryParse(inputValue, out amountHave);

            // Error handling for invalid input
            if (inputValue != "") {
                // If value entered not numeric
                if (!okay) {
                    btnEquals.Enabled = false;
                    MessageBox.Show("\"Amount I have\" must be a number.");
                // If negative number entered
                } else if (amountHave < 0) {
                    btnEquals.Enabled = false;
                    MessageBox.Show("Amount entered cannot be less than 0.");
                } else {
                    btnEquals.Enabled = true;
                }
            }
        }

        /// <summary>
        /// Resets the Currency Conversion to default state pre any user entry.
        /// Allows user to perform multiple conversions.
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
        /// User asked to confirm exit with MessageBox.
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
