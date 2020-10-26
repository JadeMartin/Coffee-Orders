using CodingChallenge.Models;
using System;


namespace CodingChallenge.controllers
{
    public class OrderController
    {

//todo make async and enter into database
        public void postOrder(Order order)
        {
            Console.WriteLine(order.Drink);
        }
    }
}