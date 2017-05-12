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
    public partial class IntitalGUIForm : Form {
        public IntitalGUIForm() {
            InitializeComponent();
        }

        private void optDiceGame_CheckedChanged(object sender, EventArgs e) {
            EnableStart();
        } // end optDiceGame_CheckedChanged

        private void optCardGame_CheckedChanged(object sender, EventArgs e) {
            EnableStart();
        } // end optCardGame_CheckedChanged

        /// <summary>
        /// Enales Start button to be clickable by the user.
        /// </summary>
        private void EnableStart() {
            btnStart.Enabled = true;
        } // end EnableStart

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

        private void btnStart_Click(object sender, EventArgs e) {

            if (optDiceGame.Checked) {
                WhichDiceGameForm DiceGameForm = new WhichDiceGameForm();

                DiceGameForm.Show();
            } else {
                WhichCardGameForm CardGameForm = new WhichCardGameForm();

                CardGameForm.Show();
            }

        }
    }
}
