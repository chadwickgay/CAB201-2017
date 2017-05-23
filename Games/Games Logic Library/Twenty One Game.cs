using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Low_Level_Objects_Library;

namespace Games_Logic_Library {
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
        private static int[] numOfGamesWon = new int[] {0,0}; // INITIAL BUG STILL EXISTS
        private static int numOfUserAcesWithValueOne;

        // Class methods

        public static void SetUpGame() {

            totalPoints = new int[] { 0, 0 };
            numOfUserAcesWithValueOne = 0;

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
        }

        public static Card DealOneCardTo(int who) {
            Card card;

            // Create new deck of cards if the pile is empty
            if (cardPile.GetCount() == 0) {
                cardPile = new CardPile(true);
                cardPile.Shuffle();
            }

            // Deal card to person
            card = cardPile.DealOneCard();
            hands[who].Add(card);

            return card;
        }

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

            DeterminePlayerBust(who);

            return totalHand;
        }

        public static void PlayForDealer() {
            totalPoints[DEALER] = CalculateHandTotal(DEALER);

            while (totalPoints[DEALER] < DEALER_HIT_TRESHOLD) {
                DealOneCardTo(DEALER);

                totalPoints[DEALER] = CalculateHandTotal(DEALER);
            }

           DetermineWinner(DEALER);
        } 

        public static Hand GetHand(int who) {
            return hands[who];
        }

        public static int GetTotalPoints(int who) {
            return totalPoints[who];
        }

        public static int GetNumOfGamesWon(int who) {
            return numOfGamesWon[who];
        }

        public static int GetNumOfUserAcesWithValueOfOne() {
            return numOfUserAcesWithValueOne;
        }

        public static void IncrementNumOfUserAcesWithValueOne() {
            numOfUserAcesWithValueOne++;
        }

        private static void DetermineWinner(int who) {
            // Dealer busts
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
        }

        private static void DeterminePlayerBust(int who) {
            // Player Bust
            if (who == PLAYER && totalPoints[PLAYER] > WIN) {
                numOfGamesWon[DEALER]++;
            } // Dealer bust - avoids double increment from DetermineWinner
            else if (who == DEALER && totalPoints[DEALER] > WIN && totalPoints[PLAYER] != WIN) {
                numOfGamesWon[PLAYER]++;
            }
        }

    }


}
