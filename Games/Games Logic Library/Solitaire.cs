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

        // Number of face up cards per pile
        private static int[] numCardsFaceUp = new int[] {1, 1, 1, 1, 1, 1, 1};

        // Pile for discard pile
        static CardPile drawPile;

        // Pile for discard pile
        private static CardPile discardPile;

        private static Hand[] tableauPiles = new Hand[NUM_OF_TABLEAU];
        private static Card[] suitPiles;

        public static void SetupGame() {

            drawPile = new CardPile(true);
            drawPile.Shuffle();

            // Add card from drawPile to the discardPile
            discardPile = new CardPile();
            discardPile.Add(drawPile.DealOneCard());

            // Setup each tableau
            SetupTableau(TABLEAU_ONE, 1);
            SetupTableau(TABLEAU_TWO, 2);
            SetupTableau(TABLEAU_THREE, 3);
            SetupTableau(TABLEAU_FOUR, 4);
            SetupTableau(TABLEAU_FIVE, 5);
            SetupTableau(TABLEAU_SIX, 6);
            SetupTableau(TABLEAU_SEVEN, 7);


        }

        public static int GetNumCardsFaceUp(int whichTableau) {
            return numCardsFaceUp[whichTableau];
        }

        public static Hand GetTableau(int whichTableau) {
            return tableauPiles[whichTableau];
        }

        //Sets a single table at the start of the game
        private static Hand SetupTableau(int tableauNo, int amountOfCards) {
            Hand tableau;

            tableau = new Hand(drawPile.DealCards(amountOfCards));

            tableauPiles[tableauNo] = tableau;

            return tableau;
        }

        public static void DrawCard() {
            discardPile.Add(drawPile.DealOneCard());
        }

        public static Card GetLastDiscard() {
            return discardPile.GetLastCardInPile();
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
