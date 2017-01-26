﻿using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace MoneyWorks
{
    /// <summary>
    ///   Represents a monetary value and currency code.
    /// </summary>
    public class Money : IEquatable<Money>
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

        #region Equality
        /// <inheritdoc />
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            var that = obj as Money;
            return that != null
                && this.Amount == that.Amount
                && this.Currency == that.Currency;
        }

        /// <summary>
        ///   Determines if the current instance and a specified <see cref="Money"/> 
        ///   object have the same value.
        /// </summary>
        /// <param name="that">The object to compare.</param>
        /// <returns>
        ///   <b>true</b> if the values are equal; otherwise, <b>false</b>.
        /// </returns>
        /// <remarks>
        ///    Money objects are equal when both the <see cref="Amount"/>
        ///    and <see cref="Currency"/> are equal.
        /// </remarks>
        public bool Equals(Money that)
        {
            return that != null
                && this.Amount == that.Amount
                && this.Currency == that.Currency;
        }

        /// <summary>
        ///   Value equality.
        /// </summary>
        public static bool operator ==(Money a, Money b)
        {
            if (object.ReferenceEquals(a, b)) return true;
            if (object.ReferenceEquals(a, null)) return false;
            if (object.ReferenceEquals(b, null)) return false;

            return a.Equals(b);
        }

        /// <summary>
        ///   Value inequality.
        /// </summary>
        public static bool operator !=(Money a, Money b)
        {
            if (object.ReferenceEquals(a, b)) return false;
            if (object.ReferenceEquals(a, null)) return true;
            if (object.ReferenceEquals(b, null)) return true;

            return !a.Equals(b);
        }
        #endregion

        /// <inheritdoc />
        public override string ToString()
        {
            return this.Amount.ToString(CultureInfo.InvariantCulture)
                + " " + this.Currency;
        }

        #region Math
        /// <summary>
        ///   Adds two <see cref="Money"/> values and returns the result.
        /// </summary>
        /// <param name="a">The first value to add.</param>
        /// <param name="b">The second value to add.</param>
        /// <returns>The sum of <paramref name="a"/> and <paramref name="b"/>.</returns>
        /// <exception cref="InvalidOperationException">
        ///   When the <see cref="Money.Currency"/> are not the same.
        /// </exception>
        public static Money operator +(Money a, Money b)
        {
            if (a.Currency != b.Currency)
                throw new InvalidOperationException("Currencies must be the same.");

            return new Money(a.Amount + b.Amount, a.Currency);
        }

        /// <summary>
        ///   Subtract one <see cref="Money"/> value from another and returns the result.
        /// </summary>
        /// <param name="a">The value to subtract from (the minuend).</param>
        /// <param name="b">The value to subtract (the subtrahend).</param>
        /// <returns>The result of subtracting <paramref name="b"/> from <paramref name="a"/>.</returns>
        /// <exception cref="InvalidOperationException">
        ///   When the <see cref="Money.Currency"/> are not the same.
        /// </exception>
        public static Money operator -(Money a, Money b)
        {
            if (a.Currency != b.Currency)
                throw new InvalidOperationException("Currencies must be the same.");

            return new Money(a.Amount - b.Amount, a.Currency);
        }

        /// <summary>
        ///   Multiple the <see cref="Money"/> value by a <see cref="decimal"/>.
        /// </summary>
        /// <param name="a">The multiplicand,</param>
        /// <param name="b">The multiplier.</param>
        public static Money operator *(Money a, decimal b)
        {
            return new Money(a.Amount * b, a.Currency);
        }
        #endregion
    }
}
