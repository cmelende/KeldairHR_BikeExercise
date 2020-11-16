namespace BikeDistributor
{
    public class QuantityPriceDiscountHandler : BaseDiscountHandler
    {
        private int _qualifiedQuantity;
        private double _discountModifier;
        private int _price;
        public QuantityPriceDiscountHandler(int price, int qualifiedQuantity, double discountModifier)
        {
            _price = price;
            _qualifiedQuantity = qualifiedQuantity;
            _discountModifier = discountModifier;
        }

        public override double Handle(Line line)
        {
            if (line.Quantity >= _qualifiedQuantity && _price == line.Bike.Price)
            {
                return line.Quantity * line.Bike.Price * _discountModifier;
            }

            return base.Handle(line);
        }
    }
}