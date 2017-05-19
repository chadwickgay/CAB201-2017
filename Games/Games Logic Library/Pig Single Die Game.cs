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
        const int NUM_OF_PLAYERS = 2;

        static int faceValue;

        static int[] pointsTotal;

        static string[] playersName;

        /// <summary>
        /// Initializes class variables at start of a new game.
        /// </summary>
        public static void SetUpGame() {

            faceValue = GetFaceValue();

            playersName = new string [] {"Player 1", "Player 2"};            
        }

        public static bool PlayGame() {
            bool playGame = false;

            myDie.RollDie();

            faceValue = GetFaceValue();

            return playGame;
        }

        public static bool HasWon() {
            bool won = false;

            return won;
        }

        public static string GetFirstPLayersName() {
            string name = "";

            return name;
        }

        public static string GetNextPlayersName() {
            string name = "";

            return name;
        }

        public static int GetPointsTotal(string nameOfPlayer) {
            int totalPoints = 0;

            return totalPoints;
        }

        public static int GetFaceValue() {
            int faceValue;

            faceValue = myDie.GetFaceValue();

            return faceValue;
        }
    }
}
