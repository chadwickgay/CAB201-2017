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
    public partial class WhichCardGameForm : Form {
        public WhichCardGameForm() {
            InitializeComponent();

            //Populate Card Games dropdown list
            cboCardGameSelect.DataSource = InitialiseComboBox();
        }

        private void cboCardGameSelect_SelectedIndexChanged(object sender, EventArgs e) {
            // Finish this

            /*
            SolitaireGameForm SolitaireGameForm = new SolitaireGameForm();

            TwentyOneGameForm TwentyOneGameForm = new TwentyOneGameForm();
            */
        }

        private static string[] InitialiseComboBox() {

            string[] games = {   "",
                                 "Solitaire",
                                 "Twenty-One",};

            return games;
        } //end InitialiseComboBox()  

        private void btnExit_Click(object sender, EventArgs e) {
            ExitProgram();
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
    }
}
