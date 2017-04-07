using System;



namespace Gold_Lotto_Checker_Stage_2 {
    /// <summary>
    /// 
    /// Stage 2 Gold Lotto Checker program which displays pre-defined lotto numbers for multiple 
    /// lotto games. Set of unique draw numbers are randomly generated each time program is run.
    /// Checks draw numbers against multiple lotto games to determine how many winning or 
    /// supplementary numbers exist in each game. Outputs results to console.
    /// 
    /// Prompts user to exit the program gracefully.
    /// 
    /// Author Chadwick Gay April 2017
    /// Student Number 9410392
    /// </summary>
    class Program {

        static Random randomValue = new Random(10);

        // Sets the inclusive  range of numbers that can be drawn as part of the lotto.
        const int DRAW_FIRST_NUMBER = 1;
        const int DRAW_LAST_NUMBER = 45;

        // Threshold for standard number/supplementary number in draw numbers
        const int SUPP_THRESHOLD = 5;

        // Number of lotto draw numbers to be generated
        const int NUM_DRAW_NUMBERS = 8;       

        static void Main() {

            int[,] lottoNumbers ={
                                  { 4, 7, 19, 23, 28, 36},
                                  {14, 18, 26, 34, 38, 45},
                                  { 8, 10,11, 19, 28, 30},
                                  {15, 17, 19, 24, 43, 44},
                                  {10, 27, 29, 30, 32, 41},
                                  { 9, 13, 26, 32, 37,  43},
                                  { 1, 3, 25, 27, 35, 41},
                                  { 7, 9, 17, 26, 28, 44},
                                  {17, 18, 20, 28, 33, 38}
                              };

            int[] drawNumbers = new int[NUM_DRAW_NUMBERS];

            drawNumbers = GenerateDrawNumbers(NUM_DRAW_NUMBERS);

            WelcomeMessage();

            DisplayLottoNumbers(lottoNumbers);

            DisplayDrawNumbers(drawNumbers);

            CheckLottoNumbers(lottoNumbers, drawNumbers);

            ThankYouMessage();

            ExitProgram();
        }//end Main

        /// <summary>
        /// Prints string to console welcoming user to the Lotto Checker.
        /// </summary>
        static void WelcomeMessage() {
            Console.WriteLine("\n\n\t\tWelcome to Lotto Checker");
        }//end WelcomeMessage
        /// <summary>
        /// Loops through 2 dimensional array of lotto numbers passed as param
        /// to ouput game number and lotto numbers in tabular format.
        /// </summary>
        /// <param name="lottoNumbers">2 dimensional array of lotto numbers.</param>
        static void DisplayLottoNumbers(int[,] lottoNumbers) {
            Console.Write("\nYour Lotto numbers are");

            // loops through lotto games... game 1, game 2, game 3...
            for (int row = 0; row < lottoNumbers.GetLength(0); row++) {
                Console.Write("\n\nGame \t{0}: ", row + 1);

                // loops through numbers in a lotto game... num 1, num 2, num 3...
                for (int column = 0; column < lottoNumbers.GetLength(1); column++) {
                    Console.Write("\t{0,2}", lottoNumbers[row, column]);
                }
            }
        }//end DisplayLottoNumbers
        /// <summary>
        /// Loops through single dimension array of lotto draw numbers passed as param
        /// to output lotto draw numbers to console in tabular format.
        /// </summary>
        /// <param name="drawNumbers">Single dimension array of lotto draw numbers</param>
        static void DisplayDrawNumbers(int[] drawNumbers) {
            Console.WriteLine("\n\nLotto Draw Numbers are:\n");

            for (int i = 0; i < drawNumbers.Length; i++) {
                Console.Write("{0,5}", drawNumbers[i]);
            }
        }//end DisplayDrawNumbers
        /// <summary>
        /// Randomly generates lotto draw numbers.
        /// Calls DuplicateCheck method to ensure numbers are unique.
        /// </summary>
        /// <param name="drawSize">Number of lotto draw numbers to be generated</param>
        /// <returns>Randomly generated draw numbers as a single dimension array.</returns>
        static int[] GenerateDrawNumbers(int drawSize) {

            int randomNumber = randomValue.Next(DRAW_FIRST_NUMBER, DRAW_LAST_NUMBER + 1);

            bool isDuplicate;

            int[] someArray = new int[drawSize];

            for (int i = 0; i < drawSize; i++) {

                do {

                    isDuplicate = DuplicateCheck(drawSize, someArray, randomNumber);

                    if (isDuplicate) {
                        randomNumber = randomValue.Next(DRAW_FIRST_NUMBER, DRAW_LAST_NUMBER + 1);
                    }

                } while (isDuplicate);

                someArray[i] = randomNumber;
            }
            return someArray;

        } // end InitializeArrayWithNoDuplicates
        /// <summary>
        /// Checks generated number against array of existing randomly generated numbers.
        /// </summary>
        /// <param name="size">Size of existing array of randomly generated numbers.</param>
        /// <param name="someArray">Existing array of randomly generated numbers to check against</param>
        /// <param name="randomNumber">Random number to be tested against existing numbers.</param>
        /// <returns>If random number found returns false. If not found returns true.</returns>
        static bool DuplicateCheck(int size, int[] someArray, int randomNumber) {
            for (int j = 0; j < size; j++) {
                if (someArray[j] == randomNumber) {
                    return true;
                }
            }
            return false;
        } // end DuplicateCheck

        static void CheckLottoNumbers(int[,] lottoNumbers, int[] drawNumbers) {

            int winningNum = 0, suppNum = 0;

            for (int row = 0; row < lottoNumbers.GetLength(0); row++) {

                for (int column = 0; column < lottoNumbers.GetLength(1); column++) {

                    for (int drawNumber = 0; drawNumber < drawNumbers.Length; drawNumber++) {

                        if (drawNumber <= SUPP_THRESHOLD && lottoNumbers[row, column] == drawNumbers[drawNumber]) {
                            winningNum++;
                        }

                        if (drawNumber > SUPP_THRESHOLD && lottoNumbers[row, column] == drawNumbers[drawNumber]) {
                            suppNum++;
                        }
                    }
                }
                DisplayGameResults(winningNum, suppNum, row + 1);

                // Reset number of winning and supplementary numbers found
                // before looping through next game.
                winningNum = 0;
                suppNum = 0;
            }
        }// end CheckLottoNumbers
        
        /// <summary>
        /// Outputs game results to console in formatted string.
        /// </summary>
        /// <param name="winningNum">Number of winning numbers located by search method.</param>
        /// <param name="suppNum">Number of supplementary numbers located by search method.</param>
        /// <param name="gameNum">Lotto game number.</param>
        static void DisplayGameResults(int winningNum, int suppNum, int gameNum) {
            Console.WriteLine("\n\nfound {0} matching numbers and {1} supplmentary numbers in Game {2}", winningNum, suppNum, gameNum);
        } // end DisplayGameResults
        /// <summary>
        /// Prints string to console thanking user for using the Lotto Checker.
        /// </summary>
        static void ThankYouMessage() {
            Console.Write("\n\n\t\tThanks for using the Lotto Checker");
        }//end ThankYouMessage
        /// <summary>
        /// Prints string to console prompting user to press any key to exit.
        /// Halts console to allow user to exit the program gracefully.
        /// </summary>
        static void ExitProgram() {
            Console.Write("\n\nPress any key to exit program: ");
            Console.ReadKey();
        }//end ExitProgram
    }//end class
}
