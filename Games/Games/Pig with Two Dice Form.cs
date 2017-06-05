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

        private const int NUM_OF_DICE = 2;
        int timerCounter = 0;
        private static PictureBox[] diceImages;

        public PigWithTwoDiceForm() {
            InitializeComponent();

            diceImages = new PictureBox[] { picDie1, picDie2 };

            // Calls Game class method to setup the initial game parameters
            Pig_Two_Die_Game.SetUpGame();   
               
            SetDieImages();
            DisplayFirstPlayerName();
            SetRollMessage();
            SetPlayerScores();
        }

        /// <summary>
        /// Calls PlayGame from Game class to play single round of rolls
        /// Determinesif player has won after each roll by calling HasWon from Game class
        /// </summary>
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
        } // end PlayGameRound

        /// <summary>
        /// Sets the die images based on the values rolled
        /// </summary>
        private void SetDieImages() {
            for (int i = 0; i < NUM_OF_DICE; i++) {
                diceImages[i].Image = Images.GetDieImage(Pig_Two_Die_Game.GetFaceValue(i));
            }
        }// end SetDieImages

        /// <summary>
        /// Switches between players - called after each turn
        /// </summary>
        private void SwitchPlayers() {
            lblWhoseTurn.Text = Pig_Two_Die_Game.GetNextPlayersName();

            SetRollMessage();
        }//end SwitchPlayer  

        /// <summary>
        /// Displays player scores from the Game class in the GUI
        /// </summary>
        private void SetPlayerScores() {
            txtPlayerOneTotal.Text = Pig_Two_Die_Game.GetPointsTotal("Player 1").ToString();

            txtPlayerTwoTotal.Text = Pig_Two_Die_Game.GetPointsTotal("Player 2").ToString();
        }//end SetPlayerScores

        /// <summary>
        /// Displays end turn message as messagebox.
        /// Players reverted score is displayed.
        /// </summary>
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
        } //end EndTurn

        /// <summary>
        /// Displays message box announcing which player won
        /// </summary>
        private void VictoryMessage() {
            string currentPlayer;

            EndGameRound();

            currentPlayer = lblWhoseTurn.Text.ToString();

            MessageBox.Show(currentPlayer + " has won!\nWell done.");

        } //end VictoryMessage

        /// <summary>
        /// Resets GUI controls/message for a new game
        /// </summary>
        private void ResetGame() {
            DisplayFirstPlayerName();

            EnableRollButton();

            DisableHoldButton();

            txtPlayerOneTotal.Text = "0";

            txtPlayerTwoTotal.Text = "0";

            optAnotherGameYes.Checked = false;
        }//end ResetGame

        /// <summary>
        /// Prompts user to exit the program gracefully.
        /// User asked to confirm exit with MessageBox.
        /// </summary>
        private void ExitProgram() {
            string message = "Thank you for playing Pig Game with Two Die.\n\n Are you sure you want to exit?";
            string caption = "\n\n Pig Game with Two Die.";

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult result = MessageBox.Show(message, caption, buttons);

            // Close program on user confirmation or abort program exit
            if (result == DialogResult.Yes) {
                Close();
            } else {
                optAnotherGameNo.Checked = false;
            }
        } // end ExitProgram

        /// <summary>
        /// Displays the name of the first player - used at start of new game
        /// </summary>
        public void DisplayFirstPlayerName() {
            lblWhoseTurn.Text = Pig_Two_Die_Game.GetFirstPLayersName();
        } // DisplayFirstPlayerName

        /// <summary>
        /// Sets roll message instruction in GUI
        /// </summary>
        private void SetRollMessage() {
            lblRollOrHold.Text = "Roll Die";
        }//end SetRollMessage

        /// <summary>
        /// Sets roll or hold message instruction in GUI
        /// </summary>
        private void SetRollOrHoldMessage() {
            lblRollOrHold.Text = "Roll or Hold";
        }//end SetRollOrHoldMessage

        /// <summary>
        /// Enables the roll butoon
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
        /// Enables the hold button
        /// </summary>
        private void EnableHoldButton() {
            btnHold.Enabled = true;
        }//end EnableHoldButton

        /// <summary>
        /// Diables the hold button
        /// </summary>
        private void DisableHoldButton() {
            btnHold.Enabled = false;
        }//end DisableHoldButton

        /// <summary>
        /// Enables the another game group box to allow selecting another game or not
        /// </summary>
        private void EnableAnotherGame() {
            grpAnotherGame.Enabled = true;
        }//end EnableAnotherGame

        /// <summary>
        /// Enables/disables set of GUI controls changes at end of round
        /// </summary>
        private void EndGameRound() {
            DisableRollButton();

            DisableHoldButton();

            EnableAnotherGame();
        }//end EndGameRound

        private void btnRoll_Click(object sender, EventArgs e) {
            timerCounter = 0;
            timer.Start();
            DisableRollButton();
        } // end btnRoll_Click

        private void btnHold_Click(object sender, EventArgs e) {
            SwitchPlayers();
            SetRollMessage();
            DisableHoldButton();
        } // end btnHold_Click

        private void optAnotherGameNo_CheckedChanged(object sender, EventArgs e) {
            ExitProgram();
        } // end optAnotherGameNo_CheckedChanged

        private void optAnotherGameYes_CheckedChanged(object sender, EventArgs e) {
            ResetGame();
        } // end optAnotherGameYes_CheckedChanged

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

                PlayGameRound();
            }
        } // end timer_Tick
    }
}

