using System.Text;

namespace BikeDistributor
{
    public class HtmlFormatter : IReceiptFormatter
    {
        public void FormatDocument(StringBuilder sb)
        {
            sb.Insert(0, "<html><body>");
            sb.Append("</body></html>");
        }

        public void FormatHeader(StringBuilder sb)
        {
            sb.Insert(0, "<h1>");
            sb.Append("</h1>");
        }

        public void FormatLine(StringBuilder sb)
        {
            sb.Insert(0, "<li>");
            sb.Append("</li>");
        }

        public void FormatAllLines(StringBuilder sb)
        {
            sb.Insert(0, "<ul>");
            sb.Append("</ul>");
        }

        public void FormatSubTotal(StringBuilder sb)
        {
            sb.Insert(0, "<h3>");
            sb.Append("</h3>");
        }

        public void FormatTax(StringBuilder sb)
        {
            sb.Insert(0, "<h3>");
            sb.Append("</h3>");
        }

        public void FormatTotal(StringBuilder sb)
        {
            sb.Insert(0, "<h2>");
            sb.Append("</h2>");
        }
    }
}