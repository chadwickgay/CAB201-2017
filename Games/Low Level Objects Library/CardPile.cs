using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Low_Level_Objects_Library {

    /// <summary>
    /// CardPile holds a collection of playing cards.
    /// 
    /// Objects in this class may be used for different purposes.
    /// 
    /// When first constructed, a CardPile may contain a full deck of 52 playing cards,
    /// with all the combinations of FaceValue (from Two to Ace) and Suit (from Clubs to Spades).
    /// 
    /// Alternatively, a CardPile may be constructed as an empty pile, 
    /// e.g. for holding cards that will be discarded during a game.
    /// 
    /// Based on earlier Java Program written in 2002 for ITB410 at QUT
    /// 
    /// Mike Roggenkamp and Jim Reye (2009)
    /// 
    /// </summary>
    public class CardPile {

        public static int NUM_SUITS = 4;
        public static int NUM_CARDS_PER_SUIT = 13;
        private List<Card> pile;

        private static Random randomValue = new Random(10);

        
        /// <summary>
        /// initialises a pile of cards with a full deck of 52 playing cards
        /// when parameter is true
        /// </summary>
        /// <params> if true pile will have 52 cards
        ///           else pile will be empty
        ///</params>
        public CardPile(bool initialiseWith52Cards) {
            Colour suitColour;
            
            pile = new List<Card>();

            if (initialiseWith52Cards) {
                // Add 52 cards - One card of each Suit and FaceValue combination to the pile.
                for (Suit suit = Suit.Clubs; suit <= Suit.Spades; suit++) {
                    suitColour = DetermineSuitColour(suit);
                    for (FaceValue faceValue = FaceValue.Two; faceValue <= FaceValue.Ace; faceValue++) {
                        pile.Add(new Card(suit, faceValue, suitColour));
                    }
                }
            } // else empty card pile
        }

        /// <summary>
        /// Default Constructor - no cards in the pile.
        /// </summary>
        public CardPile() {
            pile = new List<Card>();
        }


        /// <summary>
        /// Adds a card to the pile
        /// </summary>
        /// <param name="card"> the card to be added to the pile</param>
        public void Add(Card card) {
            pile.Add(card);
        }

        /// <summary>
        /// The number of cards currently in the pile
        /// </summary>
        /// <returns>The number of cards  in the pile</returns>
        public int GetCount() {
            return pile.Count;
        }

        /// <summary>
        /// Returns the card in the last position in the pile,
        /// but does not remove it from the pile.
        /// </summary>
        /// <returns> the last card  in the pile</returns>
        public Card GetLastCardInPile() {
            return pile[pile.Count - 1];
        }

        /// <summary>
        /// Shuffles a pile of cards
        /// in order to randomly mix the order 
        /// of the cards in the pile.
        /// </summary>
        public void Shuffle() {

            for (int n = pile.Count - 1; n > 0; n--) {
                int k = randomValue.Next(n + 1);
                Card temp = pile[n];
                pile[n] = pile[k];
                pile[k] = temp;
            }

        } //end Shuffle

        /// <summary>
        /// Deals the next card from the pile
        /// removing it from the pile.
        /// </summary>
        /// <returns>the next card in the pile</returns>
        public Card DealOneCard() {
            Card card = pile[0];
            pile.RemoveAt(0);
            return card;
        }//end DealOneCard

        /// <summary>
        /// Deals a number of cards from the pile.
        /// 
        /// Post: numCardsToDeal cards of the pile have been dealt, removing them from the pile.
        /// </summary>
        /// <param name="numCardsToDeal"> number of cards to be dealt</param>
        /// <returns>A list containing the next numCardsToDeal cards from the pile</returns>
        public List<Card> DealCards(int numCardsToDeal) {
            List<Card> cards = new List<Card>();

            for (int i = 0; i < numCardsToDeal; i++)
                cards.Add(DealOneCard());
                       
            return cards;
        } //end DealCards

        /// <summary>
        /// Determines the colour of the Suit
        /// </summary>
        /// <param name="suit">a card's suit</param>
        /// <returns>the colour of that suit</returns>
        private Colour DetermineSuitColour(Suit suit) {
         
            switch (suit) {
                case Suit.Clubs:
                case Suit.Spades: return Colour.Black;

                case Suit.Hearts:
                case Suit.Diamonds: return Colour.Red;


            }//end switch

            return Colour.Black;  // this code is unreachable but necessary for compiler to see all paths return a value.

        } //end DetermineSuitColour


    }//end class CardPile
}//end namespace
