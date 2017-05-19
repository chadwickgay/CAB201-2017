using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Games {
    public partial class WhichDiceGameForm : Form {
        public WhichDiceGameForm() {
            InitializeComponent();
        }

        private void optSingleDiePig_CheckedChanged(object sender, EventArgs e) {

            if (optSingleDiePig.Checked) {
                PigGameForm PigGameForm = new PigGameForm();

                PigGameForm.Show();
            }

            // reset back to uncheck to allow re-selection on exit
            optSingleDiePig.Checked = false;          
        }

        private void optTwoDicePig_CheckedChanged(object sender, EventArgs e) {

            if (optTwoDicePig.Checked) {
                PigWithTwoDiceForm PigGameWithTwoDiceForm = new PigWithTwoDiceForm();

                PigGameWithTwoDiceForm.Show();
            }
            // reset back to uncheck to allow re-selection on exit
            optTwoDicePig.Checked = false;      
        }

        /// <summary>
        /// Prompts user to exit the program gracefully.
        /// User asked to confirm exit with MessageBox.
        /// </summary>
        private void ExitProgram() {
            string message = "Do you really want to quit?";
            string caption = "Quit?";

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult result = MessageBox.Show(message, caption, buttons);

            // Close program on user confirmation or abort program exit
            if (result == DialogResult.Yes) {
                Close();
            }
        } // end ExitProgram()

        private void btnExit_Click(object sender, EventArgs e) {
            ExitProgram();
        }
    }
}
