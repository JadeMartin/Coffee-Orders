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
            ReceiptController receiptController = new ReceiptController();
            receiptController.setUp(); // function that reads the files then calls the controller endpoints

            Dictionary<String, Receipt> receiptDictionary = receiptController.GetReceipts();
            foreach (KeyValuePair<String, Receipt> dic in receiptDictionary)
            {
                Console.WriteLine("User = {0}, TotalOrderCost = {1}", dic.Key, dic.Value.Order_total);
            }
        }
    }
}
