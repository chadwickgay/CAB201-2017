﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Low_Level_Objects_Library;

namespace Games_Logic_Library {
    public class Pig_Single_Die_Game {

        static Die myDie = new Die();

        private static int faceValue;

        private static int[] pointsTotal;

        private static string[] playersName;

        // Added variables
        // Should I even have this?
        private const int NUM_OF_PLAYERS = 2;
        private const int WINNING_SCORE = 30;

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

            currentPlayer = 1;            
        }

        public static bool PlayGame() {
            bool playGame = true;
            int gameOver;

            gameOver = 1;    

            if (firstRoll) {
                previousScore = pointsTotal[currentPlayer];
            }

            myDie.RollDie();

            faceValue = GetFaceValue();

            if (faceValue == gameOver) {
                pointsTotal[currentPlayer] = previousScore;
                return playGame = false;
            } else {
                pointsTotal[currentPlayer] = pointsTotal[currentPlayer] + faceValue;
                playGame = true;
            }

            firstRoll = false;
                    
            return playGame;
        }

        public static bool HasWon() {
            if (pointsTotal[currentPlayer] >= WINNING_SCORE) {

                ResetPlayerScores();

                ResetCurrentPlayer();

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

        // Private methods

        private static void SwitchPlayers() {
            if (currentPlayer == 1) {
                currentPlayer = 2;
            } else {
                currentPlayer = 1;
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
    }
}