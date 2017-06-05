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
        private static int[] numCardsFaceUp = new int[NUM_OF_TABLEAU];
        private const int DEFAULT_FACE_UP = 1;

        // Pile for discard pile
        static CardPile drawPile;

        // Pile for discard pile
        private static CardPile discardPile;

        // Arrays for tableauPiles and suitPile
        private static Hand[] tableauPiles = new Hand[NUM_OF_TABLEAU];
        private static CardPile[] suitPiles = new CardPile[NUM_OF_SUITS];

        // To identify locations within game
        private const string LOCATION_DISCARD = "discard";
        private const string LOCATION_SUIT = "suit";
        private const string LOCATION_TABLE = "table";

        // To identify valid moves using Cards enum 
        private const int ONE_LESS = 1;
        private const int ONE_HIGHER = 1;

        // To identify suitPiles
        private const int PILE_ONE = 0;
        private const int PILE_TWO = 1;
        private const int PILE_THREE = 2;
        private const int PILE_FOUR = 3;


        // Public methods

        /// <summary>
        /// Initializes all class variabless at start of a new game
        /// </summary>
        public static void SetupGame() {

            drawPile = new CardPile(true);
            discardPile = new CardPile();

            ResetNumFaceUp();

            // Shuffle drawPile
            drawPile.Shuffle();

            // Create piles of cards for each suit
            SetupSuitPiles();

            // Draw initial card from drawPile to discardPile
            DrawCard();

            // Setup each tableau
            SetupTableau();
        }

        // Methods to move cards on the board

        /// <summary>
        /// Performs move of card from table or discardPile to table or suitPile if validMove is possible
        /// Utilizes parameters to identify from and to locations to apply different game rules by location
        /// </summary>
        /// <param name="firstCard">Card to be moved if valid move is possible.</param>
        /// <param name="secondCard">Card firstCard will be moved onto if valid move is possible</param>
        /// <param name="startLocation">Current location of the firstCard - discard or table</param>
        /// <param name="destLocation">Location where the Card is trying to be added to - suit or table</param>
        /// <returns></returns>
        public static bool TryMakeMove(Card firstCard, Card secondCard, string startLocation, string destLocation) {
            // If the card is from 1 of 7 the seven tables to another table
            if (startLocation == LOCATION_TABLE && destLocation == LOCATION_TABLE) {
                // Checks if the colour of the cards is opposite
                if (!CheckSameColour(firstCard, secondCard)) {
                    // Check if card is one less in the cards enum
                    if (CheckValidNumericalMove(firstCard, secondCard, destLocation)) {
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
                    if (CheckValidNumericalMove(firstCard, secondCard, destLocation)) {
                        MoveFromDiscard();
                        MoveToTable(firstCard, secondCard);
                        return true;
                    }
                }
                // If the card is in the discard pile moving to the suitpile
            } else if (startLocation == LOCATION_DISCARD && destLocation == LOCATION_SUIT) {
                if (secondCard != null) {
                    // Checks if the cards of the same suit
                    if (CheckSameSuit(firstCard, secondCard)) {
                        // Checks whether there is a valid move for Two onto Ace or card is one more than the cards enum
                        if (CheckValidNumericalMove(firstCard, secondCard, destLocation)) {
                            MoveFromDiscard();
                            MoveToSuitPile(firstCard, secondCard);
                            return true;
                        }
                    }
                } else {
                    return false;
                }

            } else if (startLocation == LOCATION_TABLE && destLocation == LOCATION_SUIT) {
                if (secondCard != null) {
                    // Checks if the cards of the same suit
                    if (CheckSameSuit(firstCard, secondCard)) {
                        // Checks whether there is a valid move for Two onto Ace or card is one more than the cards enum
                        if (CheckValidNumericalMove(firstCard, secondCard, destLocation)) {
                            MoveToSuitPile(firstCard, secondCard);
                            MoveFromTable(firstCard);
                            return true;
                        }
                    }
                }
            } else {
                return false;
            }
            // unreacable code - inserted to satisfy compiler
            return false;
        }

        /// <summary>
        /// Performs move of King to empty tableau from tables or discard pile if valid move is possible
        /// </summary>
        /// <param name="startLocation">Location where the King is coming from - discard, suit or table</param>
        /// <param name="king">King to be moved to empty tableau</param>
        /// <param name="tableauNo">Index of tableauPile in tableauPiles to move King to</param>
        public static void PlayKing(string startLocation, Card king, int tableauNo) {

            if (startLocation == LOCATION_TABLE) {
                Hand toTable;

                MoveFromTable(king);

                toTable = GetTableau(tableauNo);
                //Add card to table
                AddCardToTable(toTable, king);

                //Increment number of cards face up
                numCardsFaceUp[tableauNo]++;

            } else if (startLocation == LOCATION_DISCARD) {
                Hand toTable;

                MoveFromDiscard();

                toTable = GetTableau(tableauNo);
                //Add card to table
                AddCardToTable(toTable, king);

                //Increment number of cards face up
                numCardsFaceUp[tableauNo]++;
            }
        }

        /// <summary>
        /// Performs move of Ace to empty suitPile from tables or discard pile if valid move is possible 
        /// </summary>
        /// <param name="ace">Ace to be moved to suitPile</param>
        /// <param name="startLocation">location where the ace is coming from - discard, suit or table</param>
        public static void PlayAce(Card ace, string startLocation) {
            int tableauNo;

            // If the from location is the discard pile
            if (startLocation == LOCATION_DISCARD) {

                AddAceToEmptySuitPile(ace);

                RemoveLastDiscard();

                DrawCard();
                // If the from location is one of the tables
            } else if (startLocation == LOCATION_TABLE) {

                AddAceToEmptySuitPile(ace);

                Hand fromTable;

                fromTable = GetTableauContainingCard(ace, out tableauNo);

                RemoveCardFromTableau(fromTable, ace);
            }
        }

        // Methods to return class variables

        /// <summary>
        /// Returns the last card in specified suitPile in suitPiles array
        /// </summary>
        /// <param name="whichSuit">Index of suitPile in suitPiles to return last card of</param>
        /// <returns>Returns the last card in specified suitPile in suitPiles array</returns>
        public static Card GetLastCardSuitPile(int whichSuit) {
            return suitPiles[whichSuit].GetLastCardInPile();
        }

        /// <summary>
        /// Returns number of cards in specified suitPile in suitPiles array
        /// </summary>
        /// <param name="whichSuit">Index of suitPile in suitPiles to return number of cards for</param>
        /// <returns>Returns number of cards in specified suitPile in suitPiles array</returns>
        public static int GetSuitPileCount(int whichSuit) {
            return suitPiles[whichSuit].GetCount();
        }

        /// <summary>
        /// Returns number of cards face up in specified tableau
        /// </summary>
        /// <param name="whichTableau">Index of tableau in tableauPiles to number face up cards for</param>
        /// <returns>Returns number of cards face up in specified tableau</returns>
        public static int GetNumCardsFaceUp(int whichTableau) {
            return numCardsFaceUp[whichTableau];
        }

        /// <summary>
        /// Returns tableau at specified location in tableauPiles array
        /// </summary>
        /// <param name="tableauNum">Index of tableau in tableauPiles to return tableau for</param>
        /// <returns>Returns tableau at specified location in tableauPiles array</returns>
        public static Hand GetTableau(int tableauNum) {
            return tableauPiles[tableauNum];
        }

        /// <summary>
        /// Returns last card in the discardPile
        /// </summary>
        /// <returns>Returns last card in the discardPile</returns>
        public static Card GetLastDiscard() {
            return discardPile.GetLastCardInPile();
        }

        /// <summary>
        /// Returns number of cards in the drawPile
        /// </summary>
        /// <returns>Returns number of cards in the drawPile</returns>
        public static int GetNumDrawCards() {
            return drawPile.GetCount();
        }

        /// <summary>
        /// Returns number of cards in the discardPile
        /// </summary>
        /// <returns>Returns number of cards in the discardPile</returns>
        public static int GetNumDiscardCards() {
            return discardPile.GetCount();
        }

        // Basic gameplay methods

        /// <summary>
        /// Resets drawPile by assigning discardPile into drawPile. Then draws a new card
        /// </summary>
        public static void ResetDrawPile() {
            drawPile = discardPile;
            discardPile = new CardPile();
            discardPile.Add(drawPile.DealOneCard());
        }

        /// <summary>
        /// Checks whether a game has been won.
        /// Win condition - all suitPiles must contain 13 cards
        /// Returns true if game won, otherwise returns false.
        /// </summary>
        /// <returns>Returns true if game won, otherwise returns false.</returns>
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

        /// <summary>
        /// Draws a new card from the drawPile and adds it to the discardPile
        /// </summary>
        public static void DrawCard() {

            if (drawPile.GetCount() == 0) {
                ResetDrawPile();
            }

            discardPile.Add(drawPile.DealOneCard());
        }

        /// <summary>
        /// Removes last card from the discardPile
        /// </summary>
        public static void RemoveLastDiscard() {
            discardPile.RemoveLastCard();
        }

        // Private methods

        // Helper methods to move cards between areas on board

        /// <summary>
        /// Adds card passed as parameter to an available empty suitPile if the card is an Ace
        /// </summary>
        /// <param name="card">Card to be added to empty suitPile if it is an Ace</param>
        private static void AddAceToEmptySuitPile(Card card) {

            if (card.GetFaceValue() == FaceValue.Ace) {
                if (suitPiles[PILE_ONE].GetCount() == 0) {
                    suitPiles[PILE_ONE].Add(card);
                } else if (suitPiles[PILE_TWO].GetCount() == 0) {
                    suitPiles[PILE_TWO].Add(card);
                } else if (suitPiles[PILE_THREE].GetCount() == 0) {
                    suitPiles[PILE_THREE].Add(card);
                } else if (suitPiles[PILE_FOUR].GetCount() == 0) {
                    suitPiles[PILE_FOUR].Add(card);
                }
            }
        }

        /// <summary>
        /// Removes firstCard from the 'giving' suitPile 
        /// Decrements number of numCardsFaceUp if number of cards in numCardsFaceUp is greater than 1
        /// Method paired with MoveToTable to move cards between tables
        /// </summary>
        /// <param name="firstCard">Card to be moved from table to other location if valid move possible</param>
        private static void MoveFromTable(Card firstCard) {
            Hand fromTable;
            int tableauNo;

            fromTable = GetTableauContainingCard(firstCard, out tableauNo);

            //Remove card from table
            RemoveCardFromTableau(fromTable, firstCard);

            //Decrement number of cards visible if number visible is greather than 1
            if (numCardsFaceUp[tableauNo] > 1) {
                numCardsFaceUp[tableauNo]--;
            }
        }

        /// <summary>
        /// Adds firstCard contained in one suitPile to different receiving suitPile containing secondCard 
        /// Increments numCardsFaceUp to reflect additional card in suitPile
        /// Method paired with MoveFromTable to move cards between tables
        /// </summary>
        /// <param name="firstCard">Card to be added to different located suitPile</param>
        /// <param name="secondCard">Card firstCard will be placed onto if valid move is possible</param>
        private static void MoveToTable(Card firstCard, Card secondCard) {
            Hand toTable;
            int tableauNo;

            toTable = GetTableauContainingCard(secondCard, out tableauNo);

            //Add card to table
            AddCardToTable(toTable, firstCard);

            //Increment number of cards face up
            numCardsFaceUp[tableauNo]++;
        }

        /// <summary>
        /// Removes last card from discardPile and draws a new card
        /// </summary>
        private static void MoveFromDiscard() {
            // Remove last card from discard
            RemoveLastDiscard();

            // Draw card
            DrawCard();
        }

        /// <summary>
        /// Adds firstCard to suitpile containing secondCard
        /// Uses secondCard to identify which suitpile the firstCard should be added to
        /// </summary>
        /// <param name="firstCard">Card to be moved to other suitpile</param>
        /// <param name="secondCard">Card contained in receiving cardpile used to identify suitPile</param>
        private static void MoveToSuitPile(Card firstCard, Card secondCard) {

            for (int i = 0; i < NUM_OF_SUITS; i++) {

                if (suitPiles[i].GetCount() != 0) {
                    if (suitPiles[i].GetLastCardInPile() == secondCard) {
                        suitPiles[i].Add(firstCard);
                    }
                }
            }
        }

        /// <summary>
        /// Returns tableau that contains specified card
        /// </summary>
        /// <param name="card">Card to search tableauPiles for</param>
        /// <param name="tableauNo">What number table in the tableauPiles array</param>
        /// <returns>Returns tableau that contains specified card</returns>
        private static Hand GetTableauContainingCard(Card card, out int tableauNo) {
            Hand tableau = new Hand();
            // assigned value to prevent compiler error
            tableauNo = 0;

            for (int i = 0; i < NUM_OF_TABLEAU; i++) {
                if (tableauPiles[i].Contains(card)) {
                    tableau = tableauPiles[i];
                    tableauNo = i;
                }
            }
            return tableau;
        }

        /// <summary>
        /// Adds card passed as parameter from  tableau passed as parameter
        /// </summary>
        /// <param name="tableau">Tableau to add card to</param>
        /// <param name="card">Card to be added to tableau</param>
        private static void AddCardToTable(Hand tableau, Card card) {
            tableau.Add(card);
        }

        /// <summary>
        /// Removes card passed as parameter from  tableau passed as parameter
        /// </summary>
        /// <param name="tableau">Tableau to remove card from</param>
        /// <param name="card">Card to be removed from tableau</param>
        private static void RemoveCardFromTableau(Hand tableau, Card card) {
            tableau.Remove(card);
        }

        // Helper methods to do validation of moves

        /// <summary>
        /// Checks wheteher a move is a valid numerical move. Uses Cards enum to compare card values
        /// Valid move returns true, otherwise returns false
        /// </summary>
        /// <param name="firstCard"></param>
        /// <param name="secondCard"></param>
        /// <param name="destLocation"></param>
        /// <returns></returns>
        private static bool CheckValidNumericalMove(Card firstCard, Card secondCard, string destLocation) {
            bool validMove = false;

            // Move to table pile - valid move if card 2 facevalue is is one less than card 1 in Cards enum
            if (destLocation == LOCATION_TABLE) {
                if ((int)secondCard.GetFaceValue() - (int)firstCard.GetFaceValue() == ONE_LESS) {
                    validMove = true;
                }
            } // Move to suit pile - valid if Facevalue Two moved onto FaceValue Ace
            else if (destLocation == LOCATION_SUIT && secondCard.GetFaceValue() == FaceValue.Ace) {
                if (firstCard.GetFaceValue() == FaceValue.Two) {
                    return true;
                }
            } // Move to suit pile - valid if card 1 facevalue is one higher than card 2 in Cards enum
            else if (destLocation == LOCATION_SUIT) {
                if ((int)firstCard.GetFaceValue() - (int)secondCard.GetFaceValue() == ONE_HIGHER) {
                    validMove = true;
                }
            } else {
                validMove = false;
            }

            return validMove;
        }

        /// <summary>
        /// Checks whether the colour of the firstCard and secondCard match
        /// If they match returns true, otherwise returns false.
        /// </summary>
        /// <param name="firstCard">First card to compare colour</param>
        /// <param name="secondCard">Second card to compare suits</param>
        /// <returns>Returns true if cards colour matches, otherwise returns false</returns>
        private static bool CheckSameColour(Card firstCard, Card secondCard) {
            if (firstCard.GetColour() == secondCard.GetColour()) {
                return true;
            } else {
                return false;
            }
        }

        /// <summary>
        /// Checks whether the suit of the firstCard and secondCard match
        /// If they match returns true, otherwise returns false.
        /// </summary>
        /// <param name="firstCard">First card to compare suits</param>
        /// <param name="secondCard">Second card to be compared</param>
        /// <returns>Returns true if cards suit matches, otherwise returns false </returns>
        private static bool CheckSameSuit(Card firstCard, Card secondCard) {
            if (firstCard.GetSuit() == secondCard.GetSuit()) {
                return true;
            } else {
                return false;
            }
        }

        // Private helper methods to setup the game

        /// <summary>
        /// Initializes  hand objects in the tableauPiles array
        /// including dealing number of cards reqiured for initial board layout 
        /// </summary>
        private static void SetupTableau() {
            int numOfCards;
            for (int tableauNo = 0; tableauNo < NUM_OF_TABLEAU; tableauNo++) {
                // Each hand of cards contains the array position + 1 number of cards
                numOfCards = tableauNo + 1;
                tableauPiles[tableauNo] = new Hand(drawPile.DealCards(numOfCards));
            }
        }

        /// <summary>
        /// Initializes the cardPile objects inside the suitPiles array. 
        /// </summary>
        private static void SetupSuitPiles() {
            // Add new CardPile to each position in suitPiles array
            for (int i = 0; i < NUM_OF_SUITS; i++) {
                suitPiles[i] = new CardPile();
            }
        }

        /// <summary>
        /// Resets number of fards faceup for each table in numCardsFaceUp back to the default value
        /// </summary>
        private static void ResetNumFaceUp() {
            for (int i = 0; i < NUM_OF_TABLEAU; i++) {
                numCardsFaceUp[i] = DEFAULT_FACE_UP;
            }
        }
    }
}
