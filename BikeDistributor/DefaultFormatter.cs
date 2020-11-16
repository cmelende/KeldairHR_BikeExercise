using System;
using System.Text;

namespace BikeDistributor
{
    public class DefaultFormatter: IReceiptFormatter
    {
        public virtual void FormatHeader(StringBuilder sb)
        {
            sb.Append(Environment.NewLine);
        }

        public virtual void FormatLine(StringBuilder sb)
        {
            sb.Insert(0, "\t");
            sb.Append(Environment.NewLine);
        }

        public virtual void FormatSubTotal(StringBuilder sb)
        {
            sb.Append(Environment.NewLine);
        }

        public virtual void FormatTax(StringBuilder sb)
        {
            sb.Append(Environment.NewLine);
        }
        
        public virtual void FormatDocument(StringBuilder sb) { }
        public virtual void FormatAllLines(StringBuilder sb) { }
        public virtual void FormatTotal(StringBuilder sb) { }
    }
}