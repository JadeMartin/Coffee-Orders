using CodingChallenge.Models;
using System;


namespace CodingChallenge.controllers
{
    public class OrderController
    {

//todo make async and enter into database
        public void post(Order order)
        {
            Console.WriteLine(order.Drink);
        }
    }
}