using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Low_Level_Objects_Library;

namespace Games_Logic_Library {
    public static class Pig_Two_Die_Game {

        // UML variables
        private static Die[] dice = new Die[NUM_OF_DICE];
        private static int[] faceValue = new int[NUM_OF_DICE];
        private static int[] pointsTotal;
        private static string[] playersName;

        // Constants for game parameters
        private const int NUM_OF_PLAYERS = 2;
        private const int WINNING_SCORE = 30;
        private const int GAME_OVER = 1;
        private const int DOUBLE_ONE_ROLL = 25;
        private const int DOUBLE_SCORE = 2;
        private const int NUM_OF_DICE = 2;
        private const int DIE_ONE = 0;
        private const int DIE_TWO = 1;
        private const int PLAYER_ONE = 1;
        private const int PLAYER_TWO = 2;

        // Helper functions
        private static int currentPlayer;
        private static int previousScore;
        private static bool firstRoll = true;
  
        /// <summary>
        /// Initializes class variables at start of a new game.
        /// </summary>
        public static void SetUpGame() {

            // New
            InitializeDice();

            // Get face values of each die
            for (int i = 0; i < NUM_OF_DICE; i++) {
                faceValue[i] = GetFaceValue(i);
            }

            // Index 0 unused to make player numbering more intuitive
            playersName = new string[] { "", "Player 1", "Player 2" };

            // Index 0 unused to make player numbering more intuitive
            pointsTotal = new int[] { 0, 0, 0 };

            // Setup the first player as the current player for first round
            currentPlayer = 1;
        }

        /// <summary>
        /// Rolls the dice once for the current player, updating the player’s score
        /// appropriately according to the faceValues of the dice just rolled.
        /// </summary>
        /// <returns>Returns true if the player has rolled a single “1”, otherwise it returns false</returns>
        public static bool PlayGame() {
            bool playGame = true;

            // Store the previous score of the player if this is their first roll
            if (firstRoll) {
                previousScore = pointsTotal[currentPlayer];
            }

            // Roll each of the dice
            RollDie();

            // Store facevalues of each die rolled
            StoreFaceValues();

            // Calculate score from facevalues - false if turn ended
            playGame = CalculateScore();

            // reset firstRoll before the next game 
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
        ///  Returns the name of the next player
        /// </summary>
        /// <returns>Returns the name of the next player</returns>
        public static string GetNextPlayersName() {
            SwitchPlayers();

            return playersName[currentPlayer];
        }

        /// <summary>
        /// Returns the specified player’s current points total
        /// </summary>
        /// <param name="nameOfPlayer">Name of the current player</param>
        /// <returns></returns>
        public static int GetPointsTotal(string nameOfPlayer) {

            if (nameOfPlayer == "Player 1") {
                return pointsTotal[PLAYER_ONE];
            } else {
                return pointsTotal[PLAYER_TWO];
            }
        }

        /// <summary>
        /// Returns the faceValue of the specified die
        /// </summary>
        /// <param name="whichDie">What number die to return faceValue of</param>
        /// <returns></returns>
        public static int GetFaceValue(int whichDie) {
            int faceValue;

            faceValue = dice[whichDie].GetFaceValue();

            return faceValue;
        }

        // Need to comment these
        // Private methods
        private static void SwitchPlayers() {
            if (currentPlayer == PLAYER_ONE) {
                currentPlayer = PLAYER_TWO;
            } else {
                currentPlayer = PLAYER_ONE;
            }

            firstRoll = true;
        }

        private static void ResetPlayerScores() {
            for (int i = 0; i < pointsTotal.Length; i++) {
                pointsTotal[i] = 0;
            }

            firstRoll = true;
        }

        private static void ResetCurrentPlayer() {
            currentPlayer = 1;
        }

        private static void InitializeDice() {
            for (int i = 0; i < NUM_OF_DICE; i++) {
                dice[i] = new Die();
            }
        }

        private static void RollDie() {
            for (int i = 0; i < NUM_OF_DICE; i++) {
                dice[i].RollDie();
            }
        }

        private static void StoreFaceValues() {
            for (int i = 0; i < NUM_OF_DICE; i++) {
                faceValue[i] = GetFaceValue(i);
            }
        }

        private static bool CalculateScore() {
            bool playGame;

            // Comment each of the if statements
            if (faceValue[DIE_ONE] == GAME_OVER && faceValue[DIE_TWO] != GAME_OVER) {
                pointsTotal[currentPlayer] = previousScore;
                playGame = false;

            } else if (faceValue[DIE_ONE] != GAME_OVER && faceValue[DIE_TWO] == GAME_OVER) {
                pointsTotal[currentPlayer] = previousScore;
                playGame = false;

            } else if (faceValue[DIE_ONE] == GAME_OVER && faceValue[DIE_TWO] == GAME_OVER) {
                pointsTotal[currentPlayer] = pointsTotal[currentPlayer] + DOUBLE_ONE_ROLL;
                playGame = true;

            } else if (faceValue[DIE_ONE] == faceValue[DIE_TWO]) {
                pointsTotal[currentPlayer] = pointsTotal[currentPlayer] + ((faceValue[DIE_ONE] + faceValue[DIE_TWO]) * DOUBLE_SCORE);
                playGame = true;

            } else {
                pointsTotal[currentPlayer] = pointsTotal[currentPlayer] + (faceValue[DIE_ONE] + faceValue[DIE_TWO]);
                playGame = true;
            }

            return playGame;
        }
    }
}
