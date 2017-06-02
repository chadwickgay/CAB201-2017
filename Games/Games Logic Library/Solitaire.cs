using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Low_Level_Objects_Library;

namespace Games_Logic_Library {
    public static class Solitaire {

        // Play board index values
        private const int TABLEAU_ONE = 0;
        private const int TABLEAU_TWO = 1;
        private const int TABLEAU_THREE = 2;
        private const int TABLEAU_FOUR = 3;
        private const int TABLEAU_FIVE = 4;
        private const int TABLEAU_SIX = 5;
        private const int TABLEAU_SEVEN = 6;

        // number of tableau
        private const int NUM_OF_TABLEAU = 7;

        // number of suits
        public  const int NUM_OF_SUITS = 4;

        // Number of face up cards per pile
        private static int[] numCardsFaceUp = new int[] {1, 1, 1, 1, 1, 1, 1};

        // Pile for discard pile
        static CardPile drawPile;

        // Pile for discard pile
        private static CardPile discardPile;

        private static Hand[] tableauPiles = new Hand[NUM_OF_TABLEAU];
        private static CardPile[] suitPiles = new CardPile[NUM_OF_SUITS];

        private const string LOCATION_DISCARD = "discard";
        private const string LOCATION_SUIT = "suit";
        private const string LOCATION_TABLE = "table";

        private const int PILE_ONE = 0;
        private const int PILE_TWO = 1;
        private const int PILE_THREE = 2;
        private const int PILE_FOUR = 3;

        public static void SetupGame() {

            drawPile = new CardPile(true);
            discardPile = new CardPile();

            // Shuffle drawPile
            drawPile.Shuffle();

            // Create piles of cards for each suit
            SetupSuitPiles();

            // Draw initial card from drawPile to discardPile
            DrawCard();

            // Setup each tableau
            // do in loop
            SetupTableau(TABLEAU_ONE, 1);
            SetupTableau(TABLEAU_TWO, 2);
            SetupTableau(TABLEAU_THREE, 3);
            SetupTableau(TABLEAU_FOUR, 4);
            SetupTableau(TABLEAU_FIVE, 5);
            SetupTableau(TABLEAU_SIX, 6);
            SetupTableau(TABLEAU_SEVEN, 7);
        }

        public static void PlayAce(Card ace, string startLocation){

            if (startLocation == LOCATION_DISCARD) {

                if (suitPiles[PILE_ONE].GetCount() == 0) {
                    suitPiles[PILE_ONE].Add(ace);
                } else if (suitPiles[PILE_TWO].GetCount() == 0) {
                    suitPiles[PILE_TWO].Add(ace);
                } else if (suitPiles[PILE_THREE].GetCount() == 0) {
                    suitPiles[PILE_THREE].Add(ace);
                } else if (suitPiles[PILE_FOUR].GetCount() == 0) {
                    suitPiles[PILE_FOUR].Add(ace);
                }

                RemoveLastDiscard();
            }

        }



        public static Card GetLastCardSuitPile(int whichSuit) {
            return suitPiles[whichSuit].GetLastCardInPile();
        }

        public static int GetSuitPileCount(int whichSuit) {
            return suitPiles[whichSuit].GetCount();
        }

        public static int GetNumCardsFaceUp(int whichTableau) {
            return numCardsFaceUp[whichTableau];
        }

        public static Hand GetTableau(int TableauNum) {
            return tableauPiles[TableauNum];
        }

        //Sets a single table at the start of the game
        private static Hand SetupTableau(int tableauNo, int amountOfCards) {
            Hand tableau;

            tableau = new Hand(drawPile.DealCards(amountOfCards));

            tableauPiles[tableauNo] = tableau;

            return tableau;
        }

        private static void SetupSuitPiles() {
            // Add new CardPile to each position in suitPiles array
            for (int i = 0; i < NUM_OF_SUITS; i++) {
                suitPiles[i] = new CardPile();
            }
        }

        public static void DrawCard() {
            discardPile.Add(drawPile.DealOneCard());
        }

        public static Card GetLastDiscard() {
            return discardPile.GetLastCardInPile();
        }

        public static void RemoveLastDiscard() {
            discardPile.RemoveLastCard();
        }

        public static int GetNumDrawCards() {
            return drawPile.GetCount();
        }

        public static int GetNumDiscardCards() {
            return discardPile.GetCount();
        }

        public static void ResetDrawPile() {
            drawPile = discardPile;
            discardPile = new CardPile();
            discardPile.Add(drawPile.DealOneCard());
        }
    }
}
