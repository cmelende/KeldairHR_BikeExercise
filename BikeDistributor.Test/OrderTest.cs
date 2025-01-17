﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BikeDistributor.Test
{
    [TestClass]
    public class OrderTest
    {
        private static readonly Bike Defy = new Bike("Giant", "Defy 1", 1000);
        private static readonly Bike Elite = new Bike("Specialized", "Venge Elite", 2000);
        private static readonly Bike DuraAce = new Bike("Specialized", "S-Works Venge Dura-Ace", 5000);

        private IDiscountHandler GetDefaultDiscountHandler()
        {
            var tierOneDiscountHandler = new QuantityPriceDiscountHandler(1000, 20, .1d);
            var tierTwoDiscountHandler = new QuantityPriceDiscountHandler(2000, 10, .2d);
            var tierThreeDiscountHandler = new QuantityPriceDiscountHandler(5000, 5, .2d);

            tierOneDiscountHandler.SetNext(tierTwoDiscountHandler).SetNext(tierThreeDiscountHandler);

            return tierOneDiscountHandler;
        }
        [TestMethod]
        public void ReceiptOneDefy()
        {
            IDiscountHandler discount = GetDefaultDiscountHandler();
            var order = new Order("Anywhere Bike Shop", discount);
            order.AddLine(new Line(Defy, 1));
            Assert.AreEqual(ResultStatementOneDefy, order.Receipt());
        }

        private const string ResultStatementOneDefy = @"Order Receipt for Anywhere Bike Shop
	1 x Giant Defy 1 = $1,000.00
Sub-Total: $1,000.00
Tax: $72.50
Total: $1,072.50";

        [TestMethod]
        public void ReceiptOneElite()
        {
            IDiscountHandler discount = GetDefaultDiscountHandler();
            var order = new Order("Anywhere Bike Shop", discount);
            order.AddLine(new Line(Elite, 1));
            Assert.AreEqual(ResultStatementOneElite, order.Receipt());
        }

        private const string ResultStatementOneElite = @"Order Receipt for Anywhere Bike Shop
	1 x Specialized Venge Elite = $2,000.00
Sub-Total: $2,000.00
Tax: $145.00
Total: $2,145.00";

        [TestMethod]
        public void ReceiptOneDuraAce()
        {
            IDiscountHandler discount = GetDefaultDiscountHandler();
            var order = new Order("Anywhere Bike Shop", discount);
            order.AddLine(new Line(DuraAce, 1));
            Assert.AreEqual(ResultStatementOneDuraAce, order.Receipt());
        }

        private const string ResultStatementOneDuraAce = @"Order Receipt for Anywhere Bike Shop
	1 x Specialized S-Works Venge Dura-Ace = $5,000.00
Sub-Total: $5,000.00
Tax: $362.50
Total: $5,362.50";

        [TestMethod]
        public void HtmlReceiptOneDefy()
        {
            IDiscountHandler discount = GetDefaultDiscountHandler();
            var order = new Order("Anywhere Bike Shop", discount);
            order.AddLine(new Line(Defy, 1));
            Assert.AreEqual(HtmlResultStatementOneDefy, order.Receipt(new HtmlFormatter()));
        }

        private const string HtmlResultStatementOneDefy = @"<html><body><h1>Order Receipt for Anywhere Bike Shop</h1><ul><li>1 x Giant Defy 1 = $1,000.00</li></ul><h3>Sub-Total: $1,000.00</h3><h3>Tax: $72.50</h3><h2>Total: $1,072.50</h2></body></html>";

        [TestMethod]
        public void HtmlReceiptOneElite()
        {
            IDiscountHandler discount = GetDefaultDiscountHandler();
            var order = new Order("Anywhere Bike Shop", discount);
            order.AddLine(new Line(Elite, 1));
            Assert.AreEqual(HtmlResultStatementOneElite, order.Receipt(new HtmlFormatter()));
        }

        private const string HtmlResultStatementOneElite = @"<html><body><h1>Order Receipt for Anywhere Bike Shop</h1><ul><li>1 x Specialized Venge Elite = $2,000.00</li></ul><h3>Sub-Total: $2,000.00</h3><h3>Tax: $145.00</h3><h2>Total: $2,145.00</h2></body></html>";

        [TestMethod]
        public void HtmlReceiptOneDuraAce()
        {
            IDiscountHandler discount = GetDefaultDiscountHandler();
            var order = new Order("Anywhere Bike Shop", discount);
            order.AddLine(new Line(DuraAce, 1));
            Assert.AreEqual(HtmlResultStatementOneDuraAce, order.Receipt(new HtmlFormatter()));
        }

        private const string HtmlResultStatementOneDuraAce = @"<html><body><h1>Order Receipt for Anywhere Bike Shop</h1><ul><li>1 x Specialized S-Works Venge Dura-Ace = $5,000.00</li></ul><h3>Sub-Total: $5,000.00</h3><h3>Tax: $362.50</h3><h2>Total: $5,362.50</h2></body></html>";    
    }
}


