using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BikeDistributor.Test
{
    [TestClass]
    public class HmtlFormatterTests
    {
        [TestMethod]
        public void FormatDocument_ReturnsHtmlBodyTags()
        {
            var formatter = new HtmlFormatter();
            var testSb = new StringBuilder("test");
            formatter.FormatDocument(testSb);
            
            var result = testSb.ToString();
            
            Assert.AreEqual(result, "<html><body>test</body></html>");
        }

        [TestMethod]
        public void FormatHeader_ReturnsHeaderOneTags()
        {
            var formatter = new HtmlFormatter();
            var testSb = new StringBuilder("test");
            formatter.FormatHeader(testSb);
            
            var result = testSb.ToString();

            Assert.AreEqual(result, "<h1>test</h1>");
        }

        [TestMethod]
        public void FormatLine_ReturnsLineItemTags()
        {
            var formatter = new HtmlFormatter();
            var testSb = new StringBuilder("test");
            formatter.FormatLine(testSb);
            
            var result = testSb.ToString();

            Assert.AreEqual(result, "<li>test</li>");
        }

        [TestMethod]
        public void FormatAllLines_ReturnsUnorderedListTags()
        {
            var formatter = new HtmlFormatter();
            var testSb = new StringBuilder("test");
            formatter.FormatAllLines(testSb);
            
            var result = testSb.ToString();

            Assert.AreEqual(result, "<ul>test</ul>");
        }

        [TestMethod]
        public void FormatSubTotal_ReturnsHeaderThreeTags()
        {
            var formatter = new HtmlFormatter();
            var testSb = new StringBuilder("test");
            formatter.FormatSubTotal(testSb);
            
            var result = testSb.ToString();

            Assert.AreEqual(result, "<h3>test</h3>");
        }

        [TestMethod]
        public void FormatTax_ReturnsHeaderThreeTags()
        {
            var formatter = new HtmlFormatter();
            var testSb = new StringBuilder("test");
            formatter.FormatTax(testSb);
            
            var result = testSb.ToString();

            Assert.AreEqual(result, "<h3>test</h3>");
        }

        [TestMethod]
        public void FormatTotal_ReturnsHeaderTwoTags()
        {
            var formatter = new HtmlFormatter();
            var testSb = new StringBuilder("test");
            formatter.FormatTotal(testSb);
            
            var result = testSb.ToString();

            Assert.AreEqual(result, "<h2>test</h2>");
        }
    }
}