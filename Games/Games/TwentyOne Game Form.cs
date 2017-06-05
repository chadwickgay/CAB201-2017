using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Low_Level_Objects_Library;
using Games_Logic_Library;

namespace Games {
    public partial class TwentyOneGameForm : Form {
        // class variables

        private const int PLAYER = 0;
        private const int DEALER = 1;
        private const int NUM_INITIAL_CARDS = 2;
        private const int WIN = 21;
    
        TableLayoutPanel[] tableLayoutPanels;

        Label[] bustedLabels;
        Label[] pointsLabels;
        Label[] gamesWonLabels;

        public TwentyOneGameForm() {

            InitializeComponent();

            tableLayoutPanels = new TableLayoutPanel[Twenty_One_Game.NUM_OF_PLAYERS] { tblPanelPlayer, tblPanelDealer };
            bustedLabels = new Label[Twenty_One_Game.NUM_OF_PLAYERS] {lblBustedPlayer, lblBustedDealer};
            pointsLabels = new Label[Twenty_One_Game.NUM_OF_PLAYERS] {lblPointsPlayer, lblPointsDealer};
            gamesWonLabels = new Label[Twenty_One_Game.NUM_OF_PLAYERS] {lblNumberWonPlayer, lblNumberWonDealer};

        }

        private void btnDeal_Click(object sender, EventArgs e) {

            Twenty_One_Game.SetUpGame();

            // Hide busted message(s)
            HideBustedMessage();

            // Reset Ace counter label
            DisplayAcesValueOne();

            // Diplay dealt cards for player and dealer
            DisplayGuiHand(Twenty_One_Game.GetHand(PLAYER), tblPanelPlayer);
            DisplayGuiHand(Twenty_One_Game.GetHand(DEALER), tblPanelDealer);

            // Calcualte hand totals for player and dealer on first draw
            Twenty_One_Game.CalculateHandTotal(PLAYER);
            Twenty_One_Game.CalculateHandTotal(DEALER);

            // Display points for player and dealer
            DisplayPoints();

            // Check if initial player hand includes an Ace
            CheckPlayerHandForAce();

            //DisableDealButton();

            // Enable buttons for next stage of game
            EnableHitButton();
            EnableStandButton();

            // Check for dual ace automatic dealer bust
            AutomaticDealerBust();

        } // end btnDeal_Click

        private void btnHit_Click(object sender, EventArgs e) {
            bool busted;

            Twenty_One_Game.DealOneCardTo(PLAYER);

            // Display players hand
            DisplayGuiHand(Twenty_One_Game.GetHand(PLAYER), tblPanelPlayer);

            // If Ace drawn - prompt user for value
            CheckPlayerHandForAce();

            // Recalculate totals for player after each new card hit
            Twenty_One_Game.CalculateHandTotal(PLAYER);

            // Update points disply to reflect new calculation
            DisplayPoints();

            // Test if player busted message should be displayed on each new hit
            busted = DetermineIfPlayerBusted(PLAYER);

            if (busted) {
                // Reset for next game
                DisableHitButton();
                DisableStandButton();             
                EnableDealButton();
                // Update Games won totals on player bust
                DisplayGamesWon();
            } else {
                // Continue game
                EnableHitButton();
                EnableStandButton();
            }

        } // end btnHit_Click

        private void btnStand_Click(object sender, EventArgs e) {

            // Play dealer turn
            Twenty_One_Game.PlayForDealer();

            // Display dealers hand
            DisplayGuiHand(Twenty_One_Game.GetHand(DEALER), tblPanelDealer);

            // Display total of dealers hand
            DisplayPoints();

            // Update display of hand total
            DisplayGamesWon();

            // Determine if busted message should be displayed
            DetermineIfPlayerBusted(DEALER);

            // Reset for next game
            DisableHitButton();
            DisableStandButton();           
            EnableDealButton();
        }// end btnStand_Click

        private void btnCancel_Click(object sender, EventArgs e) {

            //Display exit summary
            ExitGameSummary();

            // Reset totals so another set of games can be played
            Twenty_One_Game.ResetTotals();

            Close();
        }// end btnCancel_Click

        /// <summary>
        /// Displays the hand of the player / dealer in the GUI 
        /// </summary>
        /// <param name="hand">Hand of the player / dealer to be displayed</param>
        /// <param name="tableLayoutPanel">which tableLayoutPanel to display the hand in</param>
        private void DisplayGuiHand(Hand hand, TableLayoutPanel tableLayoutPanel) {
            tableLayoutPanel.Controls.Clear(); // Remove any cards already being shown.
            foreach (Card card in hand) {
                // Construct a PictureBox object.
                PictureBox pictureBox = new PictureBox();
                // Set the PictureBox to use all of its space
                pictureBox.Dock = DockStyle.Fill;
                // Remove spacing around the PictureBox. (Default is 3 pixels.)
                pictureBox.Margin = new Padding(0);
                pictureBox.Image = Images.GetCardImage(card);
                // Add the PictureBox object to the tableLayoutPanel.
                tableLayoutPanel.Controls.Add(pictureBox);
            }
        }// end DisplayGuiHand

        /// <summary>
        /// Checks the players hand for an Ace. Calls DetermineAceValue to 
        /// prompt player to decide whether they want the Ace to have the value one
        /// </summary>
        private void CheckPlayerHandForAce() {
            Hand hand = Twenty_One_Game.GetHand(PLAYER);

            // Checks entire hand for Ace
            if (hand.GetCount() <= NUM_INITIAL_CARDS) {
                foreach (Card card in hand) {
                    if (card.GetFaceValue() == FaceValue.Ace) {

                        // Ask user what value the want the Ace to be
                        DetermineAceValue();

                        // Update hand calculation
                        Twenty_One_Game.CalculateHandTotal(PLAYER);

                        // Update displayed hand total
                        DisplayPoints();
                    }
                }
            } else {
                // Checks the last drawn card for an Ace
                if (hand.GetCard(hand.GetCount() - 1).GetFaceValue() == FaceValue.Ace) {
                    // Ask user what value the want the Ace to be
                    DetermineAceValue();

                    // Update hand calculation
                    Twenty_One_Game.CalculateHandTotal(PLAYER);

                    // Update displayed hand total
                    DisplayPoints();
                }
            }


        }// end CheckPlayerHandForAce

        /// <summary>
        /// Message box to prompt the player what value they want for the Aces
        /// Calls IncrementNumOfUserAcesWithValueOne() in Game class to update number of Aces with value 1
        /// </summary>
        public void DetermineAceValue() {
            string message = "Count Ace as one?";
            string caption = "You got an Ace!";

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, caption, buttons);

            if (result == DialogResult.Yes) {
                // Increments number of Aces with value 1
                Twenty_One_Game.IncrementNumOfUserAcesWithValueOne();

                // Update displayed total to reflect decision
                DisplayAcesValueOne();
                }
        }// end DetermineAceValue   

        /// <summary>
        /// Displays the total points from the Game class in the GUI for each player
        /// </summary>
        private void DisplayPoints() {
            for (int i = 0; i < Twenty_One_Game.NUM_OF_PLAYERS; i++) {
                pointsLabels[i].Text = Twenty_One_Game.GetTotalPoints(i).ToString();
            }
        }// end DisplayPoints

        /// <summary>
        /// Displays the total games won from the Game class in the GUI for each player
        /// </summary>
        private void DisplayGamesWon() {
            for (int i = 0; i < Twenty_One_Game.NUM_OF_PLAYERS; i++) {
                gamesWonLabels[i].Text = Twenty_One_Game.GetNumOfGamesWon(i).ToString();
            }
        }// end DisplayGamesWon

        /// <summary>
        /// Displays the total number of Aces with value 1 from the Game class in the GUI for player
        /// </summary>
        private void DisplayAcesValueOne() {
            lblNumberAcesValueOne.Text = Twenty_One_Game.GetNumOfUserAcesWithValueOfOne().ToString();
        }// end DisplayAcesValueOne    

        /// <summary>
        /// Determines if the player or dealer has busted and shows busted label accordingly
        /// </summary>
        /// <param name="person">Index of person in points array of Game class. 0 for PLAYER. 1 for DEALER</param>
        /// <returns></returns>
        private bool DetermineIfPlayerBusted(int person) {
            int score;

            score = Twenty_One_Game.GetTotalPoints(person);
            if (score > WIN) {
                bustedLabels[person].Visible = true;
                return true;
            } else {
                return false;
            }
        }// end DetermineIfPlayerBusted

        /// <summary>
        /// Calls DetermineIfPlayerBusted to determine if busted label 
        /// should be shown for initial dealer hand. i.e. dealer drawing 2 Aces
        /// </summary>
        private void AutomaticDealerBust() {
            bool busted;

            busted = DetermineIfPlayerBusted(DEALER);

            if (busted) {
                DisableHitButton();
                DisableStandButton();

                // Update Games won to reflect automatic bust
                DisplayGamesWon();
            }
        }// end AutomaticDealerBust

        /// <summary>
        /// Display exit score summary message depending upon scores
        /// </summary>
        private void ExitGameSummary() {
            string message;
            int dealerScore, playerScore;

            dealerScore = Twenty_One_Game.GetNumOfGamesWon(DEALER);
            playerScore = Twenty_One_Game.GetNumOfGamesWon(PLAYER);

            // determine message to display on exit
            if (dealerScore > playerScore) {
                message = "House Won. Better luck next time!";
            } else if (playerScore > dealerScore) {
                message = "You won. Well done!";
            } else {
                message = "It was a draw!";
            }

            // output message via MessageBox
            MessageBox.Show(message);
        }// end ExitGameSummary

        /// <summary>
        /// Disables deal button
        /// </summary>
        private void DisableDealButton() {
            btnDeal.Enabled = false;
        }// end DisableDealButton

        /// <summary>
        /// Enables deal button
        /// </summary>
        private void EnableDealButton() {
            btnDeal.Enabled = true;
        }// end EnableDealButton

        /// <summary>
        /// Enables hit button
        /// </summary>
        private void EnableHitButton() {
            btnHit.Enabled = true;
        }// end EnableHitButton

        /// <summary>
        /// Disables hit button
        /// </summary>
        private void DisableHitButton() {
            btnHit.Enabled = false;
        }// end DisableHitButton

        /// <summary>
        /// Enables stand button
        /// </summary>  
        private void EnableStandButton() {
            btnStand.Enabled = true;
        }// end EnableStandButton

        /// <summary>
        /// Disables stand button
        /// </summary>
        private void DisableStandButton() {
            btnStand.Enabled = false;
        }// end DisableStandButton

        /// <summary>
        /// Hides player and dealer busted messages
        /// </summary>
        private void HideBustedMessage() {
            for (int i = 0; i < Twenty_One_Game.NUM_OF_PLAYERS; i++) {
                bustedLabels[i].Visible = false;
            }
        }// end HideBustedMessage
    }
}
