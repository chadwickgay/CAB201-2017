using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB201_Assignment1 {
    /// <summary>
    /// 
    /// Program which calculates waist-to-height ratio to determine risk of obesity
    /// cardiovascular diseases based on user input values for waist and height in cm.
    /// Risk determination is based upon gender and pre-defined WTH ratio thresholds.
    /// 
    /// Able to perform additional waist-to-height calculations and 
    /// recommendations until user elects not to perform addition calculations.
    /// 
    /// Author Chadwick Gay March 2017
    /// Student Number 9410392
    /// </summary>
    class Program {
        // Minimum required waist and height measurements
        const double WAIST_LOWER_LIMIT = 60.0;
        const double HEIGHT_LOWER_LIMIT = 120.0;

        // Threshold for low/high risk cardiovascular disease determinations
        const double MALE_THRESHOLD = 0.536;
        const double FEMALE_THRESHOLD = 0.492;

        static void Main(string[] args) {
            string gender, riskLevel, additionalCalculation;
            double waist, height, ratio;

            WelcomeMessage();

            do {
                waist = GetMeasurementFromConsole("waist", WAIST_LOWER_LIMIT);
                height = GetMeasurementFromConsole("height", HEIGHT_LOWER_LIMIT);
                gender = GetGender();
                ratio = CalculateRatio(waist, height);
                riskLevel = DetermineRiskLevel(ratio, gender);
                DisplayResults(ratio, riskLevel);
                additionalCalculation = PerformAdditionalCalculation();
            } while (additionalCalculation == "Y" || additionalCalculation == "y");

            ExitProgram();
        }

        static void WelcomeMessage() {
            Console.WriteLine("\n\n\tWaist Height Calculator\n\n");
        }//end WelcomeMessage

        static double GetMeasurementFromConsole(string measurementType, double lowerLimit) {
            string input;
            double measurement;
            bool validMeasurement;

            do {
                Console.Write("\nEnter {0} measurement in cm: ", measurementType);
                input = Console.ReadLine();

                validMeasurement = ValidateMeasureFromConsole(input, measurementType, lowerLimit, out measurement);

            } while (!validMeasurement);

            return measurement;
        } // end GetMeasurementFromConsole

        static bool ValidateMeasureFromConsole(string input, string measurementType, double lowerLimit, out double measurement) {
            bool okay, validMeasurement;

            okay = double.TryParse(input, out measurement);

            if (!okay) {
                Console.WriteLine("\nYou entered \"{0}\".\n\nError: {1} measurement must be a number in cm.\n\nPlease try again.",
                    input, measurementType);
                validMeasurement = false;
            } else if (okay && measurement < lowerLimit) {
                Console.WriteLine("\nYou entered \"{0}\".\n\nError: minimum {1} measurement required is {2}cm.\n\nPlease try again.",
                    input, measurementType, lowerLimit);
                validMeasurement = false;
            } else {
                validMeasurement = true;
            }
            return validMeasurement;
        } // end ValidateMeasureFromConsole

        static void DisplayGenderMenu() {
            string menu = "\nAre you"
                        + "\n\t1) male"
                        + "\n\t2) female"
                        + "\n\n\tEnter your option (1 or 2): ";
            Console.Write(menu);
        } // end DisplayGenderMenu

        static string GetGender() {
            string menuSelection, gender;
            bool validMenuSelection;

            do {
                DisplayGenderMenu();
                menuSelection = Console.ReadLine();
                validMenuSelection = ValidateGenderMenuSelection(menuSelection);
            } while (!validMenuSelection);

            gender = ReturnGender(menuSelection);

            return gender;
        } // end GetGender

        static bool ValidateGenderMenuSelection(string menuSelection) {
            if (menuSelection != "1" && menuSelection != "2") {
                Console.WriteLine("\nYou entered \"{0}\". Please enter 1 or 2.", menuSelection);
                return false;
            } else {
                return true;
            }
        } // end ValidateGenderMenuSelection

        static string ReturnGender(string menuSelection) {
            if (menuSelection == "1") {
                return "male";
            } else {
                return "female";
            }
        } // end ReturnGender

        static double CalculateRatio(double waist, double height) {
            return waist / height;
        } // end CalculateRatio

        static string DetermineRiskLevel(double ratio, string gender) {
            string riskLevel;

            if (gender == "male") {
                if (ratio < MALE_THRESHOLD) {
                    riskLevel = "low";
                } else {
                    riskLevel = "high";
                }
            } else {
                if (ratio < FEMALE_THRESHOLD) {
                    riskLevel = "low";
                } else {
                    riskLevel = "high";
                }
            }
            return riskLevel;
        } // end DetermineRiskLevel

        static void DisplayResults(double ratio, string riskLevel) {
            Console.WriteLine("\nYour waist to height ratio is {0:f3}", ratio);
            Console.WriteLine("\tand");
            Console.WriteLine(" you are at a {0} risk of obesity related cardiovascular diseases.", riskLevel);
        } // end DisplayResults

        static string PerformAdditionalCalculation() {
            string input;
            Console.Write("\nAnother calculation (Enter 'Y' or 'y' to perform another calculation): ");
            input = Console.ReadLine();
            return input;
        } // end AdditionalCalculation

        static void ExitProgram() {
            Console.Write("\nProgram Exited.");
            Console.Write("\n\nPress any key to exit.");
            Console.ReadKey();
        }//end ExitProgram
    }
}
