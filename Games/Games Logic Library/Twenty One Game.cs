using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Low_Level_Objects_Library;

namespace Games_Logic_Library {
    public class Twenty_One_Game {

        // Class variables

        public const int NUM_OF_PLAYERS = 2;
        private const int INITIAL_HAND_SIZE = 2;
        private const int FACE_CARD_VALUE = 10;
        private const int ACE_VALUE = 11;
        private const int CARD_ENUM_VALUE_OFFSET = 2;
        private const int PLAYER = 0;
        private const int DEALER = 1;
        private const int WIN = 21;

        private static CardPile cardPile;
        private static Hand[] hands;
        private static int[] totalPoints;
        private static int[] numOfGamesWon;
        private static int numOfUserAcesWithValueOne;

        // Class methods

        public static void SetUpGame() {

            totalPoints = new int[] { 0, 0 };
            numOfGamesWon = new int[] { 0, 0 };
            numOfUserAcesWithValueOne = 0;

            cardPile = new CardPile(true);

            cardPile.Shuffle();

            Hand playerHand = new Hand();
            Hand dealerHand = new Hand();

            hands = new Hand[NUM_OF_PLAYERS] { playerHand, dealerHand };

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
            // Subtract 10 points for every Ace in hand with value of 1. Dealer has no option to do this
            if (who == PLAYER) {
                totalHand -= (10 * numOfUserAcesWithValueOne);
            }
            // need to check this section
            totalPoints[who] = totalHand;
            return totalHand;
        }

        public static void PlayForDealer() {
            totalPoints[DEALER] = CalculateHandTotal(DEALER);

            while (totalPoints[DEALER] < 17) {
                DealOneCardTo(DEALER);

                totalPoints[DEALER] = CalculateHandTotal(DEALER);
            }
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

        private static void DetermineWinner() {
            // Dealer gets 21
            if (totalPoints[DEALER] == WIN) {
                numOfGamesWon[DEALER]++;
            }
            // Dealer busts
            if (totalPoints[DEALER] > 21) {
                numOfGamesWon[PLAYER]++;
            }
            // Dealer score higher
            if (totalPoints[DEALER] > totalPoints[PLAYER]) {
                numOfGamesWon[DEALER]++;
            }
            // Player score higher
            if (totalPoints[PLAYER] > totalPoints[DEALER]) {
                numOfGamesWon[PLAYER]++;
            }
        }

    }


}
