using System;
using System.IO;
using CodingChallenge.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using CodingChallenge.controllers;
using CodingChallenge.Tests;

namespace CodingChallenge
{
    class Program
    {

        static void Main(string[] args)
        {
            // ReceiptController receiptController = new ReceiptController();
            // receiptController.setUp(); // function that reads the files then calls the controller endpoints
            // String jsonResult = receiptController.GetReceipts(); // function to get the expected result
            // Console.WriteLine(jsonResult);
            Test test = new Test();
            test.HasUsersWhoOrderedCoffee();
        }
    }
}
