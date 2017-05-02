using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Currency_Converter_GUI {

    enum Currencies { AUD = 1, CNY, DKK, EUR, INR, NZD, AED, GBP, USD, VND };
    /// <summary>
    /// Name: Chadwick Gay
    /// Student Number: 9410392
    /// </summary>
    static class Currency_Exchange_Class {

        // Number of decimal places for program output
        private static double[] xRates = { 0, 1, 4.2681, 5.0844, 0.6849, 43.5921, 0.9705, 2.7094, 0.4963, 0.7382, 19115.5547 };

        /// <summary>
        /// Provides country names and currency code which  can be used to initialise a Combo Box
        /// </summary>
        /// <returns> string array each elemnt of which contains the country name and three letter currency code</returns>
        public static string[] InitialiseComboBox() {

            string[] countries = {   "",
                                    "Australia (AUD)",
                                    "China (CNY)",
                                    "Denmark (DKK)",
                                    "Europe (EUR)",
                                    "India (INR)",
                                    "New Zealand (NZD)",
                                    "United Arab Emirates (AED)",
                                    "United Kingdom (GBP)",
                                    "United States (USD)",
                                    "Vietnam (VND)" };

            return countries;
        } //end InitialiseComboBox()   

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fromCurrencyIndex"></param>
        /// <param name="toCurrencyIndex"></param>
        /// <param name="inputValue"></param>
        /// <returns></returns>
        public static double PerformCurrencyConversion(int fromCurrencyIndex, int toCurrencyIndex, string inputValue) {

            bool okay;
            double inputAmount, audAmount, convertedAmount;

            // Convert string input to double
            okay = double.TryParse(inputValue, out inputAmount);

            // Convert to AUD
            audAmount = ConvertToAud(fromCurrencyIndex, inputAmount);

            // Convert from Aud to other currency
            convertedAmount = ConvertFromAud(toCurrencyIndex, audAmount);

            // Round to specified decimal places
            return convertedAmount;
        } // end PerformCurrencyConversion()

        /// <summary>
        /// 
        /// </summary>
        /// <param name="currencyIndex"></param>
        /// <param name="inputValue"></param>
        /// <returns></returns>
        public static double ConvertToAud(int currencyIndex, double inputValue) {
            double outputValue, rate;

            rate = xRates[currencyIndex];

            outputValue = inputValue / rate;

            return outputValue;
        } // end ConvertToAud()

        /// <summary>
        /// 
        /// </summary>
        /// <param name="currencyIndex"></param>
        /// <param name="inputValue"></param>
        /// <returns></returns>
        public static double ConvertFromAud(int currencyIndex, double inputValue) {
            double outputValue, rate;

            rate = xRates[currencyIndex];

            outputValue = inputValue * rate;

            return outputValue;
        } // end ConvertFromAud()

        /// <summary>
        /// 
        /// </summary>
        /// <param name="currencyIndex"></param>
        /// <returns></returns>
        public static string GetCurrencyCode(int currencyIndex) {
            string currencyCode;

            currencyCode = ((Currencies)currencyIndex).ToString();

            return currencyCode;
        } // end GetCurrencyCode()         

    }//end class
}
