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
    
        private Dictionary<String, Receipt> receiptDictionary;
         //TODO: Replace backend list with SQL lite DB
        private List<Receipt> receiptList;

        public ReceiptController()
        {
            priceController = new PriceController();
            orderController = new OrderController();
            paymentController = new PaymentController();
            receiptList = new List<Receipt>();
            receiptDictionary = new Dictionary<String, Receipt>();
        }


        //function to setup and read the json files.
        public void setUp()
        {
            var jsonOrdersString = File.ReadAllText("./Data/orders.json");
            processOrders(jsonOrdersString);
            var jsonPaymentsString = File.ReadAllText("./Data/payments.json");
            processPayments(jsonPaymentsString);
            var jsonPricesString = File.ReadAllText("./Data/prices.json");
            processPrices(jsonPricesString);
        }

        //GET: api/Receipts
        //[HttpGet]
        //Get function to create, calculate and return Receipts
        public string GetReceipts()
        {
            calculateOrderCost();
            calculateTotalPayments();
            calculateTotalOwned();
            return JsonConvert.SerializeObject(receiptList);
        }

        private double round(double value)
        {
            return Math.Round(value, 2);
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
                    receiptDictionary[order.User].Order_total = round(receiptDictionary[order.User].Order_total +  orderPrice);
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
                    receiptDictionary[payment.User].Payment_total = round(receiptDictionary[payment.User].Payment_total +  payment.Amount);
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
            foreach (KeyValuePair<String, Receipt> dic in receiptDictionary)
            {   //Loop over dictionary to add balance and add to list to output
                receiptDictionary[dic.Key].Balance = round(dic.Value.Order_total - dic.Value.Payment_total);
                receiptList.Add(dic.Value);
            }
        }


        //Function to deserialize JSON Order object then pass it into backend
        public static void processOrders(String jsonString)
        { 
            var myJson = JsonConvert.DeserializeObject<List<Order>>(jsonString);
            foreach (Order order in myJson)
            {
                orderController.post(order);
            }
        }

        //Function to deserialize JSON Payment object then pass it into backend
        public static void processPayments(String jsonString)
        {
            var myJson = JsonConvert.DeserializeObject<List<Payment>>(jsonString);
            foreach (Payment payment in myJson)
            {
                paymentController.post(payment);
            }
        }

        //Function to deserialize JSON Price object then pass it into backend
        public static void processPrices(String jsonString)
        {
            var myJson = JsonConvert.DeserializeObject<List<Price>>(jsonString);
            foreach (Price price in myJson)
            {
                priceController.post(price);
            }
        }
    }

}