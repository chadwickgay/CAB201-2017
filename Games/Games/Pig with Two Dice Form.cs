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
    public partial class PigWithTwoDiceForm : Form {
        // Variables
        private const int NUM_OF_DICE = 2;
        int timerCounter = 0;
        private static PictureBox[] diceImages;

        // Methods
        public PigWithTwoDiceForm() {
            InitializeComponent();

            diceImages = new PictureBox[] { picDie1, picDie2 };

            Pig_Two_Die_Game.SetUpGame();      
            SetDieImages();
            lblWhoseTurn.Text = Pig_Two_Die_Game.GetFirstPLayersName().ToString();
            SetRollMessage();
            SetPlayerScores();
        }

        // Created Methods
        private void PlayGameRound() {
            // Re-enable Roll button after timer
            EnableRollButton();

            //Play game here
            bool playGame = Pig_Two_Die_Game.PlayGame();
            SetDieImages();

            if (playGame == false) {
                EndTurn();
            } else {

                EnableHoldButton();
                SetRollOrHoldMessage();
                SetPlayerScores();

                if (Pig_Two_Die_Game.HasWon()) {
                    VictoryMessage();
                }
            }
        } // end PlayGameRound()

        private void SetDieImages() {
            for (int i = 0; i < NUM_OF_DICE; i++) {
                diceImages[i].Image = Images.GetDieImage(Pig_Two_Die_Game.GetFaceValue(i));
            }
        }// end SetDieImages()

        private void SwitchPlayers() {
            lblWhoseTurn.Text = Pig_Two_Die_Game.GetNextPlayersName();

            SetRollMessage();
        }//end SwitchPlayers()

        private void SetRollMessage() {
            lblRollOrHold.Text = "Roll Die";
        }//end SetRollMessage()

        private void SetRollOrHoldMessage() {
            lblRollOrHold.Text = "Roll or Hold";
        }//end SetRollOrHoldMessage()

        private void EnableRollButton() {
            btnRoll.Enabled = true;
        }// end EnableRollButton()

        private void DisableRollButton() {
            btnRoll.Enabled = false;
        }// end DisableRollButton()

        private void DisableHoldButton() {
            btnHold.Enabled = false;
        }//end DisableHoldButton()

        private void EnableHoldButton() {
            btnHold.Enabled = true;
        }//end EnableHoldButton()

        private void SetPlayerScores() {
            txtPlayerOneTotal.Text = Pig_Two_Die_Game.GetPointsTotal("Player 1").ToString();

            txtPlayerTwoTotal.Text = Pig_Two_Die_Game.GetPointsTotal("Player 2").ToString();
        }//end SetPlayerScores()

        private void EndTurn() {

            string currentPlayer, revertedScore;

            SetPlayerScores();

            currentPlayer = lblWhoseTurn.Text.ToString();

            revertedScore = Pig_Two_Die_Game.GetPointsTotal(currentPlayer).ToString();

            // Finish this part

            MessageBox.Show("Sorry you have thrown a 1." +
                            "\nYour turn is over." +
                            "\nYour score reverts to " + revertedScore);

            SwitchPlayers();
        } //end EndTurn()

        private void VictoryMessage() {
            string currentPlayer;

            EndGameRound();

            currentPlayer = lblWhoseTurn.Text.ToString();

            MessageBox.Show(currentPlayer + " has won!\nWell done.");

        } //end VictoryMessage()

        private void EnableAnotherGame() {
            grpAnotherGame.Enabled = true;
        }//end EnableAnotherGame()

        private void EndGameRound() {
            DisableRollButton();

            DisableHoldButton();

            EnableAnotherGame();
        }//end EndGameRound()

        private void ResetGame() {
            lblWhoseTurn.Text = Pig_Two_Die_Game.GetFirstPLayersName();

            EnableRollButton();

            DisableHoldButton();

            txtPlayerOneTotal.Text = "0";

            txtPlayerTwoTotal.Text = "0";

            optAnotherGameYes.Checked = false;
        }//end ResetGame()

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

        // Event handler methods
        private void btnRoll_Click(object sender, EventArgs e) {
            timerCounter = 0;
            timer.Start();
            DisableRollButton();
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

        private void timer_Tick(object sender, EventArgs e) {
            int dieOne, dieTwo;
            Random random = new Random();
            timerCounter++;

            if (timerCounter < 11) {
                dieOne = random.Next(1, 6);
                dieTwo = random.Next(1, 6);

                picDie1.Image = Images.GetDieImage(dieOne);
                picDie2.Image = Images.GetDieImage(dieTwo);

            } else {
                timer.Stop();

                PlayGame();
            }
        }
    }
}

