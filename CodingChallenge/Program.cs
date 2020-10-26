using System;
using System.IO;
using CodingChallenge.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using CodingChallenge.controllers;


namespace CodingChallenge
{
    class Program
    {

        static void Main(string[] args)
        {
            processOrders();
            processPayments();
            processPrices();
        }

        private static void processOrders()
        {
            var jsonString = File.ReadAllText("./Data/orders.json");
            var myJson = JsonConvert.DeserializeObject<List<Order>>(jsonString);
            OrderController orderController = new OrderController(); 
            foreach (Order order in myJson)
            {
                orderController.post(order);
            }
        }

        private static void processPayments()
        {
            var jsonString = File.ReadAllText("./Data/payments.json");
            var myJson = JsonConvert.DeserializeObject<List<Payment>>(jsonString);
            PaymentController paymentController = new PaymentController(); 
            foreach (Payment payment in myJson)
            {
                paymentController.post(payment);
            }
        }
        private static void processPrices()
        {
            var jsonString = File.ReadAllText("./Data/prices.json");
            var myJson = JsonConvert.DeserializeObject<List<Price>>(jsonString);
            PriceController priceController = new PriceController(); 
            foreach (Price price in myJson)
            {
                priceController.post(price);
            }
        }
    }
}
