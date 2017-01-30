using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MoneyWorks
{
    [TestClass]
    public class MathTest
    {
        [TestMethod]
        public void Add()
        {
            var a = new Money(0.30m, "NZD");
            var b = new Money(-0.20m, "NZD");
            var c = new Money(-0.20m, "USD");
            var d = new Money(0.10m, "NZD");
            Assert.AreEqual(d, a + b);
            ExceptionAssert.Throws<InvalidOperationException>(() => { var e = a + c; });
        }

        [TestMethod]
        public void Subtract()
        {
            var a = new Money(0.30m, "NZD");
            var b = new Money(-0.20m, "NZD");
            var c = new Money(-0.20m, "USD");
            var d = new Money(0.50m, "NZD");
            Assert.AreEqual(d, a - b);
            ExceptionAssert.Throws<InvalidOperationException>(() => { var e = a - c; });
        }

        [TestMethod]
        public void Multiply()
        {
            var a = new Money(0.30m, "NZD");
            var b = new Money(3.00m, "NZD");
            Assert.AreEqual(b, a * 10);
            Assert.AreEqual(b, a * 10.00m);
        }

        [TestMethod]
        public void Round_Currency_Precision()
        {
            var nzd = new Money(123.577m, "NZD");
            var jpy = new Money(123.577m, "JPY");

            Assert.AreEqual("123.58 NZD", nzd.Round().ToString());
            Assert.AreEqual("124 JPY", jpy.Round().ToString());
        }

        [TestMethod]
        public void Round_Specified_Precision()
        {
            var a = new Money(123.57719m, "NZD");

            Assert.AreEqual("123.58 NZD", a.Round(2).ToString());
            Assert.AreEqual("123.5772 NZD", a.Round(4).ToString());
            Assert.AreEqual("123.57719 NZD", a.Round(5).ToString());
        }

        [TestMethod]
        public void Allocate()
        {
            var shares = new Money(10, "JPY").Allocate(new[] { 1, 1, 1 });
            Assert.AreEqual(3, shares.Length);
            Assert.AreEqual("4 JPY", shares[0].ToString());
            Assert.AreEqual("3 JPY", shares[1].ToString());
            Assert.AreEqual("3 JPY", shares[2].ToString());

            shares = new Money(0.10m, "USD").Allocate(new[] { 70, 30 });
            Assert.AreEqual(2, shares.Length);
            Assert.AreEqual("0.07 USD", shares[0].ToString());
            Assert.AreEqual("0.03 USD", shares[1].ToString());

            shares = new Money(0.01m, "USD").Allocate(new[] { 70, 20, 10 });
            Assert.AreEqual(3, shares.Length);
            Assert.AreEqual("0.01 USD", shares[0].ToString());
            Assert.AreEqual("0.00 USD", shares[1].ToString());
            Assert.AreEqual("0.00 USD", shares[2].ToString());

            shares = new Money(100, "USD").Allocate(new[] { 1, 1, 1 });
            Assert.AreEqual(3, shares.Length);
            Assert.AreEqual("33.34 USD", shares[0].ToString());
            Assert.AreEqual("33.33 USD", shares[1].ToString());
            Assert.AreEqual("33.33 USD", shares[2].ToString());

            ExceptionAssert.Throws<ArgumentException>(() => new Money(100, "USD").Allocate(new int[0]));
        }

        [TestMethod]
        public void Round_Bankers()
        {
            Assert.AreEqual("3 JPY", new Money(3.0m, "JPY").Round(0).ToString());
            Assert.AreEqual("3 JPY", new Money(3.1m, "JPY").Round(0).ToString());
            Assert.AreEqual("3 JPY", new Money(3.2m, "JPY").Round(0).ToString());
            Assert.AreEqual("3 JPY", new Money(3.3m, "JPY").Round(0).ToString());
            Assert.AreEqual("3 JPY", new Money(3.4m, "JPY").Round(0).ToString());
            Assert.AreEqual("4 JPY", new Money(3.5m, "JPY").Round(0).ToString());
            Assert.AreEqual("4 JPY", new Money(3.6m, "JPY").Round(0).ToString());
            Assert.AreEqual("4 JPY", new Money(3.7m, "JPY").Round(0).ToString());
            Assert.AreEqual("4 JPY", new Money(3.8m, "JPY").Round(0).ToString());
            Assert.AreEqual("4 JPY", new Money(3.9m, "JPY").Round(0).ToString());

            Assert.AreEqual("4 JPY", new Money(4.0m, "JPY").Round(0).ToString());
            Assert.AreEqual("4 JPY", new Money(4.1m, "JPY").Round(0).ToString());
            Assert.AreEqual("4 JPY", new Money(4.2m, "JPY").Round(0).ToString());
            Assert.AreEqual("4 JPY", new Money(4.3m, "JPY").Round(0).ToString());
            Assert.AreEqual("4 JPY", new Money(4.4m, "JPY").Round(0).ToString());
            Assert.AreEqual("4 JPY", new Money(4.5m, "JPY").Round(0).ToString());
            Assert.AreEqual("5 JPY", new Money(4.6m, "JPY").Round(0).ToString());
            Assert.AreEqual("5 JPY", new Money(4.7m, "JPY").Round(0).ToString());
            Assert.AreEqual("5 JPY", new Money(4.8m, "JPY").Round(0).ToString());
            Assert.AreEqual("5 JPY", new Money(4.9m, "JPY").Round(0).ToString());
        }

        [TestMethod]
        public void CurrencyPrecision()
        {
            Assert.AreEqual(2, new Money(0, "USD").CurrencyPrecision);
            Assert.AreEqual(0, new Money(0, "JPY").CurrencyPrecision);
            Assert.AreEqual(3, new Money(0, "BHD").CurrencyPrecision);
            Assert.AreEqual(2, new Money(0, "XXA").CurrencyPrecision); // unknown
        }

    }
}
