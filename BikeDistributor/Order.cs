using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BikeDistributor
{
    public class Order
    {
        private const double TaxRate = .0725d;
        private readonly IList<Line> _lines = new List<Line>();
        private IDiscountHandler _discountHandler;

        public Order(string company, IDiscountHandler discountHandler)
        {
            Company = company;
            _discountHandler = discountHandler;
        }

        public string Company { get; private set; }

        public void AddLine(Line line)
        {
            _lines.Add(line);
        }

        public string Receipt(IReceiptFormatter formatter = null)
        {
            if (formatter == null)
            {
                formatter = new DefaultFormatter();
            }
            
            var totalAmount = 0d;
            var documentSb = new StringBuilder();
            
            var headerSb = new StringBuilder($"Order Receipt for {Company}");
            formatter.FormatHeader(headerSb);
            documentSb.Append(headerSb);
            
            var allLinesSb = new StringBuilder();
            if (_lines.Any())
            {
                
                foreach (Line line in _lines)
                {
                    double thisAmount = line.GetChargeAmount() - _discountHandler.Handle(line);
                    var lineSb = new StringBuilder($"{line.Quantity} x {line.Bike.Brand} {line.Bike.Model} = {thisAmount:C}");
                    formatter.FormatLine(lineSb);
                    allLinesSb.Append(lineSb);
                    
                    totalAmount += thisAmount;
                }

                formatter.FormatAllLines(allLinesSb);
            }

            documentSb.Append(allLinesSb);

            var subTotalSb = new StringBuilder($"Sub-Total: {totalAmount:C}");
            formatter.FormatSubTotal(subTotalSb);
            documentSb.Append(subTotalSb);

            double tax = totalAmount * TaxRate;
            var taxSb = new StringBuilder($"Tax: {tax:C}");
            formatter.FormatTax(taxSb);
            documentSb.Append(taxSb);

            var totalSb = new StringBuilder($"Total: {totalAmount + tax:C}");
            formatter.FormatTotal(totalSb);
            documentSb.Append(totalSb);

            formatter.FormatDocument(documentSb);

            return documentSb.ToString();
        }
    }
}
