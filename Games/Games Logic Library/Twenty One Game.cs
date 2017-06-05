using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Low_Level_Objects_Library;

namespace Games_Logic_Library {
    /// <summary>
    /// Underlying game logic class to play simplified version of Twenty-One.
    /// 
    /// Functionality allows for play of multiple games of Twenty-One 
    /// with calculation of player totals and determination of winner
    /// after each round is played.
    /// 
    /// Implimented in combination with TwentyOne Game Form
    /// 
    /// Author Chadwick Gay June 2017 - Student number n9410392
    /// </summary>
    public static class Twenty_One_Game {

        // Game parameters
        public const int NUM_OF_PLAYERS = 2;
        private const int INITIAL_HAND_SIZE = 2;
        private const int FACE_CARD_VALUE = 10;
        private const int ACE_VALUE = 11;

        private const int CARD_ENUM_VALUE_OFFSET = 2;

        // Player and dealer index values
        private const int PLAYER = 0;
        private const int DEALER = 1;

        // Game thresholds
        private const int WIN = 21;
        private const int DEALER_HIT_TRESHOLD = 17;

        // UML Variables
        private static CardPile cardPile = new CardPile(true);
        private static Hand[] hands = new Hand[NUM_OF_PLAYERS];
        private static int[] totalPoints;
        private static int[] numOfGamesWon = new int[] {0,0}; 
        private static int numOfUserAcesWithValueOne;

        // Class methods

        /// <summary>
        /// Initializes the class variables at start of a new game.
        /// </summary>
        public static void SetUpGame() {

            totalPoints = new int[] { 0, 0 };
            numOfUserAcesWithValueOne = 0;

            //Move this to a method of its own
            // Create new deck of cards if the pile is empty
            if (cardPile.GetCount() < (NUM_OF_PLAYERS * INITIAL_HAND_SIZE)) {
                cardPile = new CardPile(true);
                cardPile.Shuffle();
            }

            // Shuffle cards
            cardPile.Shuffle();

            // Deal intital hand for player and dealer
            Hand playerHand = new Hand(cardPile.DealCards(INITIAL_HAND_SIZE));
            Hand dealerHand = new Hand(cardPile.DealCards(INITIAL_HAND_SIZE));

            // Store dealt cards in hands arrays
            hands[PLAYER] = playerHand;
            hands[DEALER] = dealerHand;
        } // end SetUpGame

        /// <summary>
        /// Deals one card from cardPile to the hand of who and returns that card.
        /// </summary>
        /// <param name="who">The index of the person in the hands array to be dealt to</param>
        /// <returns>Returns the card dealt</returns>
        public static Card DealOneCardTo(int who) {
            Card card;

            // Move this to method of its own
            // Create new deck of cards if the pile is empty
            if (cardPile.GetCount() == 0) {
                cardPile = new CardPile(true);
                cardPile.Shuffle();
            }
            
            // Deal card to person
            card = cardPile.DealOneCard();
            hands[who].Add(card);

            return card;
        } // end DealOneCardTo

        /// <summary>
        ///  Adds the faceValues of all cards in the hand of who and
        ///  returns that total which is adjusted if who is the Player 
        ///  and has one or more aces valued as 1
        /// </summary>
        /// <param name="who">The index of the person in the hands array for score to be caluclated</param>
        /// <returns>returns that total which is adjusted if who is the Player and has one or more aces valued as 1</returns>
        public static int CalculateHandTotal(int who) {
            int totalHand = 0;

            foreach (Card card in hands[who]) {
                FaceValue faceValue = card.GetFaceValue();
                
                switch (faceValue) {
                    case FaceValue.Jack:
                    case FaceValue.Queen:
                    case FaceValue.King:
                        totalHand += FACE_CARD_VALUE;
                        break;
                    case FaceValue.Ace:
                        totalHand += ACE_VALUE;
                        break;
                    default:
                        totalHand += (int)faceValue + CARD_ENUM_VALUE_OFFSET;
                        break;
                }
            }
            // Subtract 10 points for every Ace in hand with value of 1. 
            if (who == PLAYER) {
                totalHand -= (10 * numOfUserAcesWithValueOne);
            }

            // need to check if this section is allowed/good idea
            totalPoints[who] = totalHand;

            DetermineBustOnPlayerTurn(who);

            return totalHand;
        } // end CalculateHandTotal

        /// <summary>
        /// Plays the Dealer’s turn until the Dealer stands or goes bust
        /// </summary>
        public static void PlayForDealer() {
            totalPoints[DEALER] = CalculateHandTotal(DEALER);

            while (totalPoints[DEALER] < DEALER_HIT_TRESHOLD) {
                DealOneCardTo(DEALER);

                totalPoints[DEALER] = CalculateHandTotal(DEALER);
            }

           DetermineWinner(DEALER);
        } // end PlayForDealer

        /// <summary>
        /// Returns the hand of who
        /// </summary>
        /// <param name="who">The index of the person in the hands array</param>
        /// <returns>Returns the hand of who</returns>
        public static Hand GetHand(int who) {
            return hands[who];
        } // end GetHand

        /// <summary>
        ///  Returns the points total of who
        /// </summary>
        /// <param name="who">The index of the person in the totalpoints array</param>
        /// <returns>Returns the points total of who</returns>
        public static int GetTotalPoints(int who) {
            return totalPoints[who];
        } // end GetTotalPoints

        /// <summary>
        /// Returns number of games won by who
        /// </summary>
        /// <param name="who">The index of the person in the numOfGamesWon array</param>
        /// <returns>Returns number of games won by who</returns>
        public static int GetNumOfGamesWon(int who) {
            return numOfGamesWon[who];
        } // end GetNumOfGamesWon

        /// <summary>
        /// Returns the number of Aces that the user has chosen
        /// to have value of 1.
        /// </summary>
        /// <returns>Returns the number of Aces that the user has chosen to have value of 1.</returns>
        public static int GetNumOfUserAcesWithValueOfOne() {
            return numOfUserAcesWithValueOne;
        } // end GetNumOfUserAcesWithValueOfOne

        /// <summary>
        /// Adds 1 to the numOfUserAcesWithValueOne
        /// </summary>
        public static void IncrementNumOfUserAcesWithValueOne() {
            numOfUserAcesWithValueOne++;
        } // end IncrementNumOfUserAcesWithValueOne

        /// <summary>
        /// Initialise the elements of the array, totalPoints to zero as well.
        /// Allows for player to cancel out of a game and come back in with scores reset 
        /// </summary>
        public static void ResetTotals() {
            for (int i = 0; i < NUM_OF_PLAYERS; i++) {
                numOfGamesWon[i] = 0;
            }
        } // end ResetTotals

        /// <summary>
        /// Determines winner of round after the dealer has taken their turn
        /// Incremements numOfGamesWon of dealer/player accordingly
        /// </summary>
        /// <param name="who">The index of the person in the totalpoints array</param>
        private static void DetermineWinner(int who) {
            // Dealer busts after drawing additional cards
            if (totalPoints[DEALER] > WIN && totalPoints[PLAYER] < WIN) {
                numOfGamesWon[PLAYER]++;
            } // Player score higher than dealer - but not busted
            else if (totalPoints[PLAYER] > totalPoints[DEALER] && totalPoints[PLAYER] <= WIN) {
                numOfGamesWon[PLAYER]++;
            } // Dealer scores higher than player - but not busted
            else if (totalPoints[DEALER] > totalPoints[PLAYER]  && totalPoints[DEALER] <= WIN) {
                numOfGamesWon[DEALER]++;
            } // Dealer gets 21 and player does not
            else if (totalPoints[DEALER] == WIN && totalPoints[PLAYER] != WIN) {
                numOfGamesWon[DEALER]++;
            } // Player gets 21 and player does not
            else if (totalPoints[PLAYER] == WIN && totalPoints[DEALER] != WIN) {
                numOfGamesWon[PLAYER]++;
            }
        } // end DetermineWinner

        /// <summary>
        /// Determines if either the player or the dealer has busted on the players turn.
        /// Incremements numOfGamesWon of dealer/player accordingly
        /// </summary>
        /// <param name="who">The index of the person in the totalpoints array</param>
        private static void DetermineBustOnPlayerTurn(int who) {
            // Determine if player has busted 
            if (who == PLAYER && totalPoints[PLAYER] > WIN) {
                numOfGamesWon[DEALER]++;
            } // Determine if dealer has busted on their initial hand (two Aces will cause dealer bust)
            else if (who == PLAYER && totalPoints[DEALER] > WIN && totalPoints[PLAYER] != WIN) {
                numOfGamesWon[PLAYER]++;
            }
        } // end DetermineBustOnPlayerTurn

    }


}
