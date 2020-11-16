using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BikeDistributor.Test
{
    [TestClass]
    public class DefaultFormatterTests
    {
        [TestMethod]
        public void FormatDocument_ReturnsOriginalString()
        {
            var formatter = new DefaultFormatter();
            var testSb = new StringBuilder("test");
            formatter.FormatDocument(testSb);
            
            var result = testSb.ToString();
            
            Assert.AreEqual(result, "test");
        }

        [TestMethod]
        public void FormatHeader_ReturnsWithNewLine()
        {
            var formatter = new DefaultFormatter();
            var testSb = new StringBuilder("test");
            formatter.FormatHeader(testSb);
            
            var result = testSb.ToString();

            Assert.AreEqual(result, $"test{Environment.NewLine}");
        }

        [TestMethod]
        public void FormatLine_ReturnsTabAndNewLine()
        {
            var formatter = new DefaultFormatter();
            var testSb = new StringBuilder("test");
            formatter.FormatLine(testSb);
            
            var result = testSb.ToString();

            Assert.AreEqual(result, $"\ttest{Environment.NewLine}");
        }

        [TestMethod]
        public void FormatAllLines_ReturnsOriginalString()
        {
            var formatter = new DefaultFormatter();
            var testSb = new StringBuilder("test");
            formatter.FormatAllLines(testSb);
            
            var result = testSb.ToString();

            Assert.AreEqual(result, "test");
        }

        [TestMethod]
        public void FormatSubTotal_ReturnsWithNewLine()
        {
            var formatter = new DefaultFormatter();
            var testSb = new StringBuilder("test");
            formatter.FormatSubTotal(testSb);
            
            var result = testSb.ToString();

            Assert.AreEqual(result, $"test{Environment.NewLine}");
        }

        [TestMethod]
        public void FormatTax_ReturnsWithNewLine()
        {
            var formatter = new DefaultFormatter();
            var testSb = new StringBuilder("test");
            formatter.FormatTax(testSb);
            
            var result = testSb.ToString();

            Assert.AreEqual(result, $"test{Environment.NewLine}");
        }

        [TestMethod]
        public void FormatTotal_ReturnsOriginalString()
        {
            var formatter = new DefaultFormatter();
            var testSb = new StringBuilder("test");
            formatter.FormatTotal(testSb);
            
            var result = testSb.ToString();

            Assert.AreEqual(result, "test");
        }
    }
}