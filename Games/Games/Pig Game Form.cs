using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Games_Logic_Library;


namespace Games {
    public partial class PigGameForm : Form {

        public PigGameForm() {
            InitializeComponent();

            Pig_Single_Die_Game.SetUpGame();

            SetDieImage();

            lblWhoseTurn.Text = Pig_Single_Die_Game.GetFirstPLayersName().ToString();

            SetRollMessage();

            SetPlayerScores();
        }

        // Created Methods

        /// <summary>
        /// Sets the die image based on the values rolled
        /// </summary>
        private void SetDieImage() {
            picDie.Image = Images.GetDieImage(Pig_Single_Die_Game.GetFaceValue());
        } // end SetDieImage

        /// <summary>
        /// Switches between players - called after each turn
        /// </summary>
        private void SwitchPlayers() {
            lblWhoseTurn.Text = Pig_Single_Die_Game.GetNextPlayersName();

            SetRollMessage();
        }// end SwitchPlayers

        /// <summary>
        /// Sets roll message instruction on form
        /// </summary>
        private void SetRollMessage() {
            lblRollOrHold.Text = "Roll Die";
        }// end SetRollMessage

        /// <summary>
        /// Sets the Roll or Hold message on the form
        /// </summary>
        private void SetRollOrHoldMessage() {
            lblRollOrHold.Text = "Roll or Hold";
        }// end SetRollOrHoldMessage

        /// <summary>
        /// Enables the roll button
        /// </summary>
        private void EnableRollButton() {
            btnRoll.Enabled = true;
        }// end EnableRollButton

        /// <summary>
        /// Disables the roll butoon
        /// </summary>
        private void DisableRollButton() {
            btnRoll.Enabled = false;
        }// end DisableRollButton

        /// <summary>
        /// Disables the hold butoon
        /// </summary>
        private void DisableHoldButton() {
            btnHold.Enabled = false;
        }// end DisableHoldButton

        /// <summary>
        /// Enables the hold butoon
        /// </summary>
        private void EnableHoldButton() {
            btnHold.Enabled = true;
        }// end EnableHoldButton

        /// <summary>
        /// Displays player scores from the Game class on the form
        /// </summary>
        private void SetPlayerScores() {
            txtPlayerOneTotal.Text = Pig_Single_Die_Game.GetPointsTotal("Player 1").ToString();

            txtPlayerTwoTotal.Text = Pig_Single_Die_Game.GetPointsTotal("Player 2").ToString();
        }// end SetPlayerScores

        /// <summary>
        /// Displays end turn message as messagebox.
        /// Players reverted score is displayed.
        /// </summary>
        private void EndTurn() {
            
            string currentPlayer, revertedScore;

            SetPlayerScores();

            currentPlayer = lblWhoseTurn.Text.ToString();

            revertedScore = Pig_Single_Die_Game.GetPointsTotal(currentPlayer).ToString();

            // Finish this part

            MessageBox.Show("Sorry you have thrown a 1." +
                            "\nYour turn is over." +
                            "\nYour score reverts to " + revertedScore);

            SwitchPlayers();
        } // end EndTurn()

        /// <summary>
        /// Displays message box announcing which player won
        /// </summary>
        private void VictoryMessage() {
            string currentPlayer;

            EndGameRound();

            currentPlayer = lblWhoseTurn.Text.ToString();

            MessageBox.Show(currentPlayer + " has won!\nWell done.");     

        } // end VictoryMessage()

        /// <summary>
        /// Enables the another game group box to allow selecting another game or not
        /// </summary>
        private void EnableAnotherGame() {
            grpAnotherGame.Enabled = true;
        }// end EnableAnotherGame

        /// <summary>
        /// Enables/disables set of GUI controls changes at end of round
        /// </summary>
        private void EndGameRound() {
            DisableRollButton();

            DisableHoldButton();

            EnableAnotherGame();
        }// end EndGameRound

        /// <summary>
        /// Resets GUI controls/message for a new game
        /// </summary>
        private void ResetGame() {
            lblWhoseTurn.Text = Pig_Single_Die_Game.GetFirstPLayersName();

            EnableRollButton();

            DisableHoldButton();

            txtPlayerOneTotal.Text = "0";

            txtPlayerTwoTotal.Text = "0";

            optAnotherGameYes.Checked = false;
        }// end ResetGame

        /// <summary>
        /// Prompts user to exit the program gracefully.
        /// User asked to confirm exit with MessageBox.
        /// </summary>
        private void ExitProgram() {
            string message = "Thank you for playing Pig Single Die.\n\n Are you sure you want to exit?";
            string caption = "\n\n Pig Single Die.";

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult result = MessageBox.Show(message, caption, buttons);

            // Close program on user confirmation or abort program exit
            if (result == DialogResult.Yes) {
                Close();
            } else {
                optAnotherGameNo.Checked = false;
            }
        } // end ExitProgram()

        // Event handlers 

        private void btnRoll_Click(object sender, EventArgs e) {

            bool playGame = Pig_Single_Die_Game.PlayGame();

            SetDieImage();

            if (playGame == false) {
                EndTurn();
            } else {

                EnableHoldButton();

                SetRollOrHoldMessage();

                SetPlayerScores();

                if (Pig_Single_Die_Game.HasWon()) {
                    VictoryMessage();
                }
            }
        }// end btnRoll_Click

        private void btnHold_Click(object sender, EventArgs e) {

            SwitchPlayers();

            SetRollMessage();

            DisableHoldButton();
        }// end btnHold_Click

        private void optAnotherGameNo_CheckedChanged(object sender, EventArgs e) {
            ExitProgram();
        }// end optAnotherGameNo_CheckedChanged

        private void optAnotherGameYes_CheckedChanged(object sender, EventArgs e) {
            ResetGame();
        }// end optAnotherGameYes_CheckedChanged
    }
}
