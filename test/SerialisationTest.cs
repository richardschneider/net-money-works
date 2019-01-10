using System;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MoneyWorks
{
    [TestClass]
    public class SerialisationTest
    {
        [TestMethod]
        public void DataContract()
        {
            var a0 = new Money(-0.20m, "NZD");

            var sb = new StringBuilder();
            var writer = XmlWriter.Create(sb);
            var serializer = new DataContractSerializer(typeof(Money));
            serializer.WriteObject(writer, a0);
            writer.Flush();

            var reader = XmlReader.Create(new StringReader(sb.ToString()));
            var a1 = (Money)serializer.ReadObject(reader);
            Assert.AreEqual(a0, a1);

            StringAssert.Contains(sb.ToString(), "<currency>NZD</currency><amount>-0.20</amount>");
        }

    }
}
