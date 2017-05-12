using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Currency_Converter_GUI {

    enum Currencies { AUD = 1, CNY, DKK, EUR, INR, NZD, AED, GBP, USD, VND };
    /// <summary>
    /// GUI driven program that allows user to convert from 
    /// one selected currency to another selected currency.
    /// 
    /// Upon completetion of conversion user can reset form 
    /// and perform multiple currency conversions.
    /// 
    /// Author Chadwick Gay May 2017 - Student Number: 9410392
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

        /// <summary>
        /// Performs conversion from one selected currency to the other selected currency.
        /// Amount is converted to AUD before being converted to selected 'to' currency.
        /// </summary>
        /// <param name="fromCurrencyIndex">Index of the currency the user has - 'amount have'.</param>
        /// <param name="toCurrencyIndex">Index of the currency the user wants - 'amount wanted'.</param>
        /// <param name="inputValue">Amount to be converted from the 'from' to the 'to' currency</param>
        /// <returns>Converted amount in selected 'amount wanted' currency</returns>
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
        /// Converts amount in selected currency to amount in AUD and returns amount.
        /// </summary>
        /// <param name="currencyIndex">Index of the currency the user wants - 'amount have'.</param>
        /// <param name="inputValue">Amount to be converted from the 'from' to the 'to' currency</param>
        /// <returns>Amount in AUD</returns>
        public static double ConvertToAud(int currencyIndex, double inputValue) {
            double outputValue, rate;

            rate = xRates[currencyIndex];

            outputValue = inputValue / rate;

            return outputValue;
        } // end ConvertToAud()

        /// <summary>
        /// Converts amount in AUD to the selected currency and returns result.
        /// </summary>
        /// <param name="currencyIndex">Index of the currency the user has - 'amount wanted'.</param>
        /// <param name="inputValue">Amount in AUD to be converted to the 'to' currency</param>
        /// <returns>Converted amount in selected 'amount wanted' currency</returns>
        public static double ConvertFromAud(int currencyIndex, double inputValue) {
            double outputValue, rate;

            rate = xRates[currencyIndex];

            outputValue = inputValue * rate;

            return outputValue;
        } // end ConvertFromAud()

        /// <summary>
        /// Gets the currency code according to the index value provided.
        /// </summary>
        /// <param name="currencyIndex">Index of the currency selected in form selection</param>
        /// <returns>Currency code of respective currency from passed index</returns>
        public static string GetCurrencyCode(int currencyIndex) {
            string currencyCode;

            currencyCode = ((Currencies)currencyIndex).ToString();

            return currencyCode;
        } // end GetCurrencyCode()         

    }//end class
}
