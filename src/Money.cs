using System;
using System.Text.RegularExpressions;

namespace MoneyWorks
{
    /// <summary>
    ///   Represents a monetary value and currency code.
    /// </summary>
    public class Money
    {
        static Regex iso4217 = new Regex(@"[A-Z]{3}", RegexOptions.Compiled | RegexOptions.CultureInvariant);

        /// <summary>
        ///   Creates a new instance of the <see cref="Money"/> class
        ///   with the specified <see cref="Amount"/> and
        ///   <see cref="Currency"/>.
        /// </summary>
        /// <param name="amount">The amount of money.</param>
        /// <param name="currency">
        ///   An <see href="https://en.wikipedia.org/wiki/ISO_4217">ISO 4217</see> currency code.  For example: "CNY", "NZD" or "JPY".
        /// </param>
        public Money(decimal amount, string currency)
        {
            if (currency.Length != 3 || !iso4217.IsMatch(currency))
                throw new FormatException($"'{currency}' is not a valid ISO 4217 currency code.");

            Amount = amount;
            Currency = currency;
        }

        /// <summary>
        ///   The amount of money.
        /// </summary>
        public decimal Amount { get; }

        /// <summary>
        ///   The currency of the money.
        /// </summary>
        /// <value>
        ///   An <see href="https://en.wikipedia.org/wiki/ISO_4217">ISO 4217</see> currency code.  For example: "CNY", "NZD" or "JPY".
        /// </value>
        public string Currency { get; }
    }
}
