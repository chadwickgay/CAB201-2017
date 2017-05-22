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
        private const int PLAYER = 0;
        private const int DEALER = 1;
        private const int NUM_INITIAL_CARDS = 2;

        // class variables
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

            // Deal first two to the player and dealer
            for (int i = 0; i < NUM_INITIAL_CARDS; i++) {

                Twenty_One_Game.DealOneCardTo(PLAYER);
                Twenty_One_Game.DealOneCardTo(DEALER);
            }

            // Diplay dealt cards for player and dealer
            DisplayGuiHand(Twenty_One_Game.GetHand(PLAYER), tblPanelPlayer);
            DisplayGuiHand(Twenty_One_Game.GetHand(DEALER), tblPanelDealer);

            // Calcualte hand totals for player and dealer on first draw
            Twenty_One_Game.CalculateHandTotal(PLAYER);
            Twenty_One_Game.CalculateHandTotal(DEALER);

            DisplayPoints();

            // DisableDealButton();

            EnableHitButton();

            EnableStandButton();

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

        public void DetermineAceValue(Card card) {

            string message = "Count Ace as one?";
            string caption = "You got an Ace!";

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            if (card.GetFaceValue() == FaceValue.Ace) {
                DialogResult result = MessageBox.Show(message, caption, buttons);
                if (result == DialogResult.Yes) {
                    Twenty_One_Game.IncrementNumOfUserAcesWithValueOne();

                    // Update displayed total to reflect decision
                    lblNumberAcesValueOne.Text = Twenty_One_Game.GetNumOfUserAcesWithValueOfOne().ToString();
                }
            }
        }

        private void DisableDealButton() {
            btnDeal.Enabled = false;
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

        private void btnHit_Click(object sender, EventArgs e) {
            int playerScore;

            Card card = Twenty_One_Game.DealOneCardTo(PLAYER);

            DisplayGuiHand(Twenty_One_Game.GetHand(PLAYER), tblPanelPlayer);

            DetermineAceValue(card);

            // Recalculate totals after each new card hit
            Twenty_One_Game.CalculateHandTotal(PLAYER);

            DisplayPoints();

            playerScore = Twenty_One_Game.GetTotalPoints(PLAYER);
            if (playerScore > 21) {
                bustedLabels[PLAYER].Visible = true;
            }

        }

        private void btnStand_Click(object sender, EventArgs e) {
            int dealerScore;

            Twenty_One_Game.PlayForDealer();

            DisplayGuiHand(Twenty_One_Game.GetHand(DEALER), tblPanelDealer);

            DisplayPoints();

            DisplayGamesWon();

            dealerScore = Twenty_One_Game.GetTotalPoints(DEALER);
            if (dealerScore > 21) {
                bustedLabels[DEALER].Visible = true;
            }

            DisableHitButton();

            DisableStandButton();
            
        }
    }
}
