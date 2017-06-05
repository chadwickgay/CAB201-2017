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

    /// <summary>
    /// GUI driven program that allows the user to play a 
    /// simplified game of Solitaire.
    /// 
    /// Utilizes underlying game logic library of Solitaire.cs
    /// for core game logic.
    /// 
    /// Author Chadwick Gay June 2017 - Student number n9410392
    /// </summary>
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
            UpdateDiscardPile();

            // Display the cards in each tableau
            UpdateTableauPiles();

        }

        // Created methods

        /// <summary>
        /// Displays a blank picture box image to allow King to be placed onto the board.
        /// </summary>
        /// <param name="hand">Tableau (column) of cards to be displayed</param>
        /// <param name="tableLayoutPanel">Which tableLayoutPanel to display the cards in</param>
        /// <param name="tableauNo">index of the tableau in underlying game logic class</param>
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

        /// <summary>
        /// Displays each of the cards in the tableau pile on the play board.
        /// Utilizes numCardsFaceUp array to determine how many cards should be placed face up on the board
        /// </summary>
        /// <param name="hand">Tableau (column) of cards to be displayed</param>
        /// <param name="tableLayoutPanel">Which tableLayoutPanel to display the cards in</param>
        /// <param name="numCardsFaceUp">Number of cards that shoul de displayed face up</param>
        /// <param name="tableauNo">index of the tableau in underlying game logic class</param>
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

        /// <summary>
        /// Updates the cards displayed in the suit piles.
        /// </summary>
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

        /// <summary>
        /// Updates the cards displayed in the discard pile.
        /// </summary>
        private void UpdateDiscardPile() {
            pbDiscardPile.Image = Images.GetCardImage(Solitaire.GetLastDiscard());

            pbDiscardPile.Tag = Solitaire.GetLastDiscard();
        }// end UpdateDiscardPile

        /// <summary>
        /// Calls DisplayGuiHand to update the cards displayed in all of the seven tableaus. 
        /// </summary>
        private void UpdateTableauPiles() {
            for (int tableau = 0; tableau < NUM_OF_TABLEAU; tableau++) {
                DisplayGuiHand(Solitaire.GetTableau(tableau), tableauPiles[tableau], Solitaire.GetNumCardsFaceUp(tableau), tableau);
            }
        }// end UpdateTableauPiles

        /// <summary>
        /// Gets location of where Card has come from and where the user wants to place the card
        /// Calls game logic functions to attempt to place card according to user selection
        /// Updates disply on successful placement or displays error message
        /// </summary>
        /// <param name="clickedCard">Card the user has selected to move or move card to</param>
        /// <param name="location">Location from where the user selected the card</param>
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

        /// <summary>
        /// Displays contextual errors messages to user on invalid move request.
        /// </summary>
        /// <param name="destLocation">Location where the Card is trying to be added to - suit or table</param>
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
                UpdateDiscardPile();

                // If last card is drawn, make image blank to show end of deck
                if (Solitaire.GetNumDrawCards() == 0) {

                    // consider showing outline of empty card
                    pbDrawPile.Image = null;
                }

            } else {
                Solitaire.ResetDrawPile();
                UpdateDiscardPile();
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
