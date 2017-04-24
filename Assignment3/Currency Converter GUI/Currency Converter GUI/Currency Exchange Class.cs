using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Currency_Converter_GUI {

    enum Currencies { AUD = 1, CYN, DKK, EUR, INR, NZD, AED, GBP, USD, VND };
    /// <summary>
    /// 
    /// </summary>
    static class Currency_Exchange_Class {

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

        public static double ConvertCurrency(int fromCurrencyIndex, int toCurrencyIndex, string inputValue) {
            bool okay;
            double inputAmount, amountAud, amountConverted, rate;
            
            okay = double.TryParse(inputValue, out inputAmount);

            // Convert to AUD
            rate = xRates[fromCurrencyIndex];
            amountAud = inputAmount / rate;

            // Convert to other currency
            rate = xRates[toCurrencyIndex];
            amountConverted = amountAud * rate;

            return Math.Round(amountConverted, 4);
        }


        public static double ConvertToAud(int currencyIndex, double inputValue) {
            double outputValue, rate;

            rate = xRates[currencyIndex];

            outputValue = inputValue / rate;

            return outputValue;            
        }
        
        public static double ConvertFromAud(int currencyIndex, double inputValue) {
            double outputValue, rate;

            rate = xRates[currencyIndex];

            outputValue = inputValue * rate;

            return outputValue;
        }
        
        public static string GetCurrencyCode(int currencyIndex) {
            string currencyCode;

            currencyCode = ((Currencies)currencyIndex).ToString();

            return currencyCode;
        }          

    }//end class
}
