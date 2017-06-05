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
    public partial class SolitaireGameForm : Form {

        private const string LOCATION_DISCARD = "discard";
        private const string LOCATION_SUIT = "suit";
        private const string LOCATION_TABLE = "table";

        private const int NUM_OF_TABLEAU = 7;

        private string startLocation;
        private string destLocation;

        private bool firstClick = false;

        private PictureBox[] suitPiles;
        private TableLayoutPanel[] tableauPiles;

        Card firstCard;
        Card secondCard;

        public SolitaireGameForm() {

            InitializeComponent();

            suitPiles = new PictureBox[Solitaire.NUM_OF_SUITS] { pbSuitPile1, pbSuitPile2, pbSuitPile3, pbSuitPile4 };
            tableauPiles = new TableLayoutPanel[NUM_OF_TABLEAU] { tblPlayBoard1, tblPlayBoard2, tblPlayBoard3, tblPlayBoard4, 
                                                                    tblPlayBoard5, tblPlayBoard6, tblPlayBoard7 };

            Solitaire.SetupGame();

            // Draw Pile image
            pbDrawPile.Image = Images.GetBackOfCardImage();

            // Discard Pile image
            DisplayDiscard();

            // Display the cards in each tableau
            UpdateTableauPiles();

        }

        // Created methods

        private void DisplayBlankPictureBox(Hand hand, TableLayoutPanel tableLayoutPanel, int tableauNo) {
            if (hand.GetCount() == 0) {
                PictureBox blankPictureBox = new PictureBox();

                blankPictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
                blankPictureBox.Dock = DockStyle.Fill;
                blankPictureBox.Image = null;
                blankPictureBox.BackColor = System.Drawing.Color.White;
                blankPictureBox.Size = new System.Drawing.Size(65, 95);
                blankPictureBox.Margin = new Padding(0);
                blankPictureBox.Tag = tableauNo;

                // Create mew event handler for blankPictureBox image
                blankPictureBox.Click += new EventHandler(blankPictureBox_Click);

                // Add the blankPictureBox to the tableLayoutPanel
                tableLayoutPanel.Controls.Add(blankPictureBox);
            }
        } // DisplayBlankPictureBox

        private void DisplayGuiHand(Hand hand, TableLayoutPanel tableLayoutPanel, int numCardsFaceUp, int tableauNo) {
            tableLayoutPanel.Controls.Clear(); // Remove any cards already being shown.

            // If the hand is empty, a blank picture box will be displayed
            DisplayBlankPictureBox(hand, tableLayoutPanel, tableauNo);

            for (int i = 0; i < hand.GetCount(); i++) {
                Card card;

                // Construct a PictureBox object.
                PictureBox pictureBox = new PictureBox();
                // Set the PictureBox to use all of its space
                pictureBox.Dock = DockStyle.Fill;
                // Remove spacing around the PictureBox. (Default is 3 pixels.)
                pictureBox.Margin = new Padding(0);
                pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
                card = hand.GetCard(i);

                // If card face up
                if (i >= hand.GetCount() - numCardsFaceUp) {
                    pictureBox.Image = Images.GetCardImage(card);
                                      
                    // Only set event handler + tag for last card in the hand 
                    if (i == hand.GetCount() - 1) {
                        // set event-handler for Click on this PictureBox.
                        pictureBox.Click += new EventHandler(pictureBox_Click);
                        // tell the PictureBox which Card object it has the picture of.
                        pictureBox.Tag = card;
                    }              

                } else {
                    pictureBox.Image = Images.GetBackOfCardImage();
                    pictureBox.Tag = card;
                }
                // Add the PictureBox object to the tableLayoutPanel.
                tableLayoutPanel.Controls.Add(pictureBox);
            }
        }// End DisplayGuiHand

        private void DisplayDiscard() {
            Card lastCard;

            lastCard = Solitaire.GetLastDiscard();

            if (Solitaire.GetNumDiscardCards() != 0) {
                pbDiscardPile.Image = Images.GetCardImage(lastCard);

                // Tag to know what card was clicked
                pbDiscardPile.Tag = lastCard;
            } else {
                pbDiscardPile.Image = null;
            }
        }// end DisplayDiscard

        private void UpdateSuitPiles() {

            for (int suitPile = 0; suitPile < Solitaire.NUM_OF_SUITS; suitPile++) {
                Card card;
                
                if (Solitaire.GetSuitPileCount(suitPile) != 0) {
                    card = Solitaire.GetLastCardSuitPile(suitPile);
                    suitPiles[suitPile].Image = Images.GetCardImage(card);

                    suitPiles[suitPile].Tag = card;
                }
            }
        }// end UpdateSuitPiles

        private void UpdateDiscardPile() {
            pbDiscardPile.Image = Images.GetCardImage(Solitaire.GetLastDiscard());

            pbDiscardPile.Tag = Solitaire.GetLastDiscard();
        }// end UpdateDiscardPile

        private void UpdateTableauPiles() {
            for (int tableau = 0; tableau < NUM_OF_TABLEAU; tableau++) {
                DisplayGuiHand(Solitaire.GetTableau(tableau), tableauPiles[tableau], Solitaire.GetNumCardsFaceUp(tableau), tableau);
            }
        }// end UpdateTableauPiles

        private void TryToPlayCard(Card clickedCard, string location) {

            // Moves card directly to 1 of the suitPiles without needing addition click
            if (clickedCard != null && clickedCard.GetFaceValue() == FaceValue.Ace && location != LOCATION_SUIT) {
                Solitaire.PlayAce(clickedCard, location);
                firstClick = false;

                UpdateDiscardPile();
                UpdateSuitPiles();
                UpdateTableauPiles();
            } else {
                // If start of new move
                if (firstClick == false) {
                    firstCard = clickedCard;
                    startLocation = location;
                    firstClick = true;
                // If second click in move
                } else {
                    secondCard = clickedCard;
                    destLocation = location;

                    // Check if valid move here
                    if (!Solitaire.TryMakeMove(firstCard, secondCard, startLocation, destLocation)) {
                        
                        // Error messages for invalid moves
                        InvalidMoveError(destLocation);

                    } else if (Solitaire.CheckGameVictory()) {
                        MessageBox.Show("Congratulations, you won!");
                    }

                    firstClick = false;

                    UpdateDiscardPile();
                    UpdateSuitPiles();
                    UpdateTableauPiles();
                }
            }
        }// end TryToPlayCard

        private void InvalidMoveError(string destLocation) {
            if (destLocation == LOCATION_DISCARD) {
                MessageBox.Show("Cannot place card onto Discard Pile");
                firstClick = false;
            } else if (destLocation == LOCATION_TABLE) {
                MessageBox.Show("ERROR - Move not allowed - Cannot place card onto this pile");
                firstClick = false;
            } else if (destLocation == LOCATION_SUIT) {
                MessageBox.Show("ERROR - Move not allowed - Cannot place card onto this suit pile");
            }
        }// end InvalidMoveError

        // Event handlers

        private void pbDrawPile_Click(object sender, EventArgs e) {
            //
            if (Solitaire.GetNumDrawCards() != 0) {
                Solitaire.DrawCard();
                DisplayDiscard();

                // If last card is drawn, make image blank to show end of deck
                if (Solitaire.GetNumDrawCards() == 0) {

                    // consider showing outline of empty card
                    pbDrawPile.Image = null;
                }

            } else {
                Solitaire.ResetDrawPile();
                DisplayDiscard();
                pbDrawPile.Image = Images.GetBackOfCardImage();
            }
        }// end pbDrawPile_Click

        private void pbDiscardPile_Click(object sender, EventArgs e) {
            // Determine which card was clicked
            PictureBox clickedPictureBox = (PictureBox)sender;
            // Get a reference to the card
            Card clickedCard = (Card)clickedPictureBox.Tag;

            TryToPlayCard(clickedCard, LOCATION_DISCARD);

        }// end pbDiscardPile_Click

        private void pictureBox_Click(object sender, EventArgs e) {
            // Determine which card was clicked
            PictureBox clickedPictureBox = (PictureBox)sender;
            // Get a reference to the card
            Card clickedCard = (Card)clickedPictureBox.Tag;

            TryToPlayCard(clickedCard, LOCATION_TABLE);
        }// end pictureBox_Click

        private void blankPictureBox_Click(object sender, EventArgs e) {
            // Determine which card was clicked
            PictureBox clickedPictureBox = (PictureBox)sender;
            // Get a reference to the card
            int clickedCardTableauNo = (int)clickedPictureBox.Tag;

            if (firstClick = true && firstCard.GetFaceValue() == FaceValue.King) {

                Solitaire.PlayKing(startLocation, firstCard, clickedCardTableauNo);

            } else {

                // Error handling here
            }

            firstClick = false;

            UpdateDiscardPile();
            UpdateSuitPiles();
            UpdateTableauPiles();
        }// end blankPictureBox_Click

        private void pbSuitPile_Click(object sender, EventArgs e) {
            // which card was clicked?
            PictureBox clickedPictureBox = (PictureBox)sender;
            // get a reference to the card
            Card clickedCard = (Card)clickedPictureBox.Tag;

            TryToPlayCard(clickedCard, LOCATION_SUIT);
        }// end pbSuitPile1_Click

    }
}
