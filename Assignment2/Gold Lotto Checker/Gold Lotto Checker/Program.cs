using System;

namespace Gold_Lotto_Checker {


    class Program {



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

            //LinearSearch(lottoNumbers, 7);

            LinearSearch(lottoNumbers, drawNumbers);

            // Locate Lotto Draw Numbers in Games 

            ThankYouMessage();

            ExitProgram();
        }//end Main

        static void WelcomeMessage() {
            Console.WriteLine("\n\n\t\tWelcome to Lotto Checker");
        }//end WelcomeMessage

        static void DisplayLottoNumbers(int[,] lottoNumbers) {
            Console.Write("\nYour Lotto numbers are");

            for (int row = 0; row < lottoNumbers.GetLength(0); row++) {
                Console.Write("\n\nGame \t{0}: ", row + 1);

                for (int column = 0; column < lottoNumbers.GetLength(1); column++) {
                    Console.Write("\t{0,2}", lottoNumbers[row, column]);
                }
            }
        }//end DisplayLottoNumbers

        static void DisplayDrawNumbers(int[] drawNumbers) {
            Console.WriteLine("\n\nLotto Draw Numbers are:\n");

            for (int i = 0; i < drawNumbers.Length; i++) {
                Console.Write("{0,5}", drawNumbers[i]);
            }
        }//end DisplayDrawNumbers

        /* static void LinearSearch(int[,] lottoNumbers, int item) {
            int timesFound = 0;

            for (int row = 0; row < lottoNumbers.GetLength(0); row++) {
                for (int column = 0; column < lottoNumbers.GetLength(1); column++) {
                    if (lottoNumbers[row, column] == item) {
                        timesFound++;
                    }
                }
                Console.WriteLine("\n\n{0} was found {1} times in Game {2}", item, timesFound, row + 1);
                timesFound = 0; // reset to 0 at end of a game
            }


        } // end LinearSearch */

        /* static void LinearSearch2(int[,] lottoNumbers, int[] drawNumbers) {
            int timesFound = 0;

            for (int drawNumber = 0; drawNumber < drawNumbers.Length; drawNumber++) {

                int searchNum;

                searchNum = drawNumbers[drawNumber];

                for (int row = 0; row < lottoNumbers.GetLength(0); row++) {

                    for (int column = 0; column < lottoNumbers.GetLength(1); column++) {

                        if (lottoNumbers[row, column] == drawNumbers[drawNumber]) {
                            timesFound++;
                        }
                    }
                    Console.WriteLine("\n\nSearch NUM : {2} - found {0} matching number in Game {1}", timesFound, row + 1, searchNum);
                    timesFound = 0; // reset to 0 at end of a game
                }
            }
        } // end LinearSearch2 */

        static void LinearSearch(int[,] lottoNumbers, int[] drawNumbers) {

            int winningNum = 0, suppNum = 0;

            int searchNum = 0; // only used for testings

            for (int row = 0; row < lottoNumbers.GetLength(0); row++) {

                for (int column = 0; column < lottoNumbers.GetLength(1); column++) {

                    for (int drawNumber = 0; drawNumber < drawNumbers.Length; drawNumber++) {

                        searchNum = drawNumbers[drawNumber]; // only used for testings

                        if (drawNumber <= 5 && lottoNumbers[row, column] == drawNumbers[drawNumber]) { // remove supp threshold magic number
                            winningNum++;
                        }

                        if (drawNumber > 5 && lottoNumbers[row, column] == drawNumbers[drawNumber]) {
                            suppNum++;
                        }
                    }       
                }
                Console.WriteLine("\n\nfound {0} matching numbers and {1} supplmentary numbers in Game {2}", winningNum, suppNum, row + 1);

                winningNum = 0;
                suppNum = 0;
            }
        }// end LinearSearch

        static void ThankYouMessage() {
            Console.Write("\n\nThanks for using the Lotto Checker");
        }//end ThankYouMessage

        static void ExitProgram() {
            Console.Write("\n\nPress any key to exit program: ");
            Console.ReadKey();
        }//end ExitProgram



    }//end class
}//end namespace
