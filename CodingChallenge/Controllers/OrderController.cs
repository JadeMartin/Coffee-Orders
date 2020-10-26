using CodingChallenge.Models;
using System;


namespace CodingChallenge.controllers
{
    public class OrderController
    {


        public async void postOrder(Order order)
        {
            Console.WriteLine(order.Drink);
        }
    }
}