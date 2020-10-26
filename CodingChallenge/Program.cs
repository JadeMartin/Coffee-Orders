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
            Console.WriteLine("Hello World! ********************************************");
            var jsonString = File.ReadAllText("./Data/orders.json");
            var myJson = JsonConvert.DeserializeObject<List<Order>>(jsonString);
            OrderController orderController = new OrderController(); 
            foreach (Order order in myJson)
            {
                orderController.postOrder(order);
            }
            
        }
    }
}
