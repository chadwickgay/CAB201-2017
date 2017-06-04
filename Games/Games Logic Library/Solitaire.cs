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
            SetupTableau();

        }

        public static void PlayAce(Card ace, string startLocation){

            // If the card selected is an Ace
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

        public static bool TryMakeMove(Card firstCard, Card secondCard, string startLocation, string destLocation) {

            // If the card is in 1 of 7 the seven tables
            if (startLocation == LOCATION_TABLE && destLocation == LOCATION_TABLE) {

                // Check if the move is a valid move

                // Checks colour of the card first
                if (firstCard.GetColour() != secondCard.GetColour()) {

                    // Check if card is one less in the cards enum
                    if ((int)secondCard.GetFaceValue() - (int)firstCard.GetFaceValue() == 1) {

                        // Move is vaid

                        // Need to locate which table the card has come from & which card it is going to

                        Hand fromTable;
                        Hand toTable;

                        fromTable = GetTableauContainingCard(firstCard);
                        toTable = GetTableauContainingCard(secondCard);

                        //Remove card from table
                        RemoveCardFromTableau(fromTable, firstCard);

                        //Add card to table
                        AddCardToTable(toTable, firstCard);

                        return true;

                    } else {
                        return false;
                    }
                }           
            }
            return false;
        }

        private static void AddCardToTable(Hand tableau, Card card) {
            tableau.Add(card);
        }

        private static void RemoveCardFromTableau(Hand tableau, Card card) {
            tableau.Remove(card);
        }

        private static Hand GetTableauContainingCard(Card card) {
            Hand tableau = new Hand();

            for (int tableauNo = 0; tableauNo < NUM_OF_TABLEAU; tableauNo++) {
                if (tableauPiles[tableauNo].Contains(card)) {
                    tableau = tableauPiles[tableauNo];
                }
            }

            return tableau;
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
        private static void SetupTableau() {
            for (int tableauNo = 0; tableauNo < NUM_OF_TABLEAU; tableauNo++) {
                tableauPiles[tableauNo] = new Hand(drawPile.DealCards(tableauNo + 1));
            }
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
