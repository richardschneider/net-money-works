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
    }
}
