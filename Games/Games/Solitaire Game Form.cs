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
        public SolitaireGameForm() {
            InitializeComponent();

            Solitaire.SetupGame();

            // Draw Pile image
            pbDrawPile.Image = Images.GetBackOfCardImage();

            // Discard Pile image
            DisplayDiscard();

            // Display the cards in each tableau
            DisplayGuiHand(Solitaire.GetTableau(0), tblPlayBoard1, Solitaire.GetNumCardsFaceUp(0));
            DisplayGuiHand(Solitaire.GetTableau(1), tblPlayBoard2, Solitaire.GetNumCardsFaceUp(1));
            DisplayGuiHand(Solitaire.GetTableau(2), tblPlayBoard3, Solitaire.GetNumCardsFaceUp(2));
            DisplayGuiHand(Solitaire.GetTableau(3), tblPlayBoard4, Solitaire.GetNumCardsFaceUp(3));
            DisplayGuiHand(Solitaire.GetTableau(4), tblPlayBoard5, Solitaire.GetNumCardsFaceUp(4));
            DisplayGuiHand(Solitaire.GetTableau(5), tblPlayBoard6, Solitaire.GetNumCardsFaceUp(5));
            DisplayGuiHand(Solitaire.GetTableau(6), tblPlayBoard7, Solitaire.GetNumCardsFaceUp(6));
        }

        private void DisplayGuiHand(Hand hand, TableLayoutPanel tableLayoutPanel, int numCardsFaceUp) {
            tableLayoutPanel.Controls.Clear(); // Remove any cards already being shown.

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
                    
                    // set event-handler for Click on this PictureBox.
                    pictureBox.Click += new EventHandler(pictureBox_Click);
                    // tell the PictureBox which Card object it has the picture of.
                    pictureBox.Tag = card;

                } else {
                    pictureBox.Image = Images.GetBackOfCardImage();

                    pictureBox.Tag = card;
                }
                // Add the PictureBox object to the tableLayoutPanel.
                tableLayoutPanel.Controls.Add(pictureBox);
            }
        }// End DisplayGuiHand

        // passs card and picturebox... make general method
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
        }

        /*   Click events for draw and discard piles            */

        private void pbDrawPile_Click(object sender, EventArgs e) {
            //
            if (Solitaire.GetNumDrawCards() != 0) {
                Solitaire.DrawCard();
                DisplayDiscard();
            } else {
                Solitaire.ResetDrawPile();
                DisplayDiscard();
            }
        }

        private void pbDiscardPile_Click(object sender, EventArgs e) {
            // which card was clicked?
            PictureBox clickedPictureBox = (PictureBox)sender;
            // get a reference to the card
            Card clickedCard = (Card)clickedPictureBox.Tag;
            TryToPlayCard(clickedCard);
        }

        /*   Click events for suit piles            */

        private void pbSuitPile1_Click(object sender, EventArgs e) {
            //
        }

        private void pbSuitPile2_Click(object sender, EventArgs e) {
            //
        }

        private void pbSuitPile3_Click(object sender, EventArgs e) {
            //
        }

        private void pbSuitPile4_Click(object sender, EventArgs e) {
            //
        }

        /*   private helper methods       */

        /*   Events & methods for picture boxes - from Assignment instructions       */

        private void pictureBox_Click(object sender, EventArgs e) {
            // which card was clicked?
            PictureBox clickedPictureBox = (PictureBox)sender;
            // get a reference to the card
            Card clickedCard = (Card)clickedPictureBox.Tag;
            TryToPlayCard(clickedCard);
        }

        private void TryToPlayCard(Card clickedCard) {
            // This MessageBox.Show is for debugging purposes only.
            // comment out line, once sure you can click on a card in a tableau
            MessageBox.Show(clickedCard.ToString(false, true), "Clicked");
            
            // Add code to do something with the clicked card.
        }
    }
}
