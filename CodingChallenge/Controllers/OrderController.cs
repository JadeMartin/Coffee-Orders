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
        //POST: api/order
        //[HttpPOST]
        //Post function to create and add order to orderList (Ideally eventually a database context)
        public void post(Order order)
        {
            orderList.Add(order);
        }

        //TODO make functions ASYNC & interact with database
        //GET: api/order
        //[HttpGET]
        //Get function to return all order in orderList (Ideally eventually a database context)
        public List<Order> GetOrders()
        {
            return orderList;
        }
    }
}