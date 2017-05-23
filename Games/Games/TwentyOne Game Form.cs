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
            CheckForAce(PLAYER);

            //DisableDealButton();

            // Enable buttons for next stage of game
            EnableHitButton();
            EnableStandButton();

            // Check for dual ace automatic dealer bust
            AutomaticDealerBust();
            
        }

        private void CheckForAce(int who) {
            Hand hand = Twenty_One_Game.GetHand(who);

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
                if (hand.GetCard(hand.GetCount() - 1).GetFaceValue() == FaceValue.Ace) {
                    // Ask user what value the want the Ace to be
                    DetermineAceValue();

                    // Update hand calculation
                    Twenty_One_Game.CalculateHandTotal(PLAYER);

                    // Update displayed hand total
                    DisplayPoints();
                }
            }


        }

        private void btnHit_Click(object sender, EventArgs e) {
            bool busted;
            Card card;

            card = Twenty_One_Game.DealOneCardTo(PLAYER); // NEED TO FIX THIS!

            // Display players hand
            DisplayGuiHand(Twenty_One_Game.GetHand(PLAYER), tblPanelPlayer);

            // If Ace drawn - prompt user for value
            //DetermineAceValue(card);
            CheckForAce(PLAYER);

            // Recalculate totals for player after each new card hit
            Twenty_One_Game.CalculateHandTotal(PLAYER);

            // Update points disply to reflect new calculation
            DisplayPoints();

            // Test if player busted on each new hit
            busted = DetermineIfPlayerBusted(PLAYER);

            if (busted) {
                DisableHitButton();
                DisableStandButton();

                // Reset for next game
                EnableDealButton();
                // Update Games won totals on player bust
                DisplayGamesWon();
            } else {
                EnableHitButton();
                EnableStandButton();
            }  
                
        }

        private void btnStand_Click(object sender, EventArgs e) {

            Twenty_One_Game.PlayForDealer();

            DisplayGuiHand(Twenty_One_Game.GetHand(DEALER), tblPanelDealer);

            DisplayPoints();

            DisplayGamesWon();

            DetermineIfPlayerBusted(DEALER);

            // Update Game results
            DisplayGamesWon();

            // Reset for next game
            DisableHitButton();
            DisableStandButton();           
            EnableDealButton();
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            ExitGameSummary();

            Close();
        }

        private void btnTest_Click(object sender, EventArgs e) {
            const int testNumOfCardsForDealer = 2;
            const int testNumOfCardsForPlayer = 8;
            CardPile testCardPile = new CardPile(true);
            testCardPile.Shuffle();
            Hand testHandForDealer = new Hand(testCardPile.DealCards(testNumOfCardsForDealer));
            Hand testHandForPlayer = new Hand(testCardPile.DealCards(testNumOfCardsForPlayer));
            DisplayGuiHand(testHandForDealer, tblPanelDealer);
            DisplayGuiHand(testHandForPlayer, tblPanelPlayer);
        }

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
        }// End DisplayGuiHand

        public void DetermineAceValue() {

            string message = "Count Ace as one?";
            string caption = "You got an Ace!";

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

                DialogResult result = MessageBox.Show(message, caption, buttons);
                if (result == DialogResult.Yes) {
                    Twenty_One_Game.IncrementNumOfUserAcesWithValueOne();

                    // Update displayed total to reflect decision
                    DisplayAcesValueOne();
                }             
        }

        private void AutomaticDealerBust() {
            bool busted;
            busted = DetermineIfPlayerBusted(DEALER);

            if (busted) {
                DisableHitButton();
                DisableStandButton();

                // Update Games won to reflect automatic bust
                DisplayGamesWon();
            }
        }

        private void DisableDealButton() {
            btnDeal.Enabled = false;
        }

        private void EnableDealButton() {
            btnDeal.Enabled = true;
        }

        private void EnableHitButton() {
            btnHit.Enabled = true;
        }

        private void EnableStandButton() {
            btnStand.Enabled = true;
        }

        private void DisableHitButton() {
            btnHit.Enabled = false;
        }

        private void DisableStandButton() {
            btnStand.Enabled = false;
        }

        private void DisplayPoints() {
            for (int i = 0; i < Twenty_One_Game.NUM_OF_PLAYERS; i++) {
                pointsLabels[i].Text = Twenty_One_Game.GetTotalPoints(i).ToString();
            }
        }

        private void DisplayGamesWon() {
            for (int i = 0; i < Twenty_One_Game.NUM_OF_PLAYERS; i++) {
                gamesWonLabels[i].Text = Twenty_One_Game.GetNumOfGamesWon(i).ToString();
            }
        }

        private void DisplayAcesValueOne() {
            lblNumberAcesValueOne.Text = Twenty_One_Game.GetNumOfUserAcesWithValueOfOne().ToString();
        }

        private bool DetermineIfPlayerBusted(int person) {
            int score;

            score = Twenty_One_Game.GetTotalPoints(person);
            if (score > WIN) {
                bustedLabels[person].Visible = true;
                return true;
            } else {
                return false;
            }
        }

        private void HideBustedMessage() {
            for (int i = 0; i < Twenty_One_Game.NUM_OF_PLAYERS; i++) {
                bustedLabels[i].Visible = false;
            }
        }

        // minor bug here - if no game selected. unhandled excep
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
        }
    }
}
