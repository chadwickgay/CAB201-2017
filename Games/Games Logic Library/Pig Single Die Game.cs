using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Low_Level_Objects_Library;

namespace Games_Logic_Library {

    /// <summary>
    /// Underlying game logic to play Pig with 2 Dice
    /// 
    /// Functionality includes rolling multiple dice, with score calculation
    /// after each die roll and ability to play multiple rounds. 
    /// Double scoring is implimented for double rolls along with increased 
    /// score for double 1s.
    /// 
    /// Implimented in combination with Pig with To Dice Form
    /// 
    /// Author Chadwick Gay June 2017 - Student number n9410392
    /// </summary>
    public static class Pig_Single_Die_Game {

        static Die die = new Die();
        private static int faceValue;
        private static int[] pointsTotal;
        private static string[] playersName;

        private const int NUM_OF_PLAYERS = 2;
        private const int WINNING_SCORE = 30;
        private const int GAME_OVER = 1;

        private const int PLAYER_ONE = 1;
        private const int PLAYER_TWO = 2;

        private static int currentPlayer;
        private static int previousScore;
        private static bool firstRoll = true;

        /// <summary>
        /// Initializes class variables at start of a new game.
        /// </summary>
        public static void SetUpGame() {

            faceValue = GetFaceValue();

            // Index 0 unused to make player numbering more intuitive
            playersName = new string [] {"", "Player 1", "Player 2"};

            // Index 0 unused to make player numbering more intuitive
            pointsTotal = new int[] { 0, 0, 0 };

            // Setup the first player as the current player for first round
            currentPlayer = 1;            
        }

        /// <summary>
        /// Rolls the die once for the current player, updating the player’s score
        /// appropriately according to the faceValue just rolled.
        /// </summary>
        /// <returns> returns true if the player has rolled a “1”, otherwise it returns false.</returns>
        public static bool PlayGame() {
            bool playGame = true;

            if (firstRoll) {
                previousScore = pointsTotal[currentPlayer];
            }

            die.RollDie();

            faceValue = GetFaceValue();

            if (faceValue == GAME_OVER) {
                pointsTotal[currentPlayer] = previousScore;
                return playGame = false;
            } else {
                pointsTotal[currentPlayer] = pointsTotal[currentPlayer] + faceValue;
                playGame = true;
            }

            firstRoll = false;
                    
            return playGame;
        }

        /// <summary>
        /// Returns true if player has won this game else returns false
        /// </summary>
        /// <returns>Returns true if player has won this game else returns false</returns>
        public static bool HasWon() {
            if (pointsTotal[currentPlayer] >= WINNING_SCORE) {

                ResetPlayerScores();

                ResetCurrentPlayer();

                return true;
            } else {
                return false;
            }
        }

        /// <summary>
        /// Returns the name of the player going first
        /// </summary>
        /// <returns>Returns the name of the player going first</returns>
        public static string GetFirstPLayersName() {
            return playersName[currentPlayer];
        }

        /// <summary>
        /// Returns the name of the next player
        /// </summary>
        /// <returns>Returns the name of the next player</returns>
        public static string GetNextPlayersName() {
           SwitchPlayers();

           return playersName[currentPlayer];
        }

        /// <summary>
        /// Returns the specified player’s current points totals
        /// </summary>
        /// <param name="nameOfPlayer">Name of player to return points for</param>
        /// <returns>Returns the specified player’s current points totals</returns>
        public static int GetPointsTotal(string nameOfPlayer) {

            if (nameOfPlayer == "Player 1") {
                return pointsTotal[PLAYER_ONE];
            } else {
                return pointsTotal[PLAYER_TWO];
            }
        }

        /// <summary>
        /// Returns the current faceValue of the die
        /// </summary>
        /// <returns>Returns the current faceValue of the die</returns>
        public static int GetFaceValue() {
            int faceValue;

            faceValue = die.GetFaceValue();

            return faceValue;
        }

        // Private methods

        /// <summary>
        /// Switches the current player to the other player
        /// </summary>
        private static void SwitchPlayers() {
            if (currentPlayer == 1) {
                currentPlayer = 2;
            } else {
                currentPlayer = 1;
            }

            firstRoll = true;
        }

        /// <summary>
        /// Resets each of the player scores back to 0
        /// so a new round can be played
        /// </summary>
        private static void ResetPlayerScores() {
            for (int i = 0; i < pointsTotal.Length; i++) {
                pointsTotal[i] = 0;
            }

            firstRoll = true;
        }

        /// <summary>
        /// Resets the current player back to player 1
        /// </summary>
        private static void ResetCurrentPlayer() {
            currentPlayer = 1;
        }
    }
}
