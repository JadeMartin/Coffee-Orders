using CodingChallenge.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;
using CodingChallenge.controllers;

namespace CodingChallenge.Tests
{

    public class Test
    {

        // Example Prices JSON test data that may be used
         String prices_json = @"[ 
                        { 'drink_name': 'short espresso', 'prices': { 'small': 3.03 } },
                        { 'drink_name': 'latte', 'prices': { 'small': 3.50, 'medium': 4.00, 'large': 4.50 } },
                        { 'drink_name': 'flat white', 'prices': { 'small': 3.50, 'medium': 4.00, 'large': 4.50 } },
                        { 'drink_name': 'long black', 'prices': { 'small': 3.25, 'medium': 3.50 } },
                        { 'drink_name': 'mocha', 'prices': { 'small': 4.00, 'medium': 4.50, 'large': 5.00 } },
                        { 'drink_name': 'supermochacrapucaramelcream', 'prices': { 'large': 5.00, 'huge': 5.50, 'mega': 6.00, 'ultra': 7.00 } }
                      ]";  
                            
        //Example Orders JSON test data 
        String orders_json = @"[ 
                        { 'user': 'coach', 'drink': 'long black', 'size': 'medium' },
                        { 'user': 'ellis', 'drink': 'long black', 'size': 'small' },
                        { 'user': 'rochelle', 'drink': 'flat white', 'size': 'large' },
                        { 'user': 'coach', 'drink': 'flat white', 'size': 'large' },
                        { 'user': 'zoey', 'drink': 'long black', 'size': 'medium' },
                        { 'user': 'zoey', 'drink': 'short espresso', 'size': 'small' }
                      ]";
                

        //Example Payments JSON test data
        String payments_json = @"[
                            { 'user': 'coach', 'amount': 2.50 },
                            { 'user': 'ellis', 'amount': 2.60 },
                            { 'user': 'rochelle', 'amount': 4.50 },
                            { 'user': 'ellis', 'amount': 0.65 }
                        ] ";
        ReceiptController receiptController;

        private String setUp()
        {
            receiptController = new ReceiptController();
            ReceiptController.processOrders(orders_json);
            ReceiptController.processPayments(payments_json);
            ReceiptController.processPrices(prices_json);
            return receiptController.GetReceipts();
        }

        [Fact]
        public void OutputJSONInExpectedForm()
        {
            String output = setUp();
            Boolean assert = true;
            try
            {
                var myJson = JsonConvert.DeserializeObject<List<Receipt>>(output);
            } 
            catch (JsonReaderException) 
            {
                assert = false;
            }
            Assert.True(assert); 
        }

        [Fact]
        public void HasUsersWhoOrderedCoffee()
        {
            String output = setUp();
            var result = JsonConvert.DeserializeObject<List<Receipt>>(output);
            Assert.Equal(result[0].User, "coach");
            Assert.Equal(result[1].User, "ellis");
            Assert.Equal(result[2].User, "rochelle");
            Assert.Equal(result[3].User, "zoey");
        }

        [Fact]
        public void HasOrderTotalsForUsers()
        {
            String output = setUp();
            var result = JsonConvert.DeserializeObject<List<Receipt>>(output);
            Assert.Equal(result[0].Order_total, 8.00);
            Assert.Equal(result[1].Order_total, 3.25);
            Assert.Equal(result[2].Order_total, 4.50);
            Assert.Equal(result[3].Order_total, 6.53);
        }

        [Fact]
        public void HasPaymentTotalsForUsers()
        {
            String output = setUp();
            var result = JsonConvert.DeserializeObject<List<Receipt>>(output);
            Assert.Equal(result[0].Payment_total, 2.50);
            Assert.Equal(result[1].Payment_total, 3.25);
            Assert.Equal(result[2].Payment_total, 4.50);
            Assert.Equal(result[3].Payment_total, 0.00);
        }

        [Fact]
        public void HasCurrentBalanceForUsers()
        {
            String output = setUp();
            var result = JsonConvert.DeserializeObject<List<Receipt>>(output);
            Assert.Equal(result[0].Balance, 5.50);
            Assert.Equal(result[1].Balance, 0.00);
            Assert.Equal(result[2].Balance, 0.00);
            Assert.Equal(result[3].Balance, 6.53);
        }

        [Fact]
        public void correctAmountOfTicketsCreated()
        {
            String output = setUp();
            List<Receipt> result = JsonConvert.DeserializeObject<List<Receipt>>(output);
            List<Receipt> expectedResult = JsonConvert.DeserializeObject<List<Receipt>>(payments_json);
            Assert.Equal(result.Count, expectedResult.Count);
        }

        [Fact]
        public void DrinkSizeGetPriceBySize()
        {
            double price1 = 3.0;
            double price2 = 5.0;
            double price3 = 7.50;

            DrinkSize drink = new DrinkSize
            {
                Small = 3.0,
                Large = 5.0,
                Ultra = 7.50,
            };

            Assert.Equal(price1, drink.getPriceBySize("small"));
            Assert.Equal(price2, drink.getPriceBySize("large"));
            Assert.Equal(price3, drink.getPriceBySize("ultra"));

        }

        [Fact]
        public void getPriceOfItemByOrder()
        {
            setUp();

            DrinkSize drink = new DrinkSize
            {
                Small = 3.0,
                Large = 5.0,
                Ultra = 7.50,
            };

            Price price = new Price
            {
                Drink_name = "Caffè mocha",
                Prices = drink
            };

            Order order = new Order
            {
                User = "Bob",
                Drink = "Caffè mocha",
                Size = "large",
            };

            PriceController pricecontroller = new PriceController();
            pricecontroller.post(price);
            double priceOfOrder = pricecontroller.getPriceByOrder(order);

            Assert.Equal(drink.Large, priceOfOrder);
        }
    }
}
