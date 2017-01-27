using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MoneyWorks
{
    [TestClass]
    public class ComparisonTest
    {
        [TestMethod]
        public void CompareTo()
        {
            var a = new Money(30, "NZD");
            var b = new Money(40, "NZD");
            var c = new Money(50, "USD");

            Assert.IsTrue(a.CompareTo(a) == 0);
            Assert.IsTrue(a.CompareTo(b) < 0);
            Assert.IsTrue(b.CompareTo(a) > 0);

            ExceptionAssert.Throws<InvalidOperationException>(() => a.CompareTo(c));
        }

        [TestMethod]
        public void Operators()
        {
            var a = new Money(30, "NZD");
            var b = new Money(40, "NZD");
            var c = new Money(50, "USD");

#pragma warning disable 1718
            Assert.IsFalse(a < a);
            Assert.IsTrue(a < b);
            Assert.IsFalse(b < a);

#pragma warning disable 1718
            Assert.IsTrue(a <= a);
            Assert.IsTrue(a <= b);
            Assert.IsFalse(b <= a);

#pragma warning disable 1718
            Assert.IsFalse(a > a);
            Assert.IsFalse(a > b);
            Assert.IsTrue(b > a);

#pragma warning disable 1718
            Assert.IsTrue(a >= a);
            Assert.IsFalse(a >= b);
            Assert.IsTrue(b >= a);
        }
    }
}
