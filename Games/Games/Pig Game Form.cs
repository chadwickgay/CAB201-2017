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
        }

        private void btnHold_Click(object sender, EventArgs e) {

            SwitchPlayers();

            SetRollMessage();

            DisableHoldButton();
        }

        private void optAnotherGameNo_CheckedChanged(object sender, EventArgs e) {
            ExitProgram();
        }

        private void optAnotherGameYes_CheckedChanged(object sender, EventArgs e) {
            ResetGame();
        }

        // Created Methods

        private void SetDieImage() {
            picDie.Image = Images.GetDieImage(Pig_Single_Die_Game.GetFaceValue());
        }

        private void SwitchPlayers() {
            lblWhoseTurn.Text = Pig_Single_Die_Game.GetNextPlayersName();

            SetRollMessage();
        }

        private void SetRollMessage() {
            lblRollOrHold.Text = "Roll Die";
        }

        private void SetRollOrHoldMessage() {
            lblRollOrHold.Text = "Roll or Hold";          
        }

        private void EnableRollButton() {
            btnRoll.Enabled = true;
        }

        private void DisableRollButton() {
            btnRoll.Enabled = false;
        }

        private void DisableHoldButton() {
            btnHold.Enabled = false;
        }

        private void EnableHoldButton() {
            btnHold.Enabled = true;
        }

        private void SetPlayerScores() {
            txtPlayerOneTotal.Text = Pig_Single_Die_Game.GetPointsTotal("Player 1").ToString();

            txtPlayerTwoTotal.Text = Pig_Single_Die_Game.GetPointsTotal("Player 2").ToString();
        }

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

        private void VictoryMessage() {
            string currentPlayer;

            EndGameRound();

            currentPlayer = lblWhoseTurn.Text.ToString();

            MessageBox.Show(currentPlayer + " has won!\nWell done.");     

        } // end VictoryMessage()

        private void EnableAnotherGame() {
            grpAnotherGame.Enabled = true;
        }

        private void EndGameRound() {
            DisableRollButton();

            DisableHoldButton();

            EnableAnotherGame();
        }

        private void ResetGame() {
            lblWhoseTurn.Text = Pig_Single_Die_Game.GetFirstPLayersName();

            EnableRollButton();

            DisableHoldButton();

            txtPlayerOneTotal.Text = "0";

            txtPlayerTwoTotal.Text = "0";

            optAnotherGameYes.Checked = false;
        }

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
    }
}
