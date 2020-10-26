using CodingChallenge.Models;
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;




namespace CodingChallenge.controllers
{
    public class ReceiptController
    {

        private static OrderController orderController;
        private static PaymentController paymentController; 
        private static PriceController priceController;
    
        private Dictionary<String, Receipt> receiptDictionary = new Dictionary<String, Receipt>();
        private List<Receipt> receiptList = new List<Receipt>();

        public ReceiptController()
        {
            priceController = new PriceController();
            orderController = new OrderController();
            paymentController = new PaymentController();
        }


        public void setUp()
        {
            processOrders();
            processPayments();
            processPrices();
        }

        public Dictionary<String, Receipt> GetReceipts()
        {
            calculateReceipts();
            return receiptDictionary;
        }

        private void calculateReceipts()
        {
            calculateOrderCost();
            calculateTotalPayments();
            calculateTotalOwned();
        }

        private void calculateOrderCost()
        {
            List<Order> orderList = orderController.GetOrders();
            double orderPrice = 0;
            foreach (Order order in orderList)
            {   
                orderPrice = priceController.getPriceByOrder(order);
                if(receiptDictionary.ContainsKey(order.User)) //Check if user is already in dictionary
                { //if so add onto the order_total
                    receiptDictionary[order.User].Order_total = receiptDictionary[order.User].Order_total +  orderPrice;
                } 
                else  //if not then create a new entry to handle the user
                {
                    Receipt newRecipe = new Receipt();
                    newRecipe.User = order.User;
                    newRecipe.Order_total = orderPrice;
                    receiptDictionary.Add(order.User, newRecipe);
                }
            }
        }

        private void calculateTotalPayments()
        {
            List<Payment> paymentList = paymentController.GetPayments();
            foreach (Payment payment in paymentList)
            {   
                if(receiptDictionary.ContainsKey(payment.User)) //Check if user is already in dictionary
                { //if so add onto the order_total
                    receiptDictionary[payment.User].Payment_total = receiptDictionary[payment.User].Payment_total +  payment.Amount;
                } 
                else  //if not then create a new entry to handle the user
                {
                    Receipt newRecipe = new Receipt();
                    newRecipe.User = payment.User;
                    newRecipe.Payment_total = payment.Amount;
                    receiptDictionary.Add(payment.User, newRecipe);
                }
            }
        }

        private void calculateTotalOwned()
        {

        }


        private static void processOrders()
        {
            var jsonString = File.ReadAllText("./Data/orders.json");
            var myJson = JsonConvert.DeserializeObject<List<Order>>(jsonString);
            foreach (Order order in myJson)
            {
                orderController.post(order);
            }
        }

        private static void processPayments()
        {
            var jsonString = File.ReadAllText("./Data/payments.json");
            var myJson = JsonConvert.DeserializeObject<List<Payment>>(jsonString);
            foreach (Payment payment in myJson)
            {
                paymentController.post(payment);
            }
        }
        private static void processPrices()
        {
            var jsonString = File.ReadAllText("./Data/prices.json");
            var myJson = JsonConvert.DeserializeObject<List<Price>>(jsonString);
            foreach (Price price in myJson)
            {
                priceController.post(price);
            }
        }
    }

}