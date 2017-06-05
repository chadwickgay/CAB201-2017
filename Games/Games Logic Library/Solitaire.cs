using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Low_Level_Objects_Library;

namespace Games_Logic_Library {
    public static class Solitaire {

        // number of tableau
        private const int NUM_OF_TABLEAU = 7;

        // number of suits
        public  const int NUM_OF_SUITS = 4;

        // Number of cards in suit pile for a complete suit pile
        private const int TOTAL_CARDS_SUIT = 13;

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

        private const int ONE_LESS = 1;
        private const int ONE_HIGHER = 1;

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

        public static bool TryMakeMove(Card firstCard, Card secondCard, string startLocation, string destLocation) {
            // If the card is from 1 of 7 the seven tables to another table
            if (startLocation == LOCATION_TABLE && destLocation == LOCATION_TABLE) {
                // Checks if the colour of the cards is opposite
                if (!CheckSameColour(firstCard, secondCard)) {
                    // Check if card is one less in the cards enum
                    if (CheckValidMove(firstCard, secondCard, destLocation)) {
                        MoveFromTable(firstCard);
                        MoveToTable(firstCard, secondCard);
                        return true;
                    } else {
                        return false;
                    }
                }
                // If card is from the discard pile moving to table
            } else if (startLocation == LOCATION_DISCARD && destLocation == LOCATION_TABLE) {
                // Checks if the colour of the cards is opposite
                if (!CheckSameColour(firstCard, secondCard)) {
                    // Check if card is one less in the cards enum
                    if (CheckValidMove(firstCard, secondCard, destLocation)) {
                        MoveFromDiscard();
                        MoveToTable(firstCard, secondCard);                     
                        return true;
                    }
                }
                // If the card is in the discard pile moving to the suitpile
            } else if (startLocation == LOCATION_DISCARD && destLocation == LOCATION_SUIT) {
                // Checks if the cards of the same suit
                if (CheckSameSuit(firstCard, secondCard)) {
                    // Checks whether there is a valid move for Two onto Ace or card is one more than the cards enum
                    if (CheckValidMove(firstCard, secondCard, destLocation)) {
                        MoveFromDiscard();
                        MoveToSuitPile(firstCard, secondCard);                 
                        return true;
                    }
                }
            } else if (startLocation == LOCATION_TABLE && destLocation == LOCATION_SUIT) {
                // Checks if the cards of the same suit
                if (CheckSameSuit(firstCard, secondCard)) {
                    // Checks whether there is a valid move for Two onto Ace or card is one more than the cards enum
                    if (CheckValidMove(firstCard, secondCard, destLocation)) {
                        MoveToSuitPile(firstCard, secondCard);
                        MoveFromTable(firstCard);
                        return true;
                    }
                }
            } else {
                return false;
            }

            // unreacable code - inserted to satisfy compiler
            return false;
        }

        // Helper methods to move cards between areas on board

        private static Hand GetTableauContainingCard(Card card, out int tableauNo) {
            Hand tableau = new Hand();
            // assigned to prevent compiler error
            tableauNo = 0;

            for (int i = 0; i < NUM_OF_TABLEAU; i++) {
                if (tableauPiles[i].Contains(card)) {
                    tableau = tableauPiles[i];
                    tableauNo = i;
                }
            }
            return tableau;
        }

        private static void MoveFromTable(Card firstCard) {
            Hand fromTable;
            int tableauNo;

            fromTable = GetTableauContainingCard(firstCard, out tableauNo);

            //Remove card from table
            RemoveCardFromTableau(fromTable, firstCard);

            //Decrement number of cards visible
            if (numCardsFaceUp[tableauNo] > 1) {
                numCardsFaceUp[tableauNo]--;
            }           
        }

        private static void MoveToTable(Card firstCard, Card secondCard) {
            Hand toTable;
            int tableauNo;

            toTable = GetTableauContainingCard(secondCard, out tableauNo);

            //Add card to table
            AddCardToTable(toTable, firstCard);

            //Increment number of cards face up
            numCardsFaceUp[tableauNo]++;
        }

        private static void MoveFromDiscard() {
            // Remove last card from discard
            //RemoveLastDiscard();
            discardPile.RemoveLastCard();
           
            // Draw card
            DrawCard();
        }

        private static void MoveToSuitPile(Card firstCard, Card secondCard) {

            for (int i = 0; i < NUM_OF_SUITS; i++) {

                if (suitPiles[i].GetCount() != 0) {
                    if (suitPiles[i].GetLastCardInPile() == secondCard) {
                        suitPiles[i].Add(firstCard);
                    }
                }
            }
        }

        private static void AddCardToTable(Hand tableau, Card card) {
            tableau.Add(card);
        }

        private static void RemoveCardFromTableau(Hand tableau, Card card) {
            tableau.Remove(card);
        }

        // Methods for dealing with Aces

        public static void PlayAce(Card ace, string startLocation){
            int tableauNo;

            // If the card selected is an Ace
            if (startLocation == LOCATION_DISCARD) {

                AddAceEmptySuitPile(ace);

                RemoveLastDiscard();

                DrawCard();
            } else if (startLocation == LOCATION_TABLE) {

                AddAceEmptySuitPile(ace);

                Hand fromTable;

                fromTable = GetTableauContainingCard(ace, out tableauNo);

                RemoveCardFromTableau(fromTable, ace);

            }

        }

        private static void AddAceEmptySuitPile(Card ace) {
            if (suitPiles[PILE_ONE].GetCount() == 0) {
                suitPiles[PILE_ONE].Add(ace);
            } else if (suitPiles[PILE_TWO].GetCount() == 0) {
                suitPiles[PILE_TWO].Add(ace);
            } else if (suitPiles[PILE_THREE].GetCount() == 0) {
                suitPiles[PILE_THREE].Add(ace);
            } else if (suitPiles[PILE_FOUR].GetCount() == 0) {
                suitPiles[PILE_FOUR].Add(ace);
            }
        }

        // Helper methods to do validation of moves

        private static bool CheckValidMove(Card firstCard, Card secondCard, string destLocation) {
            bool validMove = false;

            if (destLocation == LOCATION_TABLE) {
                if ((int)secondCard.GetFaceValue() - (int)firstCard.GetFaceValue() == ONE_LESS) {
                    validMove = true;
                }
            } else if (destLocation == LOCATION_SUIT && secondCard.GetFaceValue() == FaceValue.Ace) {
                if (firstCard.GetFaceValue() == FaceValue.Two) {
                    return true;
                }
            }
            else if (destLocation == LOCATION_SUIT) {
                if ((int)firstCard.GetFaceValue() - (int)secondCard.GetFaceValue() == ONE_HIGHER) {
                    validMove = true;
                }
            }

            return validMove;
        }

        private static bool CheckSameColour(Card firstCard, Card secondCard) {
            if (firstCard.GetColour() == secondCard.GetColour()) {
                return true;
            } else {
                return false;
            }
        }

        private static bool CheckSameSuit(Card firstCard, Card secondCard) {
            if (firstCard.GetSuit() == secondCard.GetSuit()) {
                return true;
            } else {
                return false;
            }
        }

        // Private helper methods to setup the game

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

        // Public methods

        public static Card GetLastCardSuitPile(int whichSuit) {
            return suitPiles[whichSuit].GetLastCardInPile();
        }

        public static int GetSuitPileCount(int whichSuit) {
            return suitPiles[whichSuit].GetCount();
        }

        public static int GetNumCardsFaceUp(int whichTableau) {
            return numCardsFaceUp[whichTableau];
        }

        public static Hand GetTableau(int tableauNum) {
            return tableauPiles[tableauNum];
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

        public static bool CheckGameVictory() {
            int suitsComplete = 0;

            for (int i = 0; i < NUM_OF_SUITS; i++) {
                if (suitPiles[i].GetCount() == TOTAL_CARDS_SUIT) {
                    suitsComplete++;
                }
            }

            if (suitsComplete == NUM_OF_SUITS) {
                return true;
            } else {
                return false;
            }
        }
    }
}
