using CodingChallenge.Models;
using System;
using System.Collections.Generic;


namespace CodingChallenge.controllers
{
    public class PriceController
    {

        private List<Price> priceList = new List<Price>();

        //TODO make functions ASYNC & interact with database
        public void post(Price price)
        {
            priceList.Add(price);
        }

        public List<Price> GetPrices()
        {
            return priceList;
        }

        public double getPriceByOrder(Order order)
        {
           Price orderPrice = priceList.Find(price => price.Drink_name == order.Drink);
           return orderPrice.Prices.getPriceBySize(order.Size);
        }

    }
}