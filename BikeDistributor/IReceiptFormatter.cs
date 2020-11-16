using System.Text;

namespace BikeDistributor
{
    public interface IReceiptFormatter
    {
        void FormatDocument(StringBuilder sb);
        void FormatHeader(StringBuilder sb);
        void FormatLine(StringBuilder sb);
        void FormatAllLines(StringBuilder sb);
        void FormatSubTotal(StringBuilder sb);
        void FormatTax(StringBuilder sb);
        void FormatTotal(StringBuilder sb);
    }
}