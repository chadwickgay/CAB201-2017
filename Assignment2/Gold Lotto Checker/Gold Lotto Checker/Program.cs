using System;

namespace Gold_Lotto_Checker {
    /// <summary>
    /// 
    /// Program which displays pre-defined lotto numbers for multiple lotto games and single
    /// set of pre-defined draw numbers. Checks draw numbers against multiple lotto games
    /// to determine if any winning or supplementary numbers exist. Outputs number of winning 
    /// and supplementary numbers found per game.
    /// 
    /// Prompts user to exit the program gracefully.
    /// 
    /// Author Chadwick Gay April 2017
    /// Student Number 9410392
    /// </summary>
    class Program {

        // Threshold for standard number/supplementary number in draw numbers
        const int SUPP_THRESHOLD = 5;

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

            int[] drawNumbers = new int[] { 44, 9, 17, 43, 26, 7, 28, 19 };

            WelcomeMessage();

            DisplayLottoNumbers(lottoNumbers);

            DisplayDrawNumbers(drawNumbers);

            PerformLottoDrawMatch(lottoNumbers, drawNumbers);

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
            int gameNum = 0;

            Console.Write("\nYour Lotto numbers are");

            // loops through lotto games... game 1, game 2, game 3...
            for (int row = 0; row < lottoNumbers.GetLength(0); row++) {
                gameNum++;
                Console.Write("\n\nGame \t{0}: ", gameNum);
                // loops through numbers in a lotto game... num 1, num 2, num 3...
                for (int column = 0; column < lottoNumbers.GetLength(1); column++) {
                    Console.Write("\t{0,2}", lottoNumbers[row, column]);
                }
            }
        }//end DisplayLottoNumbers

        /// <summary>
        /// Loops through array of lotto draw numbers passed as param
        /// to output lotto draw numbers to console in tabular format.
        /// </summary>
        /// <param name="drawNumbers">Array of lotto draw numbers</param>
        static void DisplayDrawNumbers(int[] drawNumbers) {
            Console.WriteLine("\n\nLotto Draw Numbers are:\n");

            for (int i = 0; i < drawNumbers.Length; i++) {
                Console.Write("{0,5}", drawNumbers[i]);
            }
        }//end DisplayDrawNumbers

        /// <summary>
        /// Loops through array of lotto numbers (game by game) and draw numbers (number by number). 
        /// If matching value found respective counter for winning or supplementary number incremented.
        /// Calls DisplayGameResults() method to output formatted results to console.
        /// </summary>
        /// <param name="lottoNumbers">2 dimensional array of lotto numbers.</param>
        /// <param name="drawNumbers">Array of lotto draw numbers</param>
        static void PerformLottoDrawMatch(int[,] lottoNumbers, int[] drawNumbers) {

            int winningNum = 0;
            int suppNum = 0;
            int gameNum = 0;

            // loops through lotto games... game 1, game 2, game 3...
            for (int row = 0; row < lottoNumbers.GetLength(0); row++) {
                // loops through numbers in a lotto game... num 1, num 2, num 3...
                for (int column = 0; column < lottoNumbers.GetLength(1); column++) {
                    // Loop through each number in a lotto draw... num 1, num 2, num 3...
                    for (int drawNumber = 0; drawNumber < drawNumbers.Length; drawNumber++) {
                        if (drawNumber <= SUPP_THRESHOLD && lottoNumbers[row, column] == drawNumbers[drawNumber]) {
                            winningNum++;
                        }
                        if (drawNumber > SUPP_THRESHOLD && lottoNumbers[row, column] == drawNumbers[drawNumber]) {
                            suppNum++;
                        }
                    }
                }

                gameNum++;

                DisplayGameResults(winningNum, suppNum, gameNum);

                // Reset number of winning and supplementary numbers found
                // before looping through next game.
                winningNum = 0;
                suppNum = 0;
            }
        }// end PerformLottoDrawMatch

        /// <summary>
        /// Outputs game results to console in formatted string.
        /// </summary>
        /// <param name="winningNum">Number of winning numbers located by search method.</param>
        /// <param name="suppNum">Number of supplementary numbers located by search method.</param>
        /// <param name="gameNum">Lotto game number.</param>
        static void DisplayGameResults(int winningNum, int suppNum, int gameNum) {
            Console.WriteLine("\n\nfound {0} matching numbers and {1} supplmentary numbers in Game {2}", 
                winningNum, suppNum, gameNum);
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
}//end namespace
