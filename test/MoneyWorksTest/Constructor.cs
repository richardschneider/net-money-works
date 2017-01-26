using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MoneyWorks
{
    [TestClass]
    public class ConstructorTest
    {
        [TestMethod]
        public void Accepts_DecimalAmount()
        {
            var money = new Money(123.45m, "JPY");
            Assert.AreEqual(123.45m, money.Amount);
            Assert.AreEqual("JPY", money.Currency);

            var min = new Money(Decimal.MinValue, "JPY");
            Assert.AreEqual(Decimal.MinValue, min.Amount);
            Assert.AreEqual("JPY", min.Currency);

            var max = new Money(Decimal.MaxValue, "JPY");
            Assert.AreEqual(Decimal.MaxValue, max.Amount);
            Assert.AreEqual("JPY", min.Currency);
        }

        [TestMethod]
        public void Accepts_Int32Amount()
        {
            var money = new Money(123, "JPY");
            Assert.AreEqual(123, money.Amount);
            Assert.AreEqual("JPY", money.Currency);

            var min = new Money(Int32.MinValue, "JPY");
            Assert.AreEqual(Int32.MinValue, min.Amount);
            Assert.AreEqual("JPY", min.Currency);

            var max = new Money(Int32.MaxValue, "JPY");
            Assert.AreEqual(Int32.MaxValue, max.Amount);
            Assert.AreEqual("JPY", min.Currency);
        }

        [TestMethod]
        public void Accepts_Int64Amount()
        {
            var money = new Money(123L, "JPY");
            Assert.AreEqual(123, money.Amount);
            Assert.AreEqual("JPY", money.Currency);

            var min = new Money(Int64.MinValue, "JPY");
            Assert.AreEqual(Int64.MinValue, min.Amount);
            Assert.AreEqual("JPY", min.Currency);

            var max = new Money(Int64.MaxValue, "JPY");
            Assert.AreEqual(Int64.MaxValue, max.Amount);
            Assert.AreEqual("JPY", min.Currency);
        }

        [TestMethod]
        public void Throws_On_Invalid_Currency()
        {
            var ok = new Money(0, "NZD");

            ExceptionAssert.Throws<FormatException>(() => new Money(0, "N"));
            ExceptionAssert.Throws<FormatException>(() => new Money(0, "NZ"));
            ExceptionAssert.Throws<FormatException>(() => new Money(0, "NZDX"));
            ExceptionAssert.Throws<FormatException>(() => new Money(0, "nzd"));
        }
    }
}
