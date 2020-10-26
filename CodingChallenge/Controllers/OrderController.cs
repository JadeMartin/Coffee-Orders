using CodingChallenge.Models;
using System;
using System.Collections.Generic;



namespace CodingChallenge.controllers
{
    public class OrderController
    {
        //TODO: Replace backend list with SQL lite DB
        private List<Order> orderList = new List<Order>();

        //TODO make functions ASYNC & interact with database
        public void post(Order order)
        {
            orderList.Add(order);
        }

        public List<Order> GetOrders()
        {
            return orderList;
        }
    }
}