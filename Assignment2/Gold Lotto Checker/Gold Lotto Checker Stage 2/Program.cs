using System;



namespace Gold_Lotto_Checker_Stage_2 {
    class Program {

        static Random randomValue = new Random(10);

        const int FIRST_NUMBER = 1;
        const int LAST_NUMBER = 45;
        const int SUPP_THRESHOLD = 5;
        const int NUM_DRAW_NUMS = 8;       

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

            int[] drawNumbers = new int[8];

            drawNumbers = InitializeArrayWithNoDuplicates(NUM_DRAW_NUMS);

            WelcomeMessage();

            DisplayLottoNumbers(lottoNumbers);

            DisplayDrawNumbers(drawNumbers);

            CheckLottoNumbers(lottoNumbers, drawNumbers);

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

                winningNum = 0;
                suppNum = 0;
            }
        }// end LinearSearch

        static void DisplayGameResults(int winningNum, int suppNum, int gameNum) {
            Console.WriteLine("\n\nfound {0} matching numbers and {1} supplmentary numbers in Game {2}", winningNum, suppNum, gameNum);
        }

        static int[] InitializeArrayWithNoDuplicates(int size) {

            int randomNumber = randomValue.Next(FIRST_NUMBER, LAST_NUMBER + 1);

            int[] someArray = new int[size];

            for (int i = 0; i < size; i++) {

                while (!DuplicateCheck(size, someArray, randomNumber)) {
                    randomNumber = randomValue.Next(FIRST_NUMBER, LAST_NUMBER + 1);
                }

                someArray[i] = randomNumber;
            }
            return someArray;

        } // end InitializeArrayWithNoDuplicates

        static bool DuplicateCheck(int size, int[] someArray, int randomNumber) {
            for (int j = 0; j < size; j++) {
                if (someArray[j] == randomNumber) {
                    return false;
                }
            }
            return true;
        } // end DuplicateCheck

        static void ThankYouMessage() {
            Console.Write("\n\n\t\tThanks for using the Lotto Checker");
        }//end ThankYouMessage

        static void ExitProgram() {
            Console.Write("\n\nPress any key to exit program: ");
            Console.ReadKey();
        }//end ExitProgram



    }//end class
}
