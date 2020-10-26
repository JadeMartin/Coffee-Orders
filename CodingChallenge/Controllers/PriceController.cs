using CodingChallenge.Models;
using System;
using System.Collections.Generic;


namespace CodingChallenge.controllers
{
    public class PriceController
    {

        //TODO: Replace backend list with SQL lite DB
        private List<Price> priceList = new List<Price>();

        //TODO make functions ASYNC & interact with database
        //POST: api/price
        //[HttpPOST]
        //Post function to create and add price to priceList (Ideally eventually a database context)
        public void post(Price price)
        {
            priceList.Add(price);
        }

        //TODO make functions ASYNC & interact with database
        //GET: api/price
        //[HttpGET]
        //Get function to return all prices in priceList (Ideally eventually a database context)
        public List<Price> GetPrices()
        {
            return priceList;
        }

        //Helper function for the backend to get the price from a given order (coffee + size)
        public double getPriceByOrder(Order order)
        {
           Price orderPrice = priceList.Find(price => price.Drink_name == order.Drink);
           return orderPrice.Prices.getPriceBySize(order.Size);
        }

    }
}