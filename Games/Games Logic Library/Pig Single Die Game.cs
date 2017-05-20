using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Low_Level_Objects_Library;

namespace Games_Logic_Library {
    public class Pig_Single_Die_Game {

        static Die myDie = new Die();

        // Should I even have this?
        private const int NUM_OF_PLAYERS = 2;
        private const int WINNING_SCORE = 30;

        private static int faceValue;

        private static int[] pointsTotal;

        private static string[] playersName;

        private static int currentPlayer;

        /// <summary>
        /// Initializes class variables at start of a new game.
        /// </summary>
        public static void SetUpGame() {

            faceValue = GetFaceValue();

            // Index 0 unused to make player numbering more intuitive
            playersName = new string [] {"", "Player 1", "Player 2"};

            // Index 0 unused to make player numbering more intuitive
            pointsTotal = new int[] { 0, 0, 0 };

            currentPlayer = 1;            
        }

        public static bool PlayGame() {
            bool playGame = true;
            int previousScore, gameOver;

            gameOver = 1;

            // problem here
            previousScore = pointsTotal[currentPlayer];

            myDie.RollDie();

            faceValue = GetFaceValue();

            if (faceValue == gameOver) {
                pointsTotal[currentPlayer] = previousScore;
                return playGame = false;
            } else {
                pointsTotal[currentPlayer] = pointsTotal[currentPlayer] + faceValue;
                playGame = true;
            }         
            return playGame;
        }

        public static bool HasWon() {
            if (pointsTotal[currentPlayer] >= WINNING_SCORE) {
                return true;
            } else {
                return false;
            }
        }

        public static string GetFirstPLayersName() {
            return playersName[currentPlayer];
        }

        public static string GetNextPlayersName() {
           SwitchPlayers();

           return playersName[currentPlayer];
        }

        public static int GetPointsTotal(string nameOfPlayer) {

            int playerOne, playerTwo;

            playerOne = 1;
            playerTwo = 2;

            if (nameOfPlayer == "Player 1") {
                return pointsTotal[playerOne];
            } else {
                return pointsTotal[playerTwo];
            }
        }

        public static int GetFaceValue() {
            int faceValue;

            faceValue = myDie.GetFaceValue();

            return faceValue;
        }

        private static void SwitchPlayers() {
            if (currentPlayer == 1) {
                currentPlayer = 2;
            } else {
                currentPlayer = 1;
            }
        }
    }
}
