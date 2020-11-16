using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BikeDistributor.Test
{
    [TestClass]
    public class QuantityPriceDiscountHandlerTests
    {
        [TestMethod]
        public void Handle_ReturnsZero_WhenQuantityPriceNotMet()
        {
            var discount = new QuantityPriceDiscountHandler(1, 5, .5d);

            var bike = new Bike(string.Empty, string.Empty, 2);
            var line = new Line(bike, 1);

            double discountAmount = discount.Handle(line);

            Assert.AreEqual(discountAmount, 0d);
        }

        [TestMethod]
        public void Handle_ReturnsDiscount_WhenQuantityPriceMet()
        {
            var discount = new QuantityPriceDiscountHandler(1, 5, .5d);

            var bike = new Bike(string.Empty, string.Empty, 1);
            var line = new Line(bike, 6);

            double discountAmount = discount.Handle(line);

            Assert.AreEqual(discountAmount, line.GetChargeAmount() - discountAmount);
        }
    }
}